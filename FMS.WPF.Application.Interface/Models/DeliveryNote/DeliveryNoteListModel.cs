using System;

namespace FMS.WPF.Models
{
    public class DeliveryNoteListModel
    {
        public int DeliveryHeaderId { get; set; }

        public string DocNo { get; set; }
        public DateTime DocDate { get; set; }

        public int? FromLocationId { get; set; }
        public string FromLocationLocationName { get; set; }

        public int? ToLocationId { get; set; }
        public string ToLocationLocationName { get; set; }

        public bool IsClosed { get; set; }
    }
}
