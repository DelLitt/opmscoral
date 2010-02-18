using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Screens;

namespace AppFrame.WPF.Screens
{
    public interface IPageScreen : IScreen
    {
        string Path { get; set; }
    }
}
