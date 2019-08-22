using AutoMapper;
using FMS.Domain.Model;
using FMS.ServiceLayer.Interface.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace FMS.ServiceLayer.Utils
{
    public class EntityDtoMappingProfile : Profile
    {
        public EntityDtoMappingProfile()
        {
            #region company
            CreateMap<CompanyAddress, CompanyListDto>();
            CreateMap<CompanyAddress, CompanyAddressDto>();
            CreateMap<CompanyAddressDto, CompanyAddress>()
                .ForMember(d => d.Country, o => o.Ignore());
            CreateMap<Company, CompanyDto>()
                .ForMember(d => d.BillingAddress, o => o.MapFrom(s => s.Addresses.FirstOrDefault(a => a.IsBilling)))
                .ForMember(d => d.CompanyTypesString, o => o.MapFrom(s => 
                    string.Join(", ", s.CompanyTypesLink.OrderBy(c => c.CompanyTypeId).Select(c => c.CompanyType.Name))));
            CreateMap<CompanyDto, Company>()
                .ForMember(d => d.Addresses, o => o.MapFrom(s => new List<CompanyAddressDto>(new[] { s.BillingAddress })));
            CreateMap<Contact, CompanyContactDto>().ReverseMap();
            CreateMap<Company, CompanySmallDto>();
            #endregion

            #region product
            CreateMap<ProductBase, ProductListDto>();
            CreateMap<ProductBase, ProductBaseDto>().ReverseMap();
            CreateMap<ProductVariation, ProductVariationDto>().ReverseMap();
            CreateMap<ProductBaseProductVariation, ProductBaseProductVariationDto>().ReverseMap();
            CreateMap<Product, ProductDto>();
            CreateMap<ProductCompany, ProductCompanyDto>();
            #endregion

            #region Price
            //CreateMap<Price, PriceDto>();
            //CreateMap<PriceList, PriceListDto>();
            #endregion

            #region dropdowns
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
            #endregion
        }
    }
}
