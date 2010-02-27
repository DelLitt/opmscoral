﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Screens;

namespace AppFrame.Base
{
    public interface IScreenNode : IScreen,INode
    {
    }

    public interface  IScreenNode<T> : IScreen<T>, INode
    {
        
    }
}