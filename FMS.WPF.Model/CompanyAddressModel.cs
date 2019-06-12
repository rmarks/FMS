using System;

namespace FMS.WPF.Model
{
    public class CompanyAddressModel : EditableModelBase
    {
        public int CompanyAddressId { get; set; }

        public int CompanyId { get; set; }

        public int CountryId { get; set; }

        public string CountryName { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string PostCode { get; set; }

        public string Description { get; set; }

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
                City = s.City;
                Address = s.Address;
                PostCode = s.PostCode;
                Description = s.Description;
                IsBilling = s.IsBilling;
                IsShipping = s.IsShipping;
                CreatedOn = s.CreatedOn;
            }
        }
    }
}
