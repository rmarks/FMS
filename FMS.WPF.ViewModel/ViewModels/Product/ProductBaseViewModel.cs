using FMS.WPF.Models;
using System.Collections.ObjectModel;

namespace FMS.WPF.ViewModels
{
    public class ProductBaseViewModel : ViewModelBase
    {
        public ProductBaseViewModel(ProductBaseModel model)
        {
            Model = model;
            InitializeProducts();
        }

        #region properties
        public override string DisplayName => "Üldandmed";
        public ProductBaseModel Model { get; set; }
        public bool IsProductVariationsVisible => Model.ProductVariationsLink?.Count != 0;
        public bool IsEditMode { get; set; }
        public ObservableCollection<ProductModel> Products { get; set; }
        #endregion

        #region event handlers
        public void OnProductEditCancelled()
        {
            InitializeProducts();
        }
        #endregion

        #region helpers
        private void InitializeProducts()
        {
            Products = new ObservableCollection<ProductModel>(Model.Products);
        }
        #endregion
    }
}
