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
    public partial class CategoryManagementForm : Form
    {
        public CategoryManagementForm()
        {
            InitializeComponent();
        }

        private void CategoryManagementForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDB1.category' table. You can move, or remove it, as needed.
            this.categoryTableAdapter.Fill(this.masterDB1.category);
            // TODO: This line of code loads data into the 'masterDB.product_type' table. You can move, or remove it, as needed.
            this.product_typeTableAdapter.Fill(this.masterDB.product_type);

        }
    }
}
