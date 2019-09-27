using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class ProductDestination
    {
        public int ProductDestinationId { get; set; }

        [MaxLength(30)]
        public string CompanyProductCode { get; set; }
        [MaxLength(13)]
        public string EAN { get; set; }

        //-----------------------------------
        //relationships
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; }
    }
}
