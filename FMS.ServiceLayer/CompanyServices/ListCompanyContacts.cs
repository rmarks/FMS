using FMS.DAL.EFCore;
using FMS.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.CompanyServices
{
    public class ListCompanyContacts
    {
        private IDataContext _context;

        public ListCompanyContacts(IDataContext context)
        {
            _context = context;
        }

        public IQueryable<Contact> GetCompanyContacts(int companyId)
        {
            return _context.Contacts
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId)
                .OrderBy(c => c.ContactName);
        }
    }
}
