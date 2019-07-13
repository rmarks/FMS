using FMS.ServiceLayer.Dtos;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.Interfaces
{
    public interface IProductDropdownsService
    {
        Task<ProductListOptionsDropdownsDto> GetProductListOptionsDropdownsAsync();
    }
}
