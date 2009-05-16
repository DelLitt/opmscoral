using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Presenter;

namespace AppFrame.View
{
    public interface ISecurityView
    {
        ISecurityController SecurityController { get; set;}

        event EventHandler<SecurityEventArgs> InitSecuritySettingsEvent;
        event EventHandler<SecurityEventArgs> SaveUserEvent;
        event EventHandler<SecurityEventArgs> EditUserEvent;
    }
}
