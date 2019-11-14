using System;

namespace FMS.WPF.Models
{
    public class StockMovementModel
    {
        public string DeliveryHeaderDocNo { get; set; }
        public DateTime DeliveryHeaderDocDate { get; set; }
        public string DeliveryTypeName { get; set; }

        public int DeliveredQuantity { get; set; }

    }
}
