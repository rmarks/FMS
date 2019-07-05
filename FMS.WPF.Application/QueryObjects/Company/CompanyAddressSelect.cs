using FMS.Domain.Model;
using FMS.WPF.Models;
using System.Linq;

namespace FMS.WPF.Application.QueryObjects
{
    public static class CompanyAddressSelect
    {
        public static IQueryable<CompanyAddressModel> MapToCompanyAddressModel(this IQueryable<CompanyAddress> companyAddresses)
        {
            return companyAddresses.Select(c => new CompanyAddressModel
            {
                CompanyAddressId = c.CompanyAddressId,
                CompanyId = c.CompanyId,
                CountryId = c.CountryId,
                CountryName = c.Country.CountryName,
                County = c.County,
                City = c.City,
                Address = c.Address,
                PostCode = c.PostCode,
                ConsigneeName = c.ConsigneeName,
                IsBilling = c.IsBilling,
                IsShipping = c.IsShipping,
                CreatedOn = c.CreatedOn
            });
        }

        public static CompanyAddressModel MapToCompanyAddressModel(this CompanyAddress address)
        {
            return new CompanyAddressModel
            {
                CompanyAddressId = address.CompanyAddressId,
                CompanyId = address.CompanyId,
                CountryId = address.CountryId,
                //CountryName = address.Country.CountryName,
                County = address.County,
                City = address.City,
                Address = address.Address,
                PostCode = address.PostCode,
                ConsigneeName = address.ConsigneeName,
                IsBilling = address.IsBilling,
                IsShipping = address.IsShipping,
                CreatedOn = address.CreatedOn
            };
        }

        public static CompanyAddress MapToCompanyAddress(this CompanyAddressModel model)
        {
            return new CompanyAddress
            {
                CompanyAddressId = model.CompanyAddressId,
                CompanyId = model.CompanyId,
                CountryId = model.CountryId,
                County = model.County,
                City = model.City,
                Address = model.Address,
                PostCode = model.PostCode,
                ConsigneeName = model.ConsigneeName,
                IsBilling = model.IsBilling,
                IsShipping = model.IsShipping,
                CreatedOn = model.CreatedOn
            };
        }
    }
}
