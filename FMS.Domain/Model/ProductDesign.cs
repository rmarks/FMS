using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class ProductDesign
    {
        public int ProductDesignId { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        public int ProductCollectionId { get; set; }

        //-------------------------------------------------------
        public ProductCollection ProductCollection { get; set; }
    }
}
