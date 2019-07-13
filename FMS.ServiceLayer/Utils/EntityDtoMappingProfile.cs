using AutoMapper;
using FMS.Domain.Model;
using FMS.ServiceLayer.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace FMS.ServiceLayer.Utils
{
    public class EntityDtoMappingProfile : Profile
    {
        public EntityDtoMappingProfile()
        {
            //company
            CreateMap<CompanyAddress, CompanyListDto>();
            CreateMap<CompanyAddress, CompanyAddressDto>().ReverseMap();
            CreateMap<Company, CompanyDto>()
                .ForMember(d => d.BillingAddress, o => o.MapFrom(s => s.Addresses.FirstOrDefault(a => a.IsBilling)));
            CreateMap<CompanyDto, Company>()
                .ForMember(d => d.Addresses, o => o.MapFrom(s => new List<CompanyAddressDto>(new[] { s.BillingAddress })));
            CreateMap<Contact, CompanyContactDto>().ReverseMap();
            
            //product
            CreateMap<ProductBase, ProductListDto>()
                .ForMember(d => d.ProductBrandAndCollectionName, o => o.MapFrom(s => $"{s.ProductBrand.Name}{(s.ProductCollection.Name == null ? "" : "/" + s.ProductCollection.Name)}"));

            //dropdowns
            CreateMap<BusinessLine, BusinessLineDropdownDto>();
            CreateMap<ProductSourceType, ProductSourceTypeDropdownDto>();
            CreateMap<ProductDestinationType, ProductDestinationTypeDropdownDto>();
            CreateMap<ProductStatus, ProductStatusDropdownDto>();
            CreateMap<ProductMaterial, ProductMaterialDropdownDto>();
            CreateMap<ProductType, ProductTypeDropdownDto>();
            CreateMap<ProductGroup, ProductGroupDropdownDto>();
            CreateMap<ProductBrand, ProductBrandDropdownDto>();
            CreateMap<ProductCollection, ProductCollectionDropdownDto>();
            CreateMap<ProductDesign, ProductDesignDropdownDto>();

            CreateMap<Country, CountryDropdownDto>();
            CreateMap<Currency, CurrencyDropdownDto>();
            CreateMap<PriceList, PriceListDropdownDto>();
            CreateMap<Location, LocationDropdownDto>();
            CreateMap<DeliveryTerm, DeliveryTermDropdownDto>();
            CreateMap<PaymentTerm, PaymentTermDropdownDto>();
        }
    }
}
