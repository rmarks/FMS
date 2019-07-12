using System.Collections.Generic;

namespace FMS.ServiceLayer.Dtos
{
    public class CompanyDropdownsDto
    {
        public IList<CountryDropdownDto> Countries { get; set; }

        public IList<CurrencyDropdownDto> Currencies { get; set; }

        public IList<PriceListDropdownDto> PriceLists { get; set; }

        public IList<LocationDropdownDto> Locations { get; set; }

        public IList<DeliveryTermDropdownDto> DeliveryTerms { get; set; }

        public IList<PaymentTermDropdownDto> PaymentTerms { get; set; }
    }
}
