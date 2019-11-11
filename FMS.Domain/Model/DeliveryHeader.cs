using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class DeliveryHeader
    {
        public int DeliveryHeaderId { get; set; }

        public int DeliveryTypeId { get; set; }

        [Required, MaxLength(10)]
        public string DocNo { get; set; }
        public DateTime DocDate { get; set; }
        
        public int? FromLocationId { get; set; }
        public bool IsDelivered { get; set; }

        public int? ToLocationId { get; set; }
        public bool IsReceived { get; set; }

        public int? SalesOrderId { get; set; }

        public bool IsClosed { get; set; }

        public DateTime? CreatedOn { get; set; }

        //--- legacy system fields ---
        [MaxLength(2)]
        public string FMS_doktyyp { get; set; }

        [MaxLength(8)]
        public string FMS_doknr { get; set; }

        [MaxLength(6)]
        public string FMS_skood { get; set; }
    }
}
