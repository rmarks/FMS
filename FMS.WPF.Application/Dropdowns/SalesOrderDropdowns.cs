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
    public class SalesOrderDropdowns : ISalesOrderDropdowns
    {
        private IDataContextFactory _contextFactory;

        public SalesOrderDropdowns(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;

            InitializeAsync();
        }

        public async void InitializeAsync()
        {
            using (var context = _contextFactory.CreateContext())
            {
                Countries = await GetCountriesAsync(context);
                DocumentStates = GetDocumentStates();
            }
        }

        #region properties
        public IList<CountryDropdownModel> Countries { get; set; }
        public IList<DocumentStateModel> DocumentStates { get; set; }
        #endregion

        #region Helpers
        private async Task<IList<CountryDropdownModel>> GetCountriesAsync(IDataContext context)
        {
            return await context.Countries
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ProjectBetween<Country, CountryDropdownModel>()
                .ToListAsync();
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
