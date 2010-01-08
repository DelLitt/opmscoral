using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.Core.Metadata;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Screens;

namespace POSClient.ViewModels.Security
{
    
    public interface ILoginViewModel : IScreen
    {
        string Path { get; set; }
    }
}
