using AutoMapper;
using FMS.ServiceLayer.Dtos;
using FMS.WPF.Models;

namespace FMS.WPF.Application.Utils
{
    public class DtoModelMappingProfile : Profile
    {
        public DtoModelMappingProfile()
        {
            CreateMap<ProductListOptionsModel, ProductListOptionsDto>();
            CreateMap<ProductListDto, ProductListModel>();
            CreateMap<ProductSourceTypeDto, ProductSourceTypeModel>();
            CreateMap<ProductDestinationTypeDto, ProductDestinationTypeModel>();
        }
    }
}
