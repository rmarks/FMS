using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.ServiceLayer.Extensions;
using FMS.ServiceLayer.Interface.Dtos;
using FMS.ServiceLayer.Interface.Services;
using FMS.ServiceLayer.QueryObjects;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FMS.ServiceLayer.Services
{
    public class CompaniesService : ICompaniesService
    {
        private IDataContextFactory _contextFactory;

        public CompaniesService(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IList<CompanyListDto> GetCompanies(string query)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.CompanyAddresses
                    .AsNoTracking()
                    .FilterBy(query)
                    .OrderBy(a => a.Company.CompanyName)
                    .ProjectBetween<CompanyAddress, CompanyListDto>()
                    .ToList();
            }
        }
    }
}
