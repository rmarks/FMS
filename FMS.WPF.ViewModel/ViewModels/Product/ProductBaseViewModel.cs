using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.ViewModel.Helpers;

namespace FMS.WPF.ViewModels
{
    public class ProductBaseViewModel : GenericEditableViewModelBase<ProductBaseModel>
    {
        private IProductVmService _productService;

        public ProductBaseViewModel(int productBaseId,
                                    IProductVmService productService)
        {
            _productService = productService;

            Model = _productService.GetProductBaseModel(productBaseId);
            InitializeDropdownsAsync();
            PictureLocation = PictureLocationHelper.GetPictureLocation(Model.ProductBaseCode);
        }

        #region properties
        public override string DisplayName => "Üldandmed";

        public string PictureLocation { get; }
        #endregion

        #region overrides
        protected override bool SaveItem(ProductBaseModel model)
        {
            return true;
        }
        #endregion

        #region helpers
        private void InitializeDropdownsAsync()
        {
            _productService.SetProductBaseDropdownsAsync(Model);
        }
        #endregion
    }
}
