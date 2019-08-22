using FMS.ServiceLayer.Interface.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.Interface.Services
{
    public interface IProductService
    {
        IList<ProductListDto> GetProductBases(ProductListOptionsDto options);
        ProductBaseDto GetProductBase(int productBaseId);
        Task<IList<ProductCompanyDto>> GetProductCompaniesForSource(int productBaseId);
        Task<IList<ProductCompanyDto>> GetProductCompaniesForDest(int productBaseId);
        Task<IList<PriceListDto>> GetProductPriceLists(int productBaseId);
    }
}
