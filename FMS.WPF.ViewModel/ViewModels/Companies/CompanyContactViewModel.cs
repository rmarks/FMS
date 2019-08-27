using FMS.WPF.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.ViewModel.Services;

namespace FMS.WPF.ViewModels
{
    public class CompanyContactViewModel : GenericEditableViewModelBase<CompanyContactModel>
    {
        #region fields
        private ICompanyFacadeService _companyFacadeService;
        private IDialogService _dialogService;
        #endregion

        public CompanyContactViewModel(CompanyContactModel model, 
                                       ICompanyFacadeService companyFacadeService, 
                                       IDialogService dialogService)
        {
            _companyFacadeService = companyFacadeService;
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
            _companyFacadeService.DeleteCompanyContactModel(model.ContactId);
            Model.ContactId = 0;
        }

        protected override bool SaveItem(CompanyContactModel model)
        {
            Model.ContactId = _companyFacadeService.SaveCompanyContactModel(model);

            return false;
        }
        #endregion
    }
}
