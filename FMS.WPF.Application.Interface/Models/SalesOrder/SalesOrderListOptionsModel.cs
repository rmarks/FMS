using FMS.WPF.Application.Interface.Dropdowns;
using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace FMS.WPF.Models
{
    public class SalesOrderListOptionsModel : ModelBase
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

        #region options change notification and reset
        public void Reset()
        {
            GetType().GetProperties()
                //.Where(pi => pi.PropertyType == typeof(int?) || pi.PropertyType == typeof(string))
                .Where(pi => pi.CanWrite)
                .ToList()
                .ForEach(pi => pi.SetValue(this, null));
        }

        public event Action OptionChanged;

        public override void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            base.RaisePropertyChanged(propertyName);
            OptionChanged?.Invoke();
        }
        #endregion
    }
}
