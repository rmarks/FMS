using System.Collections.Generic;
using FMS.WPF.Model;

namespace FMS.WPF.Application.Services
{
    public interface ICompanyContactsService
    {
        IList<CompanyContactModel> GetCompanyContactModels(int companyId);
    }
}