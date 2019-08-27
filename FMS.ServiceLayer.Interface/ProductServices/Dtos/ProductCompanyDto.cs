namespace FMS.ServiceLayer.Interface.Dtos
{
    public class ProductCompanyDto
    {
        public int ProductId { get; set; }
        
        public string CompanyProductCode { get; set; }
        public string EAN { get; set; }

        public string ProductProductCode { get; set; }

        public int CompanyId { get; set; }
        public string CompanyCompanyName { get; set; }

        //public CompanySmallDto Company { get; set; }
        //public ProductDto Product { get; set; }
    }
}
