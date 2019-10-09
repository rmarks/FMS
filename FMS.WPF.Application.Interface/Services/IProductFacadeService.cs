using FMS.WPF.Models;

namespace FMS.WPF.Application.Interface.Services
{
    public interface IProductFacadeService
    {
        ProductBaseModel GetProductBaseModel(int productBaseId);
        int Save(ProductBaseModel model);
    }
}
