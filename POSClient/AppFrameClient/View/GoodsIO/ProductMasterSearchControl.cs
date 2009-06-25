using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AppFrameClient.View.GoodsIO
{
    public partial class ProductMasterSearchControl : UserControl
    {
        public ProductMasterSearchControl()
        {
            InitializeComponent();
        }

        private void txtProductMasterId_Enter(object sender, EventArgs e)
        {
            txtProductMasterId.BackColor = Color.LightGreen;
        }

        private void txtProductMasterId_Leave(object sender, EventArgs e)
        {
            txtProductMasterId.BackColor = Color.White;
        }
    }
}
