using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.ViewModels
{
    public class ProductPricesViewModel : ViewModelBase
    {
        public ProductPricesViewModel(ProductBaseModel model)
        {
            //Prices = model.Prices;
            PriceLists = model.PriceLists;
        }

        #region properties
        public override string DisplayName => "Hinnad";
        public IList<PriceListModel> PriceLists { get; private set; }
        public PriceListModel SelectedPriceList { get; set; }
        //public List<PriceModel> Prices { get; set; }
        #endregion
    }
}
