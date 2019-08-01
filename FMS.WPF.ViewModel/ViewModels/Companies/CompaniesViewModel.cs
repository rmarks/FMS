using FMS.WPF.Application.Interface.Models;
using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Utils;

namespace FMS.WPF.ViewModels
{
    public class CompaniesViewModel : WorkspaceViewModelBase
    {
        #region constructors
        public CompaniesViewModel(IWorkspaceManager workspaceManager,
                                  IViewModelFactory viewModelFactory) : base(workspaceManager)
        {
            CompanyListViewModel = viewModelFactory.CreateInstance<CompanyListViewModel>();
            CompanyViewModel = viewModelFactory.CreateInstance<CompanyViewModel>();

            CompanyListViewModel.SelectedItemChanged += CompanyListViewModel_SelectedItemChanged;
            CompanyViewModel.RequestListRefresh += CompanyViewModel_RequestListRefresh;

            CompanyListViewModel.Load();
        }
        #endregion

        #region properties
        public override string DisplayName => "Firmad";

        public CompanyListViewModel CompanyListViewModel { get; }

        public CompanyViewModel CompanyViewModel { get; }

        public bool IsCompanyAvailable => CompanyListViewModel.SelectedItem != null;
        #endregion

        #region event handlers
        private void CompanyListViewModel_SelectedItemChanged(CompanyListModel model)
        {
            CompanyViewModel.Load(model?.CompanyId ?? 0);
            RaisePropertyChanged(nameof(IsCompanyAvailable));
        }

        private void CompanyViewModel_RequestListRefresh()
        {
            CompanyListViewModel.Refresh();
        }
        #endregion
    }
}
