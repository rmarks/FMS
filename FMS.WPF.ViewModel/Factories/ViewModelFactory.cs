using Autofac;
using FMS.WPF.ViewModels;

namespace FMS.WPF.ViewModel.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly ILifetimeScope _scope;

        public ViewModelFactory(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public T CreateInstance<T>(int id = 0) where T : ViewModelBase
        {
            if (id != 0)
            {
                return _scope.Resolve<T>(new TypedParameter(typeof(int), id));
            }

            return _scope.Resolve<T>();
        }
    }
}
