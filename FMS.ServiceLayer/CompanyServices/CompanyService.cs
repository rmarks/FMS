using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.ServiceLayer.Extensions;
using FMS.ServiceLayer.Interface.Dtos;
using FMS.ServiceLayer.Interface.Services;
using FMS.ServiceLayer.QueryObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.Services
{
    public class CompanyService : ICompanyService
    {
        private IDataContextFactory _contextFactory;

        public CompanyService(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        //company list
        public async Task<IList<CompanyListDto>> GetCompaniesAsync(string query)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return await context.CompanyAddresses
                    .AsNoTracking()
                    .FilterBy(query)
                    .OrderBy(a => a.Company.CompanyName)
                    .ProjectBetween<CompanyAddress, CompanyListDto>()
                    .ToListAsync();
            }
        }

        //company
        public async Task<CompanyDto> GetCompanyAsync(int companyId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return await context.Companies
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId)
                .ProjectBetween<Company, CompanyDto>()
                .FirstOrDefaultAsync();
            }
        }

        public CompanyDto SaveCompany(CompanyDto dto)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var company = dto.MapTo<Company>();

                context.Update(company);
                context.SaveChanges();

                return company.MapTo<CompanyDto>();
            }
        }

        public void DeleteCompany(int companyId)
        {
            using (var context = _contextFactory.CreateContext())
            {
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
        }

        //company shipping addresses
        public async Task<IList<CompanyAddressDto>> GetCompanyShippingAddressesAsync(int companyId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return await context.CompanyAddresses
                .AsNoTracking()
                .Where(a => a.CompanyId == companyId && a.IsShipping)
                .OrderBy(c => c.ConsigneeName)
                .ProjectBetween<CompanyAddress, CompanyAddressDto>()
                .ToListAsync();
            }
        }

        public int SaveCompanyAddress(CompanyAddressDto dto)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var companyAddress = dto.MapTo<CompanyAddress>();

                if (companyAddress.CompanyAddressId == 0)
                {
                    companyAddress.IsShipping = true;
                    companyAddress.CreatedOn = DateTime.Now;

                    context.Add(companyAddress);
                }
                else
                {
                    context.Update(companyAddress);
                }
                context.SaveChanges();

                return companyAddress.CompanyAddressId;
            }
        }

        public void DeleteCompanyAddress(int companyAddressId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                var companyAddress = context
                    .CompanyAddresses
                    .Find(companyAddressId);

                context.Remove(companyAddress);
                context.SaveChanges();
            }
        }

        //company contacts
        public async Task<IList<CompanyContactDto>> GetCompanyContactsAsync(int companyId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return await context.Contacts
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId)
                .OrderBy(c => c.ContactName)
                .ProjectBetween<Contact, CompanyContactDto>()
                .ToListAsync();
            }
        }

        public int SaveCompanyContact(CompanyContactDto dto)
        {
            var context = _contextFactory.CreateContext();

            var contact = dto.MapTo<Contact>();

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
            using (var context = _contextFactory.CreateContext())
            {
                var contact = context
                    .Contacts
                    .Find(contactId);

                context.Remove(contact);
                context.SaveChanges();
            }
        }

        //company sales orders
        public async Task<IList<CompanySalesOrderListDto>> GetCompanySalesOrdersAsync(int companyId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return await context.SalesOrders
                    .AsNoTracking()
                    .Where(o => o.CompanyId == companyId)
                    .OrderByDescending(o => o.OrderNo)
                    .MapToDto()
                    .ToListAsync();
            }
        }

        //company sales invoices
        public async Task<IList<CompanySalesInvoiceListDto>> GetCompanySalesInvoicesAsync(int companyId)
        {
            using (var context = _contextFactory.CreateContext())
            {
                return await context.SalesInvoices
                    .AsNoTracking()
                    .Where(o => o.CompanyId == companyId)
                    .OrderByDescending(o => o.InvoiceNo)
                    .MapToDto()
                    .ToListAsync();
            }
        }
    }
}
