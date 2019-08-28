using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class Country
    {
        public int CountryId { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        public bool IsEU { get; set; }

        public DateTime? CreatedOn { get; set; }

        //---------------------------------------
        //legacy system fields
        public int FMS_rkood { get; set; }
    }
}
