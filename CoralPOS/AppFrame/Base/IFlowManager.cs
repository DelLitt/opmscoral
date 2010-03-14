using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppFrame.Base
{
    public interface IFlowManager
    {
        IFlow ActiveFlow { get; set; }
        void StartFlow();
        void ResumeFlow();
        void SuspendFlow();
        void LeaveFlow();
    }
}
