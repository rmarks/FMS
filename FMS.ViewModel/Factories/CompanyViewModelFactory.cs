using FMS.WPF.ViewModels;
using Ninject;
using Ninject.Parameters;

namespace FMS.WPF.ViewModel.Factories
{
    public class CompanyViewModelFactory : ViewModelFactoryBase, IViewModelFactory<CompanyViewModel>
    {
        public CompanyViewModelFactory(IKernel kernel) : base(kernel)
        {
        }

        public CompanyViewModel CreateInstance(int companyId)
        {
            var companyViewModel = _kernel.Get<CompanyViewModel>();

            companyViewModel.CompanyTabs.Add(_kernel.Get<CompanyBasicsViewModel>(new IParameter[] { new ConstructorArgument("companyId", companyId) }));
            companyViewModel.CompanyTabs.Add(_kernel.Get<CompanyAddressesViewModel>(new IParameter[] { new ConstructorArgument("companyId", companyId) }));
            companyViewModel.CompanyTabs.Add(_kernel.Get<CompanyContactsViewModel>(new IParameter[] { new ConstructorArgument("companyId", companyId) }));

            return companyViewModel;
        }
    }
}
