using Autofac;
using System.Reflection;

namespace FMS.ServiceLayer.Utils
{
    public class AutoFacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(GetType().GetTypeInfo().Assembly)
                .Where(c => c.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }
    }
}
