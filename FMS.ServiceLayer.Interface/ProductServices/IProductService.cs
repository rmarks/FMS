using FMS.ServiceLayer.Interface.Dtos;
using System.Collections.Generic;

namespace FMS.ServiceLayer.Interface.Services
{
    public interface IProductService
    {
        IList<ProductListDto> GetProductBases(ProductListOptionsDto options);

        ProductBaseDto GetProductBase(int productBaseId);

        IList<ProductDto> GetProducts(int productBaseId);
    }
}
