using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.ViewModel.Services;

namespace FMS.WPF.ViewModels
{
    public class CompanyAddressViewModel : GenericEditableViewModelBase<CompanyAddressModel>
    {
        private ICompanyAppService _companyAppService;
        private IDialogService _dialogService;

        public CompanyAddressViewModel(CompanyAddressModel model, 
                                       ICompanyAppService companyAppService, 
                                       IDialogService dialogService)
        {
            DisplayName = "Saaja aadress";

            _companyAppService = companyAppService;
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
            _companyAppService.DeleteCompanyAddressModel(model.CompanyAddressId);
            Model.CompanyAddressId = 0;
        }

        protected override bool SaveItem(CompanyAddressModel model)
        {
            Model.CompanyAddressId = _companyAppService.SaveCompanyAddressModel(model);

            return false;
        }
        #endregion
    }
}
