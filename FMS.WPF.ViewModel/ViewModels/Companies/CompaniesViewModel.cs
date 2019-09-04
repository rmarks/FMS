using FMS.WPF.Models;
using FMS.WPF.ViewModel.Commands;
using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Utils;
using System.Windows.Input;

namespace FMS.WPF.ViewModels
{
    public class CompaniesViewModel : ViewModelBase, IWorkspace
    {
        #region constructors
        public CompaniesViewModel(IWorkspaceManager workspaceManager,
                                  IViewModelFactory viewModelFactory)
        {
            WorkspaceManager = workspaceManager;

            CompanyListViewModel = viewModelFactory.CreateInstance<CompanyListViewModel>();
            CompanyFacadeViewModel = viewModelFactory.CreateInstance<CompanyFacadeViewModel>();

            CompanyListViewModel.SelectedItemChanged += CompanyListViewModel_SelectedItemChanged;

            CompanyFacadeViewModel.ItemSaved += (model) => CompanyListViewModel.Refresh(model.CompanyId);
            CompanyFacadeViewModel.ItemDeleted += () => CompanyListViewModel.Refresh();
            CompanyFacadeViewModel.ItemEditCancelled += CompanyFacadeViewModel_CompanyEditCancelled;

            CompanyListViewModel.Load();
        }
        #endregion

        #region properties
        public override string DisplayName => "Firmad";
        public CompanyListViewModel CompanyListViewModel { get; }
        public CompanyFacadeViewModel CompanyFacadeViewModel { get; }
        public bool IsCompanyAvailable => CompanyListViewModel.SelectedItem != null;
        #endregion

        #region IWorkspace
        public IWorkspaceManager WorkspaceManager { get; }
        public ICommand CloseWorkspaceCommand => new RelayCommand(() => WorkspaceManager.CloseWorkspace(this));
        #endregion

        #region event handlers
        private void CompanyListViewModel_SelectedItemChanged(CompanyListModel model)
        {
            if (model != null)
            {
                CompanyFacadeViewModel.Load(model.CompanyId);
            }
            
            RaisePropertyChanged(nameof(IsCompanyAvailable));
        }

        private void CompanyFacadeViewModel_CompanyEditCancelled()
        {
            CompanyFacadeViewModel.Load(CompanyListViewModel.SelectedItem.CompanyId);
        }
        #endregion
    }
}
