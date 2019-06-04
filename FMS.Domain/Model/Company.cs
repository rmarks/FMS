using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class Company
    {
        public int CompanyId { get; set; }

        [Required, MaxLength(4)]
        public string CompanyCode { get; set; }

        [Required, MaxLength(70)]
        public string CompanyName { get; set; }

        [MaxLength(20)]
        public string VATNo { get; set; }

        [MaxLength(20)]
        public string RegNo { get; set; }

        public DateTime? CreatedOn { get; set; }

        //-----------------------------------------
        public List<CompanyAddress> Addresses { get; set; }
        public List<Contact> Contacts { get; set; }

        //--- legacy system fields ---
        public int FMS_yksusid { get; set; }
    }
}
