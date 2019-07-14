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
            return _kernel.Get<CompaniesViewModel>();
        }
    }
}
