
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Model
{
    public class PaymentTerm
    {
        public int PaymentTermId { get; set; }

        [Required, MaxLength(30)]
        public string PaymentTermName { get; set; }

        public int PaymentDays { get; set; }

        public bool IsActive { get; set; }
    }
}
