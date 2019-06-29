using FMS.Domain.Model;
using FMS.WPF.Models;
using System.Linq;

namespace FMS.WPF.Application.QueryObjects
{
    public static class PriceListSelect
    {
        public static IQueryable<PriceListDropdownModel> MapToPriceListDropdownModel(this IQueryable<PriceList> priceLists)
        {
            return priceLists.Select(p => new PriceListDropdownModel
            {
                PriceListId = p.PriceListId,
                PriceListName = p.PriceListName,
                CurrencyCode = p.CurrencyCode
            });
        }
    }
}
