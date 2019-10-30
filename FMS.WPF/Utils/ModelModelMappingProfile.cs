using AutoMapper;
using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.Utils
{
    public class ModelModelMappingProfile : Profile
    {
        public ModelModelMappingProfile()
        {
            CreateMap<CompanyModel, CompanyModel>();
            CreateMap<CompanyAddressModel, CompanyAddressModel>();
            CreateMap<CompanyContactModel, CompanyContactModel>();

            CreateMap<ProductBaseModel, ProductBaseModel>();
            CreateMap<ProductModel, ProductModel>();
            CreateMap<ProductSourceModel, ProductSourceModel>();
            CreateMap<ProductDestinationModel, ProductDestinationModel>();

            CreateMap<PriceListModel, PriceListModel>();
            CreateMap<PriceModel, PriceModel>();

            CreateMap<SalesOrderModel, SalesOrderModel>();
            CreateMap<CustomerModel, CustomerModel>();
            CreateMap<CustomerAddressModel, CustomerAddressModel>();
        }
    }
}
