using System;

namespace FMS.WPF.Model
{
    public class CompanyContactModel : EditableModelBase
    {
        public int ContactId { get; set; }

        public int CompanyId { get; set; }

        public string ContactName { get; set; }

        public string Job { get; set; }

        public string Phone { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public DateTime? CreatedOn { get; set; }

        public override void Merge(EditableModelBase source)
        {
            if (source is CompanyContactModel s)
            {
                ContactId = s.ContactId;
                CompanyId = s.CompanyId;
                ContactName = s.ContactName;
                Job = s.Job;
                Phone = s.Phone;
                Mobile = s.Mobile;
                Email = s.Email;
                CreatedOn = s.CreatedOn;
            }
        }
    }
}
