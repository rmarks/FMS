namespace FMS.ServiceLayer.Interface.Dtos
{
    public class PriceDto
    {
        public int ProductId { get; set; }
        public int PriceListId { get; set; }

        public string ProductProductCode { get; set; }
        public string ProductProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
