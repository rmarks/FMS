namespace FMS.Domain.Model
{
    public class CompanyCompanyType
    {
        //fluent composite key
        public int CompanyId { get; set; }
        public int CompanyTypeId { get; set; }

        //---------------------------------------
        //relationships
        public CompanyType CompanyType { get; set; }
    }
}
