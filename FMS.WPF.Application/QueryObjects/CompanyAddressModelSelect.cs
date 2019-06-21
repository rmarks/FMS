using FMS.Domain.Model;
using FMS.WPF.Model;
using System.Linq;

namespace FMS.WPF.Application.QueryObjects
{
    public static class CompanyAddressModelSelect
    {
        public static IQueryable<CompanyAddressModel> MapCompanyAddressQueryToModelQuery(this IQueryable<CompanyAddress> companyAddresses)
        {
            return companyAddresses.Select(c => new CompanyAddressModel
            {
                CompanyAddressId = c.CompanyAddressId,
                CompanyId = c.CompanyId,
                CountryId = c.CountryId,
                CountryName = c.Country.CountryName,
                City = c.City,
                Address = c.Address,
                PostCode = c.PostCode,
                ConsigneeName = c.ConsigneeName,
                IsBilling = c.IsBilling,
                IsShipping = c.IsShipping,
                CreatedOn = c.CreatedOn
            });
        }

        public static CompanyAddress MapModelToCompanyAddress(this CompanyAddressModel model)
        {
            return new CompanyAddress
            {
                CompanyAddressId = model.CompanyAddressId,
                CompanyId = model.CompanyId,
                CountryId = model.CountryId,
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
