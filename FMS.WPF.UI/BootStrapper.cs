﻿using FMS.WPF.ViewModel.Factories;
using FMS.WPF.ViewModel.Utils;
using FMS.WPF.ViewModels;
using FMS.WPF.Application.Services;
using Ninject;
using FMS.WPF.ViewModel.Services;
using FMS.WPF.UI.Services;
using FMS.WPF.Application.Common;
using FMS.DAL.EFCore.Utils;
using FMS.ServiceLayer.Utils;

namespace FMS.WPF.UI
{
    public class BootStrapper
    {
        private IKernel _kernel;

        public BootStrapper()
        {
            _kernel = new StandardKernel(new NinjectBindingsForDAL(), 
                                         new NinjectBindingsForServiceLayer());

            BindViewModels();
            BindFactories();
            BindInfra();
            BindApplicationServices();
        }

        public MainWindowViewModel MainWindowViewModel => _kernel.Get<MainWindowViewModel>();

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
            _kernel.Bind<ICompaniesViewModelFactory>().To<CompaniesViewModelFactory>().InSingletonScope();
            _kernel.Bind<IProductsViewModelFactory>().To<ProductsViewModelFactory>().InSingletonScope();
            _kernel.Bind<IProductListViewModelFactory>().To<ProductListViewModelFactory>().InSingletonScope();
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
            _kernel.Bind<IProductDropdownTables>().To<ProductDropdownTables>().InTransientScope();
        }
    }
}
