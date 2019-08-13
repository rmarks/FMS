using System;
using System.Collections.ObjectModel;
using FMS.WPF.ViewModels;

namespace FMS.WPF.ViewModel.Utils
{
    public interface IWorkspaceManager
    {
        ObservableCollection<WorkspaceViewModelBase> Workspaces { get; }

        event Action<WorkspaceViewModelBase> WorkspaceSelected;

        void OpenWorkspace<T>(int id = 0) where T : WorkspaceViewModelBase;

        void CloseWorkspace(WorkspaceViewModelBase workspace);
    }
}