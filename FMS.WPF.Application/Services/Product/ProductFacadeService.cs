using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.WPF.Application.Extensions;
using FMS.WPF.Models;
using FMS.WPF.Application.Interface.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using FMS.WPF.Application.Utils;
using System.Collections.ObjectModel;

namespace FMS.WPF.Application.Services
{
    public class ProductFacadeService : IProductFacadeService
    {
        private IDataContextFactory _contextFactory;

        public ProductFacadeService(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        #region product base
        public ProductBaseModel GetProductBaseModel(int productBaseId)
        {
            if (productBaseId == 0)
            {
                return new ProductBaseModel();
            }

            using (var context = _contextFactory.CreateContext())
            {
                var model = context.ProductBases
                    .AsNoTracking()
                    .Where(p => p.ProductBaseId == productBaseId)
                    .Include(pb => pb.Products).ThenInclude(p => p.Prices)
                    .Include(pb => pb.Products).ThenInclude(p => p.ProductSource)
                    .Include(pb => pb.Products).ThenInclude(p => p.ProductDestination)
                    .Include(pb => pb.ProductVariationsLink).ThenInclude(pvl => pvl.ProductVariation)
                    .Select(p => MappingFactory.MapTo<ProductBaseModel>(p))
                    .FirstOrDefault();

                var priceList = context.PriceLists
                    .AsNoTracking()
                    .Where(pl => pl.Prices.Any(p => p.Product.ProductBaseId == productBaseId))
                    .Select(pl => MappingFactory.MapTo<PriceListModel>(pl));

                model.PriceLists = new ObservableCollection<PriceListModel>(priceList);

                return model;
            }
        }

        public int Save(ProductBaseModel model)
        {
            foreach (var productModel in model.Products)
            {
                productModel.Prices = productModel.Prices.Where(p => p.UnitPrice != 0).ToList();
            }

            var productBase = (model.IsNew ? Add(model) : Update(model));

            return productBase.ProductBaseId;
        }

        public void Delete(int productBaseId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var productBase = context.ProductBases
                    .Where(p => p.ProductBaseId == productBaseId)
                    .Include(pb => pb.Products).ThenInclude(p => p.Prices)
                    .Include(pb => pb.Products).ThenInclude(p => p.ProductSource)
                    .Include(pb => pb.Products).ThenInclude(p => p.ProductDestination)
                    .Include(pb => pb.ProductVariationsLink)
                    .FirstOrDefault();

                context.Remove(productBase);
                context.SaveChanges();
            }
        }
        #endregion

        #region helpers
        private ProductBase Update(ProductBaseModel model)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var existingProductBase = context.ProductBases
                    .Include(pb => pb.ProductVariationsLink)
                    .Include(pb => pb.Products).ThenInclude(p => p.ProductSource)
                    .Include(pb => pb.Products).ThenInclude(p => p.ProductDestination)
                    .Include(pb => pb.Products).ThenInclude(p => p.Prices)
                    .FirstOrDefault(pb => pb.ProductBaseId == model.ProductBaseId);

                context.Entry(existingProductBase).CurrentValues.SetValues(model);

                //ProductVariationsLink
                foreach (var variationLink in existingProductBase.ProductVariationsLink)
                {
                    if (!model.ProductVariationsLink.Any(v => v.ProductBaseProductVariationId == variationLink.ProductBaseProductVariationId))
                    {
                        existingProductBase.ProductVariationsLink.Remove(variationLink);
                    }
                }

                foreach (var variationLinkModel in model.ProductVariationsLink)
                {
                    var variationLink = existingProductBase.ProductVariationsLink
                        .FirstOrDefault(v => v.ProductBaseProductVariationId == variationLinkModel.ProductBaseProductVariationId);
                    if (variationLink == null)
                    {
                        existingProductBase.ProductVariationsLink.Add(variationLinkModel.MapTo<ProductBaseProductVariation>());
                    }
                    else
                    {
                        context.Entry(variationLink).CurrentValues.SetValues(variationLinkModel);
                    }
                }

                //Products
                foreach (var existingProduct in existingProductBase.Products)
                {
                    if (!model.Products.Any(p => p.ProductId == existingProduct.ProductId))
                    {
                        existingProductBase.Products.Remove(existingProduct);
                    }
                }

                foreach (var productModel in model.Products)
                {
                    var existingProduct = existingProductBase.Products.FirstOrDefault(p => p.ProductId == productModel.ProductId);
                    
                    if (existingProduct != null)
                    {
                        context.Entry(existingProduct).CurrentValues.SetValues(productModel);

                        //ProductSource
                        if (existingProduct.ProductSource != null || productModel.ProductSource != null)
                        {
                            if (existingProduct.ProductSource != null && productModel.ProductSource != null)
                            {
                                if (productModel.ProductSource.ProductSourceId == 0)
                                {
                                    existingProduct.ProductSource = productModel.ProductSource.MapTo<ProductSource>();
                                }
                                else
                                {
                                    context.Entry(existingProduct.ProductSource).CurrentValues.SetValues(productModel.ProductSource);
                                }
                            }
                            else if (existingProduct.ProductSource == null)
                            {
                                existingProduct.ProductSource = productModel.ProductSource.MapTo<ProductSource>();
                            }
                            else
                            {
                                existingProduct.ProductSource = null;
                            }
                        }

                        //ProductDestination
                        if (existingProduct.ProductDestination != null || productModel.ProductDestination != null)
                        {
                            if (existingProduct.ProductDestination != null && productModel.ProductDestination != null)
                            {
                                if (productModel.ProductDestination.ProductDestinationId == 0)
                                {
                                    existingProduct.ProductDestination = productModel.ProductDestination.MapTo<ProductDestination>();
                                }
                                else
                                {
                                    context.Entry(existingProduct.ProductDestination).CurrentValues.SetValues(productModel.ProductDestination);
                                }
                            }
                            else if (existingProduct.ProductDestination == null)
                            {
                                existingProduct.ProductDestination = productModel.ProductDestination.MapTo<ProductDestination>();
                            }
                            else
                            {
                                existingProduct.ProductDestination = null;
                            }
                        }

                        //Prices
                        foreach (var price in existingProduct.Prices)
                        {
                            if (!productModel.Prices.Any(p => p.PriceId == price.PriceId))
                            {
                                existingProduct.Prices.Remove(price);
                            }
                        }

                        foreach (var priceModel in productModel.Prices)
                        {
                            var existingPrice = existingProduct.Prices.FirstOrDefault(p => p.PriceId == priceModel.PriceId);

                            if (existingPrice == null)
                            {
                                existingProduct.Prices.Add(priceModel.MapTo<Price>());
                            }
                            else
                            {
                                context.Entry(existingPrice).CurrentValues.SetValues(priceModel);
                            }
                        }
                    }
                    else
                    {
                        existingProductBase.Products.Add(productModel.MapTo<Product>());
                    }
                }

                context.Update(existingProductBase);

                context.SaveChanges();

                return existingProductBase;
            }
        }

        private ProductBase Add(ProductBaseModel model)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var productBase = model.MapTo<ProductBase>();
                productBase.CreatedOn = DateTime.Now;

                context.Add(productBase);
                context.SaveChanges();

                return productBase;
            }
        }
        #endregion
    }
}
