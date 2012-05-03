using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Screens;

namespace AppFrame.WPF.Screens
{
    public interface ILoadViewModel : IScreenEx
    {
        void StartLoading();
        void StopLoading();
    }
}
