using Autofac;
using FMS.DAL.Interfaces;

namespace FMS.DAL.EFCore
{
    public class SQLServerDbContextFactory : IDataContextFactory
    {
        private readonly ILifetimeScope _scope;

        public SQLServerDbContextFactory(ILifetimeScope scope)
        {
            _scope = scope;
        }

        public IDataContext CreateContext() => _scope.Resolve<SQLServerDbContext>();
    }
}
