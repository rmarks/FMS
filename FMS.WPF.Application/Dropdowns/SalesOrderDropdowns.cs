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
                Customers = await GetCustomersAsync(context);
                Locations = await GetLocationsAsync(context);
                PriceLists = await GetPriceListsAsync(context);
                DeliveryTerms = await GetDeliveryTermsAsync(context);
                PaymentTerms = await GetPaymentTermsAsync(context);
            }
        }

        #region properties
        public IList<CountryDropdownModel> Countries { get; set; }
        public IList<DocumentStateModel> DocumentStates { get; set; }
        public IList<CustomerModel> Customers { get; set; }
        public IList<LocationDropdownModel> Locations { get; set; }
        public IList<PriceListDropdownModel> PriceLists { get; set; }
        public IList<DeliveryTermDropdownModel> DeliveryTerms { get; set; }
        public IList<PaymentTermDropdownModel> PaymentTerms { get; set; }
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

        private async Task<IList<CustomerModel>> GetCustomersAsync(IDataContext context)
        {
            return await context.Companies
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ProjectBetween<Company, CustomerModel>()
                .ToListAsync();
        }

        private async Task<IList<LocationDropdownModel>> GetLocationsAsync(IDataContext context)
        {
            return await context.Locations
                .AsNoTracking()
                .OrderBy(l => l.LocationName)
                .ProjectBetween<Location, LocationDropdownModel>()
                .ToListAsync();
        }

        private async Task<IList<PriceListDropdownModel>> GetPriceListsAsync(IDataContext context)
        {
            return await context.PriceLists
                .AsNoTracking()
                .OrderBy(p => p.PriceListName)
                .ProjectBetween<PriceList, PriceListDropdownModel>()
                .ToListAsync();
        }

        private async Task<IList<DeliveryTermDropdownModel>> GetDeliveryTermsAsync(IDataContext context)
        {
            return await context.DeliveryTerms
                .AsNoTracking()
                .OrderBy(d => d.DeliveryTermName)
                .ProjectBetween<DeliveryTerm, DeliveryTermDropdownModel>()
                .ToListAsync();
        }

        private async Task<IList<PaymentTermDropdownModel>> GetPaymentTermsAsync(IDataContext context)
        {
            return await context.PaymentTerms
                .AsNoTracking()
                .OrderBy(p => p.PaymentDays)
                .ProjectBetween<PaymentTerm, PaymentTermDropdownModel>()
                .ToListAsync();
        }
        #endregion
    }
}
