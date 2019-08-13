using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class CompanyType
    {
        public int CompanyTypeId { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }
    }
}
