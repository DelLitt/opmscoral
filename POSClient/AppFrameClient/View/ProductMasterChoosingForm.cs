using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrameClient.View
{
    public partial class ProductMasterChoosingForm : BaseForm
    {
        private ProductMasterCollection pmSelectedList = null;
        public ProductMasterChoosingForm()
        {
            InitializeComponent();
        }

        private void ProductMasterChoosingForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDB.product_type' table. You can move, or remove it, as needed.
            this.product_typeTableAdapter.Fill(this.masterDB.product_type);
            pmSelectedList = new ProductMasterCollection(bdsProductMaster);
            bdsProductMaster.ResetBindings(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (dgvProductMasters.CurrentCell == null) return;
            DataGridViewSelectedRowCollection dgvRows = dgvProductMasters.SelectedRows;

            foreach (DataGridViewRow row in dgvRows)
            {
                ProductMaster master = new ProductMaster
                                           {
                                               ProductName = row.Cells[0].Value.ToString()
                                           };
                if(!ExistInList(pmSelectedList,master))
                {
                    pmSelectedList.Add(master);        
                }
            }
            bdsProductMaster.ResetBindings(false);
            dgvSelectedProductMaster.Refresh();
            dgvSelectedProductMaster.Invalidate();
        }

        private bool ExistInList(ProductMasterCollection collection, ProductMaster master)
        {
            foreach (ProductMaster productMaster in collection)
            {
                if(productMaster.ProductName.Equals(master.ProductName))
                {
                    return true;
                }
            }
            return false;
        }

        private void dgvSelectedProductMaster_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            if (dgvProductMasters.CurrentCell == null) return;
            DataGridViewRowCollection dgvRows = dgvProductMasters.Rows;

            foreach (DataGridViewRow row in dgvRows)
            {
                ProductMaster master = new ProductMaster
                {
                    ProductName = row.Cells[0].Value.ToString()
                };
                if (!ExistInList(pmSelectedList, master))
                {
                    pmSelectedList.Add(master);
                }
            }
            bdsProductMaster.ResetBindings(false);
            dgvSelectedProductMaster.Refresh();
            dgvSelectedProductMaster.Invalidate();              
        }

        private void btnRemoveAll_Click(object sender, EventArgs e)
        {
            pmSelectedList.Clear();
            bdsProductMaster.ResetBindings(false);
            dgvSelectedProductMaster.Refresh();
            dgvSelectedProductMaster.Invalidate();              
        }
    }
}
