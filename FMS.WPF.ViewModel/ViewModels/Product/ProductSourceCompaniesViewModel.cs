using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using System.Collections.Generic;

namespace FMS.WPF.ViewModels
{
    public class ProductSourceCompaniesViewModel : ViewModelBase
    {
        private readonly IProductFacadeService _productFacadeService;

        public ProductSourceCompaniesViewModel(int productBaseId, 
                                               IProductFacadeService productFacadeService)
        {
            _productFacadeService = productFacadeService;
            InitializeProducts(productBaseId);
        }

        #region properties
        public override string DisplayName => "Tarne andmed";

        public IList<ProductCompanyModel> Products { get; private set; }
        #endregion

        #region helpers
        private async void InitializeProducts(int productBaseId)
        {
            Products = await _productFacadeService.GetProductCompanyModelsForSource(productBaseId);
        }
        #endregion
    }
}
