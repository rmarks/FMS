﻿using Autofac;
using AutoMapper;
using FMS.WPF.Application.Interface.Dropdowns;
using FMS.WPF.ViewModels;

namespace FMS.WPF.App
{
    public class Bootstrapper
    {
        private IContainer _container;

        public Bootstrapper()
        {
            ConfigureAutoMapper();
            ConfigureContainer();
            ConfigureDropdowns();
        }

        public MainWindowViewModel MainWindowViewModel => _container.Resolve<MainWindowViewModel>();

        #region helpers
        private void ConfigureAutoMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<FMS.ServiceLayer.Utils.EntityDtoMappingProfile>();
                cfg.AddProfile<FMS.WPF.Application.Utils.DtoModelMappingProfile>();
                cfg.AddProfile<FMS.WPF.Application.Utils.EntityModelMappingProfile>();
                cfg.AddProfile<FMS.WPF.ViewModel.Utils.ModelModelMappingProfile>();
            });
        }

        private void ConfigureContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<FMS.DAL.EFCore.Utils.AutoFacModule>()
                   .RegisterModule<FMS.ServiceLayer.Utils.AutoFacModule>()
                   .RegisterModule<FMS.WPF.Application.Utils.AutoFacModule>()
                   .RegisterModule<FMS.WPF.ViewModel.Utils.AutoFacModule>()
                   .RegisterModule<FMS.WPF.UI.Utils.AutoFacModule>();

            _container = builder.Build();
        }

        private void ConfigureDropdowns()
        {
            CompanyDropdownsProxy.Instance = _container.Resolve<ICompanyDropdowns>();
            ProductDropdownsProxy.Instance = _container.Resolve<IProductDropdowns>();
        }
        #endregion
    }
}
