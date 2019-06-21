using System;

namespace FMS.WPF.Model
{
    public class CompanySalesOrderListModel
    {
        public int SalesOrderId { get; set; }

        public string OrderNo { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? OrderDeliveryDate { get; set; }

        public string BuyerName { get; set; }

        public string ConsigneeName { get; set; }

        public bool IsClosed { get; set; }
    }
}
