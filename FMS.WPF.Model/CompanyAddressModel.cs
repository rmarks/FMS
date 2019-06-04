using System;
using System.Collections.Generic;
using System.Text;

namespace FMS.WPF.Model
{
    public class CompanyAddressModel
    {
        public int CompanyAddressId { get; set; }

        public int CompanyId { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string PostCode { get; set; }

        public string Description { get; set; }
    }
}
