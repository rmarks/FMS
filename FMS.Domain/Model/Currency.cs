using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class Currency
    {
        [Key]
        [MaxLength(3)]
        public string CurrencyCode { get; set; }

        [Required, MaxLength(30)]
        public string CurrencyName { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
