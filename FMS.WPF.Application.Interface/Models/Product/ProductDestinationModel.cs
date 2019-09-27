namespace FMS.WPF.Models
{
    public class ProductDestinationModel
    {
        public int ProductDestinationId { get; set; }

        public string CompanyProductCode { get; set; }
        public string EAN { get; set; }

        public int ProductId { get; set; }
        public int CompanyId { get; set; }
    }
}
