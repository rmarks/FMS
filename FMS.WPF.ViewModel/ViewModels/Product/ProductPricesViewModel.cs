using FMS.WPF.Models;
using System.Linq;

namespace FMS.WPF.ViewModels
{
    public class ProductPricesViewModel : ViewModelBase
    {
        public ProductPricesViewModel(ProductBaseModel model)
        {
            Model = model;
            SelectedPriceList = Model.OCPriceLists.FirstOrDefault();
        }

        #region properties
        public override string DisplayName => "Hinnad";
        public ProductBaseModel Model { get; set; }
        public PriceListModel SelectedPriceList { get; set; }
        public bool IsEditMode { get; set; }
        #endregion
    }
}
