using System;
using System.Collections.Generic;
using System.Text;

namespace FMS.WPF.Model
{
    public class CompanyBasicsModel
    {
        public int CompanyId { get; set; }

        public string CompanyCode { get; set; }

        public string CompanyName { get; set; }

        public string VATNo { get; set; }

        public string RegNo { get; set; }

        public DateTime? CreatedOn { get; set; }

        public CompanyAddressModel BillingAddress { get; set; }

        public IList<CountryModel>  Countries { get; set; }
    }
}
