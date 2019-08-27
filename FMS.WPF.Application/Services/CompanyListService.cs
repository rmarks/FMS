using FMS.ServiceLayer.Interface.Dtos;
using FMS.ServiceLayer.Interface.Services;
using FMS.WPF.Application.Extensions;
using FMS.WPF.Models;
using FMS.WPF.Application.Interface.Services;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.Services
{
    public class CompanyListService : ICompanyListService
    {
        private readonly ICompanyService _companyService;

        public CompanyListService(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        public IList<CompanyListModel> GetCompanyListModels(string query)
        {
            return _companyService
                .GetCompanies(query)
                .MapList<CompanyListDto, CompanyListModel>()
                .ToList();
        }
    }
}
