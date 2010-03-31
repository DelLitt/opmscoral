using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Caliburn.PresentationFramework.Screens;

namespace AppFrame.Base
{
    public class PosViewModel : Screen,IScreenNode
    {
        public string Name
        {
            get; set;
        }

        public IFlow Flow
        {
            get; set;
        }

        public virtual void GoToNextNode()
        {
            Flow.Next();
        }

        public IScreen AttachedMenu
        {
            get; set;
        }

        protected void SetBackToParentFlow(string key, IList list)
        {
            if(Flow is ChildFlow)
            {
                ChildFlow childFlow = (ChildFlow) Flow;
                if (childFlow.ParentFlow != null)
                {
                    childFlow.ParentFlow.Session.Put(key, list);
                }
            }
        }
    }
}
