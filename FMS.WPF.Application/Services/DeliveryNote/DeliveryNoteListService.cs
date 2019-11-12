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
    public class DeliveryNoteListService : IDeliveryNoteListService
    {
        private IDataContextFactory _contextFactory;

        public DeliveryNoteListService(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public DeliveryNoteListOptionsModel GetDeliveryNoteListOptionsModel()
        {
            return new DeliveryNoteListOptionsModel();
        }

        public IList<DeliveryNoteListModel> GetDeliveryNoteListModels(DeliveryNoteListOptionsModel options)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.DeliveryHeaders
                    .AsNoTracking()
                    .FilterBy(options)
                    .OrderByDescending(d => d.DocDate)
                    .ProjectBetween<DeliveryHeader, DeliveryNoteListModel>()
                    .ToList();
            }
        }
    }
}
