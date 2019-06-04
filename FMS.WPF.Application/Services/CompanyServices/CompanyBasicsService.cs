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

            return context.Companies
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId)
                .MapToCompanyBasicsModel();
        }
    }
}
