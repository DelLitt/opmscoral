using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Validation
{
    public interface IObjectValidator<T>
    {
        T Target { get; set; }
        POSErrorResult Validate();
    }
}
