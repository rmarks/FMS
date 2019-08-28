namespace FMS.WPF.Models
{
    public class CompanyListModel
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string CompanyTypesString { get; set; }
        public CompanyAddressListModel BillingAddress { get; set; }
    }
}
