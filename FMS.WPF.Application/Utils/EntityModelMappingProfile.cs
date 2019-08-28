﻿using AutoMapper;
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
            #endregion

            #region product
            CreateMap<ProductBase, ProductListModel>();
            
            CreateMap<ProductBase, ProductBaseModel>(); 
            CreateMap<ProductVariation, ProductVariationModel>();
            CreateMap<ProductBaseProductVariation, ProductBaseProductVariationModel>();
            CreateMap<Product, ProductModel>();
            CreateMap<ProductSource, ProductCompanyModel>();
            CreateMap<ProductDestination, ProductCompanyModel>();
            #endregion

            #region Price
            CreateMap<Price, PriceModel>();
            //CreateMap<PriceList, PriceListModel>();
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
