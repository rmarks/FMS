using System.Collections.Generic;
using System.Linq;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Interfaces;
using FMS.WPF.Application.QueryObjects;
using FMS.WPF.Models;

namespace FMS.WPF.Application.Services
{
    public class ProductsService : IProductsService
    {
        private IListProductsService _listService;

        public ProductsService(IListProductsService listService)
        {
            _listService = listService;
        }

        public IList<ProductListModel> GetProductList(ProductListOptionsModel options)
        {
            return _listService
                .GetProducts(options.MapTo<ProductListOptionsDto>())
                .MapBetween<ProductListDto, ProductListModel>()
                .ToList();
        }
    }
}
