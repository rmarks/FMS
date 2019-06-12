using FMS.DAL.EFCore;
using FMS.WPF.Application.QueryObjects;
using FMS.WPF.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.Services
{
    public class CompanyService : ICompanyService
    {
        //--- CompanyList
        public List<CompanyListModel> GetCompanyList()
        {
            var context = new FMSDbContext();

            return context.Companies
                .AsNoTracking()
                .Select(c => new
                {
                    Company = c,
                    Address = c.Addresses.FirstOrDefault(a => a.IsBilling)
                })
                .Select(c => new CompanyListModel
                {
                    CompanyId = c.Company.CompanyId,
                    CompanyCode = c.Company.CompanyCode,
                    CompanyName = c.Company.CompanyName,
                    CountryName = c.Address.Country.CountryName,
                    City = c.Address.City,
                    Address = c.Address.Address
                })
                .OrderBy(c => c.CompanyName)
                .ToList();
        }

        //--- CompanyBasics
        public CompanyBasicsModel GetCompanyBasicsModel(int companyId)
        {
            var context = new FMSDbContext();

            var model = context.Companies
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId)
                .MapCompanyBasicsQueryToModelQuery()
                .FirstOrDefault();

            if (model != null)
            {
                model.BillingAddress = GetCompanyAddressModelForBilling(companyId);
            }

            return model;
        }

        public CompanyBasicsModel SaveCompanyBasics(CompanyBasicsModel model)
        {
            var context = new FMSDbContext();

            var company = model.MapModelToCompanyBasics();

            context.Update(company);
            context.SaveChanges();

            return GetCompanyBasicsModel(company.CompanyId);
        }

        public void DeleteCompanyBasics(int companyId)
        {
            var context = new FMSDbContext();

            var company = context.Companies
                .Include(c => c.Addresses)
                .Include(c => c.Contacts)
                .FirstOrDefault(c => c.CompanyId == companyId);

            context.Remove(company);
            context.SaveChanges();
        }

        //--- CompanyAddresses
        public IList<CompanyAddressModel> GetCompanyAddressModelsForShipping(int companyId)
        {
            var context = new FMSDbContext();

            return context.CompanyAddresses
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId && c.IsShipping)
                .MapCompanyAddressQueryToModelQuery()
                .ToList();
        }

        public CompanyAddressModel GetCompanyAddressModelForBilling(int companyId)
        {
            var context = new FMSDbContext();

            return context.CompanyAddresses
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId && c.IsBilling)
                .MapCompanyAddressQueryToModelQuery()
                .FirstOrDefault();
        }

        public int SaveCompanyAddress(CompanyAddressModel model)
        {
            var context = new FMSDbContext();

            var address = model.MapModelToCompanyAddress();

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
            var context = new FMSDbContext();

            var companyAddress = context.CompanyAddresses.Find(companyAddressId);

            context.Remove(companyAddress);
            context.SaveChanges();
        }

        //--- CompanyContacts
        public IList<CompanyContactModel> GetCompanyContactModels(int companyId)
        {
            var context = new FMSDbContext();

            return context.Contacts
                .AsNoTracking()
                .Where(c => c.CompanyId == companyId)
                .Select(c => new CompanyContactModel
                {
                    ContactId = c.ContactId,
                    ContactName = c.ContactName,
                    Job = c.Job,
                    Phone = c.Phone,
                    Mobile = c.Mobile,
                    Email = c.Email,
                    CompanyId = c.CompanyId
                })
                .ToList();
        }
    }
}
