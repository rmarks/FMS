using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.WPF.Application.Extensions;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Application.QueryObjects;
using FMS.WPF.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.Services
{
    public class SalesOrderListService : ISalesOrderListService
    {
        private IDataContextFactory _contextFactory;

        public SalesOrderListService(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public SalesOrderListOptionsModel GetSalesOrderListOptionsModel()
        {
            return new SalesOrderListOptionsModel();
        }

        public IList<SalesOrderListModel> GetSalesOrderListModels(SalesOrderListOptionsModel options)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.SalesOrders
                    .AsNoTracking()
                    .FilterBy(options)
                    .OrderByDescending(s => s.OrderNo)
                    .ProjectBetween<SalesOrder, SalesOrderListModel>()
                    .ToList();
            }
        }
    }
}
