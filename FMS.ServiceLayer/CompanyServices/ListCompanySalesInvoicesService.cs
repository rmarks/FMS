using FMS.DAL.EFCore;
using FMS.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.CompanyServices
{
    public class ListCompanySalesInvoicesService
    {
        private IDataContext _context;

        public ListCompanySalesInvoicesService(IDataContext context)
        {
            _context = context;
        }

        public IQueryable<SalesInvoice> GetCompanySalesInvoices(int companyId)
        {
            return _context.SalesInvoices
                .AsNoTracking()
                .Where(o => o.CompanyId == companyId)
                .OrderByDescending(o => o.InvoiceNo);
        }
    }
}
