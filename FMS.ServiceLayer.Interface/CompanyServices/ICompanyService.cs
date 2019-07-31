using FMS.ServiceLayer.Interface.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.Interface.Services
{
    public interface ICompanyService
    {
        Task<IList<CompanyListDto>> GetCompaniesAsync(string query);

        CompanyDto GetCompany(int companyId);
        CompanyDto SaveCompany(CompanyDto dto);
        void DeleteCompany(int companyId);

        Task<IList<CompanyAddressDto>> GetCompanyShippingAddressesAsync(int companyId);
        void DeleteCompanyAddress(int companyAddressId);
        int SaveCompanyAddress(CompanyAddressDto dto);

        Task<IList<CompanyContactDto>> GetCompanyContactsAsync(int companyId);
        void DeleteCompanyContact(int contactId);
        int SaveCompanyContact(CompanyContactDto dto);

        Task<IList<CompanySalesOrderListDto>> GetCompanySalesOrdersAsync(int companyId);

        Task<IList<CompanySalesInvoiceListDto>> GetCompanySalesInvoicesAsync(int companyId);
    }
}
