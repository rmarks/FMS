using System.Collections.Generic;

namespace FMS.WPF.Models
{
    public class ProductDeliveriesModel
    {
        public int ProductId { get; set; }

        public string ProductCode { get; set; }
        public string ProductName { get; set; }

        public IList<ProductDeliveryModel> DeliveryLines { get; set; }
    }
}
