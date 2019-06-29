using FMS.Domain.Model;
using FMS.WPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FMS.WPF.Application.QueryObjects
{
    public static class CompanyContactModelSelect
    {
        public static IQueryable<CompanyContactModel> MapCompanyContactQueryToModelQuery(this IQueryable<Contact> contacts)
        {
            return contacts.Select(c => new CompanyContactModel
            {
                ContactId = c.ContactId,
                CompanyId = c.CompanyId,
                ContactName = c.ContactName,
                Job = c.Job,
                Phone = c.Phone,
                Mobile = c.Mobile,
                Email = c.Email,
                CreatedOn = c.CreatedOn
            });
        }

        public static Contact MapModelToCompanyContact(this CompanyContactModel model)
        {
            return new Contact
            {
                ContactId = model.ContactId,
                CompanyId = model.CompanyId,
                ContactName = model.ContactName,
                Job = model.Job,
                Phone = model.Phone,
                Mobile = model.Mobile,
                Email = model.Email,
                CreatedOn = model.CreatedOn
            };
        }
    }
}
