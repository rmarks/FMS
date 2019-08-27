using AutoMapper;
using FMS.ServiceLayer.Interface.Dtos;
using FMS.WPF.Application.Dropdowns;
using FMS.WPF.Models;

namespace FMS.WPF.Application.Utils
{
    public class DtoModelMappingProfile : Profile
    {
        public DtoModelMappingProfile()
        {
            #region company
            CreateMap<CompanyListDto, CompanyListModel>();
            CreateMap<CompanyDto, CompanyBasicsModel>().ReverseMap();
            CreateMap<CompanyAddressDto, CompanyAddressModel>().ReverseMap();
            CreateMap<CompanyContactDto, CompanyContactModel>().ReverseMap();
            CreateMap<CompanySalesOrderListDto, CompanySalesOrderListModel>();
            CreateMap<CompanySalesInvoiceListDto, CompanySalesInvoiceListModel>();
            CreateMap<CompanySmallDto, CompanySmallModel>();
            #endregion

            #region product
            CreateMap<ProductListOptionsModel, ProductListOptionsDto>();
            CreateMap<ProductListDto, ProductListModel>();
            CreateMap<ProductBaseDto, ProductBaseModel>().ReverseMap();
            CreateMap<ProductVariationDto, ProductVariationModel>().ReverseMap();
            CreateMap<ProductBaseProductVariationDto, ProductBaseProductVariationModel>().ReverseMap();
            CreateMap<ProductDto, ProductModel>();
            CreateMap<ProductCompanyDto, ProductCompanyModel>();
            #endregion

            #region Price
            CreateMap<PriceDto, PriceModel>();
            CreateMap<PriceListDto, PriceListModel>();
            #endregion

            #region dropdowns
            CreateMap<CompanyDropdownsDto, CompanyDropdowns>();
            CreateMap<CountryDropdownDto, CountryDropdownModel>();
            CreateMap<CurrencyDropdownDto, CurrencyDropdownModel>();
            CreateMap<PriceListDropdownDto, PriceListDropdownModel>();
            CreateMap<LocationDropdownDto, LocationDropdownModel>();
            CreateMap<DeliveryTermDropdownDto, DeliveryTermDropdownModel>();
            CreateMap<PaymentTermDropdownDto, PaymentTermDropdownModel>();

            CreateMap<ProductDropdownsDto, ProductDropdowns>();
            CreateMap<BusinessLineDropdownDto, BusinessLineDropdownModel>();
            CreateMap<ProductSourceTypeDropdownDto, ProductSourceTypeDropdownModel>();
            CreateMap<ProductDestinationTypeDropdownDto, ProductDestinationTypeDropdownModel>();
            CreateMap<ProductStatusDropdownDto, ProductStatusDropdownModel>();
            CreateMap<ProductMaterialDropdownDto, ProductMaterialDropdownModel>();
            CreateMap<ProductTypeDropdownDto, ProductTypeDropdownModel>();
            CreateMap<ProductGroupDropdownDto, ProductGroupDropdownModel>();
            CreateMap<ProductBrandDropdownDto, ProductBrandDropdownModel>();
            CreateMap<ProductCollectionDropdownDto, ProductCollectionDropdownModel>();
            CreateMap<ProductDesignDropdownDto, ProductDesignDropdownModel>();
            #endregion
        }
    }
}