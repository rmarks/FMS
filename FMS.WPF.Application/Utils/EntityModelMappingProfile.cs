using AutoMapper;
using FMS.Domain.Model;
using FMS.WPF.Application.Interface.Models;

namespace FMS.WPF.Application.Utils
{
    public class EntityModelMappingProfile : Profile
    {
        public EntityModelMappingProfile()
        {
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
            #endregion
        }
    }
}
