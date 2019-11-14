namespace FMS.Domain.Model
{
    public class Inventory
    {
        public int InventoryId { get; set; }

        public int LocationId { get; set; }
        public Location Location { get; set; }

        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int ReservedQuantity { get; set; }
        public int StockQuantity { get; set; }
    }
}
