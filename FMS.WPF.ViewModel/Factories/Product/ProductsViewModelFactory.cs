using FMS.WPF.ViewModels;
using Ninject;

namespace FMS.WPF.ViewModel.Factories
{
    public class ProductsViewModelFactory : IProductsViewModelFactory
    {
        private IKernel _kernel;

        public ProductsViewModelFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public WorkspaceViewModelBase CreateInstance()
        {
            return _kernel.Get<ProductsViewModel>();
        }
    }
}
