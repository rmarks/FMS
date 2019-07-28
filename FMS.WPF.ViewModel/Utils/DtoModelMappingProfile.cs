using AutoMapper;
using FMS.ServiceLayer.Interface.Dtos;
using FMS.WPF.Models;

namespace FMS.WPF.ViewModel.Utils
{
    public class DtoModelMappingProfile : Profile
    {
        public DtoModelMappingProfile()
        {
            CreateMap<CompanyDto, CompanyBasicsModel>().ReverseMap();
            CreateMap<CompanyAddressDto, CompanyAddressModel>().ReverseMap();
            CreateMap<CompanyContactDto, CompanyContactModel>().ReverseMap();
        }
    }
}
