using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class ProductCompany
    {
        //fluent composite key
        public int ProductId { get; set; }
        public int CompanyId { get; set; }

        public bool IsSource { get; set; }
        [MaxLength(30)]
        public string CompanyProductCode { get; set; }
        [MaxLength(13)]
        public string EAN { get; set; }

        //-----------------------------------
        //relationships
        public Product Product { get; set; }
        public Company Company { get; set; }
    }
}
