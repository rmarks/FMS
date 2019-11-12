using FMS.WPF.Models;
using System;

namespace FMS.WPF.Strategies
{
    public class OutboundStoreDeliveryStrategy : IDeliveryStrategy
    {
        public string DisplayName => "Poe väljaminekud";

        public bool IsFromLocationTypeEnabled => false;

        public bool IsToLocationTypeEnabled => true;

        public Action<DeliveryNoteListOptionsModel> SetDefaultOptions => (o) =>
        {
            o.DeliveryTypeId = 1;
            o.FromLocationTypeId = 4;
            o.IsClosed = false;
        };
    }
}
