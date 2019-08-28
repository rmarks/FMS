using FMS.WPF.Application.Interface.Dropdowns;
using FMS.WPF.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FMS.WPF.Application.Extensions;

namespace FMS.WPF.Application.Dropdowns
{
    public class CompanyDropdowns : ICompanyDropdowns
    {
        private IDataContextFactory _contextFactory;

        public CompanyDropdowns(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;

            InitializeAsync();
        }

        public async void InitializeAsync()
        {
            using (var context = _contextFactory.CreateContext())
            {
                Countries = await GetCountriesAsync(context);
                Currencies = await GetCurrenciesAsync(context);
                PriceLists = await GetPriceListsAsync(context);
                Locations = await GetLocationsAsync(context);
                DeliveryTerms = await GetDeliveryTermsAsync(context);
                PaymentTerms = await GetPaymentTermsAsync(context);
            }
        }

        #region properties
        public IList<CountryDropdownModel> Countries { get; set; }
        public IList<CurrencyDropdownModel> Currencies { get; set; }
        public IList<PriceListDropdownModel> PriceLists { get; set; }
        public IList<LocationDropdownModel> Locations { get; set; }
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

        private async Task<IList<CurrencyDropdownModel>> GetCurrenciesAsync(IDataContext context)
        {
            return await context.Currencies
                .AsNoTracking()
                .OrderBy(c => c.CurrencyCode)
                .ProjectBetween<Currency, CurrencyDropdownModel>()
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

        private async Task<IList<LocationDropdownModel>> GetLocationsAsync(IDataContext context)
        {
            return await context.Locations
                .AsNoTracking()
                .OrderBy(l => l.LocationName)
                .ProjectBetween<Location, LocationDropdownModel>()
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
