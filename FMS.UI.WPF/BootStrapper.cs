using FMS.ViewModel.Factories;
using FMS.ViewModel.Utils;
using FMS.ViewModels;
using Ninject;

namespace FMS.UI.WPF
{
    public class BootStrapper
    {
        private IKernel _kernel = new StandardKernel();

        public BootStrapper()
        {
            BindViewModels();
            BindFactories();
            BindUtils();
        }

        public MainWindowViewModel MainWindowViewModel => _kernel.Get<MainWindowViewModel>();

        private void BindViewModels()
        {
            _kernel.Bind<MainWindowViewModel>().ToSelf().InSingletonScope();
            _kernel.Bind<CompaniesViewModel>().ToSelf().InTransientScope();
        }

        private void BindFactories()
        {
            _kernel.Bind<ICompaniesWorkspaceFactory>().To<CompaniesWorkspaceFactory>().InTransientScope();
        }

        private void BindUtils()
        {
            _kernel.Bind<IWorkspaceManager>().To<WorkspaceManager>().InSingletonScope();
        }
    }
}
