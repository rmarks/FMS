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
        #endregion Helpers
    }
}
