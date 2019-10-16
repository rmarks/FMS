namespace FMS.WPF.Utils
{
    public interface IWorkspace
    {
        IWorkspaceManager WorkspaceManager { get; }
        RelayCommand CloseWorkspaceCommand { get; }
        string DisplayName { get; }
    }
}
