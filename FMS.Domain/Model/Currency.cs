using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FMS.Domain.Model
{
    public class Currency
    {
        [Key]
        [MaxLength(3)]
        public string CurrencyCode { get; set; }

        [Required, MaxLength(30)]
        public string CurrencyName { get; set; }
    }
}
