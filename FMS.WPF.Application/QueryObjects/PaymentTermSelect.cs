using FMS.Domain.Model;
using FMS.WPF.Model;
using System.Linq;

namespace FMS.WPF.Application.QueryObjects
{
    public static class PaymentTermSelect
    {
        public static IQueryable<PaymentTermDropdownModel> MapToPaymentTermDropdownModel(this IQueryable<PaymentTerm> paymentTerms)
        {
            return paymentTerms.Select(p => new PaymentTermDropdownModel
            {
                PaymentDays = p.PaymentDays,
                PaymentTermName = p.PaymentTermName
            });
        }
    }
}
