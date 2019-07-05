using System.Collections.Generic;
using System.Linq;
using FMS.DAL.EFCore;
using FMS.WPF.Application.QueryObjects;
using FMS.WPF.Models;
using Microsoft.EntityFrameworkCore;

namespace FMS.WPF.Application.Common
{
    public class CompanyDropdownTables : ICompanyDropdownTables
    {
        #region Properties
        private IList<CountryModel> _countries;
        public IList<CountryModel> Countries => _countries ?? (_countries = GetCountries());

        private IList<CurrencyModel> _currencies;
        public IList<CurrencyModel> Currencies => _currencies ?? (_currencies = GetCurrencies());

        private IList<PriceListDropdownModel> _priceLists;
        public IList<PriceListDropdownModel> PriceLists => _priceLists ?? (_priceLists = GetPriceLists());

        private IList<LocationDropdownModel> _locations;
        public IList<LocationDropdownModel> Locations => _locations ?? (_locations = GetLocations());

        private IList<DeliveryTermModel> _deliveryTerms;
        public IList<DeliveryTermModel> DeliveryTerms => _deliveryTerms ?? (_deliveryTerms = GetDeliveryTerms());

        private IList<PaymentTermDropdownModel> _paymentTerms;
        public IList<PaymentTermDropdownModel> PaymentTerms => _paymentTerms ?? (_paymentTerms = GetPaymentTerms());
        #endregion Properties

        #region Helpers
        private IList<CountryModel> GetCountries()
        {
            var context = new SQLServerDbContext();

            return context.Countries
                .AsNoTracking()
                .MapToCountryModel()
                .OrderBy(c => c.CountryName)
                .ToList();
        }

        private IList<CurrencyModel> GetCurrencies()
        {
            var context = new SQLServerDbContext();

            return context.Currencies
                .AsNoTracking()
                .MapToCurrencyModel()
                .OrderBy(c => c.CurrencyCode)
                .ToList();
        }

        private IList<PriceListDropdownModel> GetPriceLists()
        {
            var context = new SQLServerDbContext();

            return context.PriceLists
                .AsNoTracking()
                .MapToPriceListDropdownModel()
                .OrderBy(p => p.PriceListName)
                .ToList();
        }

        private IList<LocationDropdownModel> GetLocations()
        {
            var context = new SQLServerDbContext();

            return context.Locations
                .AsNoTracking()
                .MapToLocationDropdownModel()
                .OrderBy(l => l.LocationName)
                .ToList();
        }

        private IList<DeliveryTermModel> GetDeliveryTerms()
        {
            var context = new SQLServerDbContext();

            return context.DeliveryTerms
                .AsNoTracking()
                .MapToDeliveryTermModel()
                .OrderBy(d => d.DeliveryTermName)
                .ToList();
        }

        private IList<PaymentTermDropdownModel> GetPaymentTerms()
        {
            var context = new SQLServerDbContext();

            return context.PaymentTerms
                .AsNoTracking()
                .MapToPaymentTermDropdownModel()
                .OrderBy(p => p.PaymentDays)
                .ToList();
        }
        #endregion Helpers
    }
}
