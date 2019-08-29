using FMS.WPF.Application.Interface.Dropdowns;
using System;
using System.Linq;

namespace FMS.WPF.Models
{
    public class CompanyAddressModel : ModelBase
    {
        #region model properties
        public int CompanyAddressId { get; set; }
        public int CompanyId { get; set; }

        private int _countryId;
        public int CountryId 
        { 
            get => _countryId;
            set
            {
                _countryId = value;
                CountryName = Dropdowns.Countries.FirstOrDefault(c => c.CountryId == _countryId)?.Name;
            } 
        }

        public string CountryName { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string Description { get; set; }
        public bool IsBilling { get; set; }
        public bool IsShipping { get; set; }
        public DateTime? CreatedOn { get; set; }
        #endregion

        #region dropdowns
        public ICompanyDropdowns Dropdowns => CompanyDropdownsProxy.Instance;
        #endregion
    }
}
