using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class SalesType
    {
        public int SalesTypeId { get; set; }

        [Required, MaxLength(30)]
        public string SalesTypeName { get; set; }

        public short IOSales { get; set; }
    }
}
