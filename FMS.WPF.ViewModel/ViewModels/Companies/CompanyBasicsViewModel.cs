using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.ViewModel.Services;

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
            _companyAppService = companyAppService;
            _dialogService = dialogService;
        }

        #region properties
        public override string DisplayName => "Üldandmed";
        #endregion

        #region public methods
        public void Load(int companyId)
        {
            Model = _companyAppService.GetCompanyBasicsModel(companyId);
        }
        #endregion

        #region overrides
        protected override bool SaveItem(CompanyBasicsModel model)
        {
            EditableModel = _companyAppService.SaveCompanyBasicsModel(model);

            return true;
        }

        protected override bool ConfirmDelete()
        {
            return _dialogService.ShowMessageBox("Kas kustutame firma?", "Kustutamine", "YesNo");
        }

        protected override void DeleteItem(CompanyBasicsModel model)
        {
            _companyAppService.DeleteCompanyBasicsModel(model.CompanyId);
        }
        #endregion
    }
}
