using Autofac;
using FMS.WPF.ViewModels;

namespace FMS.WPF.Utils
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly ILifetimeScope _scope;

        public ViewModelFactory(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public T CreateInstance<T>() where T : ViewModelBase
        {
            return _scope.Resolve<T>();
        }

        public T CreateInstance<T>(int id) where T : ViewModelBase
        {
            return _scope.Resolve<T>(new TypedParameter(typeof(int), id));
        }

        public TInstance CreateInstance<TInstance, TParameter>(TParameter param) where TInstance : ViewModelBase
        {
            return _scope.Resolve<TInstance>(new TypedParameter(typeof(TParameter), param));
        }
    }
}
