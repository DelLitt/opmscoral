﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using Caliburn.PresentationFramework.Screens;
using Microsoft.Practices.ServiceLocation;

namespace POSServer.ViewModels
{
    public interface IShellViewModel
    {
        void Open<T>() where T : IScreen;
        IServiceLocator ServiceLocator { get; set; }
        IScreen ActiveMenu { get; set; }

        bool EnterFlow(string flowName);
        bool StartFlow(string flowName);
        bool ResumeFlow(string flowName);
        void LeaveFlow();
        void EnterChildFlow(string childFlowName, IFlow parentFlow);
    }
}