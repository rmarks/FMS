using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using FMS.ServiceLayer.Interfaces;
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

        //product list
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

        //product dropdowns
        public async Task<ProductDropdownsDto> GetProductDropdownsAsync()
        {
            return await _dropdownsService.GetProductDropdownsAsync();
        }

        //product
        public ProductInfoDto GetProduct(int productBaseId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.ProductBases
                    .AsNoTracking()
                    .Where(p => p.ProductBaseId == productBaseId)
                    .ProjectBetween<ProductBase, ProductInfoDto>()
                    .FirstOrDefault();
            }
        }
    }
}
