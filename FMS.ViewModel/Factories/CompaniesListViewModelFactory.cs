using FMS.WPF.ViewModels;
using Ninject;

namespace FMS.WPF.ViewModel.Factories
{
    public class CompaniesListViewModelFactory : ViewModelFactoryBase, IViewModelFactory<CompaniesListViewModel>
    {
        public CompaniesListViewModelFactory(IKernel kernel) : base(kernel)
        {
        }

        public CompaniesListViewModel CreateInstance(int Id = 0) => _kernel.Get<CompaniesListViewModel>();
    }
}
