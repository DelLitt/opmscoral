using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;

using AppFrame.CustomAttributes;
using AppFrame.CustomAttributes;

namespace POSServer.ViewModels.Security
{
    public interface ILoginViewModel : IScreenNode
    {
        string Path { get; set; }
    }
}