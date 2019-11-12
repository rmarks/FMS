using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.WPF.Application.Extensions;
using FMS.WPF.Application.Interface.Dropdowns;
using FMS.WPF.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.WPF.Application.Dropdowns
{
    public class DeliveryNoteDropdowns : IDeliveryNoteDropdowns
    {
        private IDataContextFactory _contextFactory;

        public DeliveryNoteDropdowns(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;

            InitializeAsync();
        }

        public async void InitializeAsync()
        {
            using (var context = _contextFactory.CreateContext())
            {
                LocationTypes = await GetLocationTypesAsync(context);
                Locations = await GetLocationsAsync(context);
                DocumentStates = GetDocumentStates();
            }
        }

        #region properties
        public IList<LocationTypeDropdownModel> LocationTypes { get; set; }
        public IList<LocationDropdownModel> Locations { get; set; }
        public IList<DocumentStateModel> DocumentStates { get; set; }
        #endregion

        #region helpers
        private async Task<IList<LocationTypeDropdownModel>> GetLocationTypesAsync(IDataContext context)
        {
            var list = await context.LocationTypes
                .AsNoTracking()
                .OrderBy(l => l.LocationTypeName)
                .ProjectBetween<LocationType, LocationTypeDropdownModel>()
                .ToListAsync();

            list.Insert(0, new LocationTypeDropdownModel());

            return list;
        }

        private async Task<IList<LocationDropdownModel>> GetLocationsAsync(IDataContext context)
        {
            var list = await context.Locations
                .AsNoTracking()
                .OrderBy(l => l.LocationName)
                .ProjectBetween<Location, LocationDropdownModel>()
                .ToListAsync();

            list.Insert(0, new LocationDropdownModel());

            return list;
        }

        private IList<DocumentStateModel> GetDocumentStates()
        {
            return new List<DocumentStateModel>
            {
                new DocumentStateModel { IsClosed = null, StateName = "" },
                new DocumentStateModel { IsClosed = false, StateName = "Avatud" },
                new DocumentStateModel { IsClosed = true, StateName = "Suletud" }
            };
        }
        #endregion
    }
}
