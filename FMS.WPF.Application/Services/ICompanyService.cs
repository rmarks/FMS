using System.Collections.Generic;
using FMS.WPF.Models;

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
        int SaveCompanyContact(CompanyContactModel model);
        void DeleteCompanyContact(int contactId);

        IList<CompanySalesOrderListModel> GetCompanySalesOrderList(int companyId);

        IList<CompanySalesInvoiceListModel> GetCompanySalesInvoiceList(int companyId);
    }
}