using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.WPF.Application.Extensions;
using FMS.WPF.Models;
using FMS.WPF.Application.Interface.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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
                    .ProjectBetween<ProductBase, ProductBaseModel>()
                    .FirstOrDefault();

                model.PriceLists = context.PriceLists
                    .AsNoTracking()
                    .Where(pl => pl.Prices.Any(p => p.Product.ProductBaseId == productBaseId))
                    .Select(pl => new PriceListModel
                    {
                        PriceListId = pl.PriceListId,
                        PriceListName = pl.PriceListName,
                        IsVAT = pl.IsVAT,
                        CurrencyCode = pl.CurrencyCode,
                        //left outer join
                        Prices = model.Products
                            .GroupJoin(pl.Prices.Where(p => p.Product.ProductBaseId == productBaseId),
                                       product => product.ProductId,
                                       price => price.ProductId,
                                       (product, prices) => new { Product = product, Prices = prices })
                            .SelectMany(x => x.Prices.DefaultIfEmpty(),
                                        (x, y) => new { Product = x.Product, Price = y })
                            .Select(p => new PriceModel
                            {
                                ProductId = p.Product.ProductId,
                                PriceListId = pl.PriceListId,
                                ProductProductCode = p.Product.ProductCode,
                                ProductProductName = p.Product.ProductName,
                                UnitPrice = (p.Price == null ? 0 : p.Price.UnitPrice)
                            })
                            .OrderBy(p => p.ProductProductCode)
                            .ToList()
                    })
                    .ToList();

                model.Products = model.Products
                    .OrderBy(p => p.ProductCode)
                    .ToList();

                return model;
            }
        }

        public ProductBaseModel Save(ProductBaseModel model)
        {
            model.Save();

            var productBase = (model.IsNew ? Add(model) : Update(model));

            return GetProductBaseModel(productBase.ProductBaseId);
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
                    .FirstOrDefault(pb => pb.ProductBaseId == model.ProductBaseId);

                context.Entry(existingProductBase).CurrentValues.SetValues(model);

                //ProductVariationsLink
                foreach (var variationLink in existingProductBase.ProductVariationsLink)
                {
                    if (!model.ProductVariationsLink
                        .Any(v => v.ProductBaseId == variationLink.ProductBaseId && v.ProductVariationId == variationLink.ProductVariationId))
                    {
                        existingProductBase.ProductVariationsLink.Remove(variationLink);
                    }
                }

                foreach (var variationLinkModel in model.ProductVariationsLink)
                {
                    var variationLink = existingProductBase.ProductVariationsLink
                        .FirstOrDefault(v => v.ProductBaseId == variationLinkModel.ProductBaseId && v.ProductVariationId == variationLinkModel.ProductVariationId);
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

                context.Add(productBase);
                context.SaveChanges();

                return productBase;
            }
        }
        #endregion
    }
}
