using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class Country
    {
        public int CountryId { get; set; }

        [Required, MaxLength(30)]
        public string CountryName { get; set; }

        public bool IsEU { get; set; }

        //--- legacy system fields ---
        public int FMS_rkood { get; set; }
    }
}
