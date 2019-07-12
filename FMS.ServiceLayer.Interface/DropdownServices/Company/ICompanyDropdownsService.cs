using FMS.ServiceLayer.Dtos;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.Interfaces
{
    public interface ICompanyDropdownsService
    {
        Task<CompanyDropdownsDto> GetCompanyDropdownsAsync();
    }
}
