using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Screens;

namespace AppFrame.Base
{
    public interface IRootNode<T> where T:class,INode
    {
        void Open(T node);
        T CreateNode(string typeName);
        //IScreen MainScreen { get; set; }
    }
}
