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
                .ForMember(d => d.BillingAddress, o => o.MapFrom(s => s.Addresses.FirstOrDefault(a => a.IsBilling)))
                .ForMember(d => d.Addresses, o => o.MapFrom(s => s.Addresses.Where(a => a.IsShipping)))
                .ForMember(d => d.Contacts, o => o.MapFrom(s => s.Contacts))
                .ForMember(d => d.CompanyTypesLink, o => o.MapFrom(s => s.CompanyTypesLink));
            CreateMap<CompanyModel, Company>()
                .ForMember(d => d.Addresses, o => o.MapFrom(s => s.Addresses))
                .ForMember(d => d.Contacts, o => o.MapFrom(s => s.Contacts))
                .ForMember(d => d.CompanyTypesLink, o => o.MapFrom(s => s.CompanyTypesLink));
            CreateMap<CompanyType, CompanyTypeModel>().ReverseMap();
            CreateMap<CompanyCompanyType, CompanyCompanyTypeModel>();
            CreateMap<CompanyCompanyTypeModel, CompanyCompanyType>()
                .ForMember(d => d.CompanyType, o => o.Ignore());
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

            #region sales order
            CreateMap<SalesOrder, SalesOrderListModel>();
            CreateMap<SalesOrder, SalesOrderModel>();
            CreateMap<SalesOrderLine, SalesOrderLineModel>();
            CreateMap<CompanyAddress, CustomerAddressModel>();
            CreateMap<Company, CustomerModel>()
                .ForMember(d => d.Addresses, o => o.MapFrom(s => s.Addresses.OrderBy(a => a.Description)));
            #endregion

            #region delivery notes
            CreateMap<DeliveryHeader, DeliveryNoteListModel>();
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

            CreateMap<LocationType, LocationTypeDropdownModel>();
            #endregion
        }
    }
}
