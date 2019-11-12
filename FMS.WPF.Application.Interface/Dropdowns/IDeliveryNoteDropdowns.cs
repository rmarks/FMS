using FMS.WPF.Models;
using System.Collections.Generic;

namespace FMS.WPF.Application.Interface.Dropdowns
{
    public interface IDeliveryNoteDropdowns
    {
        IList<LocationDropdownModel> Locations { get; set; }
        IList<LocationTypeDropdownModel> LocationTypes { get; set; }
        IList<DocumentStateModel> DocumentStates { get; set; }

        void InitializeAsync();
    }

    public class DeliveryNoteDropdownsProxy
    {
        public static IDeliveryNoteDropdowns Instance { get; set; }
    }
}