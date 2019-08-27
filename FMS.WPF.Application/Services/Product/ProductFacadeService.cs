using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.WPF.Application.Extensions;
using FMS.WPF.Models;
using FMS.WPF.Application.Interface.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.WPF.Application.Services
{
    public class ProductFacadeService : IProductFacadeService
    {
        private IDataContextFactory _contextFactory;

        public ProductFacadeService(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        #region product base
        public ProductBaseModel GetProductBaseModel(int productBaseId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var model = context.ProductBases
                    .AsNoTracking()
                    .Where(p => p.ProductBaseId == productBaseId)
                    .ProjectBetween<ProductBase, ProductBaseModel>()
                    .FirstOrDefault();

                model.Products = model.Products
                    .OrderBy(p => p.ProductCode)
                    .ToList();

                return model;
            }
        }
        #endregion
    }
}
