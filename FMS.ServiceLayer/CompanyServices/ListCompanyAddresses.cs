using FMS.DAL.EFCore;
using FMS.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.CompanyServices
{
    public class ListCompanyAddresses
    {
        private IDataContext _context;

        public ListCompanyAddresses(IDataContext context)
        {
            _context = context;
        }

        public IQueryable<CompanyAddress> GetCompanyShippingAddresses(int companyId)
        {
            return _context.CompanyAddresses
                .AsNoTracking()
                .Where(a => a.CompanyId == companyId && a.IsShipping)
                .OrderBy(c => c.ConsigneeName);
        }
    }
}
