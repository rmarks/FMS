using AutoMapper;
using FMS.Domain.Model;
using FMS.WPF.Models;

namespace FMS.WPF.Application.Utils
{
    public class ModelMappingProfile : Profile
    {
        public ModelMappingProfile()
        {
            CreateMap<ProductBase, ProductListModel>()
                .ForMember(d => d.ProductBrandAndCollectionName, o => o.MapFrom(s => $"{s.ProductBrand.Name}{(s.ProductCollection.Name == null ? "" : "/" + s.ProductCollection.Name)}"));
        }
    }
}
