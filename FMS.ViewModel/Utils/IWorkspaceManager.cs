using System.Collections.ObjectModel;
using FMS.ViewModel.Factories;
using FMS.ViewModels;

namespace FMS.ViewModel.Utils
{
    public interface IWorkspaceManager
    {
        ObservableCollection<WorkspaceViewModelBase> Workspaces { get; }

        void OpenWorkspace<T>(string displayName) where T : IWorkspaceFactory;

        void CloseWorkspace(WorkspaceViewModelBase workspace);
    }
}