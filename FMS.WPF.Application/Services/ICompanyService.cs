using System.Collections.Generic;
using System.Threading.Tasks;
using FMS.WPF.Models;

namespace FMS.WPF.Application.Services
{
    public interface ICompanyService
    {
        Task<List<CompanyListModel>> GetCompanyListAsync(string query);

        CompanyBasicsModel GetCompanyBasicsModel(int companyId);
        CompanyBasicsModel SaveCompanyBasics(CompanyBasicsModel model);
        void DeleteCompanyBasics(int companyId);

        IList<CompanyAddressModel> GetCompanyAddressModelsForShipping(int companyId);
        CompanyAddressModel GetCompanyAddressModelForBilling(int companyId);
        int SaveCompanyAddress(CompanyAddressModel model);
        void DeleteCompanyAddress(int companyAddressId);

        IList<CompanyContactModel> GetCompanyContactModels(int companyId);
        int SaveCompanyContact(CompanyContactModel model);
        void DeleteCompanyContact(int contactId);

        Task<IList<CompanySalesOrderListModel>> GetCompanySalesOrderListAsync(int companyId);

        Task<IList<CompanySalesInvoiceListModel>> GetCompanySalesInvoiceListAsync(int companyId);
    }
}