using FMS.WPF.Application.Interface.Models;
using FMS.WPF.ViewModel.Helpers;

namespace FMS.WPF.ViewModels
{
    public class ProductBaseViewModel : GenericEditableViewModelBase<ProductBaseModel>
    {
        public ProductBaseViewModel(ProductBaseModel productBaseModel)
        {
            Model = productBaseModel;

            PictureLocation = PictureLocationHelper.GetPictureLocation(Model.ProductBaseCode);
        }

        #region properties
        public override string DisplayName => "Üldandmed";
        public string PictureLocation { get; }
        public bool IsProductVariationsVisible => Model.ProductVariationsLink?.Count != 0;
        #endregion

        #region overrides
        protected override bool SaveItem(ProductBaseModel model)
        {
            return true;
        }
        #endregion
    }
}
