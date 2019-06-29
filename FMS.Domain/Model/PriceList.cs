using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FMS.Domain.Model
{
    public class PriceList
    {
        public int PriceListId { get; set; }

        [Required, MaxLength(30)]
        public string PriceListName { get; set; }

        [Required, MaxLength(3)]
        public string CurrencyCode { get; set; }

        public bool IsVAT { get; set; }

        public DateTime CreatedOn { get; set; }

        //--------------------------------
        [ForeignKey("CurrencyCode")]
        public Currency Currency { get; set; }

        //--- legacy system fields ---
        [Required, MaxLength(3)]
        public string FMS_hnr { get; set; }
    }
}
