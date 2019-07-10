using FMS.DAL.Interfaces;
using Ninject;

namespace FMS.DAL.EFCore
{
    public class DataContextFactory :IDataContextFactory
    {
        private IKernel _kernel;

        public DataContextFactory(IKernel kernel)
        {
            _kernel = kernel;
        }

        public IDataContext CreateContext() => _kernel.Get<IDataContext>();
    }
}
