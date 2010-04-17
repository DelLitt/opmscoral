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
    public partial class ProductTypeMasterForm : Form
    {
        public ProductTypeMasterForm()
        {
            InitializeComponent();
        }

        private void product_typeBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.product_typeBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.masterDB);

        }

        private void ProductTypeMasterForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDB.product_type' table. You can move, or remove it, as needed.
            this.product_typeTableAdapter.Fill(this.masterDB.product_type);

        }
    }
}
