using Autofac;
using FMS.DAL.Interfaces;

namespace FMS.DAL.EFCore
{
    public class DataContextFactory :IDataContextFactory
    {
        private readonly ILifetimeScope _scope;

        public DataContextFactory(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public IDataContext CreateContext() => _scope.Resolve<IDataContext>();
    }
}
