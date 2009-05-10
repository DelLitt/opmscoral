using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrameClient.View
{
    public partial class PosLogDetailForm : Form
    {
        public PosLog PosLog { get; set; }
        public PosLogDetailForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void PosLogDetailForm_Load(object sender, EventArgs e)
        {
            if (PosLog != null)
            {
                lblDate.Text = PosLog.Date.ToString("dd/MM/yyyy hh:mm:ss");
                lblUser.Text = PosLog.PosUser;
                lblAction.Text = PosLog.PosAction;
                txtDetail.Text = PosLog.Message;
            }
        }
    }
}
