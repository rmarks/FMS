using System.Collections.ObjectModel;
using FMS.WPF.ViewModels;

namespace FMS.WPF.ViewModel.Utils
{
    public interface IWorkspaceManager
    {
        ObservableCollection<WorkspaceViewModelBase> Workspaces { get; }

        void OpenWorkspace<T>(string paramName = null, int paramValue = 0) where T : WorkspaceViewModelBase;

        void CloseWorkspace(WorkspaceViewModelBase workspace);
    }
}