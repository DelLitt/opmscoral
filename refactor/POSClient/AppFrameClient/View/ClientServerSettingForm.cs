using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrameClient.Common;

namespace AppFrameClient.View
{
    public partial class ClientServerSettingForm : Form
    {
        public ClientServerSettingForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                Properties.Settings.Default.IsClient = FormConstants.SERVER_MODE;
            }
            if(radioButton2.Checked)
            {
                Properties.Settings.Default.IsClient = FormConstants.CLIENT_MODE;    
            }

            Properties.Settings.Default.Save();
            Close();
        }
    }
}
