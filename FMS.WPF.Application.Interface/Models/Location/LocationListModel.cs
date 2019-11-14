namespace FMS.WPF.Models
{
    public class LocationListModel
    {
        public int LocationId { get; set; }

        public string LocationName { get; set; }

        public int TotalReservedQuantity { get; set; }
        public int TotalStockQuantity { get; set; }
    }
}
