using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class CompanyAddress
    {
        public int CompanyId { get; set; }
        public int AddressId { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public bool IsBilling { get; set; }

        public bool IsShipping { get; set; }

        public DateTime? CreatedOn { get; set; }

        //----------------------------------
        public Company Company { get; set; }
        public Address Address { get; set; }
    }
}
