using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;

namespace AppFrame.Common
{
    public class BaseForm : Form
    {
        private ToolStripProgressBar ProgressBar;
        private ToolStripStatusLabel StatusLabel;
        private StatusStrip baseStatusStrip;

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
                if(showStatusStrip)
                {
                    
                }
            }
        }
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

        private void InitializeComponent()
        {
            this.baseStatusStrip = new System.Windows.Forms.StatusStrip();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.baseStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseStatusStrip
            // 
            this.baseStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProgressBar,
            this.StatusLabel});
            this.baseStatusStrip.Location = new System.Drawing.Point(0, 240);
            this.baseStatusStrip.Name = "baseStatusStrip";
            this.baseStatusStrip.Size = new System.Drawing.Size(284, 22);
            this.baseStatusStrip.TabIndex = 0;
            this.baseStatusStrip.Text = "statusStrip1";
            // 
            // ProgressBar
            // 
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(100, 16);
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(16, 17);
            this.StatusLabel.Text = "...";
            // 
            // BaseForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.baseStatusStrip);
            this.Name = "BaseForm";
            this.baseStatusStrip.ResumeLayout(false);
            this.baseStatusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }

    public enum ViewStatus { ADD, EDIT, DELETE,OPENDIALOG }
}
