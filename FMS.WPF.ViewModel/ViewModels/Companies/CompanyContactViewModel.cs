using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Interfaces;
using FMS.WPF.Models;
using FMS.WPF.ViewModel.Extensions;
using FMS.WPF.ViewModel.Services;

namespace FMS.WPF.ViewModels
{
    public class CompanyContactViewModel : GenericEditableViewModelBase<CompanyContactModel>
    {
        #region Fields
        private ICompanyService _companyService;
        private IDialogService _dialogService;
        #endregion Fields

        public CompanyContactViewModel(CompanyContactModel model, ICompanyService companyService, IDialogService dialogService)
        {
            DisplayName = "Kontakt";

            _companyService = companyService;
            _dialogService = dialogService;

            Model = model;
            EditCommand?.Execute(null);
        }

        #region GenericEditableViewModelBase Members
        protected override bool ConfirmDelete()
        {
            return _dialogService.ShowMessageBox("Kas kustutame kontakti?", "Kustutamine", "YesNo");
        }

        protected override void DeleteItem(CompanyContactModel model)
        {
            _companyService.DeleteCompanyContact(model.ContactId);
            Model.ContactId = 0;
        }

        protected override bool SaveItem(CompanyContactModel model)
        {
            Model.ContactId = _companyService.SaveCompanyContact(model.MapTo<CompanyContactDto>());

            return false;
        }
        #endregion GenericEditableViewModelBase Members
    }
}
