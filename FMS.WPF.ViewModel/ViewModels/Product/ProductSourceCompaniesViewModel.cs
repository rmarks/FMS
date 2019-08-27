using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.ViewModels
{
    public class ProductSourceCompaniesViewModel : ViewModelBase
    {
        public ProductSourceCompaniesViewModel(ProductBaseModel productBaseModel)
        {
            Products = productBaseModel.Products;
        }

        #region properties
        public override string DisplayName => "Tarne andmed";

        public IList<ProductModel> Products { get; private set; }
        #endregion
    }
}
