using FMS.WPF.Models;
using System;

namespace FMS.WPF.Strategies
{
    public class InboundWarehouseDeliveryStrategy : IDeliveryStrategy
    {
        public string DisplayName => "VL sissetulekud";
        public bool IsFromLocationTypeEnabled => true;
        public bool IsToLocationTypeEnabled => false;

        public Action<DeliveryNoteListOptionsModel> SetDefaultOptions => (o) =>
        {
            o.DeliveryTypeId = 1;
            o.ToLocationTypeId = 1;
            o.IsClosed = false;
        };
    }
}
