using System.Collections.Generic;
using System.Linq;
using AutoMapper.QueryableExtensions;
using FMS.ServiceLayer.Interfaces.ProductServices;
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

        public IList<ProductListModel> GetProductList()
        {
            return _listService
                .GetProductBases()
                .ProjectTo<ProductListModel>()
                .ToList();
        }
    }
}
