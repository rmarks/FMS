using System;

namespace FMS.ServiceLayer.Interface.Dtos
{
    public class CompanyDto
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public string VATNo { get; set; }

        public string RegNo { get; set; }

        public string CurrencyCode { get; set; }

        public int? PriceListId { get; set; }

        public int? LocationId { get; set; }

        public int PaymentDays { get; set; }

        public string DeliveryTermName { get; set; }

        public int FixedDiscountPercent { get; set; }

        public bool IsVAT { get; set; }

        public DateTime? CreatedOn { get; set; }

        public CompanyAddressDto BillingAddress { get; set; }
    }
}
