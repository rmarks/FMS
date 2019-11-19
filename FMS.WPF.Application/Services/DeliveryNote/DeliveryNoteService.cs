using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.WPF.Application.Extensions;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.WPF.Application.Services
{
    public class DeliveryNoteService : IDeliveryNoteService
    {
        private IDataContextFactory _contextFactory;

        public DeliveryNoteService(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public DeliveryNoteModel GetDeliveryNoteModel(int deliveryHeaderId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.DeliveryHeaders
                    .AsNoTracking()
                    .Where(d => d.DeliveryHeaderId == deliveryHeaderId)
                    .ProjectBetween<DeliveryHeader, DeliveryNoteModel>()
                    .FirstOrDefault();
            }
        }
    }
}
