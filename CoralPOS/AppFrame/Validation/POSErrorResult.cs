using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Validation
{
    public class POSErrorResult
    {
        private IList<POSError> _errors = new List<POSError>();

        public bool HasError
        {
            get
            {
                return _errors.Count > 0;
            }
        }

        public IList<POSError> Errors
        {
            get
            {
                return _errors;
            }
            set
            {
                _errors = value;
            }
        }

        public void AddError(POSError error)
        {
            _errors.Add(error);
        }
        public void RemoveError(POSError error)
        {
            _errors.Remove(error);
        }
        public void ClearErrors()
        {
            _errors.Clear();
        }
    }
}
