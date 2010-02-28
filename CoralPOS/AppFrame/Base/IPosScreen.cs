using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Screens;

namespace AppFrame.Base
{
    public interface IPosScreen : IScreen
    {
        IScreen AttachedMenu { get; set; }
    }

    public interface IPosScreen<T> : IScreen<T>, INode
    {
        IScreen ActiveMenu { get; set; }
    }
}
