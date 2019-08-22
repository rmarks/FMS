namespace FMS.ServiceLayer.Interface.Dtos
{
    public class ProductCompanyDto
    {
        public int ProductId { get; set; }
        public int CompanyId { get; set; }

        public bool IsSource { get; set; }
        public string CompanyProductCode { get; set; }
        public string EAN { get; set; }
        public CompanySmallDto Company { get; set; }
        public ProductDto Product { get; set; }
    }
}
