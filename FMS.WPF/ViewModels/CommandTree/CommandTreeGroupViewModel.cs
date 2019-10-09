using System.Collections.Generic;

namespace FMS.WPF.ViewModels
{
    public class CommandTreeGroupViewModel : CommandTreeNodeViewModelBase
    {
        public List<CommandTreeNodeViewModelBase> CommandTreeItems { get; } = new List<CommandTreeNodeViewModelBase>();

        public CommandTreeGroupViewModel(string displayName)
        {
            base.DisplayName = displayName;
        }
    }
}
