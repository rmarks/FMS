﻿using FMS.ServiceLayer.Interface.Services;
using FMS.ServiceLayer.Services;
using Ninject.Modules;

namespace FMS.ServiceLayer.Utils
{
    public class NinjectBindingsForServiceLayer : NinjectModule
    {
        public override void Load()
        {
            Bind<ICompanyService>().To<CompanyService>().InTransientScope();
            Bind<ICompanyDropdownsService>().To<CompanyDropdownsService>().InTransientScope();

            Bind<IProductService>().To<ProductService>().InTransientScope();
            Bind<IProductDropdownsService>().To<ProductDropdownsService>().InTransientScope();
        }
    }
}
