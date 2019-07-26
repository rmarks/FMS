using AutoMapper;
using FMS.ServiceLayer.Dtos;
using FMS.WPF.Application.Interface.Models;

namespace FMS.WPF.Application.Utils
{
    public class DtoModelMappingProfile : Profile
    {
        public DtoModelMappingProfile()
        {
            CreateMap<ProductListOptionsModel, ProductListOptionsDto>();
            CreateMap<ProductListDto, ProductListModel>();

            CreateMap<ProductBaseDto, ProductBaseModel>();
            CreateMap<ProductDto, ProductModel>();
        }
    }
}
