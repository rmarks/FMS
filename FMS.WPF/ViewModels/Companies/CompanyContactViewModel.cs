using FMS.WPF.Models;

namespace FMS.WPF.ViewModels
{
    public class CompanyContactViewModel : GenericEditableViewModelBase<CompanyContactModel>
    {
        public CompanyContactViewModel(CompanyContactModel model)
        {
            Model = model;
            EditCommand?.Execute(null);
        }

        #region properties
        public override string DisplayName => "Kontakt";
        #endregion

        #region overrides
        protected override bool SaveItem(CompanyContactModel model)
        {
            return true;
        }
        #endregion
    }
}
