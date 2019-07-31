using FMS.WPF.Application.Dropdowns;
using FMS.WPF.Application.Interface.Dropdowns;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Application.Services;
using Ninject.Modules;

namespace FMS.WPF.Application.Utils
{
    public class NinjectBindingsForApplicationLayer : NinjectModule
    {
        public override void Load()
        {
            Bind<ICompanyAppService>().To<CompanyAppService>().InSingletonScope();
            Bind<ICompanyDropdowns>().To<CompanyDropdowns>().InSingletonScope();

            Bind<IProductAppService>().To<ProductAppService>().InSingletonScope();
            Bind<IProductDropdowns>().To<ProductDropdowns>().InSingletonScope();
        }
    }
}
