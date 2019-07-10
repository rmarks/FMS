using FMS.WPF.Application.Common;
using FMS.WPF.ViewModels;
using Ninject;

namespace FMS.WPF.ViewModel.Factories
{
    public class ProductListViewModelFactory : IProductListViewModelFactory
    {
        private IKernel _kernel;

        public ProductListViewModelFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public ProductListViewModel CreateInstance()
        {
            var vm = _kernel.Get<ProductListViewModel>();
            vm.DropdownTables = _kernel.Get<IProductDropdownTables>();

            return vm;
        }
    }
}
