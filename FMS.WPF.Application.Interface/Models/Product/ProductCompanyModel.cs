namespace FMS.WPF.Application.Interface.Models
{
    public class ProductCompanyModel
    {
        public int ProductId { get; set; }
        public int CompanyId { get; set; }

        public bool IsSource { get; set; }
        public string CompanyProductCode { get; set; }
        public string EAN { get; set; }
        public CompanySmallModel Company { get; set; }
        public ProductModel Product { get; set; }
    }
}
