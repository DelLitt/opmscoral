using System;
using System.Collections.Generic;
using System.Text;
using AopAlliance.Aop;
using AppFrame.Common;

namespace AppFrame.Logic
{
    public interface IAuthoriseLogic : IAdvice
    {
        BaseUser CurrentUser { get; set; }
    }
}
