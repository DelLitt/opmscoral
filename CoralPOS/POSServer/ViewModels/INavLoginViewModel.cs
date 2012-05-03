using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.CustomAttributes;
using Caliburn.Micro;

namespace POSServer.ViewModels
{
    public interface INavLoginViewModel : IScreen
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}