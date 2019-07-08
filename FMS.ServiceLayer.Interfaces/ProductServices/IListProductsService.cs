using FMS.Domain.Model;
using System.Linq;

namespace FMS.ServiceLayer.Interfaces.ProductServices
{
    public interface IListProductsService
    {
        IQueryable<ProductBase> GetProductBases();
    }
}
