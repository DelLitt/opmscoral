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
    public partial class ProductSizeMasterForm : Form
    {
        public ProductSizeMasterForm()
        {
            InitializeComponent();
        }

        private void product_sizeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.product_sizeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.masterDB);

        }

        private void product_sizeBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            this.Validate();
            this.product_sizeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.masterDB);

        }

        private void ProductSizeMasterForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDB.product_size' table. You can move, or remove it, as needed.
            this.product_sizeTableAdapter.Fill(this.masterDB.product_size);

        }
    }
}
