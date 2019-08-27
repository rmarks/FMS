using FMS.ServiceLayer.Interface.Dtos;
using FMS.ServiceLayer.Interface.Services;
using FMS.WPF.Application.Interface.Dropdowns;
using FMS.WPF.Models;
using FMS.WPF.Application.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMS.WPF.Application.Dropdowns
{
    public class CompanyDropdowns : ICompanyDropdowns
    {
        private readonly ICompanyDropdownsService _dropdownsService;

        public CompanyDropdowns(ICompanyDropdownsService dropdownsService)
        {
            _dropdownsService = dropdownsService;
        }

        public async Task InitializeAsync()
        {
            var dto = await _dropdownsService.GetCompanyDropdownsAsync();

            MappingFactory.MapTo<CompanyDropdownsDto, CompanyDropdowns>(dto, this);
        }

        #region properties
        public IList<CountryDropdownModel> Countries { get; set; }
        public IList<CurrencyDropdownModel> Currencies { get; set; }
        public IList<PriceListDropdownModel> PriceLists { get; set; }
        public IList<LocationDropdownModel> Locations { get; set; }
        public IList<DeliveryTermDropdownModel> DeliveryTerms { get; set; }
        public IList<PaymentTermDropdownModel> PaymentTerms { get; set; }
        #endregion

        
    }
}
