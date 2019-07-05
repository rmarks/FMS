using FMS.DAL.EFCore;
using FMS.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.CompanyServices
{
    public class ListCompanySalesOrdersService
    {
        private IDataContext _context;

        public ListCompanySalesOrdersService(IDataContext context)
        {
            _context = context;
        }

        public IQueryable<SalesOrder> GetCompanySalesOrders(int companyId)
        {
            return _context.SalesOrders
                .AsNoTracking()
                .Where(o => o.CompanyId == companyId)
                .OrderByDescending(o => o.OrderNo);
        }
    }
}
