using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Model
{
    public class CompanyCompanyType
    {
        //fluent composite key
        public int CompanyId { get; set; }
        public int CompanyTypeId { get; set; }

        //---------------------------------------
        public CompanyType CompanyType { get; set; }
    }
}
