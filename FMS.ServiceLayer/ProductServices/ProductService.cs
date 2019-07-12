using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using FMS.ServiceLayer.Interfaces;
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

        public IList<ProductListDto> GetProducts(ProductListOptionsDto options)
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
    }
}
