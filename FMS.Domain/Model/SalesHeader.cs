using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Model
{
    public class SalesHeader
    {
        public int SalesHeaderId { get; set; }

        [Required, MaxLength(10)]
        public string DocNo { get; set; }
        public DateTime DocDate { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int? BillingAddressId { get; set; }
        [ForeignKey(nameof(BillingAddressId))]
        public CompanyAddress BillingAddress { get; set; }

        public int? ShippingAddressId { get; set; }
        [ForeignKey(nameof(ShippingAddressId))]
        public CompanyAddress ShippingAddress { get; set; }

        public int? PriceListId { get; set; }
        [MaxLength(50)]
        public string DeliveryTermName { get; set; }
        public int PaymentDays { get; set; }
        public int FixedDiscountPercent { get; set; }
        public int VATPercent { get; set; }

        public bool IsClosed { get; set; }

        public DateTime? CreatedOn { get; set; }

        public IList<SalesLine> SalesInvoiceLines { get; set; }

        //--- legacy system fields ---
        [MaxLength(2)]
        public string FMS_doktyyp { get; set; }
        [MaxLength(8)]
        public string FMS_doknr { get; set; }
    }
}
