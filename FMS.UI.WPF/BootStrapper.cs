﻿using FMS.ViewModel.Factories;
using FMS.ViewModel.Utils;
using FMS.ViewModels;
using FMS.WPF.Application.Services;
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
            BindApplicationServices();
        }

        public MainWindowViewModel MainWindowViewModel => _kernel.Get<MainWindowViewModel>();

        private void BindViewModels()
        {
            _kernel.Bind<MainWindowViewModel>().ToSelf().InSingletonScope();
            _kernel.Bind<CompaniesViewModel>().ToSelf().InTransientScope();
            _kernel.Bind<CompaniesListViewModel>().ToSelf().InTransientScope();
        }

        private void BindFactories()
        {
            _kernel.Bind<ICompaniesWorkspaceFactory>().To<CompaniesWorkspaceFactory>().InTransientScope();
            _kernel.Bind<ICompaniesListViewModelFactory>().To<CompaniesListViewModelFactory>().InTransientScope();
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
