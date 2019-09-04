using System.Windows.Input;

namespace FMS.WPF.ViewModel.Utils
{
    public interface IWorkspace
    {
        IWorkspaceManager WorkspaceManager { get; }
        ICommand CloseWorkspaceCommand { get; }
        string DisplayName { get; }
    }
}
