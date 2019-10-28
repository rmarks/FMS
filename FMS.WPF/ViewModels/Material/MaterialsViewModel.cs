using FMS.WPF.Models;
using FMS.WPF.Utils;

namespace FMS.WPF.ViewModels
{
    public class MaterialsViewModel : ViewModelBase, IWorkspace
    {
        public MaterialsViewModel(IWorkspaceManager workspaceManager,
                                  IViewModelFactory viewModelFactory)
        {
            WorkspaceManager = workspaceManager;

            MaterialListViewModel = viewModelFactory.CreateInstance<MaterialListViewModel>();
            MaterialViewModel = viewModelFactory.CreateInstance<MaterialViewModel>();

            MaterialListViewModel.SelectedItemChanged += MaterialListViewModel_SelectedItemChanged;

            MaterialListViewModel.Load();
        }

        #region properties
        public override string DisplayName => "Materjalid";
        public MaterialListViewModel MaterialListViewModel { get; }
        public MaterialViewModel MaterialViewModel { get; set; }
        public bool IsMaterialVisible { get; set; }
        public bool IsInEditMode { get; set; }
        #endregion

        #region event handlers
        private void MaterialListViewModel_SelectedItemChanged(MaterialModel model)
        {
            if (model != null)
            {
                MaterialViewModel.Load(model);
            }

            IsMaterialVisible = (model != null);
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
