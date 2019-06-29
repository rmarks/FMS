using FMS.Domain.Model;
using FMS.WPF.Models;
using System.Linq;

namespace FMS.WPF.Application.QueryObjects
{
    public static class DeliveryTermModelSelect
    {
        public static IQueryable<DeliveryTermModel> MapToDeliveryTermModel(this IQueryable<DeliveryTerm> deliveryTerms)
        {
            return deliveryTerms.Select(d => new DeliveryTermModel
            {
                DeliveryTermId = d.DeliveryTermId,
                DeliveryTermName = d.DeliveryTermName
            });
        }
    }
}
