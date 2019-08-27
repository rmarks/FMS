using FMS.WPF.Application.Interface.Models;
using System.Collections.Generic;

namespace FMS.WPF.ViewModels
{
    public class ProductPricesViewModel : ViewModelBase
    {
        public ProductPricesViewModel(ProductBaseModel productBaseModel)
        {
            Prices = productBaseModel.Prices;
        }

        #region properties
        public override string DisplayName => "Hinnad";
        public IList<PriceListModel> PriceLists { get; private set; }
        public PriceListModel SelectedPriceList { get; set; }
        public List<PriceModel> Prices { get; set; }
        #endregion
    }
}
