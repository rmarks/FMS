using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class SalesOrderType
    {
        public int SalesOrderTypeId { get; set; }

        [Required, MaxLength(30)]
        public string SalesOrderTypeName { get; set; }

        public short IOSales { get; set; }
    }
}
