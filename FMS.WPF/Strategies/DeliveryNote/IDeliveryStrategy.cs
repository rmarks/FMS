using FMS.WPF.Models;
using System;

namespace FMS.WPF.Strategies
{
    public interface IDeliveryStrategy
    {
        string DisplayName { get; }
        bool IsFromLocationTypeEnabled { get; }
        bool IsToLocationTypeEnabled { get; }

        Action<DeliveryNoteListOptionsModel> SetDefaultOptions { get; }
    }
}
