using FMS.Domain.Model;
using FMS.ServiceLayer.Dtos;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace FMS.ServiceLayer.QueryObjects
{
    public static class ProductWhere
    {
        public static IQueryable<ProductBase> FilterBy(this IQueryable<ProductBase> productBases, ProductListOptionsDto options)
        {
            Expression<Func<ProductBase, bool>> filter =
                pb => (options.ProductSourceTypeId == null || pb.ProductSourceTypeId == options.ProductSourceTypeId) &&
                      (options.ProductDestinationTypeId == null || pb.ProductDestinationTypeId == options.ProductDestinationTypeId);

            return productBases.Where(filter);
        }
    }
}
