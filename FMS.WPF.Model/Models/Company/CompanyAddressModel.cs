using System;

namespace FMS.WPF.Models
{
    public class CompanyAddressModel : EditableModelBase
    {
        public int CompanyAddressId { get; set; }

        public int CompanyId { get; set; }

        public int CountryId { get; set; }

        public string County { get; set; }

        public string CountryName { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string PostCode { get; set; }

        public string ConsigneeName { get; set; }

        public bool IsBilling { get; set; }

        public bool IsShipping { get; set; }

        public DateTime? CreatedOn { get; set; }


        public override void Merge(EditableModelBase source)
        {
            if (source is CompanyAddressModel s)
            {
                CompanyAddressId = s.CompanyAddressId;
                CompanyId = s.CompanyId;
                CountryId = s.CountryId;
                CountryName = s.CountryName;
                County = s.County;
                City = s.City;
                Address = s.Address;
                PostCode = s.PostCode;
                ConsigneeName = s.ConsigneeName;
                IsBilling = s.IsBilling;
                IsShipping = s.IsShipping;
                CreatedOn = s.CreatedOn;
            }
        }
    }
}
