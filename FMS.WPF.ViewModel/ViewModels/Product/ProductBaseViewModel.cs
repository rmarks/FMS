using FMS.WPF.Models;
using FMS.WPF.ViewModel.Helpers;

namespace FMS.WPF.ViewModels
{
    public class ProductBaseViewModel : ViewModelBase
    {
        public ProductBaseViewModel(ProductBaseModel model)
        {
            Model = model;
        }

        #region properties
        public override string DisplayName => "Üldandmed";
        public ProductBaseModel Model { get; set; }
        public bool IsProductVariationsVisible => Model.ProductVariationsLink?.Count != 0;
        #endregion
    }
}
