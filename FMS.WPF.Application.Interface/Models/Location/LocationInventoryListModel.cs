namespace FMS.WPF.Models
{
    public class LocationInventoryListModel
    {
        public int LocationId { get; set; }

        public int ProductId { get; set; }
        public string ProductProductCode { get; set; }
        public string ProductProductName { get; set; }
        public string ProductProductBaseProductBaseCode { get; set; }

        public int ReservedQuantity { get; set; }
        public int StockQuantity { get; set; }
    }
}
