using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Screens;

namespace AppFrame.Base.Generic
{
    public class GenericPosViewModel<T> : Screen<T>, IScreenNode<T>
    {
        public string Name { get; set; }
        public IFlow Flow { get; set; }
        public void GoToNextNode()
        {
            Flow.Next();
        }


        public IScreen ActiveMenu
        {
            get; set;
        }
    }
}
