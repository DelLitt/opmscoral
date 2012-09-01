using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Base
{
    public class ChildFlow : DefaultFlow
    {
        public IFlow ParentFlow { get; set; }
    }
}
