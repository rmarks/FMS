using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.Application.Interface.Services
{
    public interface ILocationListService
    {
        IList<LocationListModel> GetLocationListModels(int locationTypeId);
    }
}