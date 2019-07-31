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
            return _kernel.Get<CompanyViewModel>();
        }
    }
}
