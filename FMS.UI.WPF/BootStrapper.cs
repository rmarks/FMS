using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Utils;
using FMS.WPF.ViewModels;
using FMS.WPF.Application.Services;
using Ninject;

namespace FMS.WPF.UI
{
    public class BootStrapper
    {
        private IKernel _kernel = new StandardKernel();

        public BootStrapper()
        {
            BindViewModels();
            BindFactories();
            BindUtils();
            BindApplicationServices();
        }

        public MainWindowViewModel MainWindowViewModel => _kernel.Get<MainWindowViewModel>();

        private void BindViewModels()
        {
            _kernel.Bind<MainWindowViewModel>().ToSelf().InSingletonScope();
            _kernel.Bind<CompaniesViewModel>().ToSelf().InTransientScope();
            _kernel.Bind<CompaniesListViewModel>().ToSelf().InTransientScope();
            _kernel.Bind<CompanyViewModel>().ToSelf().InTransientScope();
            _kernel.Bind<CompanyBasicsViewModel>().ToSelf().InTransientScope();
            _kernel.Bind<CompanyAddressesViewModel>().ToSelf().InTransientScope();
            _kernel.Bind<CompanyContactsViewModel>().ToSelf().InTransientScope();
        }

        private void BindFactories()
        {
            _kernel.Bind<IWorkspaceViewModelFactory<CompaniesViewModel>>().To<CompaniesViewModelFactory>().InTransientScope();
            _kernel.Bind<IViewModelFactory<CompaniesListViewModel>>().To<CompaniesListViewModelFactory>().InTransientScope();
            _kernel.Bind<IViewModelFactory<CompanyViewModel>>().To<CompanyViewModelFactory>().InTransientScope();
        }

        private void BindUtils()
        {
            _kernel.Bind<IWorkspaceManager>().To<WorkspaceManager>().InSingletonScope();
        }

        private void BindApplicationServices()
        {
            _kernel.Bind<IDataTransferService>().To<DataTransferService>().InTransientScope();
            _kernel.Bind<ICompaniesListService>().To<CompaniesListService>().InTransientScope();
        }
    }
}
