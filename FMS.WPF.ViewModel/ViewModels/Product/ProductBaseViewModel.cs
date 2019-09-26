using FMS.WPF.Models;
using FMS.WPF.ViewModel.Commands;
using System.Windows.Input;

namespace FMS.WPF.ViewModels
{
    public class ProductBaseViewModel : ViewModelBase
    {
        public ProductBaseViewModel(ProductBaseModel model)
        {
            Model = model;
        }

        #region properties
        public override string DisplayName => "Üldandmed";
        public ProductBaseModel Model { get; set; }
        public bool IsEditMode { get; set; }
        #endregion

        #region commands
        public ICommand AddProductCommand => new RelayCommand(AddProduct, () => CanAddProduct);
        public bool CanAddProduct => (IsEditMode && (Model.Products.Count == 0));
        private void AddProduct()
        {
            var productModel = new ProductModel
            {
                ProductBaseId = Model.ProductBaseId,
                ProductCode = Model.ProductBaseCode,
                ProductName = Model.ProductBaseName,
                ProductSource = Model.IsPurchased ? new ProductCompanyModel() : null,
                ProductDestination = Model.IsForOutsource ? new ProductCompanyModel() : null
            };
            Model.OCProducts.Add(productModel);
        }
        #endregion
    }
}
