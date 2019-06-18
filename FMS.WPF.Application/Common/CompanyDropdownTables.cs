using System.Collections.Generic;
using System.Linq;
using FMS.DAL.EFCore;
using FMS.WPF.Application.QueryObjects;
using FMS.WPF.Model;
using Microsoft.EntityFrameworkCore;

namespace FMS.WPF.Application.Common
{
    public class CompanyDropdownTables : ICompanyDropdownTables
    {
        private IList<CountryModel> _countries;
        public IList<CountryModel> Countries => _countries ?? (_countries = GetCountries());

        private IList<CurrencyModel> _currencies;
        public IList<CurrencyModel> Currencies => _currencies ?? (_currencies = GetCurrencies());

        private IList<DeliveryTermModel> _deliveryTerms;
        public IList<DeliveryTermModel> DeliveryTerms => _deliveryTerms ?? (_deliveryTerms = GetDeliveryTerms());

        private IList<PaymentTermDropdownModel> _paymentTerms;
        public IList<PaymentTermDropdownModel> PaymentTerms => _paymentTerms ?? (_paymentTerms = GetPaymentTerms());

        #region Helpers
        private IList<CountryModel> GetCountries()
        {
            var context = new FMSDbContext();

            return context.Countries
                .AsNoTracking()
                .MapToCountryModel()
                .ToList();
        }

        private IList<CurrencyModel> GetCurrencies()
        {
            var context = new FMSDbContext();

            return context.Currencies
                .AsNoTracking()
                .MapToCurrencyModel()
                .ToList();
        }

        private IList<DeliveryTermModel> GetDeliveryTerms()
        {
            var context = new FMSDbContext();

            return context.DeliveryTerms
                .AsNoTracking()
                .MapToDeliveryTermModel()
                .ToList();
        }

        private IList<PaymentTermDropdownModel> GetPaymentTerms()
        {
            var context = new FMSDbContext();

            return context.PaymentTerms
                .AsNoTracking()
                .MapToPaymentTermDropdownModel()
                .ToList();
        }
        #endregion Helpers
    }
}
