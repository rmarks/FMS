using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Model
{
    public class SalesOrder
    {
        public int SalesOrderId { get; set; }

        [Required, MaxLength(10)]
        public string OrderNo { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? OrderDeliveryDate { get; set; }

        [MaxLength(20)]
        public string ClientOrderNo { get; set; }
        public DateTime? ClientOrderDate { get; set; }
        public DateTime? ClientOrderDeliveryDate { get; set; }

        public int CompanyId { get; set; }
        public int? BillingAddressId { get; set; }
        public int? ShippingAddressId { get; set; }

        public int LocationId { get; set; }

        [Required, MaxLength(3)]
        public string CurrencyCode { get; set; }
        public int PriceListId { get; set; }

        [MaxLength(50)]
        public string DeliveryTermName { get; set; }
        public int PaymentDays { get; set; }

        public int FixedDiscountPercent { get; set; }
        public int VATPercent { get; set; }

        public bool IsClosed { get; set; }

        public DateTime? CreatedOn { get; set; }

        public List<SalesOrderLine> SalesOrderLines { get; set; } = new List<SalesOrderLine>();

        //----------------------------------
        //relationships
        public Company Company { get; set; }

        [ForeignKey(nameof(BillingAddressId))]
        public CompanyAddress BillingAddress { get; set; }

        [ForeignKey(nameof(ShippingAddressId))]
        public CompanyAddress ShippingAddress { get; set; }

        public PriceList PriceList { get; set; }
        //public Location Location { get; set; }
    }
}
