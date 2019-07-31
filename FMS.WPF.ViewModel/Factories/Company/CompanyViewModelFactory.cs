using FMS.WPF.ViewModels;
using Ninject;

namespace FMS.WPF.ViewModel.Factories
{
    public class CompanyViewModelFactory : ICompanyViewModelFactory
    {
        private readonly IKernel _kernel;

        public CompanyViewModelFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public CompanyViewModel CreateInstance()
        {
            var companyViewModel = _kernel.Get<CompanyViewModel>();

            companyViewModel.CompanyBasicsViewModel = _kernel.Get<CompanyBasicsViewModel>();
            companyViewModel.CompanyAddressesViewModel = _kernel.Get<CompanyAddressesViewModel>();
            companyViewModel.CompanyContactsViewModel = _kernel.Get<CompanyContactsViewModel>();
            companyViewModel.CompanySalesOrderListViewModel = _kernel.Get<CompanySalesOrderListViewModel>();
            companyViewModel.CompanySalesInvoiceListViewModel = _kernel.Get<CompanySalesInvoiceListViewModel>();

            companyViewModel.Initialize();

            return companyViewModel;
        }
    }
}
