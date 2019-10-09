using Autofac;
using FMS.WPF.ViewModels;
using System.Reflection;

namespace FMS.WPF.Utils
{
    public class AutoFacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<WorkspaceManager>().As<IWorkspaceManager>().SingleInstance();
            builder.RegisterType<ViewModelFactory>().As<IViewModelFactory>().SingleInstance();

            builder.RegisterType<MainWindowViewModel>().SingleInstance();

            builder.RegisterAssemblyTypes(GetType().GetTypeInfo().Assembly)
                .Where(c => c.Name.EndsWith("ViewModel"))
                .Except<MainWindowViewModel>();

            builder.RegisterAssemblyTypes(GetType().GetTypeInfo().Assembly)
                .Where(c => c.Name.EndsWith("Service"))
                .AsImplementedInterfaces();
        }
    }
}
