using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModels;
using Ninject.Modules;

namespace FMS.WPF.ViewModel.Utils
{
    public class NinjectBindingsForViewModel : NinjectModule
    {
        public override void Load()
        {
            Bind<IWorkspaceManager>().To<WorkspaceManager>().InSingletonScope();

            BindViewModels();
            BindFactories();
        }

        private void BindViewModels()
        {
            Bind<MainWindowViewModel>().ToSelf().InSingletonScope();

            Bind<CompaniesViewModel>().ToSelf().InTransientScope();
            Bind<CompanyListViewModel>().ToSelf().InTransientScope();
            Bind<CompanyViewModel>().ToSelf().InTransientScope();
            Bind<CompanyBasicsViewModel>().ToSelf().InTransientScope();
            Bind<CompanyAddressesViewModel>().ToSelf().InTransientScope();
            Bind<CompanyContactsViewModel>().ToSelf().InTransientScope();
            Bind<CompanySalesOrderListViewModel>().ToSelf().InTransientScope();
            Bind<CompanySalesInvoiceListViewModel>().ToSelf().InTransientScope();

            Bind<ProductsViewModel>().ToSelf().InTransientScope();
            Bind<ProductListViewModel>().ToSelf().InTransientScope();
            Bind<ProductViewModel>().ToSelf().InTransientScope();
        }

        private void BindFactories()
        {
            Bind<IViewModelFactory>().To<ViewModelFactory>().InSingletonScope();
        }
    }
}
