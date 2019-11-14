using FMS.Domain.Model;
using FMS.WPF.Models;
using Microsoft.Extensions.Options;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FMS.WPF.Application.QueryObjects
{
    public static class LocationInventoryWhere
    {
        public static IQueryable<Inventory> FilterBy(this IQueryable<Inventory> inventory, LocationInventoryListOptionModel options)
        {
            Expression<Func<Inventory, bool>> filter =
                i => (i.LocationId == options.LocationId) &&
                     (options.IsAll || (options.IsInStock && i.StockQuantity > 0) || (options.IsReserved && i.ReservedQuantity > 0));
                     //(options.IsAll ? true : (options.IsInStock ? i.StockQuantity > 0 : (options.IsReserved ? i.ReservedQuantity > 0 : false)));

            return inventory.Where(filter);
        }
    }
}
