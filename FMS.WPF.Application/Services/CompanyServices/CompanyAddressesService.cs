using FMS.DAL.EFCore;
using FMS.WPF.Application.QueryObjects;
using FMS.WPF.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.Services
{
    public class CompanyAddressesService : ICompanyAddressesService
    {
        public IList<CompanyAddressModel> GetCompanyAddressModels(int companyId)
        {
            var context = new FMSDbContext();

            return context.CompanyAddresses
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId && c.IsShipping)
                .MapToCompanyAddressModel()
                .ToList();
        }
    }
}
