using FMS.WPF.Models;
using System;

namespace FMS.WPF.Strategies
{
    public class InboundStoreDeliveryStrategy : IDeliveryStrategy
    {
        public string DisplayName => "Poe sissetulekud";

        public bool IsFromLocationTypeEnabled => true;

        public bool IsToLocationTypeEnabled => false;

        public Action<DeliveryNoteListOptionsModel> SetDefaultOptions => (o) =>
        {
            o.DeliveryTypeId = 1;
            o.ToLocationTypeId = 4;
            o.IsClosed = false;
        };
    }
}
