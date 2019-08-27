using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.Application.Interface.Services
{
    public interface IProductListService
    {
        ProductListOptionsModel GetProductListOptionsModel();
        IList<ProductListModel> GetProductListModels(ProductListOptionsModel model);
    }
}