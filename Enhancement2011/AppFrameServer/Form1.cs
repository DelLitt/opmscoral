using System;
using System.ServiceModel;
using System.Threading;
using System.Windows.Forms;
using AppFrameServer.Services;
using AppFrameServer.Utility;

namespace AppFrameServer
{
    public partial class Form1 : Form
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ServiceHost m_host = null;
        public Form1()
        {
            InitializeComponent();

            
            
        }

        private void RunService()
        {

            txtStatus.Text = " Đang khởi động dịch vụ ...";
            ServerUtility.Log(logger,txtStatus.Text);
            notifyIcon1.Icon = AppFrameServer.Properties.Resources.Globe_Disconnect;
            m_host = new ServiceHost(typeof(ServerService));
            while (m_host.State != CommunicationState.Opened)
            {
                try
                {
                    m_host.Open();
                }
                catch (Exception exception)
                {
                    
                    txtStatus.Text = "Thất bại ... " + exception.Message;
                    ServerUtility.Log(logger, txtStatus.Text);
                    m_host = new ServiceHost(typeof(ServerService));
                    Thread.Sleep(30000);
                    txtStatus.Text = " Thử khởi động lại dịch vụ ...";
                    ServerUtility.Log(logger, txtStatus.Text);
                }
                
            }
            notifyIcon1.Icon = AppFrameServer.Properties.Resources.Globe_Connected;
            txtStatus.Text = " Dịch vụ khởi động thanh công. Đang chờ lệnh ...";
            ServerUtility.Log(logger, txtStatus.Text);
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            RunService();
        }

        private void mnuDisplay_Click(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            Show();
        }

        private void mnuHide_Click(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_host != null)
            {
                m_host.Close();
            }
        }

        private void mnuStop_Click(object sender, System.EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to quit ?", "Confirmed", MessageBoxButtons.OKCancel, MessageBoxIcon.Question,
                            MessageBoxDefaultButton.Button2);
            if(result == DialogResult.OK)
            {
                Close();    
            }
            
        }

        private void mnuConfig_Click(object sender, EventArgs e)
        {
            new SettingForm().ShowDialog();
        }
    }
}