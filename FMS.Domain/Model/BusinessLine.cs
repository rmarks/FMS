using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class BusinessLine
    {
        public int BusinessLineId { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        //--- legacy system fields ---
        [MaxLength(1)]
        public string FMS_divkood { get; set; }
    }
}
