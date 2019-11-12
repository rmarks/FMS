using FMS.Domain.Model;
using FMS.WPF.Models;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FMS.WPF.Application.QueryObjects
{
    public static class DeliveryNoteWhere
    {
        public static IQueryable<DeliveryHeader> FilterBy(this IQueryable<DeliveryHeader> deliveryHeaders, DeliveryNoteListOptionsModel options)
        {
            Expression<Func<DeliveryHeader, bool>> filter =
                dh => (String.IsNullOrWhiteSpace(options.DocNo) || dh.DocNo.ToLower().StartsWith(options.DocNo.ToLower())) &&
                      (options.DeliveryTypeId == null || dh.DeliveryTypeId == options.DeliveryTypeId) &&
                      (options.FromLocationTypeId == null || dh.FromLocation.LocationTypeId == options.FromLocationTypeId) &&
                      (options.FromLocationId == null || dh.FromLocationId == options.FromLocationId) &&
                      (options.ToLocationTypeId == null || dh.ToLocation.LocationTypeId == options.ToLocationTypeId) &&
                      (options.ToLocationId == null || dh.ToLocationId == options.ToLocationId) &&
                      (options.IsClosed == null || dh.IsClosed == options.IsClosed);

            return deliveryHeaders.Where(filter);
        }
    }
}
