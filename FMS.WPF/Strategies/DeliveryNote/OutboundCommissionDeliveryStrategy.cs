using FMS.WPF.Models;
using System;

namespace FMS.WPF.Strategies
{
    public class OutboundCommissionDeliveryStrategy : IDeliveryStrategy
    {
        public string DisplayName => "KL väljaminekud";

        public bool IsFromLocationTypeEnabled => false;

        public bool IsToLocationTypeEnabled => true;

        public Action<DeliveryNoteListOptionsModel> SetDefaultOptions => (o) =>
        {
            o.DeliveryTypeId = 1;
            o.FromLocationTypeId = 3;
            o.IsClosed = false;
        };
    }
}
