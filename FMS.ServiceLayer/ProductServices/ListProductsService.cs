using FMS.DAL.EFCore;
using FMS.Domain.Model;
using FMS.ServiceLayer.Interfaces.ProductServices;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.ProductServices
{
    public class ListProductsService : IListProductsService
    {
        private readonly IDataContext _context;

        public ListProductsService(IDataContext context)
        {
            _context = context;
        }

        public IQueryable<ProductBase> GetProductBases()
        {
            return _context.ProductBases
                .AsNoTracking()
                .OrderBy(p => p.ProductBaseCode);
        }
    }
}
