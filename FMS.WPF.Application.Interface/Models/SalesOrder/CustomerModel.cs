using System.Collections.Generic;

namespace FMS.WPF.Models
{
    public class CustomerModel
    {
        public int CompanyId { get; set; }

        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public int PriceListId { get; set; }
        public int LocationId { get; set; }
        public int PaymentDays { get; set; }
        public string DeliveryTermName { get; set; }
        public int FixedDiscountPercent { get; set; }
        public bool IsVAT { get; set; }

        public List<CustomerAddressModel> Addresses { get; set; }
    }
}
