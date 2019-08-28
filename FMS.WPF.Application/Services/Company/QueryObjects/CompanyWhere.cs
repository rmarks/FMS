using FMS.Domain.Model;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FMS.WPF.Application.Services.QueryObjects
{
    public static class CompanyWhere
    {
        public static IQueryable<Company> FilterBy(this IQueryable<Company> companies, string query)
        {
            Expression<Func<Company, bool>> filter = c => true;

            if (!string.IsNullOrWhiteSpace(query))
            {
                query = query.Trim();

                filter = c => c.Name.Contains(query)
                              || c.Addresses.Any(a => a.IsBilling && (a.Country.Name.Contains(query)
                                                                      || a.City.Contains(query)
                                                                      || a.Address.Contains(query)))
                              || c.Addresses.Any(a => a.IsShipping && a.Description.Contains(query));
            }

            return companies.Where(filter);
        }
    }
}
