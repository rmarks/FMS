﻿using System;

namespace FMS.ServiceLayer.Dtos
{
    public class CompanyContactDto
    {
        public int ContactId { get; set; }

        public int CompanyId { get; set; }

        public string ContactName { get; set; }

        public string Job { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}