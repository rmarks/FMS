using FMS.ServiceLayer.Dtos;
using System.Collections.Generic;

namespace FMS.ServiceLayer.Interfaces
{
    public interface IListProductsService
    {
        IList<ProductListDto> GetProducts(ProductListOptionsDto options);
    }
}
