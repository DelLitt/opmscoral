using System.ServiceModel;

using System.Windows.Forms;
using AppFrameServer.Services;

namespace AppFrameServer
{
    public partial class Form1 : Form
    {
        private ServiceHost m_host = null;
        public Form1()
        {
            InitializeComponent();

            m_host = new ServiceHost(typeof(ServerService));
            m_host.Open();
            
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void mnuDisplay_Click(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Normal;
        }

        private void mnuHide_Click(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
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
            Close();
        }
    }
}