using FMS.Domain.Model;
using FMS.ServiceLayer.Interface.Dtos;
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
                pb => (options.BusinessLineId == null || pb.BusinessLineId == options.BusinessLineId) &&
                      (options.ProductStatusId == null || pb.ProductStatusId == options.ProductStatusId) &&
                      (options.ProductSourceTypeId == null || pb.ProductSourceTypeId == options.ProductSourceTypeId) &&
                      (options.ProductDestinationTypeId == null || pb.ProductDestinationTypeId == options.ProductDestinationTypeId) &&
                      (options.ProductMaterialId == null || pb.ProductMaterialId == options.ProductMaterialId) &&
                      (options.ProductTypeId == null || pb.ProductTypeId == options.ProductTypeId) &&
                      (options.ProductGroupId == null || pb.ProductGroupId == options.ProductGroupId) &&
                      (options.ProductBrandId == null || pb.ProductBrandId == options.ProductBrandId) &&
                      (options.ProductCollectionId == null || pb.ProductCollectionId == options.ProductCollectionId) &&
                      (options.ProductDesignId == null || pb.ProductDesignId == options.ProductDesignId);

            return productBases.Where(filter);
        }
    }
}
