namespace FMS.WPF.Application.Interface.Models
{
    public class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal UnitGrossWeight { get; set; }

        public ProductCompanyModel ProductSource { get; set; }
        public ProductCompanyModel ProductDestination { get; set; }
    }
}
