using FMS.WPF.Models;

namespace FMS.WPF.ViewModels
{
    public class CompanyAddressViewModel : GenericEditableViewModelBase<CompanyAddressModel>
    {
        public CompanyAddressViewModel(CompanyAddressModel model) 
        {
            Model = model;
            EditCommand?.Execute(null);
        }

        #region properties
        public override string DisplayName => "Aadress";
        #endregion

        #region overrides
        protected override bool SaveItem(CompanyAddressModel model)
        {
            return true;
        }
        #endregion
    }
}
