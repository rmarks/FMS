using System.Reflection;
using Autofac;

namespace FMS.WPF.Application.Utils
{
    public class AutoFacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetType().GetTypeInfo().Assembly)
                .Where(c => c.Name.EndsWith("FacadeService") || c.Name.EndsWith("Dropdowns"))
                .AsImplementedInterfaces()
                .SingleInstance();

            //builder.RegisterAssemblyTypes(GetType().GetTypeInfo().Assembly)
            //    .Where(c => c.Name.EndsWith("ListService"))
            //    .AsImplementedInterfaces();

            //builder.RegisterType<DataTransferService>().As<IDataTransferService>();
            //builder.RegisterType<SalesOrderService>().As<ISalesOrderService>();

            builder.RegisterAssemblyTypes(GetType().GetTypeInfo().Assembly)
                .Where(c => !c.Name.EndsWith("FacadeService") && !c.Name.EndsWith("Dropdowns"))
                .AsImplementedInterfaces();
        }
    }
}
