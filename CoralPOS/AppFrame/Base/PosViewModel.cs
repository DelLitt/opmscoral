using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using AppFrame.DataLayer;
using AppFrame.WPF.Screens;
using Caliburn.Micro;

namespace AppFrame.Base
{
    public class PosViewModel : Screen,IScreenNode,IDataErrorInfo
    {
        public string Name
        {
            get; set;
        }
        public object Model { get; set;  } 

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

        public string this[string columnName]
        {
            get
            {
                        
                var errors= GlobalValidator.Instance.Validate(this,columnName)
                            .Select(x=>x.Message)
                            .ToArray();
                return string.Join(Environment.NewLine, errors);
            }
        }

        public string Error
        {
            get
            {
                var errors = GlobalValidator.Instance.Validate(this)
                            .Select(x => x.Message)
                            .ToArray();
                return string.Join(Environment.NewLine, errors);
            }
        }
        
        public void StartWaitingScreen(int type)
        {
            IoC.Get<ICircularLoadViewModel>().StartLoading();
        }
        public void StopWaitingScreen( int type)
        {
            IoC.Get<ICircularLoadViewModel>().StopLoading();
        }
    }
}
