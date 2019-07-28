using FMS.ServiceLayer.Interface.Dtos;
using FMS.ServiceLayer.Interface.Services;
using FMS.WPF.Application.Extensions;
using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.WPF.Application.Services
{
    public class ProductsVmService : IProductsVmService
    {
        private IProductService _productService;
        private IProductDropdownsService _dropdownsService;

        public ProductsVmService(IProductService productService,
                                 IProductDropdownsService dropdownsService)
        {
            _productService = productService;
            _dropdownsService = dropdownsService;
        }

        public async Task<ProductListOptionsModel> GetProductListOptionsModelAsync()
        {
            var model = new ProductListOptionsModel();
            model.Dropdowns = await _dropdownsService.GetProductDropdownsAsync();

            return model;
        }

        public IList<ProductListModel> GetProductListModels(ProductListOptionsModel optionsModel)
        {
            return _productService
                .GetProductBases(optionsModel.MapTo<ProductListOptionsDto>())
                .Select(dto => dto.MapTo<ProductListModel>())
                .ToList();
        }
    }
}
