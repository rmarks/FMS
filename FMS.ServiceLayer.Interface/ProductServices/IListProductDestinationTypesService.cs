using FMS.ServiceLayer.Dtos;
using System.Collections.Generic;

namespace FMS.ServiceLayer.Interfaces
{
    public interface IListProductDestinationTypesService
    {
        IList<ProductDestinationTypeDto> GetProductDestinationTypes();
    }
}
