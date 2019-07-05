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

        public IQueryable<CompanyAddress> GetCompaniesWithBillingAddress(string query)
        {
            return _context.CompanyAddresses
                .AsNoTracking()
                .FilterBy(query)
                .OrderBy(a => a.Company.CompanyName);
        }
    }
}
