using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class Company
    {
        public int CompanyId { get; set; }

        [Required, MaxLength(70)]
        public string CompanyName { get; set; }

        [MaxLength(20)]
        public string VATNo { get; set; }

        [MaxLength(20)]
        public string RegNo { get; set; }

        [Required, MaxLength(3)]
        public string CurrencyCode { get; set; }

        public int? PriceListId { get; set; }

        public int? LocationId { get; set; }

        public int PaymentDays { get; set; }

        [MaxLength(50)]
        public string DeliveryTermName { get; set; }

        public int FixedDiscountPercent { get; set; }

        public bool IsVAT { get; set; }

        public DateTime? CreatedOn { get; set; }

        //-----------------------------------------
        public PriceList PriceList { get; set; }

        public Location Location { get; set;}

        public List<CompanyAddress> Addresses { get; set; }

        public List<Contact> Contacts { get; set; }

        public List<SalesOrder> SalesOrders { get; set; }

        public List<SalesInvoice> SalesInvoices { get; set; }

        //--- legacy system fields ---
        public int? FMS_yksusid { get; set; }

        [MaxLength(4)]
        public string FMS_ykood { get; set; }
    }
}
