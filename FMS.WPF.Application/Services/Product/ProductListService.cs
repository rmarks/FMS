using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.WPF.Application.Extensions;
using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Application.QueryObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.Services
{
    public class ProductListService : IProductListService
    {
        private IDataContextFactory _contextFactory;

        public ProductListService(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public ProductListOptionsModel GetProductListOptionsModel()
        {
            return new ProductListOptionsModel();
        }

        public IList<ProductListModel> GetProductListModels(ProductListOptionsModel options)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.ProductBases
                .AsNoTracking()
                .FilterBy(options)
                .OrderBy(p => p.ProductBaseCode)
                .ProjectBetween<ProductBase, ProductListModel>()
                .ToList();
            }
        }
    }
}
