using FMS.ServiceLayer.Interface.Services;
using FMS.WPF.Application.Extensions;
using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.Services
{
    public class ProductVmService : IProductVmService
    {
        private IProductService _productService;
        private IProductDropdownsService _dropdownsService;

        public ProductVmService(IProductService productService,
                                IProductDropdownsService dropdownsService)
        {
            _productService = productService;
            _dropdownsService = dropdownsService;
        }

        public ProductBaseModel GetProductBaseModel(int productBaseId)
        {
            return _productService
                .GetProductBase(productBaseId)
                .MapTo<ProductBaseModel>();
        }

        public async void SetProductBaseDropdownsAsync(ProductBaseModel productBase)
        {
            productBase.Dropdowns = await _dropdownsService.GetProductDropdownsAsync();
        }

        public IList<ProductModel> GetProductModels(int productBaseId)
        {
            return _productService
                .GetProducts(productBaseId)
                .Select(p => p.MapTo<ProductModel>())
                .ToList();
        }
    }
}
