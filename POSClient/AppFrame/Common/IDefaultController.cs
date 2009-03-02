using System;
using System.Collections.Generic;
using System.Text;

namespace AppFrame.Common
{
    public abstract class AbstractDefaultController<T> : IBaseController<T> where T : BaseEventArgs
    {
        public abstract void populateFormToBean();

        #region IBaseController<T> Members

        private T resultEventArgs;
        public T ResultEventArgs
        {
            get
            {
                return resultEventArgs;
            }
            set
            {
                resultEventArgs = value;
            }
        }

        #endregion
    }
}
