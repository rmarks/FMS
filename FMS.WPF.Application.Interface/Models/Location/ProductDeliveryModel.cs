using System;

namespace FMS.WPF.Models
{
    public class ProductDeliveryModel
    {
        public int ProductId { get; set; }

        public string DeliveryHeaderDocNo { get; set; }
        public DateTime DeliveryHeaderDocDate { get; set; }
        public string DeliveryTypeName { get; set; }
        public string LocationName { get; set; }

        public int DeliveredQuantity { get; set; }
    }
}
