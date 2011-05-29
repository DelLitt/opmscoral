using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppFrameClient.View
{
    public partial class AppFrameConsumerForm : Form
    {
        public AppFrameConsumerForm()
        {
            InitializeComponent();
        }

        private void AppFrameConsumerForm_Load(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
