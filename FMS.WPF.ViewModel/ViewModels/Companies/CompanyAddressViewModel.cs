using FMS.WPF.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.ViewModel.Services;

namespace FMS.WPF.ViewModels
{
    public class CompanyAddressViewModel : GenericEditableViewModelBase<CompanyAddressModel>
    {
        private ICompanyFacadeService _companyFacadeService;
        private IDialogService _dialogService;

        public CompanyAddressViewModel(CompanyAddressModel model, 
                                       ICompanyFacadeService companyFacadeService, 
                                       IDialogService dialogService)
        {
            DisplayName = "Saaja aadress";

            _companyFacadeService = companyFacadeService;
            _dialogService = dialogService;

            Model = model;
            EditCommand?.Execute(null);
        }

        #region overrides
        protected override bool ConfirmDelete()
        {
            return _dialogService.ShowMessageBox("Kas kustutame saaja aadressi?", "Kustutamine", "YesNo");
        }

        protected override void DeleteItem(CompanyAddressModel model)
        {
            _companyFacadeService.DeleteCompanyAddressModel(model.CompanyAddressId);
            Model.CompanyAddressId = 0;
        }

        protected override bool SaveItem(CompanyAddressModel model)
        {
            Model.CompanyAddressId = _companyFacadeService.SaveCompanyAddressModel(model);

            return false;
        }
        #endregion
    }
}
