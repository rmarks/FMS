using FMS.WPF.Models;

namespace FMS.WPF.Application.Interface.Services
{
    public interface IProductFacadeService
    {
        ProductBaseModel GetProductBaseModel(int productBaseId);
        ProductBaseModel Save(ProductBaseModel model);
    }
}
