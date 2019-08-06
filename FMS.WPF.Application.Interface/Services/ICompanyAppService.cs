using System.Collections.Generic;
using System.Threading.Tasks;
using FMS.WPF.Application.Interface.Models;

namespace FMS.WPF.Application.Interface.Services
{
    public interface ICompanyAppService
    {
        IList<CompanyListModel> GetCompanyListModels(string query);

        CompanyBasicsModel GetCompanyBasicsModel(int companyId);
        CompanyBasicsModel SaveCompanyBasicsModel(CompanyBasicsModel model);
        void DeleteCompanyBasicsModel(int companyId);

        Task<IList<CompanyAddressModel>> GetCompanyAddressModelsAsync(int companyId);
        int SaveCompanyAddressModel(CompanyAddressModel model);
        void DeleteCompanyAddressModel(int companyId);

        Task<IList<CompanyContactModel>> GetCompanyContactModelsAsync(int companyId);
        int SaveCompanyContactModel(CompanyContactModel model);
        void DeleteCompanyContactModel(int companyId);

        Task<IList<CompanySalesOrderListModel>> GetCompanySalesOrderListModelsAsync(int companyId);

        Task<IList<CompanySalesInvoiceListModel>> GetCompanySalesInvoiceListModelsAsync(int companyId);
    }
}