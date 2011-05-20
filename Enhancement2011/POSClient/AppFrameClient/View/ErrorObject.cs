using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrameClient.View
{
    public interface ErrorObject
    {
        string Caption { get; set; }
        string ErrorString { get; set; }
        List<string> ErrorDetails { get; set; }
    }
}
