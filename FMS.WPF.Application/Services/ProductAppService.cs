using FMS.ServiceLayer.Interface.Dtos;
using FMS.ServiceLayer.Interface.Services;
using FMS.WPF.Application.Extensions;
using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.Services
{
    public class ProductAppService : IProductAppService
    {
        private IProductService _productService;
        private IProductDropdownsService _dropdownsService;

        public ProductAppService(IProductService productService,
                                IProductDropdownsService dropdownsService)
        {
            _productService = productService;
            _dropdownsService = dropdownsService;
        }

        #region  product list
        public ProductListOptionsModel GetProductListOptionsModel()
        {
            return new ProductListOptionsModel();
        }

        public IList<ProductListModel> GetProductListModels(ProductListOptionsModel model)
        {
            return _productService
                .GetProductBases(model.MapTo<ProductListOptionsDto>())
                .Select(dto => dto.MapTo<ProductListModel>())
                .ToList();
        }
        #endregion

        #region product base
        public ProductBaseModel GetProductBaseModel(int productBaseId)
        {
            return _productService
                .GetProductBase(productBaseId)
                .MapTo<ProductBaseModel>();
        }
        #endregion

        #region product (sizes)
        public IList<ProductModel> GetProductModels(int productBaseId)
        {
            return _productService
                .GetProducts(productBaseId)
                .Select(p => p.MapTo<ProductModel>())
                .ToList();
        }
        #endregion
    }
}
