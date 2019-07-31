using FMS.WPF.Application.Interface.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        Task InitializeAsync();
    }

    public class CompanyDropdownsProxy
    {
        public static ICompanyDropdowns Instance { get; set; }
    }
}
