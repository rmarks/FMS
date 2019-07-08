using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class Product
    {
        public int ProductId { get; set; }

        public int ProductBaseId { get; set; }

        [Required, MaxLength(15)]
        public string ProductCode { get; set; }

        //------------------------------------------
        public ProductBase ProductBase { get; set; }
    }
}
