using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Base
{
    public interface INode
    {
        string Name { get; set; }
        IFlow Flow { get; set; }
        void GoToNextNode();
    }
}