using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.Application.Interface.Services
{
    public interface ILocationInventoryListService
    {
        LocationInventoryListOptionModel GetLocationInventoryListOptionModel(int locationId);
        IList<LocationInventoryListModel> GetLocationInventoryListModels(LocationInventoryListOptionModel options);
        ProductDeliveriesModel GetProductDeliveriesModel(int productId, int locationId);
    }
}