using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.Services
{
    public class FindCompanyBasicsService
    {
        private IDataContext _context;

        public FindCompanyBasicsService(IDataContext context)
        {
            _context = context;
        }

        public IQueryable<Company> GetCompanyBasics(int companyId)
        {
            return _context.Companies
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId);
        }
    }
}
