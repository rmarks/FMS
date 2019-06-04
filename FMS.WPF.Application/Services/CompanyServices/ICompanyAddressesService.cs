using System.Collections.Generic;
using FMS.WPF.Model;

namespace FMS.WPF.Application.Services
{
    public interface ICompanyAddressesService
    {
        IList<CompanyAddressModel> GetCompanyAddressModels(int companyId);
    }
}