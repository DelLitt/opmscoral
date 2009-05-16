using System;
using System.Collections.Generic;
using System.Text;
using Spring.Aop.Support;
using AppFrame.Logic;

namespace AppFrame.Advice
{
    public class AuthoriseLogicAdvisor : DefaultIntroductionAdvisor
    {
        public AuthoriseLogicAdvisor()
            : base(new AuthoriseLogicMixin(),typeof(IAuthoriseLogic))
        {
        }
    }
}
