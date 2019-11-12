using FMS.WPF.Application.Interface.Dropdowns;
using System.Linq;

namespace FMS.WPF.Models
{
    public class SalesOrderListOptionsModel : OptionsModelBase
    {
        #region options
        public string OrderNo { get; set; }
        public string CompanyName { get; set; }
        public string ShippingAddressDescription { get; set; }
        public int? CompanyCountryId { get; set; }
        public bool? IsClosed { get; set; }
        #endregion

        #region public methods
        public void DefaultSetup()
        {
            IsClosed = Dropdowns.DocumentStates.FirstOrDefault(d => d.StateName == "Avatud")?.IsClosed;
        }
        #endregion

        #region dropdowns
        public ISalesOrderDropdowns Dropdowns => SalesOrderDropdownsProxy.Instance;
        #endregion
    }
}
