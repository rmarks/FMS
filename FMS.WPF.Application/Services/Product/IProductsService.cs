using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.Application.Services
{
    public interface IProductsService
    {
        IList<ProductListModel> GetProductList();
    }
}
