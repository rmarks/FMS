using FMS.Domain.Model;
using FMS.WPF.Models;
using System.Linq;

namespace FMS.WPF.Application.QueryObjects
{
    public static class LocationSelect
    {
        public static IQueryable<LocationDropdownModel> MapToLocationDropdownModel(this IQueryable<Location> locations)
        {
            return locations.Select(l => new LocationDropdownModel
            {
                LocationId = l.LocationId,
                LocationName = l.LocationName
            });
        }
    }
}
