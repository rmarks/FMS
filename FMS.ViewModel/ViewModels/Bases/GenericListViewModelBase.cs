using System;
using System.Collections.Generic;
using System.Text;

namespace FMS.ViewModels
{
    public abstract class GenericListViewModelBase<TModel> : ViewModelBase
    {
        public IList<TModel> Items { get; set; }

        #region Abstract Members
        protected abstract void Refresh();
        #endregion Abstract Members
    }
}
