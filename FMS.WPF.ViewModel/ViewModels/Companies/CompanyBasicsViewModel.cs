using FMS.WPF.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.ViewModel.Services;

namespace FMS.WPF.ViewModels
{
    public class CompanyBasicsViewModel : GenericEditableViewModelBase<CompanyModel>
    {
        #region fields
        private ICompanyFacadeService _companyFacadeService;
        private IDialogService _dialogService;
        #endregion

        public CompanyBasicsViewModel(ICompanyFacadeService companyFacadeService, 
                                      IDialogService dialogService)
        {
            _companyFacadeService = companyFacadeService;
            _dialogService = dialogService;
        }

        #region properties
        public override string DisplayName => "Üldandmed";
        #endregion

        #region public methods
        public void Load(int companyId)
        {
            //Model = _companyFacadeService.GetCompanyBasicsModel(companyId);
        }

        public void Load(CompanyModel model)
        {
            Model = model;
        }
        #endregion

        #region overrides
        protected override bool SaveItem(CompanyModel model)
        {
            //EditableModel = _companyFacadeService.SaveCompanyBasicsModel(model);

            return true;
        }

        protected override bool ConfirmDelete()
        {
            return _dialogService.ShowMessageBox("Kas kustutame firma?", "Kustutamine", "YesNo");
        }

        protected override void DeleteItem(CompanyModel model)
        {
            //_companyFacadeService.DeleteCompanyBasicsModel(model.CompanyId);
        }
        #endregion
    }
}
