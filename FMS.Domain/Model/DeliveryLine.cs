using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class DeliveryLine
    {
        public int DeliveryLineId { get; set; }
        
        public int DeliveryHeaderId { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int DeliveredQuantity { get; set; }

        public int? SalesOrderLineId { get; set; }

        public DateTime? CreatedOn { get; set; }

        //--- legacy system fields ---
        [MaxLength(2)]
        public string FMS_doktyyp { get; set; }

        [MaxLength(8)]
        public string FMS_doknr { get; set; }
    }
}
