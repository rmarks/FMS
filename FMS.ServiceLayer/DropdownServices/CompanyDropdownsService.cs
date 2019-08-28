using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.ServiceLayer.Interface.Dtos;
using FMS.ServiceLayer.Extensions;
using FMS.ServiceLayer.Interface.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.Services
{
    public class CompanyDropdownsService : ICompanyDropdownsService
    {
        private IDataContextFactory _contextFactory;

        public CompanyDropdownsService(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<CompanyDropdownsDto> GetCompanyDropdownsAsync()
        {
            using (var context = _contextFactory.CreateContext())
            {
                var dto = new CompanyDropdownsDto();

                dto.Countries = await GetCountriesAsync(context);
                dto.Currencies = await GetCurrenciesAsync(context);
                dto.PriceLists = await GetPriceListsAsync(context);
                dto.Locations = await GetLocationsAsync(context);
                dto.DeliveryTerms = await GetDeliveryTermsAsync(context);
                dto.PaymentTerms = await GetPaymentTermsAsync(context);

                return dto;
            }
        }

        #region Helpers
        private async Task<IList<CountryDropdownDto>> GetCountriesAsync(IDataContext context)
        {
            return await context.Countries
                .AsNoTracking()
                .OrderBy(c => c.Name)
                .ProjectBetween<Country, CountryDropdownDto>()
                .ToListAsync();
        }

        private async Task<IList<CurrencyDropdownDto>> GetCurrenciesAsync(IDataContext context)
        {
            return await context.Currencies
                .AsNoTracking()
                .OrderBy(c => c.CurrencyCode)
                .ProjectBetween<Currency, CurrencyDropdownDto>()
                .ToListAsync();
        }

        private async Task<IList<PriceListDropdownDto>> GetPriceListsAsync(IDataContext context)
        {
            return await context.PriceLists
                .AsNoTracking()
                .OrderBy(p => p.PriceListName)
                .ProjectBetween<PriceList, PriceListDropdownDto>()
                .ToListAsync();
        }

        private async Task<IList<LocationDropdownDto>> GetLocationsAsync(IDataContext context)
        {
            return await context.Locations
                .AsNoTracking()
                .OrderBy(l => l.LocationName)
                .ProjectBetween<Location, LocationDropdownDto>()
                .ToListAsync();
        }

        private async Task<IList<DeliveryTermDropdownDto>> GetDeliveryTermsAsync(IDataContext context)
        {
            return await context.DeliveryTerms
                .AsNoTracking()
                .OrderBy(d => d.DeliveryTermName)
                .ProjectBetween<DeliveryTerm, DeliveryTermDropdownDto>()
                .ToListAsync();
        }

        private async Task<IList<PaymentTermDropdownDto>> GetPaymentTermsAsync(IDataContext context)
        {
            return await context.PaymentTerms
                .AsNoTracking()
                .OrderBy(p => p.PaymentDays)
                .ProjectBetween<PaymentTerm, PaymentTermDropdownDto>()
                .ToListAsync();
        }
        #endregion Helpers
    }
}
