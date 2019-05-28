using System;
using System.Collections.Generic;
using System.Text;
using FMS.ViewModels;
using Ninject;

namespace FMS.ViewModel.Factories
{
    public class CompaniesWorkspaceFactory : ICompaniesWorkspaceFactory
    {
        private IKernel _kernel;

        public CompaniesWorkspaceFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public CompaniesViewModel CreateInstance() => _kernel.Get<CompaniesViewModel>();

        public WorkspaceViewModelBase CreateWorkspace() => CreateInstance();
    }
}
