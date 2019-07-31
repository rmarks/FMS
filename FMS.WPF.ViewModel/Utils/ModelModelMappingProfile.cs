using AutoMapper;
using FMS.WPF.Application.Interface.Models;

namespace FMS.WPF.ViewModel.Utils
{
    public class ModelModelMappingProfile : Profile
    {
        public ModelModelMappingProfile()
        {
            CreateMap<CompanyBasicsModel, CompanyBasicsModel>();
            CreateMap<ProductBaseModel, ProductBaseModel>();
        }
    }
}
