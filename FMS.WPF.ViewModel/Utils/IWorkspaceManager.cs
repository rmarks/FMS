using System;
using System.Collections.ObjectModel;
using FMS.WPF.ViewModels;

namespace FMS.WPF.ViewModel.Utils
{
    public interface IWorkspaceManager
    {
        ObservableCollection<IWorkspace> Workspaces { get; }

        event Action<IWorkspace> WorkspaceSelected;

        void OpenWorkspace<T>(int id = 0) where T : ViewModelBase, IWorkspace;

        void CloseWorkspace(IWorkspace workspace);
    }
}