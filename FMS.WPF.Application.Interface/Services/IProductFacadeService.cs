using FMS.WPF.Application.Interface.Models;
using System.Collections.Generic;

namespace FMS.WPF.Application.Interface.Services
{
    public interface IProductFacadeService
    {
        ProductBaseModel GetProductBaseModel(int productBaseId);

        IList<ProductModel> GetProductModels(int productBaseId);
    }
}
