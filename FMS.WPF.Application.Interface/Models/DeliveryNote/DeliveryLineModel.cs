using System;

namespace FMS.WPF.Models
{
    public class DeliveryLineModel
    {
        public int DeliveryLineId { get; set; }

        public int DeliveryHeaderId { get; set; }

        public int ProductId { get; set; }
        public string ProductProductCode { get; set; }
        public string ProductProductName { get; set; }

        public int DeliveredQuantity { get; set; }

        public DateTime? CreatedOn { get; set; }
    }
}
