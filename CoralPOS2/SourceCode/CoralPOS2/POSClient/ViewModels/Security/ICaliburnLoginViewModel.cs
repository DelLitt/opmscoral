using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using POSClient.DataLayer.Models;

namespace POSClient.ViewModels.Security
{
    public interface ICaliburnLoginViewModel : IScreenNode<CaliburnLoginModel>
    {
        string Path { get; set; }
    }
}
