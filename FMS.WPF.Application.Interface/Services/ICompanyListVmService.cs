using System.Collections.Generic;
using FMS.WPF.Application.Interface.Models;

namespace FMS.WPF.Application.Interface.Services
{
    public interface ICompanyListVmService
    {
        IList<CompanyListModel> GetCompanyListModels(string query);
    }
}