using System.Collections.Generic;
using System.Threading.Tasks;
using FMS.WPF.Application.Interface.Models;

namespace FMS.WPF.Application.Interface.Services
{
    public interface IProductsVmService
    {
        Task<ProductListOptionsModel> GetProductListOptionsModelAsync();

        IList<ProductListModel> GetProductListModels(ProductListOptionsModel optionsModel);
    }
}