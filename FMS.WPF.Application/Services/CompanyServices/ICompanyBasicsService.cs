using FMS.WPF.Model;

namespace FMS.WPF.Application.Services
{
    public interface ICompanyBasicsService
    {
        CompanyBasicsModel GetCompanyBasicsModel(int companyId);
    }
}