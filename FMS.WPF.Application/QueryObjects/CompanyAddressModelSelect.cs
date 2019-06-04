using FMS.Domain.Model;
using FMS.WPF.Model;
using System.Linq;

namespace FMS.WPF.Application.QueryObjects
{
    public static class CompanyAddressModelSelect
    {
        public static IQueryable<CompanyAddressModel> MapToCompanyAddressModel(this IQueryable<CompanyAddress> companyAddresses)
        {
            return companyAddresses.Select(c => new CompanyAddressModel
            {
                CompanyAddressId = c.CompanyAddressId,
                CompanyId = c.CompanyId,
                Description = c.Description,
                CountryId = c.CountryId,
                CountryName = c.Country.CountryName,
                City = c.City,
                Address = c.Address,
                PostCode = c.PostCode
            });
        }
    }
}
