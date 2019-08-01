using FMS.WPF.ViewModels;
using Ninject;
using Ninject.Parameters;

namespace FMS.WPF.ViewModel.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly IKernel _kernel;

        public ViewModelFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public T CreateInstance<T>(string paramName = null, int paramValue = 0) where T : ViewModelBase
        {
            if (paramName != null && paramValue != 0)
            {
                return _kernel.Get<T>(new ConstructorArgument(paramName, paramValue));
            }

            return _kernel.Get<T>();
        }
    }
}
