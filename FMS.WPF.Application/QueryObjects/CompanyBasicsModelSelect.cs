using FMS.Domain.Model;
using FMS.WPF.Model;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.QueryObjects
{
    public static class CompanyBasicsModelSelect
    {
        public static IQueryable<CompanyBasicsModel> MapCompanyBasicsQueryToModelQuery(this IQueryable<Company> companies)
        {
            return companies.Select(c => new CompanyBasicsModel
            {
                CompanyId = c.CompanyId,
                CompanyCode = c.CompanyCode,
                CompanyName = c.CompanyName,
                VATNo = c.VATNo,
                RegNo = c.RegNo,
                CurrencyCode = c.CurrencyCode,
                IsVAT = c.IsVAT,
                FixedDiscountPercent = c.FixedDiscountPercent,
                CreatedOn = c.CreatedOn,
            });
        }

        public static Company MapModelToCompanyBasics(this CompanyBasicsModel model)
        {
            var company = new Company
            {
                CompanyId = model.CompanyId,
                CompanyCode = model.CompanyCode,
                CompanyName = model.CompanyName,
                VATNo = model.VATNo,
                RegNo = model.RegNo,
                CurrencyCode = model.CurrencyCode,
                IsVAT = model.IsVAT,
                FixedDiscountPercent = model.FixedDiscountPercent,
                CreatedOn = model.CreatedOn,
            };

            company.Addresses = new List<CompanyAddress>();
            company.Addresses.Add(model.BillingAddress.MapModelToCompanyAddress());

            return company;
        }
    }
}
