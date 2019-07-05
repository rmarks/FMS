using FMS.DAL.EFCore;
using FMS.Domain.Model;
using FMS.ServiceLayer.CompanyServices.QueryObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.CompanyServices
{
    public class ListCompaniesService
    {
        private readonly IDataContext _context;

        public ListCompaniesService(IDataContext context)
        {
            _context = context;
        }

        public IQueryable<Company> GetCompanies(string query)
        {
            return _context.Companies
                .AsNoTracking()
                .FilterBy(query)
                .OrderBy(c => c.CompanyName);
        }
    }
}
