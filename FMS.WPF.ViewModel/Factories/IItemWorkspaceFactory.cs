using FMS.WPF.ViewModels;

namespace FMS.WPF.ViewModel.Factories
{
    public interface IItemWorkspaceFactory
    {
        WorkspaceViewModelBase CreateInstance(int id);
    }
}
