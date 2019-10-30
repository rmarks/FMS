using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.WPF.Application.Extensions;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.WPF.Application.Services
{
    public class SalesOrderService : ISalesOrderService
    {
        private IDataContextFactory _contextFactory;

        public SalesOrderService(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public SalesOrderModel GetSalesOrderModel(int salesOrderId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.SalesOrders
                    .AsNoTracking()
                    .Where(s => s.SalesOrderId == salesOrderId)
                    .ProjectBetween<SalesOrder, SalesOrderModel>()
                    .FirstOrDefault();
            }
        }
    }
}
