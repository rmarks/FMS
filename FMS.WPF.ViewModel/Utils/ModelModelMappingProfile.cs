using AutoMapper;
using FMS.WPF.Models;

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
        }
    }
}
