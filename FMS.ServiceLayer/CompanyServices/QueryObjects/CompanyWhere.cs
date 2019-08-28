using FMS.Domain.Model;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FMS.ServiceLayer.QueryObjects
{
    public static class CompanyWhere
    {
        public static IQueryable<CompanyAddress> FilterBy(this IQueryable<CompanyAddress> addresses, string query)
        {
            Expression<Func<CompanyAddress, bool>> filter = null;

            if (string.IsNullOrWhiteSpace(query))
            {
                filter = a => a.IsBilling;
            }
            else
            {
                query = query.Trim();

                filter = a => a.IsBilling
                                && (
                                    a.Company.Name.Contains(query)
                                    || a.Country.Name.Contains(query)
                                    || a.City.Contains(query)
                                    || a.Address.Contains(query)
                                    || a.Company.Addresses.Any(ca => ca.IsShipping && ca.Description.Contains(query))
                                   );
            }

            return addresses.Where(filter);
        }
    }
}
