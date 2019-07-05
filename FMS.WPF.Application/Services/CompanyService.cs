using FMS.DAL.EFCore;
using FMS.ServiceLayer.CompanyServices;
using FMS.WPF.Application.QueryObjects;
using FMS.WPF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.WPF.Application.Services
{
    public class CompanyService : ICompanyService
    {
        private IDataContextFactory _contextFactory;

        public CompanyService(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        //--- CompanyList
        public async Task<List<CompanyListModel>> GetCompanyListAsync(string query)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var listService = new ListCompaniesService(context);

                return await listService
                    .GetCompaniesWithBillingAddress(query)
                    .MapToCompanyListModel()
                    .ToListAsync();
            }
        }

        //--- CompanyBasics
        public CompanyBasicsModel GetCompanyBasicsModel(int companyId)
        {
            var context = new SQLServerDbContext();

            var model = context.Companies
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId)
                .MapToCompanyBasicsModel()
                .FirstOrDefault();

            if (model != null)
            {
                model.BillingAddress = GetCompanyAddressModelForBilling(companyId);
            }

            return model;
        }

        public CompanyBasicsModel SaveCompanyBasics(CompanyBasicsModel model)
        {
            var context = new SQLServerDbContext();

            var company = model.MapToCompanyBasics();

            context.Update(company);
            context.SaveChanges();

            return GetCompanyBasicsModel(company.CompanyId);
        }

        public void DeleteCompanyBasics(int companyId)
        {
            var context = new SQLServerDbContext();

            //var company = context.Companies
            //    .Include(c => c.Addresses)
            //    .Include(c => c.Contacts)
            //    .FirstOrDefault(c => c.CompanyId == companyId);

            var company = context.Companies.Find(companyId);
            context.Remove(company);

            foreach (var address in context.CompanyAddresses.Where(a => a.CompanyId == companyId))
            {
                context.Remove(address);
            }

            foreach (var contact in context.Contacts.Where(c => c.CompanyId == companyId))
            {
                context.Remove(contact);
            }

            foreach (var salesOrder in context.SalesOrders.Where(o => o.CompanyId == companyId))
            {
                context.Remove(salesOrder);
            }

            foreach (var salesInvoice in context.SalesInvoices.Where(i => i.CompanyId == companyId))
            {
                context.Remove(salesInvoice);
            }

            context.SaveChanges();
        }

        //--- CompanyAddresses
        public IList<CompanyAddressModel> GetCompanyAddressModelsForShipping(int companyId)
        {
            var context = new SQLServerDbContext();

            return context.CompanyAddresses
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId && c.IsShipping)
                .MapToCompanyAddressModel()
                .OrderBy(c => c.ConsigneeName)
                .ToList();
        }

        public CompanyAddressModel GetCompanyAddressModelForBilling(int companyId)
        {
            var context = new SQLServerDbContext();

            return context.CompanyAddresses
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId && c.IsBilling)
                .MapToCompanyAddressModel()
                .FirstOrDefault();
        }

        public int SaveCompanyAddress(CompanyAddressModel model)
        {
            var context = new SQLServerDbContext();

            var address = model.MapToCompanyAddress();

            if (address.CompanyAddressId == 0)
            {
                address.IsShipping = true;
                address.CreatedOn = DateTime.Now;

                context.Add(address);
            }
            else
            {
                context.Update(address);
            }
            context.SaveChanges();

            return address.CompanyAddressId;
        }

        public void DeleteCompanyAddress(int companyAddressId)
        {
            var context = new SQLServerDbContext();

            var companyAddress = context.CompanyAddresses.Find(companyAddressId);

            context.Remove(companyAddress);
            context.SaveChanges();
        }

        //--- CompanyContacts
        public IList<CompanyContactModel> GetCompanyContactModels(int companyId)
        {
            var context = new SQLServerDbContext();

            return context.Contacts
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId)
                .MapToCompanyContactModel()
                .OrderBy(c => c.ContactName)
                .ToList();
        }

        public int SaveCompanyContact(CompanyContactModel model)
        {
            var context = new SQLServerDbContext();

            var contact = model.MapToCompanyContact();

            if (contact.ContactId == 0)
            {
                contact.CreatedOn = DateTime.Now;

                context.Add(contact);
            }
            else
            {
                context.Update(contact);
            }

            context.SaveChanges();

            return contact.ContactId;
        }

        public void DeleteCompanyContact(int contactId)
        {
            var context = new SQLServerDbContext();

            var contact = context.Contacts.Find(contactId);

            context.Remove(contact);
            context.SaveChanges();
        }

        //--- CompanySalesOrders
        public async Task<IList<CompanySalesOrderListModel>> GetCompanySalesOrderListAsync(int companyId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var listService = new ListCompanySalesOrdersService(context);

                return await listService
                    .GetCompanySalesOrders(companyId)
                    .MapToCompanySalesOrderListModel()
                    .ToListAsync();
            }
        }

        //--- CompanySalesInvoices
        public async Task<IList<CompanySalesInvoiceListModel>> GetCompanySalesInvoiceListAsync(int companyId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var listService = new ListCompanySalesInvoicesService(context);

                return await listService
                    .GetCompanySalesInvoices(companyId)
                    .MapToCompanySalesInvoiceListModel()
                    .ToListAsync();
            }
        }
    }
}
