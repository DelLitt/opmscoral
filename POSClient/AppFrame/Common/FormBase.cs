using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppFrame.Common
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }


        private bool showStatusStrip;
        public bool ShowStatusStrip
        {
            get
            {
                return showStatusStrip;
            }
            set
            {
                showStatusStrip = value;

            }
        }
        protected void EndEvent(IAsyncResult iAsyncResult)
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
            get;
            set;
        }
        public void StartShowProcessing()
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ProgressBar.Value = ProgressBar.Value + 10;
            if (ProgressBar.Value > 100)
            {
                ProgressBar.Value = 0;
            }
        }
        public void StopShowProcessing()
        {
            timer1.Stop();
            ProgressBar.Value = 0;
        }
        public void ShowStatusMessage(string message)
        {
            StatusLabel.Text = message;
        }
        public void ShowStatusMessage(string message, Color color)
        {
            StatusLabel.ForeColor = color;
            StatusLabel.Text = message;
        }
        public void ShowMessage(string message)
        {
            ShowStatusMessage(message, Color.Blue);
        }
        public void ShowError(string message)
        {
            ShowStatusMessage(message, Color.Red);
        }
    }
}
