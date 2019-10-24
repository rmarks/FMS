using FMS.WPF.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMS.WPF.Application.Interface.Services
{
    public interface ICompanyFacadeService
    {
        CompanyModel GetCompanyModel(int companyId);
        int Save(CompanyModel model);
        void Delete(int companyId);
        Task<IList<CompanySalesOrderListModel>> GetCompanySalesOrderListModelsAsync(int companyId);
        Task<IList<CompanySalesInvoiceListModel>> GetCompanySalesInvoiceListModelsAsync(int companyId);
    }
}