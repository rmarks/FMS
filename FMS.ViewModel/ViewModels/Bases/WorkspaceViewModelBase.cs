using FMS.ViewModel.Commands;
using FMS.ViewModel.Utils;
using System.Windows.Input;

namespace FMS.ViewModels
{
    public abstract class WorkspaceViewModelBase : ViewModelBase
    {
        private IWorkspaceManager _workspaceManager;

        public WorkspaceViewModelBase(IWorkspaceManager workspaceManager)
        {
            _workspaceManager = workspaceManager;
        }

        #region Commands
        ICommand _closeWorkspaceCommand;
        public ICommand CloseWorkspaceCommand => _closeWorkspaceCommand ?? 
                                                (_closeWorkspaceCommand = new DelegateCommand(p => Close()));

        private void Close()
        {
            _workspaceManager.CloseWorkspace(this);
        }
        #endregion Commands
    }
}
