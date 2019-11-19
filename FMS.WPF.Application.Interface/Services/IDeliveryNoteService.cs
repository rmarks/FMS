using FMS.WPF.Models;

namespace FMS.WPF.Application.Interface.Services
{
    public interface IDeliveryNoteService
    {
        DeliveryNoteModel GetDeliveryNoteModel(int deliveryHeaderId);
    }
}