using FMS.WPF.Application.Common;
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

        public WorkspaceViewModelBase CreateInstance()
        {
            CompanyDropdownTablesProxy.Instance = _kernel.Get<ICompanyDropdownTables>();

            return _kernel.Get<CompaniesViewModel>();
        }
    }
}
