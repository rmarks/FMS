using FMS.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace FMS.ViewModels
{
    public class WorkspaceViewModelBase : ViewModelBase
    {
        #region Commands
        ICommand _closeWorkspaceCommand;
        public ICommand CloseWorkspaceCommand => _closeWorkspaceCommand ?? 
                                                (_closeWorkspaceCommand = new DelegateCommand(p => RequestCloseWorkspace?.Invoke(this)));
        #endregion Commands

        #region Events
        public event Action<WorkspaceViewModelBase> RequestCloseWorkspace;
        #endregion Events
    }
}
