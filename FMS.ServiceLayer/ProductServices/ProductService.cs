using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.ServiceLayer.Interface.Dtos;
using FMS.ServiceLayer.Extensions;
using FMS.ServiceLayer.Interface.Services;
using FMS.ServiceLayer.QueryObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
                return context.ProductBases
                    .AsNoTracking()
                    .Where(p => p.ProductBaseId == productBaseId)
                    .ProjectBetween<ProductBase, ProductBaseDto>()
                    .FirstOrDefault();
            }
        }
        #endregion

        #region  product (sizes)
        public IList<ProductDto> GetProducts(int productBaseId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Products
                    .AsNoTracking()
                    .Where(p => p.ProductBaseId == productBaseId)
                    .OrderBy(p => p.ProductCode)
                    .ProjectBetween<Product, ProductDto>()
                    .ToList();
            }
        }
        #endregion
    }
}
