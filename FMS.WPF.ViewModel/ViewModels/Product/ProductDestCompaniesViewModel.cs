﻿using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.ViewModels
{
    public class ProductDestCompaniesViewModel : ViewModelBase
    {
        public ProductDestCompaniesViewModel(ProductBaseModel productBaseModel)
        {
            Products = productBaseModel.Products;
        }

        #region properties
        public override string DisplayName => "Allhanke andmed";
        public IList<ProductModel> Products { get; private set; }
        #endregion
    }
}
