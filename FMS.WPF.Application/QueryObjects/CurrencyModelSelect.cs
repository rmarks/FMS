using FMS.Domain.Model;
using FMS.WPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FMS.WPF.Application.QueryObjects
{
    public static class CurrencyModelSelect
    {
        public static IQueryable<CurrencyModel> MapToCurrencyModel(this IQueryable<Currency> countries)
        {
            return countries.Select(c => new CurrencyModel
            {
                CurrencyCode = c.CurrencyCode,
                CurrencyName = c.CurrencyName
            });
        }
    }
}
