using System.Reflection;
using Autofac;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Application.Services;

namespace FMS.WPF.Application.Utils
{
    public class AutoFacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetType().GetTypeInfo().Assembly)
                .Where(c => c.Name.EndsWith("Service") || c.Name.EndsWith("Dropdowns"))
                .Except<DataTransferService>()
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.RegisterType<DataTransferService>().As<IDataTransferService>();
        }
    }
}
