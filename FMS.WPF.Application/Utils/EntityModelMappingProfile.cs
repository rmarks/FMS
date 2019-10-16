using AutoMapper;
using FMS.Domain.Model;
using FMS.WPF.Models;
using System.Linq;

namespace FMS.WPF.Application.Utils
{
    public class EntityModelMappingProfile : Profile
    {
        public EntityModelMappingProfile()
        {
            #region company
            CreateMap<Company, CompanyListModel>()
                .ForMember(d => d.CompanyTypesString, o => o.MapFrom(s =>
                    string.Join(", ", s.CompanyTypesLink.OrderBy(c => c.CompanyTypeId).Select(c => c.CompanyType.Name))))
                .ForMember(d => d.BillingAddress, o => o.MapFrom(s => s.Addresses.FirstOrDefault(a => a.IsBilling)));
            CreateMap<CompanyAddress, CompanyAddressListModel>();

            CreateMap<Company, CompanyModel>()
                .ForMember(d => d.CompanyTypesString, o => o.MapFrom(s =>
                    string.Join(", ", s.CompanyTypesLink.OrderBy(c => c.CompanyTypeId).Select(c => c.CompanyType.Name))))
                .ForMember(d => d.BillingAddress, o => o.MapFrom(s => s.Addresses.FirstOrDefault(a => a.IsBilling)))
                .ForMember(d => d.Addresses, o => o.MapFrom(s => s.Addresses.Where(a => a.IsShipping)));
            CreateMap<CompanyModel, Company>();
            CreateMap<CompanyAddress, CompanyAddressModel>().ReverseMap();
            CreateMap<Contact, CompanyContactModel>().ReverseMap();

            CreateMap<Company, CompanySmallModel>();
            #endregion

            #region product
            CreateMap<ProductBase, ProductListModel>();

            CreateMap<ProductBase, ProductBaseModel>()
                .ForMember(d => d.Products, o => o.MapFrom(s => s.Products.OrderBy(p => p.ProductCode)))
                .ForMember(d => d.ProductVariationsLink, o => o.MapFrom(s => s.ProductVariationsLink));
            CreateMap<ProductBaseModel, ProductBase>()
                .ForMember(d => d.ProductStatus, o => o.Ignore())
                .ForMember(d => d.Products, o => o.MapFrom(s => s.Products))
                .ForMember(d => d.ProductVariationsLink, o => o.MapFrom(s => s.ProductVariationsLink)); ;
            CreateMap<ProductVariation, ProductVariationModel>().ReverseMap();
            CreateMap<ProductBaseProductVariation, ProductBaseProductVariationModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<ProductSource, ProductSourceModel>().ReverseMap();
            CreateMap<ProductDestination, ProductDestinationModel>().ReverseMap();
            #endregion

            #region price
            CreateMap<Price, PriceModel>().ReverseMap();
            CreateMap<PriceList, PriceListModel>();
            #endregion

            #region dropdowns
            CreateMap<BusinessLine, BusinessLineDropdownModel>();
            CreateMap<ProductSourceType, ProductSourceTypeDropdownModel>();
            CreateMap<ProductDestinationType, ProductDestinationTypeDropdownModel>();
            CreateMap<ProductStatus, ProductStatusDropdownModel>();
            CreateMap<ProductMaterial, ProductMaterialDropdownModel>();
            CreateMap<ProductType, ProductTypeDropdownModel>();
            CreateMap<ProductGroup, ProductGroupDropdownModel>();
            CreateMap<ProductBrand, ProductBrandDropdownModel>();
            CreateMap<ProductCollection, ProductCollectionDropdownModel>();
            CreateMap<ProductDesign, ProductDesignDropdownModel>();

            CreateMap<Country, CountryDropdownModel>();
            CreateMap<Currency, CurrencyDropdownModel>();
            CreateMap<PriceList, PriceListDropdownModel>();
            CreateMap<Location, LocationDropdownModel>();
            CreateMap<DeliveryTerm, DeliveryTermDropdownModel>();
            CreateMap<PaymentTerm, PaymentTermDropdownModel>();
            #endregion
        }
    }
}
