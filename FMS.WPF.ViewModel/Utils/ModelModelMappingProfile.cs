using AutoMapper;
using FMS.WPF.Models;

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
