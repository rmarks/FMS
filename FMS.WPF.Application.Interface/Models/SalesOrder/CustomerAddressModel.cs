namespace FMS.WPF.Models
{
    public class CustomerAddressModel
    {
        public int CompanyAddressId { get; set; }

        public string Description { get; set; }

        public string City { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        //flattening
        public string CountryName { get; set; }
        //

        public string AddressString => $"{CountryName} {City} {Address}";
    }
}
