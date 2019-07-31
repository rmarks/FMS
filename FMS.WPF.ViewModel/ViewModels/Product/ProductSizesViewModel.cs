using FMS.WPF.Application.Interface.Models;
using FMS.WPF.Application.Interface.Services;
using System.Collections.Generic;

namespace FMS.WPF.ViewModels
{
    public class ProductSizesViewModel : ViewModelBase
    {
        public ProductSizesViewModel(int productBaseId, IProductAppService productService)
        {
            Products = productService.GetProductModels(productBaseId);
        }

        public override string DisplayName => "Suurused";

        public IList<ProductModel> Products { get; }
    }
}
