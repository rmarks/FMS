using FMS.ServiceLayer.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.Interfaces
{
    public interface IProductService
    {
        IList<ProductListDto> GetProductBases(ProductListOptionsDto options);

        Task<ProductDropdownsDto> GetProductDropdownsAsync();

        ProductBaseDto GetProductBase(int productBaseId);

        IList<ProductDto> GetProducts(int productBaseId);
    }
}
