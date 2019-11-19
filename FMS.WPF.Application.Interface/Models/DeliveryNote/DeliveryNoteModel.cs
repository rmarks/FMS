using FMS.WPF.Application.Interface.Dropdowns;
using System;
using System.Collections.Generic;

namespace FMS.WPF.Models
{
    public class DeliveryNoteModel : ModelBase
    {
        public int DeliveryHeaderId { get; set; }

        public int DeliveryTypeId { get; set; }

        public string DocNo { get; set; }
        public DateTime DocDate { get; set; }

        public int? FromLocationId { get; set; }
        public int? ToLocationId { get; set; }
        public bool IsDelivered { get; set; }

        public int? SalesOrderId { get; set; }

        public bool IsClosed { get; set; }

        public DateTime? CreatedOn { get; set; }

        public List<DeliveryLineModel> DeliveryLines { get; set; }

        #region dropdowns
        public IDeliveryNoteDropdowns Dropdowns => DeliveryNoteDropdownsProxy.Instance;
        #endregion
    }
}
