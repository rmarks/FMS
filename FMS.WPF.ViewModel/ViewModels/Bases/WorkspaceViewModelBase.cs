using FMS.WPF.ViewModel.Commands;
using FMS.WPF.ViewModel.Utils;
using System.Windows.Input;

namespace FMS.WPF.ViewModels
{
    public abstract class WorkspaceViewModelBase : ViewModelBase
    {
        public WorkspaceViewModelBase(IWorkspaceManager workspaceManager)
        {
            WorkspaceManager = workspaceManager;
        }

        protected IWorkspaceManager WorkspaceManager { get; set; }

        #region commands
        ICommand _closeWorkspaceCommand;
        public ICommand CloseWorkspaceCommand => _closeWorkspaceCommand ?? (_closeWorkspaceCommand = new RelayCommand(Close));

        private void Close()
        {
            WorkspaceManager.CloseWorkspace(this);
        }
        #endregion
    }
}
