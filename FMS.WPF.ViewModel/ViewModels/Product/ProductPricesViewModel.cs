using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.ViewModels
{
    public class ProductPricesViewModel : ViewModelBase
    {
        private readonly IProductFacadeService _productFacadeService;

        public ProductPricesViewModel(int productBaseId,
                                      IProductFacadeService productFacadeService)
        {
            _productFacadeService = productFacadeService;
            InitializePriceLists(productBaseId);
        }

        #region properties
        public override string DisplayName => "Hinnad";

        public IList<PriceListModel> PriceLists { get; private set; }

        public PriceListModel SelectedPriceList { get; set; }
        #endregion

        #region helpers
        private async void InitializePriceLists(int productBaseId)
        {
            PriceLists = await _productFacadeService.GetProductPriceListModels(productBaseId);
            SelectedPriceList = PriceLists.FirstOrDefault();
        }
        #endregion
    }
}
