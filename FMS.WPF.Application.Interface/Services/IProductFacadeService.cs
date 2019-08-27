using FMS.WPF.Application.Interface.Models;

namespace FMS.WPF.Application.Interface.Services
{
    public interface IProductFacadeService
    {
        ProductBaseModel GetProductBaseModel(int productBaseId);
    }
}
