using FMS.WPF.ViewModels;

namespace FMS.WPF.ViewModel.Factories
{
    public interface IWorkspaceFactory
    {
        WorkspaceViewModelBase CreateInstance();
    }
}
