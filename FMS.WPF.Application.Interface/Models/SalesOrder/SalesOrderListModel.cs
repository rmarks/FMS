using System;

namespace FMS.WPF.Models
{
    public class SalesOrderListModel
    {
        public int SalesOrderId { get; set; }
        public string OrderNo { get; set; }
        //flattening
        public string CompanyName { get; set; }
        public string ShippingAddressDescription { get; set; }
        //
        public DateTime OrderDate { get; set; }
        public DateTime? OrderDeliveryDate { get; set; }
        public bool IsClosed { get; set; }
    }
}
