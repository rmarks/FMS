using FMS.WPF.Models;
using System;

namespace FMS.WPF.Strategies
{
    public class InboundPurchaseDeliveryStrategy : IDeliveryStrategy
    {
        public string DisplayName => "Ostu sissetulekud";

        public bool IsFromLocationTypeEnabled => false;

        public bool IsToLocationTypeEnabled => false;

        public Action<DeliveryNoteListOptionsModel> SetDefaultOptions => (o) =>
        {
            o.DeliveryTypeId = 2;
            o.ToLocationTypeId = 1;
            o.IsClosed = false;
        };
    }
}
