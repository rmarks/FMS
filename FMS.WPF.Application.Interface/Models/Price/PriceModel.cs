namespace FMS.WPF.Models
{
    public class PriceModel
    {
        public int PriceId { get; set; }

        public int ProductId { get; set; }
        public int PriceListId { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
