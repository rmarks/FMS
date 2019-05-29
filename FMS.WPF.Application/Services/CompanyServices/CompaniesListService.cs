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

            return context.Companies
                .AsNoTracking()
                .Select(c => new CompanyListModel
                {
                    CompanyId = c.CompanyId,
                    CompanyName = c.CompanyName
                })
                .ToList();
        }
    }
}
