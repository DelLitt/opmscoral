using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Actions;

namespace AppFrame.Base
{
    public interface IActionNode : INode
    {
        void DoExecute();
    }
}
