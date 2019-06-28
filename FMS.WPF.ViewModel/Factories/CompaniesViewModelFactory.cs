using FMS.WPF.Application.Common;
using FMS.WPF.ViewModels;
using Ninject;

namespace FMS.WPF.ViewModel.Factories
{
    public class CompaniesViewModelFactory : ViewModelFactoryBase, IWorkspaceViewModelFactory<CompaniesViewModel>
    {
        public CompaniesViewModelFactory(IKernel kernel) : base(kernel)
        {
        }

        public CompaniesViewModel CreateInstance(int Id = 0)
        {
            CompanyDropdownTablesProxy.Instance = _kernel.Get<ICompanyDropdownTables>();

            return _kernel.Get<CompaniesViewModel>();
        }

        public WorkspaceViewModelBase CreateWorkspace() => CreateInstance();
    }
}
