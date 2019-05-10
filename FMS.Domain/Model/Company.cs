using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

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

        public List<Contact> Contacts { get; set; }

        //--- legacy system fields ---
        public int FMS_yksusid { get; set; }
    }
}
