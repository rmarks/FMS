using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class Company
    {
        public int CompanyId { get; set; }

        [Required, MaxLength(70)]
        public string Name { get; set; }

        [MaxLength(20)]
        public string VATNo { get; set; }
        [MaxLength(20)]
        public string RegNo { get; set; }

        public int? LocationId { get; set; }
        [Required, MaxLength(3)]
        public string CurrencyCode { get; set; }
        public int? PriceListId { get; set; }
        public string DeliveryTermName { get; set; }
        public int PaymentDays { get; set; }
        [MaxLength(50)]
        public int FixedDiscountPercent { get; set; }
        public bool IsVAT { get; set; }

        public DateTime? CreatedOn { get; set; }

        //-----------------------------------------
        //relationships
        public List<CompanyAddress> Addresses { get; set; }
        public List<Contact> Contacts { get; set; }
        public List<SalesOrder> SalesOrders { get; set; }
        public List<SalesHeader> SalesInvoices { get; set; }
        public List<CompanyCompanyType> CompanyTypesLink { get; set; }

        //--------------------------------------
        //legacy system fields
        public int? FMS_yksusid { get; set; }
        [MaxLength(4)]
        public string FMS_ykood { get; set; }
        public bool FMS_lklient { get; set; }
        public bool FMS_lhankija { get; set; }
        public bool FMS_lahanktell { get; set; }
        public bool FMS_lthankija { get; set; }
    }
}
