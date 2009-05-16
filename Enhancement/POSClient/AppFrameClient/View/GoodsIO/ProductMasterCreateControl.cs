using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using AppFrame.Utility;

namespace AppFrameClient.View.GoodsIO
{
    public partial class ProductMasterCreateControl : UserControl
    {
        public ProductMasterCreateControl()
        {
            InitializeComponent();
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {
            CheckUtility.FormatUpper((TextBox)sender);
        }
    }
}
