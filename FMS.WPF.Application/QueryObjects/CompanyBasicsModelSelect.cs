using FMS.DAL.EFCore;
using FMS.Domain.Model;
using FMS.WPF.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.WPF.Application.QueryObjects
{
    public static class CompanyBasicsModelSelect
    {
        public static CompanyBasicsModel MapToCompanyBasicsModel(this IQueryable<Company> companies)
        {
            var model = companies.Select(c => new CompanyBasicsModel
            {
                CompanyId = c.CompanyId,
                CompanyCode = c.CompanyCode,
                CompanyName = c.CompanyName,
                VATNo = c.VATNo,
                RegNo = c.RegNo,
                CurrencyCode = c.CurrencyCode,
                IsVAT = c.IsVAT,
                FixedDiscountPercent = c.FixedDiscountPercent,
                CreatedOn = c.CreatedOn
            })
            .FirstOrDefault();

            var context = new FMSDbContext();

            model.BillingAddress = context.CompanyAddresses
                .AsNoTracking()
                .Where(c => c.CompanyId == model.CompanyId && c.IsBilling)
                .MapToCompanyAddressModel()
                .FirstOrDefault();

            model.Countries = context.Countries
                .AsNoTracking()
                .MapToCountryModel()
                .ToList();

            model.Currencies = context.Currencies
                .AsNoTracking()
                .MapToCurrencyModel()
                .ToList();

            return model;
        }
    }
}
