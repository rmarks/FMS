using FMS.ServiceLayer.Interface.Dtos;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.Interface.Services
{
    public interface ICompanyDropdownsService
    {
        Task<CompanyDropdownsDto> GetCompanyDropdownsAsync();
    }
}
