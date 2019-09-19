﻿using FMS.WPF.Models;
using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class ProductSourceCompaniesViewModel : ViewModelBase
    {
        public ProductSourceCompaniesViewModel(ProductBaseModel model)
        {
            Model = model;
            InitializeProducts();
        }

        #region properties
        public override string DisplayName => "Tarne andmed";
        public ProductBaseModel Model { get; set; }
        public ObservableCollection<ProductModel> Products { get; private set; }
        public bool IsEditMode { get; set; }
        #endregion

        #region helpers
        private void InitializeProducts()
        {
            Products = new ObservableCollection<ProductModel>(Model.Products);
        }
        #endregion

        #region event handlers
        public void OnProductEditCancelled()
        {
            InitializeProducts();
        }
        #endregion
    }
}
