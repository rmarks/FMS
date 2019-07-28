using FMS.ServiceLayer.Interface.Services;
using FMS.WPF.Application.Extensions;
using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.Services
{
    public class CompanyListVmService : ICompanyListVmService
    {
        private readonly ICompaniesService _companiesService;

        public CompanyListVmService(ICompaniesService companiesService)
        {
            _companiesService = companiesService;
        }

        public IList<CompanyListModel> GetCompanyListModels(string query)
        {
            return _companiesService
                .GetCompanies(query)
                .Select(c => c.MapTo<CompanyListModel>())
                .ToList();
        }
    }
}
