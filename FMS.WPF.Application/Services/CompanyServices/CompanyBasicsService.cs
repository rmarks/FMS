using FMS.DAL.EFCore;
using FMS.WPF.Application.QueryObjects;
using FMS.WPF.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.WPF.Application.Services
{
    public class CompanyBasicsService : ICompanyBasicsService
    {
        public CompanyBasicsModel GetCompanyBasicsModel(int companyId)
        {
            var context = new FMSDbContext();

            var model = context.Companies
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId)
                .Select(c => new CompanyBasicsModel
                {
                    CompanyId = c.CompanyId,
                    CompanyCode = c.CompanyCode,
                    CompanyName = c.CompanyName,
                    VATNo = c.VATNo,
                    RegNo = c.RegNo,
                    CreatedOn = c.CreatedOn
                })
                .FirstOrDefault();

            model.BillingAddress = context.CompanyAddresses
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId && c.IsBilling)
                .MapToCompanyAddressModel()
                .FirstOrDefault();

            model.Countries = context.Countries
                .AsNoTracking()
                .MapToCountryModel()
                .ToList();

            return model;
        }
    }
}
