using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using CoralPOS2.Models;


namespace POSServer.ViewModels.Security
{
    public interface ICaliburnLoginViewModel : IScreenNode<CaliburnLoginModel>
    {
        string Path { get; set; }
    }
}