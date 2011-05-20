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
    public partial class ProductInfoForm : Form
    {
        public ProductInfoForm()
        {
            InitializeComponent();
        }

        private void fillToolStripButton_Click(object sender, EventArgs e)
        {
            try
            {
                object PrdName = new object();
                
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void fillToolStripButton_Click_1(object sender, EventArgs e)
        {
            try
            { 
                //object PrdName = new object();
                //this.productInfoTableAdapter.Fill(this.masterDB.ProductInfo, PrdName);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string product_name = "";
            if(!string.IsNullOrEmpty(txtProductName.Text))
            {
                product_name = "%" + txtProductName.Text.Trim().ToUpper() + "%";
            }
            productInfoTableAdapter.Fill(masterDB.ProductInfo, product_name);
        }

        private void btnColumnInput_Click(object sender, EventArgs e)
        {

        }
    }
}
