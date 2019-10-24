using FMS.WPF.Models;
using FMS.WPF.Utils;

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
            CompanyFacadeViewModel.EditModeChanged += CompanyFacadeViewModel_EditModeChanged;

            CompanyListViewModel.Load();
        }
        #endregion

        #region properties
        public override string DisplayName => "Firmad";
        public CompanyListViewModel CompanyListViewModel { get; }
        public CompanyFacadeViewModel CompanyFacadeViewModel { get; }
        public bool IsCompanyAvailable => CompanyListViewModel.SelectedItem != null;
        public bool IsInEditMode { get; set; }
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

        private void CompanyFacadeViewModel_EditModeChanged(bool isEditMode)
        {
            IsInEditMode = isEditMode;
            CloseWorkspaceCommand.RaiseCanExecuteChanged();
        }
        #endregion

        #region IWorkspace
        public IWorkspaceManager WorkspaceManager { get; }
        private RelayCommand _closeWorkspaceCommand;
        public RelayCommand CloseWorkspaceCommand => _closeWorkspaceCommand ??
            (_closeWorkspaceCommand = new RelayCommand(() => WorkspaceManager.CloseWorkspace(this), () => CanCloseWorkspace));
        public bool CanCloseWorkspace => !IsInEditMode;
        #endregion
    }
}
