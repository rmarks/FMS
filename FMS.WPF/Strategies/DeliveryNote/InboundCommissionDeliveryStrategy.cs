using FMS.WPF.Models;
using System;

namespace FMS.WPF.Strategies
{
    public class InboundCommissionDeliveryStrategy : IDeliveryStrategy
    {
        public string DisplayName => "KL sissetulekud";

        public bool IsFromLocationTypeEnabled => true;

        public bool IsToLocationTypeEnabled => false;

        public Action<DeliveryNoteListOptionsModel> SetDefaultOptions => (o) =>
        {
            o.DeliveryTypeId = 1;
            o.ToLocationTypeId = 3;
            o.IsClosed = false;
        };
    }
}
