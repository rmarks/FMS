using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using FMS.WPF.ViewModel.Helpers;

namespace FMS.WPF.ViewModels
{
    public class ProductBaseViewModel : GenericEditableViewModelBase<ProductBaseModel>
    {
        private IProductFacadeService _productFacadeService;

        public ProductBaseViewModel(int productBaseId,
                                    IProductFacadeService productFacadeService)
        {
            _productFacadeService = productFacadeService;

            Model = _productFacadeService.GetProductBaseModel(productBaseId);

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
