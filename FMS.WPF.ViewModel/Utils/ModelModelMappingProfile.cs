using AutoMapper;
using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.ViewModel.Utils
{
    public class ModelModelMappingProfile : Profile
    {
        public ModelModelMappingProfile()
        {
            CreateMap<CompanyModel, CompanyModel>();
            CreateMap<CompanyAddressModel, CompanyAddressModel>();
            CreateMap<CompanyContactModel, CompanyContactModel>();

            CreateMap<ProductBaseModel, ProductBaseModel>();
            CreateMap<ProductModel, ProductModel>();
            CreateMap<ProductCompanyModel, ProductCompanyModel>();

            CreateMap<PriceListModel, PriceListModel>();
            CreateMap<PriceModel, PriceModel>();
        }
    }
}
