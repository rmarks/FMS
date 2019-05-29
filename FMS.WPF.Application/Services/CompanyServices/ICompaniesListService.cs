using System.Collections.Generic;
using FMS.WPF.Model;

namespace FMS.WPF.Application.Services
{
    public interface ICompaniesListService
    {
        List<CompanyListModel> GetCompaniesList();
    }
}