using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSClient.ViewModels.Security
{
    
    public interface ILoginViewModel : IScreen,IScreenNode
    {
        string Path { get; set; }
    }
}
