namespace FMS.WPF.Application.Interface.Models
{
    public class ProductCompanyModel
    {
        public int ProductId { get; set; }

        public string CompanyProductCode { get; set; }
        public string EAN { get; set; }

        public string ProductProductCode { get; set; }

        public int CompanyId { get; set; }
        public string CompanyCompanyName { get; set; }

        //public CompanySmallModel Company { get; set; }
        //public ProductModel Product { get; set; }
    }
}
