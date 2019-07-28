using FMS.WPF.ViewModels;
using Ninject;

namespace FMS.WPF.ViewModel.Factories
{
    public class CompanyListViewModelFactory : ICompanyListViewModelFactory
    {
        private readonly IKernel _kernel;

        public CompanyListViewModelFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public CompanyListViewModel CreateInstance()
        {
            return _kernel.Get<CompanyListViewModel>();
        }
    }
}
