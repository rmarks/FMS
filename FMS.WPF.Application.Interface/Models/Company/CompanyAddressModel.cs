﻿using System;

namespace FMS.WPF.Models
{
    public class CompanyAddressModel : ModelBase
    {
        #region model properties
        public int CompanyAddressId { get; set; }
        public int CountryId { get; set; }
        public string County { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string Description { get; set; }
        public bool IsBilling { get; set; }
        public bool IsShipping { get; set; }
        public DateTime? CreatedOn { get; set; }
        #endregion

        #region overrides
        public override bool IsNew => (CompanyAddressId == 0);
        #endregion
    }
}
