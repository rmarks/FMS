using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.ViewModel.Services;
using System;

namespace FMS.WPF.ViewModels
{
    public class CompanyBasicsViewModel : GenericEditableViewModelBase<CompanyBasicsModel>
    {
        #region fields
        private ICompanyAppService _companyAppService;
        private IDialogService _dialogService;
        #endregion

        public CompanyBasicsViewModel(ICompanyAppService companyAppService, 
                                      IDialogService dialogService)
        {
            DisplayName = "Üldandmed";

            _companyAppService = companyAppService;
            _dialogService = dialogService;
        }

        public void Load(int companyId)
        {
            Model = companyId > 0
                ? _companyAppService.GetCompanyBasicsModel(companyId)
                : null;
        }

        #region events
        public event Action ItemSavedOrDeleted;
        #endregion

        #region overrides
        protected override bool SaveItem(CompanyBasicsModel model)
        {
            model = _companyAppService.SaveCompanyBasicsModel(model);

            ItemSavedOrDeleted?.Invoke();

            return true;
        }

        protected override bool ConfirmDelete()
        {
            return _dialogService.ShowMessageBox("Kas kustutame firma?", "Kustutamine", "YesNo");
        }

        protected override void DeleteItem(CompanyBasicsModel model)
        {
            _companyAppService.DeleteCompanyBasicsModel(model.CompanyId);

            ItemSavedOrDeleted?.Invoke();
        }
        #endregion
    }
}
