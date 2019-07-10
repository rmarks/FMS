using AutoMapper;
using FMS.Domain.Model;
using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.Utils
{
    public class EntityDtoMappingProfile : Profile
    {
        public EntityDtoMappingProfile()
        {
            CreateMap<ProductBase, ProductListDto>()
                .ForMember(d => d.ProductBrandAndCollectionName, o => o.MapFrom(s => $"{s.ProductBrand.Name}{(s.ProductCollection.Name == null ? "" : "/" + s.ProductCollection.Name)}"));
            CreateMap<ProductSourceType, ProductSourceTypeDto>();
            CreateMap<ProductDestinationType, ProductDestinationTypeDto>();
        }
    }
}
