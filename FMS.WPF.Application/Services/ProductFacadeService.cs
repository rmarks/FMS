using FMS.ServiceLayer.Interface.Services;
using FMS.WPF.Application.Extensions;
using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.Services
{
    public class ProductFacadeService : IProductFacadeService
    {
        private IProductService _productService;

        public ProductFacadeService(IProductService productService)
        {
            _productService = productService;
        }

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
