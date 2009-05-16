using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AppFrameClient.View.Masters
{
    public partial class ProductColorMasterForm : Form
    {
        public ProductColorMasterForm()
        {
            InitializeComponent();
        }

        private void product_colorBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.product_colorBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.masterDB);

        }

        private void ProductColorMasterForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDB.product_color' table. You can move, or remove it, as needed.
            this.product_colorTableAdapter.Fill(this.masterDB.product_color);

        }
    }
}
