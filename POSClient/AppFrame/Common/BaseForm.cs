using System;
using System.Collections.Generic;
using System.Drawing;
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
        private Timer timer1;
        private System.ComponentModel.IContainer components;

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
        public BaseForm()
        {
            InitializeComponent();
            ExtraInit();
        }

        private void ExtraInit()
        {
            baseStatusStrip.Visible = ShowStatusStrip;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.baseStatusStrip = new System.Windows.Forms.StatusStrip();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.baseStatusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // baseStatusStrip
            // 
            this.baseStatusStrip.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
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
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
        public void StartShowProcessing()
        {
           timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            ProgressBar.Value = ProgressBar.Value + 10;
            if(ProgressBar.Value > 100)
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
        
        public void ShowMessage(Label label,string message)
        {
            label.ForeColor = Color.Blue;
            label.Text = message;            
        }
        
        public void ShowError(Label label, string message)
        {
            label.ForeColor = Color.Red;
            label.Text = message;
        }

        public void ShowStatusMessage(string message,Color color)
        {
            StatusLabel.ForeColor = color;
            StatusLabel.Text = message;
        }
        public void ShowMessage(string message)
        {
            ShowStatusMessage(message,Color.Blue);
        }
        public void ShowError(string message)
        {
            ShowStatusMessage(message,Color.Red);            
        }
    }
    
    public enum ViewStatus { ADD, EDIT, DELETE,OPENDIALOG }
}
