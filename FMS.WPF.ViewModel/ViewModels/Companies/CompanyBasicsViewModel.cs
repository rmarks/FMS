using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Interfaces;
using FMS.WPF.Models;
using FMS.WPF.ViewModel.Extensions;
using FMS.WPF.ViewModel.Services;
using System;

namespace FMS.WPF.ViewModels
{
    public class CompanyBasicsViewModel : GenericEditableViewModelBase<CompanyBasicsModel>
    {
        #region Fields
        private ICompanyService _companyService;
        private IDialogService _dialogService;
        private ICompanyDropdownsService _dropdownsService;
        #endregion Fields

        public CompanyBasicsViewModel(ICompanyService companyService, 
                                      IDialogService dialogService,
                                      ICompanyDropdownsService dropdownsService)
        {
            DisplayName = "Üldandmed";

            _companyService = companyService;
            _dialogService = dialogService;
            _dropdownsService = dropdownsService;

            InitializeDropdowns();
        }

        public async void Load(int companyId)
        {
            var dto = companyId > 0
                ? await _companyService.GetCompanyAsync(companyId)
                : null;

            Model = dto?.MapTo<CompanyBasicsModel>();
        }

        #region Properties
        public CompanyDropdownsDto Dropdowns { get; private set; }
        #endregion Properties

        #region Events
        public event Action ItemSavedOrDeleted;
        #endregion Events

        #region GenericEditableViewModelBase Members
        protected override bool SaveItem(CompanyBasicsModel model)
        {
            var dto = _companyService.SaveCompany(model.MapTo<CompanyDto>());
            model = dto.MapTo<CompanyBasicsModel>();

            ItemSavedOrDeleted?.Invoke();

            return true;
        }

        protected override bool ConfirmDelete()
        {
            return _dialogService.ShowMessageBox("Kas kustutame firma?", "Kustutamine", "YesNo");
        }

        protected override void DeleteItem(CompanyBasicsModel model)
        {
            _companyService.DeleteCompany(model.CompanyId);
            ItemSavedOrDeleted?.Invoke();
        }
        #endregion GenericEditableViewModelBase Members

        #region Helpers
        private async void InitializeDropdowns()
        {
            Dropdowns = await _dropdownsService.GetCompanyDropdownsAsync();
        }
        #endregion Helpers
    }
}
