using FMS.ServiceLayer.Interface.Dtos;
using System.Collections.Generic;

namespace FMS.ServiceLayer.Interface.Services
{
    public interface ICompaniesService
    {
        IList<CompanyListDto> GetCompanies(string query);
    }
}
