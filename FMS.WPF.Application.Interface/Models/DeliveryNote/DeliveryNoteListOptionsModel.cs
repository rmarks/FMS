using FMS.WPF.Application.Interface.Dropdowns;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Models
{
    public class DeliveryNoteListOptionsModel : OptionsModelBase
    {
        #region options
        public int? DeliveryTypeId { get; set; }

        public string DocNo { get; set; }

        public int? FromLocationTypeId { get; set; }
        public int? FromLocationId { get; set; }

        public int? ToLocationTypeId { get; set; }
        public int? ToLocationId { get; set; }

        public bool? IsClosed { get; set; }
        #endregion

        #region dropdowns
        public IDeliveryNoteDropdowns Dropdowns => DeliveryNoteDropdownsProxy.Instance;

        public IList<LocationDropdownModel> FromLocations =>
            Dropdowns.Locations.Where(l => l.LocationTypeId == FromLocationTypeId || l.LocationTypeId == null).ToList();

        public IList<LocationDropdownModel> ToLocations =>
            Dropdowns.Locations.Where(l => l.LocationTypeId == ToLocationTypeId || l.LocationTypeId == null).ToList();
        #endregion
    }
}
