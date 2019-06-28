using FMS.WPF.ViewModels;

namespace FMS.WPF.ViewModel.Factories
{
    public interface IWorkspaceViewModelFactory<TViewModel> : IViewModelFactory<TViewModel>, IWorkspaceFactory 
                                                            where TViewModel : WorkspaceViewModelBase
    {
    }
}
