using FMS.DAL.Interfaces;
using FMS.Domain.Model;
using FMS.WPF.Application.Extensions;
using FMS.WPF.Application.Interface.Dropdowns;
using FMS.WPF.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.WPF.Application.Dropdowns
{
    public class ProductDropdowns : IProductDropdowns
    {
        private IDataContextFactory _contextFactory;

        public ProductDropdowns(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;

            InitializeAsync();
        }

        #region properties
        public IList<BusinessLineDropdownModel> BusinessLines { get; set; }
        public IList<ProductStatusDropdownModel> ProductStatuses { get; set; }
        public IList<ProductSourceTypeDropdownModel> ProductSourceTypes { get; set; }
        public IList<ProductDestinationTypeDropdownModel> ProductDestinationTypes { get; set; }
        public IList<ProductMaterialDropdownModel> ProductMaterials { get; set; }
        public IList<ProductTypeDropdownModel> ProductTypes { get; set; }
        public IList<ProductGroupDropdownModel> ProductGroups { get; set; }
        public IList<ProductBrandDropdownModel> ProductBrands { get; set; }
        public IList<ProductCollectionDropdownModel> ProductCollections { get; set; }
        public IList<ProductDesignDropdownModel> ProductDesigns { get; set; }
        public IList<CompanySmallModel> ProductSourceCompanies { get; set; }
        public IList<CompanySmallModel> ProductDestCompanies { get; set; }
        #endregion

        public async void InitializeAsync()
        {
            using (var context = _contextFactory.CreateContext())
            {
                BusinessLines = await GetBusinessLinesAsync(context);
                ProductSourceTypes = await GetProductSourceTypesAsync(context);
                ProductDestinationTypes = await GetProductDestinationTypesAsync(context);
                ProductStatuses = await GetProductStatusesAsync(context);
                ProductMaterials = await GetProductMaterialsAsync(context);
                ProductTypes = await GetProductTypesAsync(context);
                ProductGroups = await GetProductGroupsAsync(context);
                ProductBrands = await GetProductBrandsAsync(context);
                ProductCollections = await GetProductCollectionsAsync(context);
                ProductDesigns = await GetProductDesignsAsync(context);

                ProductSourceCompanies = await GetProductSourceCompanies(context);
                ProductDestCompanies = await GetProductDestCompanies(context);
            }
        }

        #region Helpers
        private async Task<IList<BusinessLineDropdownModel>> GetBusinessLinesAsync(IDataContext context)
        {
            var list = await context.BusinessLines
                .AsNoTracking()
                .OrderBy(b => b.Name)
                .ProjectBetween<BusinessLine, BusinessLineDropdownModel>()
                .ToListAsync();

            list.Insert(0, new BusinessLineDropdownModel());

            return list;
        }

        private async Task<IList<ProductSourceTypeDropdownModel>> GetProductSourceTypesAsync(IDataContext context)
        {
            var list = await context.ProductSourceTypes
                .AsNoTracking()
                .OrderBy(st => st.Name)
                .ProjectBetween<ProductSourceType, ProductSourceTypeDropdownModel>()
                .ToListAsync();

            list.Insert(0, new ProductSourceTypeDropdownModel());

            return list;
        }

        private async Task<IList<ProductDestinationTypeDropdownModel>> GetProductDestinationTypesAsync(IDataContext context)
        {
            var list = await context.ProductDestinationTypes
                .AsNoTracking()
                .OrderBy(pd => pd.Name)
                .ProjectBetween<ProductDestinationType, ProductDestinationTypeDropdownModel>()
                .ToListAsync();

            list.Insert(0, new ProductDestinationTypeDropdownModel());

            return list;
        }

        private async Task<IList<ProductStatusDropdownModel>> GetProductStatusesAsync(IDataContext context)
        {
            var list = await context.ProductStatuses
                .AsNoTracking()
                .OrderBy(ps => ps.Name)
                .ProjectBetween<ProductStatus, ProductStatusDropdownModel>()
                .ToListAsync();

            list.Insert(0, new ProductStatusDropdownModel());

            return list;
        }

        private async Task<IList<ProductMaterialDropdownModel>> GetProductMaterialsAsync(IDataContext context)
        {
            var list = await context.ProductMaterials
                .AsNoTracking()
                .OrderBy(pm => pm.Name)
                .ProjectBetween<ProductMaterial, ProductMaterialDropdownModel>()
                .ToListAsync();

            list.Insert(0, new ProductMaterialDropdownModel());

            return list;
        }

        private async Task<IList<ProductTypeDropdownModel>> GetProductTypesAsync(IDataContext context)
        {
            var list = await context.ProductTypes
                .AsNoTracking()
                .OrderBy(pt => pt.Name)
                .ProjectBetween<ProductType, ProductTypeDropdownModel>()
                .ToListAsync();

            list.Insert(0, new ProductTypeDropdownModel());

            return list;
        }

        private async Task<IList<ProductGroupDropdownModel>> GetProductGroupsAsync(IDataContext context)
        {
            var list = await context.ProductGroups
                .AsNoTracking()
                .OrderBy(pg => pg.Name)
                .ProjectBetween<ProductGroup, ProductGroupDropdownModel>()
                .ToListAsync();

            list.Insert(0, new ProductGroupDropdownModel());

            return list;
        }

        private async Task<IList<ProductBrandDropdownModel>> GetProductBrandsAsync(IDataContext context)
        {
            var list = await context.ProductBrands
                .AsNoTracking()
                .OrderBy(pb => pb.Name)
                .ProjectBetween<ProductBrand, ProductBrandDropdownModel>()
                .ToListAsync();

            list.Insert(0, new ProductBrandDropdownModel());

            return list;
        }

        private async Task<IList<ProductCollectionDropdownModel>> GetProductCollectionsAsync(IDataContext context)
        {
            var list = await context.ProductCollections
                .AsNoTracking()
                .OrderBy(pb => pb.Name)
                .ProjectBetween<ProductCollection, ProductCollectionDropdownModel>()
                .ToListAsync();

            list.Insert(0, new ProductCollectionDropdownModel());

            return list;
        }

        private async Task<IList<ProductDesignDropdownModel>> GetProductDesignsAsync(IDataContext context)
        {
            var list = await context.ProductDesigns
                .AsNoTracking()
                .OrderBy(pd => pd.Name)
                .ProjectBetween<ProductDesign, ProductDesignDropdownModel>()
                .ToListAsync();

            list.Insert(0, new ProductDesignDropdownModel());

            return list;
        }

        private async Task<IList<CompanySmallModel>> GetProductSourceCompanies(IDataContext context)
        {
            var list = await context.Companies
                .AsNoTracking()
                .Where(c => c.CompanyTypesLink.Any(ctl => ctl.CompanyTypeId == 2))
                .OrderBy(c => c.Name)
                .ProjectBetween<Company, CompanySmallModel>()
                .ToListAsync();

            list.Insert(0, new CompanySmallModel());

            return list;
        }

        private async Task<IList<CompanySmallModel>> GetProductDestCompanies(IDataContext context)
        {
            var list = await context.Companies
                .AsNoTracking()
                .Where(c => c.CompanyTypesLink.Any(ctl => ctl.CompanyTypeId == 3))
                .OrderBy(c => c.Name)
                .ProjectBetween<Company, CompanySmallModel>()
                .ToListAsync();

            list.Insert(0, new CompanySmallModel());

            return list;
        }
        #endregion Helpers
    }
}
