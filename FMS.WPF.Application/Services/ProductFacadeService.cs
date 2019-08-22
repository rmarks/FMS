using FMS.ServiceLayer.Interface.Services;
using FMS.WPF.Application.Extensions;
using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        #region product companies
        public async Task<IList<ProductCompanyModel>> GetProductCompanyModelsForSource(int productBaseId)
        {
            var dtos = await (_productService
                .GetProductCompaniesForSource(productBaseId));

            return dtos.Select(p => p.MapTo<ProductCompanyModel>())
                .ToList();
        }

        public async Task<IList<ProductCompanyModel>> GetProductCompanyModelsForDest(int productBaseId)
        {
            var dtos = await (_productService
                .GetProductCompaniesForDest(productBaseId));

            return dtos.Select(p => p.MapTo<ProductCompanyModel>())
                .ToList();
        }
        #endregion

        #region product prices
        public async Task<IList<PriceListModel>> GetProductPriceListModels(int productBaseId)
        {
            var dtos = await _productService
                .GetProductPriceLists(productBaseId);

            return dtos.Select(p => p.MapTo<PriceListModel>())
                .ToList();
        }
        #endregion
    }
}
