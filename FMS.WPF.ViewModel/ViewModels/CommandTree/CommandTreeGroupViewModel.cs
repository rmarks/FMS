using System;
using System.Collections.Generic;
using System.Text;

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
