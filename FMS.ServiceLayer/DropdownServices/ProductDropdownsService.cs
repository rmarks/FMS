using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using FMS.ServiceLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.Services
{
    public class ProductDropdownsService : IProductDropdownsService
    {
        private IDataContextFactory _contextFactory;

        public ProductDropdownsService(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<ProductListOptionsDropdownsDto> GetProductListOptionsDropdownsAsync()
        {
            using (var context = _contextFactory.CreateContext())
            {
                var dto = new ProductListOptionsDropdownsDto();

                dto.BusinessLines = await GetBusinessLinesAsync(context);
                dto.ProductSourceTypes = await GetProductSourceTypesAsync(context);
                dto.ProductDestinationTypes = await GetProductDestinationTypesAsync(context);
                dto.ProductStatuses = await GetProductStatusesAsync(context);
                dto.ProductMaterials = await GetProductMaterialsAsync(context);
                dto.ProductTypes = await GetProductTypesAsync(context);
                dto.ProductGroups = await GetProductGroupsAsync(context);
                dto.ProductBrands = await GetProductBrandsAsync(context);
                dto.ProductCollections = await GetProductCollectionsAsync(context);
                dto.ProductDesigns = await GetProductDesignsAsync(context);

                return dto;
            }
        }

        #region Helpers
        private async Task<IList<BusinessLineDropdownDto>> GetBusinessLinesAsync(IDataContext context)
        {
            var list = await context.BusinessLines
                .AsNoTracking()
                .OrderBy(b => b.Name)
                .ProjectBetween<BusinessLine, BusinessLineDropdownDto>()
                .ToListAsync();

            list.Insert(0, new BusinessLineDropdownDto());

            return list;
        }

        private async Task<IList<ProductSourceTypeDropdownDto>> GetProductSourceTypesAsync(IDataContext context)
        {
            var list = await context.ProductSourceTypes
                .AsNoTracking()
                .OrderBy(st => st.Name)
                .ProjectBetween<ProductSourceType, ProductSourceTypeDropdownDto>()
                .ToListAsync();

            list.Insert(0, new ProductSourceTypeDropdownDto());

            return list;
        }

        private async Task<IList<ProductDestinationTypeDropdownDto>> GetProductDestinationTypesAsync(IDataContext context)
        {
            var list = await context.ProductDestinationTypes
                .AsNoTracking()
                .OrderBy(pd => pd.Name)
                .ProjectBetween<ProductDestinationType, ProductDestinationTypeDropdownDto>()
                .ToListAsync();

            list.Insert(0, new ProductDestinationTypeDropdownDto());

            return list;
        }

        private async Task<IList<ProductStatusDropdownDto>> GetProductStatusesAsync(IDataContext context)
        {
            var list = await context.ProductStatuses
                .AsNoTracking()
                .OrderBy(ps => ps.Name)
                .ProjectBetween<ProductStatus, ProductStatusDropdownDto>()
                .ToListAsync();

            list.Insert(0, new ProductStatusDropdownDto());

            return list;
        }

        private async Task<IList<ProductMaterialDropdownDto>> GetProductMaterialsAsync(IDataContext context)
        {
            var list = await context.ProductMaterials
                .AsNoTracking()
                .OrderBy(pm => pm.Name)
                .ProjectBetween<ProductMaterial, ProductMaterialDropdownDto>()
                .ToListAsync();

            list.Insert(0, new ProductMaterialDropdownDto());

            return list;
        }

        private async Task<IList<ProductTypeDropdownDto>> GetProductTypesAsync(IDataContext context)
        {
            var list = await context.ProductTypes
                .AsNoTracking()
                .OrderBy(pt => pt.Name)
                .ProjectBetween<ProductType, ProductTypeDropdownDto>()
                .ToListAsync();

            list.Insert(0, new ProductTypeDropdownDto());

            return list;
        }

        private async Task<IList<ProductGroupDropdownDto>> GetProductGroupsAsync(IDataContext context)
        {
            var list = await context.ProductGroups
                .AsNoTracking()
                .OrderBy(pg => pg.Name)
                .ProjectBetween<ProductGroup, ProductGroupDropdownDto>()
                .ToListAsync();

            list.Insert(0, new ProductGroupDropdownDto());

            return list;
        }

        private async Task<IList<ProductBrandDropdownDto>> GetProductBrandsAsync(IDataContext context)
        {
            var list = await context.ProductBrands
                .AsNoTracking()
                .OrderBy(pb => pb.Name)
                .ProjectBetween<ProductBrand, ProductBrandDropdownDto>()
                .ToListAsync();

            list.Insert(0, new ProductBrandDropdownDto());

            return list;
        }

        private async Task<IList<ProductCollectionDropdownDto>> GetProductCollectionsAsync(IDataContext context)
        {
            var list = await context.ProductCollections
                .AsNoTracking()
                .OrderBy(pb => pb.Name)
                .ProjectBetween<ProductCollection, ProductCollectionDropdownDto>()
                .ToListAsync();

            list.Insert(0, new ProductCollectionDropdownDto());

            return list;
        }

        private async Task<IList<ProductDesignDropdownDto>> GetProductDesignsAsync(IDataContext context)
        {
            var list = await context.ProductDesigns
                .AsNoTracking()
                .OrderBy(pd => pd.Name)
                .ProjectBetween<ProductDesign, ProductDesignDropdownDto>()
                .ToListAsync();

            list.Insert(0, new ProductDesignDropdownDto());

            return list;
        }
        #endregion Helpers
    }
}
