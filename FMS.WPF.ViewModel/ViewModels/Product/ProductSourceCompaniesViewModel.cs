using FMS.WPF.Application.Interface.Models;
using System.Collections.Generic;

namespace FMS.WPF.ViewModels
{
    public class ProductSourceCompaniesViewModel : ViewModelBase
    {
        //private readonly IProductFacadeService _productFacadeService;

        public ProductSourceCompaniesViewModel(//int productBaseId,
                                               //IProductFacadeService productFacadeService,
                                               ProductBaseModel productBaseModel)
        {
            //_productFacadeService = productFacadeService;
            //InitializeProducts(productBaseId);
            Products = productBaseModel.Products;
        }

        #region properties
        public override string DisplayName => "Tarne andmed";

        public IList<ProductModel> Products { get; private set; }
        #endregion

        #region helpers
        //private async void InitializeProducts(int productBaseId)
        //{
        //    Products = await _productFacadeService.GetProductCompanyModelsForSource(productBaseId);
        //}
        #endregion
    }
}
