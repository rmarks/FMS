using FMS.Domain.Model;
using FMS.WPF.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FMS.WPF.Application.QueryObjects
{
    public static class SalesOrderWhere
    {
        public static IQueryable<SalesOrder> FilterBy(this IQueryable<SalesOrder> salesOrders, SalesOrderListOptionsModel options)
        {
            Expression<Func<SalesOrder, bool>> filter =
                so => (String.IsNullOrWhiteSpace(options.OrderNo) || so.OrderNo.ToLower().StartsWith(options.OrderNo.ToLower())) &&
                      (String.IsNullOrWhiteSpace(options.CompanyName) || so.Company.Name.ToLower().Contains(options.CompanyName.ToLower())) &&
                      (String.IsNullOrWhiteSpace(options.ShippingAddressDescription) || so.ShippingAddress.Description.ToLower().Contains(options.ShippingAddressDescription.ToLower())) &&
                      (options.CompanyCountryId == null || so.Company.Addresses.Any(a => a.CountryId == options.CompanyCountryId && a.IsBilling)) &&
                      (options.IsClosed == null || so.IsClosed == options.IsClosed);

            return salesOrders.Where(filter);
        }
    }
}
