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
using FMS.WPF.Application.Utils;

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
                return GetNewCompanyModel();

            using (var context = _contextFactory.CreateContext())
            {
                return context.Companies
                    .AsNoTracking()
                    .Include(c => c.Addresses)
                    .Include(c => c.Contacts)
                    .Include(c => c.CompanyTypesLink).ThenInclude(l => l.CompanyType)
                    .Where(c => c.CompanyId == companyId)
                    //.ProjectBetween<Company, CompanyModel>()
                    .Select(c => MappingFactory.MapTo<CompanyModel>(c))
                    .FirstOrDefault();
            }
        }

        public int Save(CompanyModel model)
        {
            model.Addresses.Add(model.BillingAddress);

            var company = (model.IsNew ? Add(model) : Update(model));

            return company.CompanyId;
        }

        public void Delete(int companyId)
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

        #region Helpers
        private Company Update(CompanyModel model)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var existingCompany = context.Companies
                    .Include(c => c.CompanyTypesLink)
                    .Include(c => c.Addresses)
                    .Include(c => c.Contacts)
                    .FirstOrDefault(c => c.CompanyId == model.CompanyId);

                context.Entry(existingCompany).CurrentValues.SetValues(model);

                //CompanyTypesLink
                foreach (var companyTypeLink in existingCompany.CompanyTypesLink.ToList())
                {
                    if (!model.CompanyTypesLink.Any(l => l.CompanyCompanyTypeId == companyTypeLink.CompanyCompanyTypeId))
                    {
                        existingCompany.CompanyTypesLink.Remove(companyTypeLink);
                    }
                }

                foreach (var companyTypeLinkModel in model.CompanyTypesLink)
                {
                    var existingCompanyTypeLink = existingCompany.CompanyTypesLink.FirstOrDefault(l => l.CompanyCompanyTypeId == companyTypeLinkModel.CompanyCompanyTypeId);

                    if (existingCompanyTypeLink == null)
                    {
                        existingCompany.CompanyTypesLink.Add(companyTypeLinkModel.MapTo<CompanyCompanyType>());
                    }
                    else
                    {
                        context.Entry(existingCompanyTypeLink).CurrentValues.SetValues(companyTypeLinkModel);
                    }
                }

                //Addresses
                foreach (var companyAddress in existingCompany.Addresses.ToList())
                {
                    if (!model.Addresses.Any(a => a.CompanyAddressId == companyAddress.CompanyAddressId))
                    {
                        existingCompany.Addresses.Remove(companyAddress);
                    }
                }

                foreach (var companyAddressModel in model.Addresses)
                {
                    var existingCompanyAddress = existingCompany.Addresses.FirstOrDefault(a => a.CompanyAddressId == companyAddressModel.CompanyAddressId);

                    if (existingCompanyAddress == null)
                    {
                        existingCompany.Addresses.Add(companyAddressModel.MapTo<CompanyAddress>());
                    }
                    else
                    {
                        context.Entry(existingCompanyAddress).CurrentValues.SetValues(companyAddressModel);
                    }
                }

                //Contacts
                foreach (var contact in existingCompany.Contacts.ToList())
                {
                    if (!model.Contacts.Any(c => c.ContactId == contact.ContactId))
                    {
                        existingCompany.Contacts.Remove(contact);
                    }
                }

                foreach (var companyContactModel in model.Contacts)
                {
                    var existingContact = existingCompany.Contacts.FirstOrDefault(c => c.ContactId == companyContactModel.ContactId);

                    if (existingContact == null)
                    {
                        existingCompany.Contacts.Add(companyContactModel.MapTo<Contact>());
                    }
                    else
                    {
                        context.Entry(existingContact).CurrentValues.SetValues(companyContactModel);
                    }
                }

                context.Update(existingCompany);
                context.SaveChanges();

                return existingCompany;
            }
        }

        private Company Add(CompanyModel model)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var company = model.MapTo<Company>();
                
                company.CreatedOn = DateTime.Now;
                var billingAddress = company.Addresses.FirstOrDefault(a => a.IsBilling);
                billingAddress.CreatedOn = DateTime.Now;

                context.Add(company);
                context.SaveChanges();

                return company;
            }
        }

        private CompanyModel GetNewCompanyModel()
        {
            return new CompanyModel
            {
                BillingAddress = new CompanyAddressModel
                {
                    IsBilling = true,
                }
            };
        }
        #endregion
    }
}
