using FMS.DAL.EFCore;
using FMS.Domain.Model;
using FMS.WPF.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.QueryObjects
{
    public static class CompanyBasicsModelSelect
    {
        public static CompanyBasicsModel MapCompanyBasicsQueryToModel(this IQueryable<Company> companies)
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
                CreatedOn = c.CreatedOn,
            })
            .FirstOrDefault();

            if (model != null)
            {
                var context = new FMSDbContext();

                model.BillingAddress = context.CompanyAddresses
                    .AsNoTracking()
                    .Where(c => c.CompanyId == model.CompanyId && c.IsBilling)
                    .MapCompanyAddressQueryToModelQuery()
                    .FirstOrDefault();

                model.Countries = context.Countries
                    .AsNoTracking()
                    .MapToCountryModel()
                    .ToList();

                model.Currencies = context.Currencies
                    .AsNoTracking()
                    .MapToCurrencyModel()
                    .ToList();
            }
            
            return model;
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
