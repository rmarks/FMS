using FMS.ServiceLayer.Interfaces;
using FMS.ServiceLayer.Services;
using Ninject.Modules;

namespace FMS.ServiceLayer.Utils
{
    public class NinjectBindingsForServiceLayer : NinjectModule
    {
        public override void Load()
        {
            Bind<IListProductsService>().To<ListProductsService>().InTransientScope();
            Bind<IListProductSourceTypesService>().To<ListProductSourceTypesService>().InTransientScope();
            Bind<IListProductDestinationTypesService>().To<ListProductDestinationTypesService>().InTransientScope();
        }
    }
}
