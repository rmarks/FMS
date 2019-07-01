using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Model
{
    public class SalesInvoice
    {
        public int SalesInvoiceId { get; set; }

        [Required, MaxLength(10)]
        public string InvoiceNo { get; set; }
        public DateTime InvoiceDate { get; set; }

        public int CompanyId { get; set; }
        public int BillingAddressId { get; set; }
        public int ShippingAddressId { get; set; }

        [MaxLength(50)]
        public string DeliveryTermName { get; set; }
        public int PaymentDays { get; set; }

        public int FixedDiscountPercent { get; set; }
        public int VATPercent { get; set; }

        public bool IsClosed { get; set; }

        public DateTime? CreatedOn { get; set; }

        public IList<SalesInvoiceLine> SalesInvoiceLines { get; set; }

        //----------------------------------
        public Company Company { get; set; }
        [ForeignKey(nameof(BillingAddressId))]
        public CompanyAddress BillingAddress { get; set; }
        [ForeignKey(nameof(ShippingAddressId))]
        public CompanyAddress ShippingAddress { get; set; }

        //--- legacy system fields ---
        [MaxLength(2)]
        public string FMS_doktyyp { get; set; }
        [MaxLength(8)]
        public string FMS_doknr { get; set; }
    }
}
