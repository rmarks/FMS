using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class Address
    {
        public int AddressId { get; set; }

        public int CountryId { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; }

        [Required, MaxLength(100)]
        public string Address1 { get; set; }

        [MaxLength(10)]
        public string PostCode { get; set; }

        public DateTime? CreatedOn { get; set; }

        //----------------------------------
        public Country Country { get; set; }

        //--- legacy system fields ---
        public int FMS_yksusid { get; set; }
    }
}
