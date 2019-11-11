using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class DeliveryType
    {
        public int DeliveryTypeId { get; set; }
        
        [Required, MaxLength(2)]
        public string DeliveryTypeCode { get; set; }

        [Required, MaxLength(30)]
        public string DeliveryTypeName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
