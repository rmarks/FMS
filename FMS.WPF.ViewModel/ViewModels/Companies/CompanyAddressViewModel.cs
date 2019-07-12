using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Interfaces;
using FMS.WPF.Models;
using FMS.WPF.ViewModel.Extensions;
using FMS.WPF.ViewModel.Services;

namespace FMS.WPF.ViewModels
{
    public class CompanyAddressViewModel : GenericEditableViewModelBase<CompanyAddressModel>
    {
        private ICompanyService _companyService;
        private IDialogService _dialogService;
        private ICompanyDropdownsService _dropdownsService;

        public CompanyAddressViewModel(CompanyAddressModel model, 
                                       ICompanyService companyService, 
                                       IDialogService dialogService,
                                       ICompanyDropdownsService dropdownsService)
        {
            DisplayName = "Saaja aadress";

            _companyService = companyService;
            _dialogService = dialogService;
            _dropdownsService = dropdownsService;

            InitializeDropdowns();

            Model = model;
            EditCommand?.Execute(null);
        }

        public CompanyDropdownsDto Dropdowns { get; private set; }

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
            Model.CompanyAddressId = _companyService.SaveCompanyAddress(model.MapTo<CompanyAddressDto>());

            return false;
        }

        #region Helpers
        private async void InitializeDropdowns()
        {
            Dropdowns = await _dropdownsService.GetCompanyDropdownsAsync();
        }
        #endregion Helpers
    }
}
