using System.Collections.Generic;
using FMS.WPF.Model;

namespace FMS.WPF.Application.Services
{
    public interface ICompanyService
    {
        void DeleteCompanyBasics(int companyId);
        IList<CompanyAddressModel> GetCompanyAddressModels(int companyId);
        CompanyBasicsModel GetCompanyBasicsModel(int companyId);
        IList<CompanyContactModel> GetCompanyContactModels(int companyId);
        List<CompanyListModel> GetCompanyList();
        CompanyBasicsModel SaveCompanyBasics(CompanyBasicsModel model);
    }
}