﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class Location
    {
        public int LocationId { get; set; }

        [Required, MaxLength(50)]
        public string LocationName { get; set; }

        public int LocationTypeId { get; set; }

        public DateTime CreatedOn { get; set; }

        //--- legacy system fields ---
        [MaxLength(2)]
        public string FMS_lkood { get; set; }

        [MaxLength(2)]
        public string FMS_skood { get; set; }
    }
}
