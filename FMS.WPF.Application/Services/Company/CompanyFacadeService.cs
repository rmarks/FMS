using FMS.WPF.Application.Extensions;
using FMS.WPF.Models;
using FMS.WPF.Application.Interface.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using FMS.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using FMS.Domain.Model;
using System;
using FMS.WPF.Application.Services.QueryObjects;

namespace FMS.WPF.Application.Services
{
    public class CompanyFacadeService : ICompanyFacadeService
    {
        private readonly IDataContextFactory _contextFactory;

        public CompanyFacadeService(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        #region company model
        public CompanyModel GetCompanyModel(int companyId)
        {
            if (companyId == 0) 
                return AddCompanyModel();

            using (var context = _contextFactory.CreateContext())
            {
                return context.Companies
                    .AsNoTracking()
                    .Where(c => c.CompanyId == companyId)
                    .ProjectBetween<Company, CompanyModel>()
                    .FirstOrDefault();
            }
        }

        private CompanyModel AddCompanyModel()
        {
            return new CompanyModel
            {
                CreatedOn = DateTime.Now,
                BillingAddress = new CompanyAddressModel
                {
                    IsBilling = true,
                    CreatedOn = DateTime.Now
                }
            };
        }

        public void SaveCompanyModel(CompanyModel model)
        {
            model.Addresses = model.OCAddresses.ToList();
            model.Contacts = model.OCContacts.ToList();
            model.Addresses.Add(model.BillingAddress);

            var company = model.MapTo<Company>();

            using (var context = _contextFactory.CreateContext())
            {
                context.Update(company);
                context.SaveChanges();
            }
        }

        public void DeleteCompanyModel(int companyId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var company = context.Companies
                    .Include(c => c.Addresses)
                    .Include(c => c.Contacts)
                    .Include(c => c.CompanyTypesLink)
                    .FirstOrDefault(c => c.CompanyId == companyId);

                context.Remove(company);
                context.SaveChanges();
            }
        }
        #endregion

        #region company sales orders
        public async Task<IList<CompanySalesOrderListModel>> GetCompanySalesOrderListModelsAsync(int companyId)
        {
            if (companyId == 0) return null;

            using (var context = _contextFactory.CreateContext())
            {
                return await context.SalesOrders
                    .AsNoTracking()
                    .Where(o => o.CompanyId == companyId)
                    .OrderByDescending(o => o.OrderNo)
                    .MapToModel()
                    .ToListAsync();
            }
        }
        #endregion

        #region company sales invoices
        public async Task<IList<CompanySalesInvoiceListModel>> GetCompanySalesInvoiceListModelsAsync(int companyId)
        {
            if (companyId == 0) return null;

            using (var context = _contextFactory.CreateContext())
            {
                return await context.SalesInvoices
                    .AsNoTracking()
                    .Where(o => o.CompanyId == companyId)
                    .OrderByDescending(o => o.InvoiceNo)
                    .MapToModel()
                    .ToListAsync();
            }
        }
        #endregion
    }
}
