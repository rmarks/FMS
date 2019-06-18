using FMS.WPF.Model;
using System.Collections.Generic;

namespace FMS.WPF.Application.Common
{
    public interface ICompanyDropdownTables
    {
        IList<CountryModel> Countries { get; }
        IList<CurrencyModel> Currencies { get; }
        IList<DeliveryTermModel> DeliveryTerms { get; }
        IList<PaymentTermDropdownModel> PaymentTerms { get; }
    }

    public class CompanyDropdownTablesProxy
    {
        public static ICompanyDropdownTables Instance { get; set; }
    }
}
