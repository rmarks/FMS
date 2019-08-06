using FMS.ServiceLayer.Interface.Dtos;
using FMS.ServiceLayer.Interface.Services;
using FMS.WPF.Application.Extensions;
using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.WPF.Application.Services
{
    public class CompanyAppService : ICompanyAppService
    {
        private readonly ICompanyService _companyService;

        public CompanyAppService(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        #region company list
        public IList<CompanyListModel> GetCompanyListModels(string query)
        {
            return _companyService
                .GetCompanies(query)
                .MapList<CompanyListDto, CompanyListModel>()
                .ToList();
        }
        #endregion

        #region company basics
        public CompanyBasicsModel GetCompanyBasicsModel(int companyId)
        {
            if (companyId == 0)
            {
                return new CompanyBasicsModel();
            }

            return _companyService
                .GetCompany(companyId)
                .MapTo<CompanyBasicsModel>();
        }

        public CompanyBasicsModel SaveCompanyBasicsModel(CompanyBasicsModel model)
        {
            return _companyService
                .SaveCompany(model.MapTo<CompanyDto>())
                .MapTo<CompanyBasicsModel>();
        }

        public void DeleteCompanyBasicsModel(int companyId)
        {
            _companyService.DeleteCompany(companyId);
        }
        #endregion

        #region company shipping addresses
        public async Task<IList<CompanyAddressModel>> GetCompanyAddressModelsAsync(int companyId)
        {
            if (companyId == 0)
            {
                return null;
            }

            var dtos = await _companyService
                .GetCompanyShippingAddressesAsync(companyId);

            return dtos.MapList<CompanyAddressDto, CompanyAddressModel>();
        }

        public int SaveCompanyAddressModel(CompanyAddressModel model)
        {
            return _companyService.SaveCompanyAddress(model.MapTo<CompanyAddressDto>());
        }

        public void DeleteCompanyAddressModel(int companyId)
        {
            _companyService.DeleteCompanyAddress(companyId);
        }
        #endregion

        #region company contacts
        public async Task<IList<CompanyContactModel>> GetCompanyContactModelsAsync(int companyId)
        {
            if (companyId == 0)
            {
                return null;
            }

            var dtos = await _companyService
                .GetCompanyContactsAsync(companyId);

            return dtos.MapList<CompanyContactDto, CompanyContactModel>();
        }

        public int SaveCompanyContactModel(CompanyContactModel model)
        {
            return _companyService.SaveCompanyContact(model.MapTo<CompanyContactDto>());
        }

        public void DeleteCompanyContactModel(int companyId)
        {
            _companyService.DeleteCompanyContact(companyId);
        }
        #endregion

        #region company sales orders
        public async Task<IList<CompanySalesOrderListModel>> GetCompanySalesOrderListModelsAsync(int companyId)
        {
            if (companyId == 0)
            {
                return null;
            }

            var dtos = await _companyService
                .GetCompanySalesOrdersAsync(companyId);

            return dtos.MapList<CompanySalesOrderListDto, CompanySalesOrderListModel>();
        }
        #endregion

        #region company sales invoices
        public async Task<IList<CompanySalesInvoiceListModel>> GetCompanySalesInvoiceListModelsAsync(int companyId)
        {
            if (companyId == 0)
            {
                return null;
            }

            var dtos = await _companyService
                .GetCompanySalesInvoicesAsync(companyId);

            return dtos.MapList<CompanySalesInvoiceListDto, CompanySalesInvoiceListModel>();
        }
        #endregion
    }
}
