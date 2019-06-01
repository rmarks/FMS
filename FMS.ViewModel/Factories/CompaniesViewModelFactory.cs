using System;
using System.Collections.Generic;
using System.Text;
using FMS.WPF.ViewModels;
using Ninject;

namespace FMS.WPF.ViewModel.Factories
{
    public class CompaniesViewModelFactory : ICompaniesViewModelFactory
    {
        private IKernel _kernel;

        public CompaniesViewModelFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public CompaniesViewModel CreateInstance() => _kernel.Get<CompaniesViewModel>();

        public WorkspaceViewModelBase CreateWorkspace() => CreateInstance();
    }
}
