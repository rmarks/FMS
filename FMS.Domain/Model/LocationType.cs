using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class LocationType
    {
        public int LocationTypeId { get; set; }
        
        [Required, MaxLength(2)]
        public string LocationTypeCode { get; set; }
        
        [Required, MaxLength(30)]
        public string LocationTypeName { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}
