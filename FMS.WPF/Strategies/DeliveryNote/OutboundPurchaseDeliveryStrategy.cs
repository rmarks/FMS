using FMS.WPF.Models;
using System;

namespace FMS.WPF.Strategies
{
    class OutboundPurchaseDeliveryStrategy : IDeliveryStrategy
    {
        public string DisplayName => "Ostu väljaminkeud";

        public bool IsFromLocationTypeEnabled => false;

        public bool IsToLocationTypeEnabled => false;

        public Action<DeliveryNoteListOptionsModel> SetDefaultOptions => (o) =>
        {
            o.DeliveryTypeId = 2;
            o.FromLocationTypeId = 1;
            o.IsClosed = false;
        };
    }
}
