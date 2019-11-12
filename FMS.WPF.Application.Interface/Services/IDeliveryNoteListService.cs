using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.Application.Interface.Services
{
    public interface IDeliveryNoteListService
    {
        DeliveryNoteListOptionsModel GetDeliveryNoteListOptionsModel();
        IList<DeliveryNoteListModel> GetDeliveryNoteListModels(DeliveryNoteListOptionsModel options);
    }
}