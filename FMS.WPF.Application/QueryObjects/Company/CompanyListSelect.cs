using FMS.Domain.Model;
using FMS.WPF.Models;
using System.Linq;

namespace FMS.WPF.Application.QueryObjects
{
    public static class CompanyListSelect
    {
        public static IQueryable<CompanyListModel> MapToCompanyListModel(this IQueryable<CompanyAddress> addresses)
        {
            return addresses.Select(a => new CompanyListModel
            {
                CompanyId = a.CompanyId,
                CompanyName = a.Company.CompanyName,
                CountryName = a.Country.CountryName,
                City = a.City,
                Address = a.Address
            });
        }
    }
}
