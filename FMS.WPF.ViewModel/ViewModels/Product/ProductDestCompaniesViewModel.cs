﻿using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using System.Collections.Generic;

namespace FMS.WPF.ViewModels
{
    public class ProductDestCompaniesViewModel : ViewModelBase
    {
        private readonly IProductFacadeService _productFacadeService;

        public ProductDestCompaniesViewModel(int productBaseId,
                                             IProductFacadeService productFacadeService)
        {
            _productFacadeService = productFacadeService;
            InitializeProducts(productBaseId);
        }

        #region properties
        public override string DisplayName => "Allhanke andmed";

        public IList<ProductCompanyModel> Products { get; private set; }
        #endregion

        #region helpers
        private async void InitializeProducts(int productBaseId)
        {
            Products = await _productFacadeService.GetProductCompanyModelsForDest(productBaseId);
        }
        #endregion
    }
}
