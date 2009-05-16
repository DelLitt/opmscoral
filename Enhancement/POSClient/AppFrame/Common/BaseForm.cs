using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;

namespace AppFrame.Common
{
    public class BaseForm : Form
    {
        protected  void EndEvent(IAsyncResult iAsyncResult)
        {
            // clean up only.
            System.Runtime.Remoting.Messaging.AsyncResult ar = (System.Runtime.Remoting.Messaging.AsyncResult)iAsyncResult;
            EventHandler<BaseEventArgs> eventHandler = ar.AsyncDelegate as EventHandler<BaseEventArgs>;

            try
            {
                eventHandler.EndInvoke(ar);
            }
            catch (Exception ex)
            {
                OnException(ex);
            }
        }
        protected virtual void OnException(System.Exception ex)
        {
            
        }
        public virtual void FormToModel()
        {
            
        }
        public virtual void ModelToForm()
        {
            
        }

        public ViewStatus Status
        {
            get; set;
        }
    }

    public enum ViewStatus { ADD, EDIT, DELETE,OPENDIALOG }
}
