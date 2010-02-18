using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Screens;

namespace POSClient.ViewModels
{
    public interface IShellViewModel
    {
        void Open<T>() where T : IScreen;
    }
}