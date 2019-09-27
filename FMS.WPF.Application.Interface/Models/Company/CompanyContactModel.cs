using System;

namespace FMS.WPF.Models
{
    public class CompanyContactModel : ModelBase
    {
        public int ContactId { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public DateTime? CreatedOn { get; set; }

        #region overrides
        public override bool IsNew => (ContactId == 0);
        #endregion
    }
}
