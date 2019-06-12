using System.Collections.Generic;
using FMS.WPF.Model;

namespace FMS.WPF.Application.Services
{
    public interface ICompanyService
    {
        List<CompanyListModel> GetCompanyList();

        CompanyBasicsModel GetCompanyBasicsModel(int companyId);
        CompanyBasicsModel SaveCompanyBasics(CompanyBasicsModel model);
        void DeleteCompanyBasics(int companyId);

        IList<CompanyAddressModel> GetCompanyAddressModelsForShipping(int companyId);
        CompanyAddressModel GetCompanyAddressModelForBilling(int companyId);
        int SaveCompanyAddress(CompanyAddressModel model);
        void DeleteCompanyAddress(int companyAddressId);

        IList<CompanyContactModel> GetCompanyContactModels(int companyId);
        
        
    }
}