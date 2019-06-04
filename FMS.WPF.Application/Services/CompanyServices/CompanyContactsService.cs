using FMS.DAL.EFCore;
using FMS.WPF.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FMS.WPF.Application.Services
{
    public class CompanyContactsService : ICompanyContactsService
    {
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
