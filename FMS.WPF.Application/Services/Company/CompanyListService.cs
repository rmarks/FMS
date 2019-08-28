using FMS.WPF.Application.Extensions;
using FMS.WPF.Models;
using FMS.WPF.Application.Interface.Services;
using System.Collections.Generic;
using System.Linq;
using FMS.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using FMS.WPF.Application.Services.QueryObjects;
using FMS.Domain.Model;

namespace FMS.WPF.Application.Services
{
    public class CompanyListService : ICompanyListService
    {
        private IDataContextFactory _contextFactory;

        public CompanyListService(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IList<CompanyListModel> GetCompanyListModels(string query)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return context.Companies
                    .AsNoTracking()
                    .FilterBy(query)
                    .OrderBy(c => c.Name)
                    .ProjectBetween<Company, CompanyListModel>()
                    .ToList();
            }
        }
    }
}
