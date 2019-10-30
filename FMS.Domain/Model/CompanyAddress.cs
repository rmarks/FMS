using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class CompanyAddress
    {
        public int CompanyAddressId { get; set; }

        [MaxLength(30)]
        public string County { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; }

        [Required, MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(10)]
        public string PostCode { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public bool IsBilling { get; set; }

        public bool IsShipping { get; set; }

        public DateTime? CreatedOn { get; set; }

        //----------------------------------
        //relationships
        public int CompanyId { get; set; }
        //public Company Company { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        //-----------------------------------
        //legacy system fields
        public int? FMS_yksusid { get; set; }

        [MaxLength(4)]
        public string FMS_ykood { get; set; }

        [MaxLength(6)]
        public string FMS_skood { get; set; }
    }
}
