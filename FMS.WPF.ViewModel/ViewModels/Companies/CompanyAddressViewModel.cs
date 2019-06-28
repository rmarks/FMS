using FMS.WPF.Application.Common;
using FMS.WPF.Application.Services;
using FMS.WPF.Model;
using FMS.WPF.ViewModel.Services;
using System.Collections.Generic;

namespace FMS.WPF.ViewModels
{
    public class CompanyAddressViewModel : GenericEditableViewModelBase<CompanyAddressModel>
    {
        private ICompanyService _companyService;
        private IDialogService _dialogService;

        public CompanyAddressViewModel(CompanyAddressModel model, ICompanyService companyService, IDialogService dialogService)
        {
            DisplayName = "Saaja aadress";

            _companyService = companyService;
            _dialogService = dialogService;

            Model = model;
            EditCommand?.Execute(null);
        }

        public IList<CountryModel> Countries => CompanyDropdownTablesProxy.Instance.Countries;


        protected override bool ConfirmDelete()
        {
            return _dialogService.ShowMessageBox("Kas kustutame saaja aadressi?", "Kustutamine", "YesNo");
        }

        protected override void DeleteItem(CompanyAddressModel model)
        {
            _companyService.DeleteCompanyAddress(model.CompanyAddressId);
            Model.CompanyAddressId = 0;
        }

        protected override bool SaveItem(CompanyAddressModel model)
        {
            Model.CompanyAddressId = _companyService.SaveCompanyAddress(model);

            return false;
        }
    }
}
