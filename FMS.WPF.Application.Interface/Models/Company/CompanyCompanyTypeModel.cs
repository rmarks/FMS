namespace FMS.WPF.Models
{
    public class CompanyCompanyTypeModel
    {
        public int CompanyCompanyTypeId { get; set; }

        public int CompanyId { get; set; }
        public int CompanyTypeId { get; set; }
        public CompanyTypeModel CompanyType { get; set; }
    }
}
