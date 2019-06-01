using System;
using System.Collections.Generic;
using System.Text;
using FMS.WPF.ViewModels;
using Ninject;
using Ninject.Parameters;

namespace FMS.WPF.ViewModel.Factories
{
    public class CompanyCompoundViewModelFactory : ICompanyCompoundViewModelFactory
    {
        private IKernel _kernel;

        public CompanyCompoundViewModelFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public CompanyCompoundViewModel CreateInstance(int companyId)
        {
            return _kernel.Get<CompanyCompoundViewModel>(new IParameter[] { new ConstructorArgument("companyId", companyId) });
        }
    }
}
