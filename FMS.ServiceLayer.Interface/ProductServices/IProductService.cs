using FMS.ServiceLayer.Interface.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.Interface.Services
{
    public interface IProductService
    {
        IList<ProductListDto> GetProductBases(ProductListOptionsDto options);

        Task<ProductDropdownsDto> GetProductDropdownsAsync();

        ProductBaseDto GetProductBase(int productBaseId);

        IList<ProductDto> GetProducts(int productBaseId);
    }
}
