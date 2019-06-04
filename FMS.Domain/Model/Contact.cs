using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FMS.Domain.Model
{
    public class Contact
    {
        public int ContactId { get; set; }

        public int CompanyId { get; set; }

        [Required, MaxLength(50)]
        public string ContactName { get; set; }

        [MaxLength(50)]
        public string Job { get; set; }

        [MaxLength(20)]
        public string Phone { get; set; }

        [MaxLength(30)]
        public string Mobile { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        //----------------------------------
        public Company Company { get; set; }
    }
}
