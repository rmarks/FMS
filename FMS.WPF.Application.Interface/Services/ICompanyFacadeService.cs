using FMS.WPF.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMS.WPF.Application.Interface.Services
{
    public interface ICompanyFacadeService
    {
        CompanyModel GetCompanyModel(int companyId);
        void SaveCompanyModel(CompanyModel model);
        void DeleteCompanyModel(int companyId);
        Task<IList<CompanySalesOrderListModel>> GetCompanySalesOrderListModelsAsync(int companyId);
        Task<IList<CompanySalesInvoiceListModel>> GetCompanySalesInvoiceListModelsAsync(int companyId);
    }
}