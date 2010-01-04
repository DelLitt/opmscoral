using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Base
{
    public interface INode
    {
        void Execute();
        void Execute(object param);
    }
}