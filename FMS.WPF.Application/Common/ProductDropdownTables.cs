using System.Collections.Generic;
using FMS.DAL.EFCore;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.ProductServices;
using FMS.WPF.Application.QueryObjects;
using FMS.WPF.Models;

namespace FMS.WPF.Application.Common
{
    public class ProductDropdownTables : IProductDropdownTables
    {
        private IDataContextFactory _contextFactory;

        public ProductDropdownTables(IDataContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        private IList<ProductSourceTypeModel> _productSourceTypes;
        public IList<ProductSourceTypeModel> ProductSourceTypes => _productSourceTypes ?? (_productSourceTypes = GetProductSourceTypes());

        private IList<ProductDestinationTypeModel> _productDestinationTypes;
        public IList<ProductDestinationTypeModel> ProductDestinationTypes => _productDestinationTypes ?? (_productDestinationTypes = GetProductDestinationTypes());

        private IList<ProductBrandModel> _productBrands;
        public IList<ProductBrandModel> ProductBrands => _productBrands;

        private IList<ProductCollectionModel> _productCollections;
        public IList<ProductCollectionModel> ProductCollections => _productCollections;

        #region Helpers
        private IList<ProductSourceTypeModel> GetProductSourceTypes()
        {
            using (var context = _contextFactory.CreateContext())
            {
                var listService = new ListProductSourceTypesService(context);

                return listService
                    .GetProductSourceTypes()
                    .MapBetween<ProductSourceTypeDto, ProductSourceTypeModel>();
            }
        }

        private IList<ProductDestinationTypeModel> GetProductDestinationTypes()
        {
            using (var context = _contextFactory.CreateContext())
            {
                var listService = new ListProductDestinationTypesService(context);

                return listService
                    .GetProductDestinationTypes()
                    .MapBetween<ProductDestinationTypeDto, ProductDestinationTypeModel>();
            }
        }
        #endregion Helpers
    }
}
