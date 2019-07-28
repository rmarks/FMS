using FMS.ServiceLayer.Interface.Dtos;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.Interface.Services
{
    public interface IProductDropdownsService
    {
        Task<ProductDropdownsDto> GetProductDropdownsAsync();
    }
}
