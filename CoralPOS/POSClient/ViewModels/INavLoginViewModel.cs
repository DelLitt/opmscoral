using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Screens;

namespace POSClient.ViewModels
{
    public interface INavLoginViewModel : IScreen
    {
        string Username { get; set; }
        string Password { get; set; }
    }
}
