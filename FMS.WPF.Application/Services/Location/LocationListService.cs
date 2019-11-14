using FMS.DAL.Interfaces;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.Services
{
    public class LocationListService : ILocationListService
    {
        private IDataContextFactory _contextFactory;

        public LocationListService(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IList<LocationListModel> GetLocationListModels(int locationTypeId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Locations
                    .AsNoTracking()
                    .Where(l => l.LocationTypeId == locationTypeId)
                    .OrderBy(l => l.LocationName)
                    .Select(l => new LocationListModel
                    {
                        LocationId = l.LocationId,
                        LocationName = l.LocationName,
                        TotalReservedQuantity = l.Inventory.Sum(i => i.ReservedQuantity),
                        TotalStockQuantity = l.Inventory.Sum(i => i.StockQuantity)
                    })
                    .ToList();
            }
        }
    }
}
