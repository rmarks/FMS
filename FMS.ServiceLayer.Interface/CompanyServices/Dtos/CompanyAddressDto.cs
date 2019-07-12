using System;

namespace FMS.ServiceLayer.Dtos
{
    public class CompanyAddressDto
    {
        public int CompanyAddressId { get; set; }

        public int CompanyId { get; set; }

        public int CountryId { get; set; }

        public string CountryCountryName { get; set; }

        public string County { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string PostCode { get; set; }

        public string ConsigneeName { get; set; }

        public bool IsBilling { get; set; }

        public bool IsShipping { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
