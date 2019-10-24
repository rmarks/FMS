namespace FMS.Domain.Model
{
    public class CompanyCompanyType
    {
        public int CompanyCompanyTypeId { get; set; }

        //---------------------------------------
        //relationships
        public int CompanyId { get; set; }
        public Company Company { get; set; }

        public int CompanyTypeId { get; set; }
        public CompanyType CompanyType { get; set; }
    }
}
