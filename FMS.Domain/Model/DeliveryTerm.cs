using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class DeliveryTerm
    {
        public int DeliveryTermId { get; set; }

        [Required, MaxLength(50)]
        public string DeliveryTermName { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
