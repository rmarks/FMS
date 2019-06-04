using FMS.Domain.Model;
using FMS.WPF.Model;
using System.Linq;

namespace FMS.WPF.Application.QueryObjects
{
    public static class CountryModelSelect
    {
        public static IQueryable<CountryModel> MapToCountryModel(this IQueryable<Country> countries)
        {
            return countries.Select(c => new CountryModel
            {
                CountryId = c.CountryId,
                CountryName = c.CountryName,
                IsEU = c.IsEU
            });
        }
    }
}
