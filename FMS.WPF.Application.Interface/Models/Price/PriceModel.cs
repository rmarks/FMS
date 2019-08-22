namespace FMS.WPF.Application.Interface.Models
{
    public class PriceModel
    {
        public int ProductId { get; set; }
        public int PriceListId { get; set; }

        public string ProductProductCode { get; set; }
        public string ProductProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
