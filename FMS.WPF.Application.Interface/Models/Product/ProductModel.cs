namespace FMS.WPF.Models
{
    public class ProductModel : ModelBase
    {
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal UnitGrossWeight { get; set; }

        public ProductCompanyModel ProductSource { get; set; }
        public ProductCompanyModel ProductDestination { get; set; }

        public int ProductBaseId { get; set; }
    }
}
