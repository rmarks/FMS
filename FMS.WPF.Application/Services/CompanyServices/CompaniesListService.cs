using FMS.DAL.EFCore;
using FMS.WPF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FMS.WPF.Application.Services
{
    public class CompaniesListService : ICompaniesListService
    {
        public List<CompanyListModel> GetCompaniesList()
        {
            var context = new FMSDbContext();

            return context.CompanyAddresses
                .AsNoTracking()
                .Where(c => c.IsBilling)
                .Select(c => new CompanyListModel
                {
                    CompanyCode = c.Company.CompanyCode,
                    CompanyName = c.Company.CompanyName,
                    CountryName = c.Address.Country.CountryName,
                    City = c.Address.City,
                    Address1 = c.Address.Address1
                })
                .OrderBy(c => c.CompanyName)
                .ToList();
        }
    }
}
