using Autofac;
using FMS.DAL.Interfaces;

namespace FMS.DAL.EFCore.Utils
{
    public class AutoFacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SQLServerDbContext>().As<IDataContext>();
            builder.RegisterType<DataContextFactory>().As<IDataContextFactory>().SingleInstance();
        }
    }
}
