using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppFrameServer
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            AppFrameServer.Properties.Settings.Default.Reload();
            string subStock = AppFrameServer.Properties.Settings.Default.SubStockDB;
            string salePoint = AppFrameServer.Properties.Settings.Default.SalePointDB;
            txtSubStock.Text = subStock;
            txtSalePoint.Text = salePoint;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AppFrameServer.Properties.Settings.Default.SubStockDB = txtSubStock.Text.Trim();
            AppFrameServer.Properties.Settings.Default.SalePointDB = txtSalePoint.Text.Trim(); 
            AppFrameServer.Properties.Settings.Default.Save();
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
