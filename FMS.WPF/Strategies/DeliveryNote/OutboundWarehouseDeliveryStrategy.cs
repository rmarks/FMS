using FMS.WPF.Models;
using System;

namespace FMS.WPF.Strategies
{
    public class OutboundWarehouseDeliveryStrategy : IDeliveryStrategy
    {
        public string DisplayName => "VL väljaminekud";
        public bool IsFromLocationTypeEnabled => false;
        public bool IsToLocationTypeEnabled => true;

        public Action<DeliveryNoteListOptionsModel> SetDefaultOptions => (o) =>
        {
            o.DeliveryTypeId = 1;
            o.FromLocationTypeId = 1;
            o.IsClosed = false;
        };
    }
}
