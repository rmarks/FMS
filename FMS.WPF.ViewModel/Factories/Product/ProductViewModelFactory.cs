using FMS.WPF.ViewModels;
using Ninject;
using Ninject.Parameters;

namespace FMS.WPF.ViewModel.Factories
{
    public class ProductViewModelFactory : IProductViewModelFactory
    {
        private IKernel _kernel;

        public ProductViewModelFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public WorkspaceViewModelBase CreateInstance(int id)
        {
            return _kernel.Get<ProductViewModel>(new ConstructorArgument("productBaseId", id));
        }
    }
}
