using FMS.WPF.Application.Interface.Models;
using System.Collections.Generic;

namespace FMS.WPF.Application.Interface.Services
{
    public interface IProductVmService
    {
        ProductBaseModel GetProductBaseModel(int productBaseId);

        void SetProductBaseDropdownsAsync(ProductBaseModel productBase);

        IList<ProductModel> GetProductModels(int productBaseId);
    }
}
