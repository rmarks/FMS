using FMS.DAL.Interfaces;
using Ninject.Modules;

namespace FMS.DAL.EFCore.Utils
{
    public class NinjectBindingsForDAL : NinjectModule
    {
        public override void Load()
        {
            Bind<IDataContext>().To<SQLServerDbContext>().InTransientScope();
            Bind<IDataContextFactory>().To<DataContextFactory>().InSingletonScope();
        }
    }
}
