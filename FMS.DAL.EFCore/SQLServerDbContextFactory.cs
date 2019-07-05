using Ninject;

namespace FMS.DAL.EFCore
{
    public class SQLServerDbContextFactory : IDataContextFactory
    {
        private IKernel _kernel;

        public SQLServerDbContextFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IDataContext CreateContext() => _kernel.Get<SQLServerDbContext>();
    }
}
