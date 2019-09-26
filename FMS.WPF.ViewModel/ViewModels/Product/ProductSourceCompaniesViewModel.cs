using FMS.WPF.Models;

namespace FMS.WPF.ViewModels
{
    public class ProductSourceCompaniesViewModel : ViewModelBase
    {
        public ProductSourceCompaniesViewModel(ProductBaseModel model)
        {
            Model = model;
        }

        #region properties
        public override string DisplayName => "Tarne andmed";
        public ProductBaseModel Model { get; set; }
        public bool IsEditMode { get; set; }
        #endregion
    }
}
