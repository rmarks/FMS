using FMS.DAL.EFCore;
using FMS.WPF.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.Services
{
    public class CompaniesListService : ICompaniesListService
    {
        public List<CompanyListModel> GetCompaniesList()
        {
            var context = new FMSDbContext();

            return context.Companies
                .AsNoTracking()
                .Select(c => new
                {
                    Company = c,
                    Address = c.Addresses.FirstOrDefault(a => a.IsBilling)
                })
                .Select(c => new CompanyListModel
                {
                    CompanyId = c.Company.CompanyId,
                    CompanyCode = c.Company.CompanyCode,
                    CompanyName = c.Company.CompanyName,
                    CountryName = c.Address.Country.CountryName,
                    City = c.Address.City,
                    Address = c.Address.Address
                })
                .OrderBy(c => c.CompanyName)
                .ToList();
        }
    }
}
