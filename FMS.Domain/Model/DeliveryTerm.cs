using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FMS.Domain.Model
{
    public class DeliveryTerm
    {
        public int DeliveryTermId { get; set; }

        [Required, MaxLength(50)]
        public string DeliveryTermName { get; set; }
    }
}
