using FMS.ServiceLayer.Interface.Dtos;
using FMS.ServiceLayer.Interface.Services;
using FMS.WPF.Application.Extensions;
using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.Services
{
    public class ProductListService : IProductListService
    {
        private readonly IProductService _productService;

        public ProductListService(IProductService productService)
        {
            _productService = productService;
        }

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
    }
}
