namespace FMS.WPF.Models
{
    public class ProductModel : ModelBase
    {
        #region model properties
        public int ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public decimal UnitGrossWeight { get; set; }

        public ProductSourceModel ProductSource { get; set; }
        public ProductDestinationModel ProductDestination { get; set; }

        public int ProductBaseId { get; set; }
        #endregion

        #region overrides
        public override bool IsNew => (ProductId == 0);
        #endregion
    }
}
