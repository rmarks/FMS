using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.ViewModel.Helpers;

namespace FMS.WPF.ViewModels
{
    public class ProductBaseViewModel : GenericEditableViewModelBase<ProductBaseModel>
    {
        private IProductAppService _productAppService;

        public ProductBaseViewModel(int productBaseId,
                                    IProductAppService productAppService)
        {
            _productAppService = productAppService;

            Model = _productAppService.GetProductBaseModel(productBaseId);

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
    }
}
