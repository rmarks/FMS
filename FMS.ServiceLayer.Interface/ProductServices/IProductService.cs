using FMS.ServiceLayer.Interface.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.Interface.Services
{
    public interface IProductService
    {
        IList<ProductListDto> GetProductBases(ProductListOptionsDto options);
        ProductBaseDto GetProductBase(int productBaseId);
        //Task<IList<ProductDto>> GetProductSources(int productBaseId);
        //Task<IList<ProductCompanyDto>> GetProductDestinations(int productBaseId);
        Task<IList<PriceListDto>> GetProductPriceLists(int productBaseId);
    }
}
