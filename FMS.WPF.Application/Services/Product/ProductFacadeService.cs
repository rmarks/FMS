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
            using (var context = _contextFactory.CreateContext())
            {
                model.Save();
                var productBase = model.MapTo<ProductBase>();
                
                context.Update(productBase);
                context.SaveChanges();

                return GetProductBaseModel(productBase.ProductBaseId);
            }
        }
        #endregion
    }
}
