using System.Collections.Generic;
using System.Threading.Tasks;
using FMS.WPF.Models;

namespace FMS.WPF.Application.Services
{
    public interface ICompanyService
    {
        Task<List<CompanyListModel>> GetCompanyListAsync(string query);

        Task<CompanyBasicsModel> GetCompanyBasicsModelAsync(int companyId);
        CompanyBasicsModel SaveCompanyBasics(CompanyBasicsModel model);
        void DeleteCompanyBasics(int companyId);

        Task<IList<CompanyAddressModel>> GetCompanyAddressModelsForShippingAsync(int companyId);
        int SaveCompanyAddress(CompanyAddressModel model);
        void DeleteCompanyAddress(int companyAddressId);

        Task<IList<CompanyContactModel>> GetCompanyContactModelsAsync(int companyId);
        int SaveCompanyContact(CompanyContactModel model);
        void DeleteCompanyContact(int contactId);

        Task<IList<CompanySalesOrderListModel>> GetCompanySalesOrderListAsync(int companyId);

        Task<IList<CompanySalesInvoiceListModel>> GetCompanySalesInvoiceListAsync(int companyId);
    }
}