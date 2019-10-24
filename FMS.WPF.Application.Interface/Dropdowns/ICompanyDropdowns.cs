using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.Application.Interface.Dropdowns
{
    public interface ICompanyDropdowns
    {
        IList<CountryDropdownModel> Countries { get; set; }
        IList<CurrencyDropdownModel> Currencies { get; set; }
        IList<PriceListDropdownModel> PriceLists { get; set; }
        IList<LocationDropdownModel> Locations { get; set; }
        IList<DeliveryTermDropdownModel> DeliveryTerms { get; set; }
        IList<PaymentTermDropdownModel> PaymentTerms { get; set; }
        IList<CompanyTypeModel> CompanyTypes { get; set; }

        void InitializeAsync();
    }

    public class CompanyDropdownsProxy
    {
        public static ICompanyDropdowns Instance { get; set; }
    }
}
