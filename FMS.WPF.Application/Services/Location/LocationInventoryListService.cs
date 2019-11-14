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
    public class LocationInventoryListService : ILocationInventoryListService
    {
        private IDataContextFactory _contextFactory;

        public LocationInventoryListService(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IList<LocationInventoryListModel> GetLocationInventoryListModels(LocationInventoryListOptionModel options)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Inventory
                    .AsNoTracking()
                    .FilterBy(options)
                    .OrderBy(i => i.Product.ProductCode)
                    .ProjectBetween<Inventory, LocationInventoryListModel>()
                    .ToList();
            }
        }

        public LocationInventoryListOptionModel GetLocationInventoryListOptionModel(int locationId)
        {
            var model = new LocationInventoryListOptionModel();
            model.SetDefaultOptions = () =>
            {
                model.LocationId = locationId;
                model.IsInStock = true;
            };

            return model;
        }

        public IList<StockMovementModel> GetStockMovementModels(int productId, int locationId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.DeliveryLines
                    .AsNoTracking()
                    .Where(d => d.ProductId == productId && 
                        (d.DeliveryHeader.FromLocationId == locationId || d.DeliveryHeader.ToLocationId == locationId))
                    //.ProjectBetween<DeliveryLine, StockMovementModel>()
                    .Select(d => new StockMovementModel
                    {
                        DeliveryHeaderDocNo = d.DeliveryHeader.DocNo,
                        DeliveryHeaderDocDate = d.DeliveryHeader.DocDate,
                        DeliveryTypeName = d.DeliveryHeader.DeliveryType.DeliveryTypeName,
                        DeliveredQuantity = (d.DeliveryHeader.FromLocationId == locationId ? -d.DeliveredQuantity : d.DeliveredQuantity)
                    })
                    .OrderByDescending(d => d.DeliveryHeaderDocDate)
                    .ToList();
            }
        }
    }
}
