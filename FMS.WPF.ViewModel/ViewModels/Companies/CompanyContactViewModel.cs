using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.ViewModel.Services;

namespace FMS.WPF.ViewModels
{
    public class CompanyContactViewModel : GenericEditableViewModelBase<CompanyContactModel>
    {
        #region fields
        private ICompanyAppService _companyAppService;
        private IDialogService _dialogService;
        #endregion

        public CompanyContactViewModel(CompanyContactModel model, 
                                       ICompanyAppService companyAppService, 
                                       IDialogService dialogService)
        {
            _companyAppService = companyAppService;
            _dialogService = dialogService;

            Model = model;
            EditCommand?.Execute(null);
        }

        #region properties
        public override string DisplayName => "Kontakt";
        #endregion

        #region overrides
        protected override bool ConfirmDelete()
        {
            return _dialogService.ShowMessageBox("Kas kustutame kontakti?", "Kustutamine", "YesNo");
        }

        protected override void DeleteItem(CompanyContactModel model)
        {
            _companyAppService.DeleteCompanyContactModel(model.ContactId);
            Model.ContactId = 0;
        }

        protected override bool SaveItem(CompanyContactModel model)
        {
            Model.ContactId = _companyAppService.SaveCompanyContactModel(model);

            return false;
        }
        #endregion
    }
}
