using FMS.WPF.Application.Interface.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMS.WPF.Application.Interface.Services
{
    public interface IProductFacadeService
    {
        ProductBaseModel GetProductBaseModel(int productBaseId);
        Task<IList<ProductCompanyModel>> GetProductCompanyModelsForSource(int productBaseId);
        Task<IList<ProductCompanyModel>> GetProductCompanyModelsForDest(int productBaseId);
        Task<IList<PriceListModel>> GetProductPriceListModels(int productBaseId);
    }
}
