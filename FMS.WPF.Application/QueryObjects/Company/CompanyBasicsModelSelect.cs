using FMS.Domain.Model;
using FMS.WPF.Models;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.QueryObjects
{
    public static class CompanyBasicsModelSelect
    {
        public static IQueryable<CompanyBasicsModel> MapToCompanyBasicsModel(this IQueryable<Company> companies)
        {
            return companies.Select(c => new CompanyBasicsModel
            {
                CompanyId = c.CompanyId,
                CompanyName = c.CompanyName,
                VATNo = c.VATNo,
                RegNo = c.RegNo,
                CurrencyCode = c.CurrencyCode,
                PriceListId = c.PriceListId,
                LocationId = c.LocationId,
                PaymentDays = c.PaymentDays,
                DeliveryTermName = c.DeliveryTermName,
                FixedDiscountPercent = c.FixedDiscountPercent,
                IsVAT = c.IsVAT,
                CreatedOn = c.CreatedOn,
                BillingAddress = c.Addresses.FirstOrDefault(a => a.IsBilling).MapToCompanyAddressModel()
            });
        }

        public static CompanyBasicsModel MapToCompanyBasicsModel(this Company company)
        {
            return new CompanyBasicsModel
            {
                CompanyId = company.CompanyId,
                CompanyName = company.CompanyName,
                VATNo = company.VATNo,
                RegNo = company.RegNo,
                CurrencyCode = company.CurrencyCode,
                PriceListId = company.PriceListId,
                LocationId = company.LocationId,
                PaymentDays = company.PaymentDays,
                DeliveryTermName = company.DeliveryTermName,
                FixedDiscountPercent = company.FixedDiscountPercent,
                IsVAT = company.IsVAT,
                CreatedOn = company.CreatedOn,
                BillingAddress = company.Addresses.FirstOrDefault(a => a.IsBilling).MapToCompanyAddressModel()
            };
        }

        public static Company MapToCompanyBasics(this CompanyBasicsModel model)
        {
            var company = new Company
            {
                CompanyId = model.CompanyId,
                CompanyName = model.CompanyName,
                VATNo = model.VATNo,
                RegNo = model.RegNo,
                CurrencyCode = model.CurrencyCode,
                PriceListId = model.PriceListId,
                LocationId = model.LocationId,
                PaymentDays = model.PaymentDays,
                DeliveryTermName = model.DeliveryTermName,
                FixedDiscountPercent = model.FixedDiscountPercent,
                IsVAT = model.IsVAT,
                CreatedOn = model.CreatedOn,
            };

            company.Addresses = new List<CompanyAddress>();
            company.Addresses.Add(model.BillingAddress.MapToCompanyAddress());

            return company;
        }
    }
}
