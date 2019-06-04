﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class CompanyAddress
    {
        public int CompanyAddressId { get; set; }

        public int CompanyId { get; set; }

        public int CountryId { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; }

        [Required, MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(10)]
        public string PostCode { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public bool IsBilling { get; set; }

        public bool IsShipping { get; set; }

        public DateTime? CreatedOn { get; set; }

        //----------------------------------
        public Company Company { get; set; }
        public Country Country { get; set; }
    }
}
