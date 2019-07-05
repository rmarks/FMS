using FMS.Domain.Model;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FMS.ServiceLayer.CompanyServices.QueryObjects
{
    public static class CompanyFilter
    {
        public static IQueryable<Company> FilterBy(this IQueryable<Company> companies, string query)
        {
            if (query == null)
                return companies;

            //var searchWords = query.ToLower().Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

            //Expression<Func<Company, bool>> filter =
            //    company => searchWords.All(w => company.CompanyName.ToLower().Contains(w)
            //                                    || company.Addresses.Any(a => a.IsBilling && (a.Country.CountryName.ToLower().Contains(w) 
            //                                                                                  || a.City.ToLower().Contains(w) 
            //                                                                                  || a.Address.ToLower().Contains(w)))
            //                                    || company.Addresses.Any(a => a.IsShipping && a.ConsigneeName.ToLower().Contains(w)));

            //return companies.Where(filter);

            query = query.Trim();

            Expression<Func<Company, bool>> filter =
                company => company.CompanyName.Contains(query)
                           || company.Addresses.Any(a => a.IsBilling && (a.Country.CountryName.Contains(query)
                                                                         || a.City.Contains(query)
                                                                         || a.Address.Contains(query)))
                           || company.Addresses.Any(a => a.IsShipping && a.ConsigneeName.Contains(query));

            return companies.Where(filter);
        }
    }
}
