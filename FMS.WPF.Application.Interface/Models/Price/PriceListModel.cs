namespace FMS.WPF.Models
{
    public class PriceListModel
    {
        public int PriceListId { get; set; }
        public string PriceListName { get; set; }
        public bool IsVAT { get; set; }
        public string CurrencyCode { get; set; }
    }
}
