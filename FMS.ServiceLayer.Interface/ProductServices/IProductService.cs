using FMS.ServiceLayer.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.Interfaces
{
    public interface IProductService
    {
        IList<ProductListDto> GetProducts(ProductListOptionsDto options);

        Task<ProductDropdownsDto> GetProductDropdownsAsync();

        ProductInfoDto GetProduct(int productBaseId);
    }
}
