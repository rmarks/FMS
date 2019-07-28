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
        private IProductDropdownsService _dropdownsService;

        public ProductService(IDataContextFactory contextFactory, IProductDropdownsService dropdownsService)
        {
            _contextFactory = contextFactory;
            _dropdownsService = dropdownsService;
        }

        //product base list
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

        //product dropdowns
        public async Task<ProductDropdownsDto> GetProductDropdownsAsync()
        {
            return await _dropdownsService.GetProductDropdownsAsync();
        }

        //product base
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

        //product list (product sizes)
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
    }
}
