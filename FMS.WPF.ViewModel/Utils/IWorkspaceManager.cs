using System.Collections.ObjectModel;
using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModels;

namespace FMS.WPF.ViewModel.Utils
{
    public interface IWorkspaceManager
    {
        ObservableCollection<WorkspaceViewModelBase> Workspaces { get; }

        void OpenWorkspace<T>(string displayName) where T : IWorkspaceFactory;

        void CloseWorkspace(WorkspaceViewModelBase workspace);
    }
}