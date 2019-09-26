using FMS.WPF.Models;

namespace FMS.WPF.ViewModels
{
    public class ProductDestCompaniesViewModel : ViewModelBase
    {
        public ProductDestCompaniesViewModel(ProductBaseModel model)
        {
            Model = model;
        }

        #region properties
        public override string DisplayName => "Allhanke andmed";
        public ProductBaseModel Model { get; set; }
        public bool IsEditMode { get; set; }
        #endregion
    }
}
