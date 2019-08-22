using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.ServiceLayer.Interface.Dtos;
using FMS.ServiceLayer.Extensions;
using FMS.ServiceLayer.Interface.Services;
using FMS.ServiceLayer.QueryObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.Services
{
    public class ProductService : IProductService
    {
        private IDataContextFactory _contextFactory;

        public ProductService(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        #region  product base list
        public IList<ProductListDto> GetProductBases(ProductListOptionsDto options)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.ProductBases
                .AsNoTracking()
                .FilterBy(options)
                .OrderBy(p => p.ProductBaseCode)
                .ProjectBetween<ProductBase, ProductListDto>()
                .ToList();
            }
        }
        #endregion

        #region  product base
        public ProductBaseDto GetProductBase(int productBaseId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var dto = context.ProductBases
                    .AsNoTracking()
                    .Where(p => p.ProductBaseId == productBaseId)
                    .ProjectBetween<ProductBase, ProductBaseDto>()
                    .FirstOrDefault();

                dto.Products = dto.Products
                    .OrderBy(p => p.ProductCode)
                    .ToList();

                return dto;
            }
        }
        #endregion

        #region  product companies
        public async Task<IList<ProductCompanyDto>> GetProductCompaniesForSource(int productBaseId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return await context.ProductCompanies
                    .AsNoTracking()
                    .Where(p => p.Product.ProductBaseId == productBaseId && p.IsSource)
                    .OrderBy(p => p.Product.ProductCode)
                    .ProjectBetween<ProductCompany, ProductCompanyDto>()
                    .ToListAsync();
            }
        }

        public async Task<IList<ProductCompanyDto>> GetProductCompaniesForDest(int productBaseId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return await context.ProductCompanies
                    .AsNoTracking()
                    .Where(p => p.Product.ProductBaseId == productBaseId && !p.IsSource)
                    .OrderBy(p => p.Product.ProductCode)
                    .ProjectBetween<ProductCompany, ProductCompanyDto>()
                    .ToListAsync();
            }
        }
        #endregion

        #region product prices
        public async Task<IList<PriceListDto>> GetProductPriceLists(int productBaseId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return await context.PriceLists
                    .AsNoTracking()
                    .Where(pl => pl.Prices.Any(p => p.Product.ProductBaseId == productBaseId))
                    .OrderBy(pl => pl.PriceListName)
                    //.ProjectBetween<PriceList, PriceListDto>()
                    .Select(pl => new PriceListDto
                    {
                        PriceListName = pl.PriceListName,
                        CurrencyCode = pl.CurrencyCode,
                        IsVAT = pl.IsVAT,
                        Prices = pl.Prices
                            .Where(p => p.Product.ProductBaseId == productBaseId)
                            .Select(p => new PriceDto
                            {   
                                ProductProductCode = p.Product.ProductCode,
                                ProductProductName = p.Product.ProductName,
                                UnitPrice = p.UnitPrice
                            })
                            .OrderBy(p => p.ProductProductCode)
                            .ToList()
                    })
                    .ToListAsync();
            }
        }
        #endregion
    }
}
