using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Utils;
using FMS.WPF.ViewModels;
using FMS.WPF.Application.Services;
using Ninject;
using FMS.WPF.ViewModel.Services;
using FMS.WPF.UI.Services;
using FMS.WPF.Application.Common;
using FMS.DAL.EFCore;
using FMS.ServiceLayer.Interfaces.ProductServices;
using FMS.ServiceLayer.ProductServices;

namespace FMS.WPF.UI
{
    public class BootStrapper
    {
        private IKernel _kernel = new StandardKernel();

        public BootStrapper()
        {
            BindViewModels();
            BindFactories();
            BindInfra();
            BindApplicationServices();
            BindDataContexts();
            BindServiceLayerServices();
        }

        public MainWindowViewModel MainWindowViewModel => _kernel.Get<MainWindowViewModel>();

        private void BindDataContexts()
        {
            _kernel.Bind<IDataContext>().To<SQLServerDbContext>().InTransientScope();
            _kernel.Bind<SQLServerDbContext>().ToSelf().InTransientScope();
        }

        private void BindViewModels()
        {
            _kernel.Bind<MainWindowViewModel>().ToSelf().InSingletonScope();

            _kernel.Bind<CompaniesViewModel>().ToSelf().InTransientScope();
            _kernel.Bind<CompanyListViewModel>().ToSelf().InTransientScope();
            _kernel.Bind<CompanyViewModel>().ToSelf().InTransientScope();
            _kernel.Bind<CompanyBasicsViewModel>().ToSelf().InTransientScope();
            _kernel.Bind<CompanyAddressesViewModel>().ToSelf().InTransientScope();
            _kernel.Bind<CompanyContactsViewModel>().ToSelf().InTransientScope();

            _kernel.Bind<ProductsViewModel>().ToSelf().InTransientScope();
            _kernel.Bind<ProductListViewModel>().ToSelf().InTransientScope();
        }

        private void BindFactories()
        {
            //_kernel.Bind<IDataContextFactory>().To<SQLServerDbContextFactory>().InSingletonScope();
            _kernel.Bind<IDataContextFactory>().To<DataContextFactory>().InSingletonScope();

            _kernel.Bind<ICompaniesViewModelFactory>().To<CompaniesViewModelFactory>().InSingletonScope();
            _kernel.Bind<IProductsViewModelFactory>().To<ProductsViewModelFactory>().InSingletonScope();
        }

        private void BindInfra()
        {
            _kernel.Bind<IWorkspaceManager>().To<WorkspaceManager>().InSingletonScope();
            _kernel.Bind<IDialogService>().To<DialogService>().InTransientScope();
            _kernel.Bind<IProgressBarService>().To<ProgressBarService>().InTransientScope();
        }

        private void BindApplicationServices()
        {
            _kernel.Bind<IDataTransferService>().To<DataTransferService>().InTransientScope();
            
            _kernel.Bind<ICompanyService>().To<CompanyService>().InTransientScope();
            _kernel.Bind<ICompanyDropdownTables>().To<CompanyDropdownTables>().InTransientScope();

            _kernel.Bind<IProductsService>().To<ProductsService>().InTransientScope();
        }

        private void BindServiceLayerServices()
        {
            _kernel.Bind<IListProductsService>().To<ListProductsService>().InTransientScope();
        }
    }
}
