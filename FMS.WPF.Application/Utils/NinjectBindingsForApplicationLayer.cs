using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Application.Services;
using Ninject.Modules;

namespace FMS.WPF.Application.Utils
{
    public class NinjectBindingsForApplicationLayer : NinjectModule
    {
        public override void Load()
        {
            Bind<ICompanyListVmService>().To<CompanyListVmService>().InTransientScope();

            Bind<IProductsVmService>().To<ProductsVmService>().InTransientScope();
            Bind<IProductVmService>().To<ProductVmService>().InTransientScope();
        }
    }
}
