using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.Application.Interface.Services
{
    public interface ILocationInventoryListService
    {
        LocationInventoryListOptionModel GetLocationInventoryListOptionModel(int locationId);
        IList<LocationInventoryListModel> GetLocationInventoryListModels(LocationInventoryListOptionModel options);
        IList<StockMovementModel> GetStockMovementModels(int productId, int locationId);
    }
}