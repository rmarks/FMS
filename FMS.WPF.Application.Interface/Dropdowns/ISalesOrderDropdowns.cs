using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.Application.Interface.Dropdowns
{
    public interface ISalesOrderDropdowns
    {
        IList<CountryDropdownModel> Countries { get; set; }
        IList<DocumentStateModel> DocumentStates { get; set; }
        IList<CustomerModel> Customers { get; set; }
        IList<LocationDropdownModel> Locations { get; set; }
        IList<PriceListDropdownModel> PriceLists { get; set; }
        IList<DeliveryTermDropdownModel> DeliveryTerms { get; set; }
        IList<PaymentTermDropdownModel> PaymentTerms { get; set; }

        void InitializeAsync();
    }

    public class SalesOrderDropdownsProxy
    {
        public static ISalesOrderDropdowns Instance { get; set; }
    }
}