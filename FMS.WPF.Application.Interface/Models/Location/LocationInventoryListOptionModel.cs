namespace FMS.WPF.Models
{
    public class LocationInventoryListOptionModel : OptionsModelBase
    {
        #region options
        public int LocationId { get; set; }

        public bool IsAll { get; set; }
        public bool IsReserved { get; set; }
        public bool IsInStock { get; set; }
        #endregion
    }
}
