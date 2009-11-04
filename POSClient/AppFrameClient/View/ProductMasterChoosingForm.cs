using System;
using System.Collections;
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

        private void btnOK_Click(object sender, EventArgs e)
        {
            IList pmList = new ArrayList();
            MasterDBTableAdapters.product_master_idsTableAdapter adp = new MasterDBTableAdapters.product_master_idsTableAdapter();

            foreach (DataGridViewRow row in dgvSelectedProductMaster.Rows)
            {
                
                string productName = row.Cells[0].Value.ToString();
                adp.Fill(masterDB.product_master_ids, productName);
                foreach (MasterDB.product_master_idsRow masterRow in masterDB.product_master_ids)
                {
                    ProductMaster pm = new ProductMaster
                                           {
                                               ProductMasterId = masterRow.product_master_id.ToString()
                                           };
                    pmList.Add(pm);
                }
            }
            SelectedProductMasterList = pmList;
            Close();
        }

        public IList SelectedProductMasterList { get; set; }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SelectedProductMasterList = null;
            Close();
        }

        private void cboProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int typeId = Int32.Parse(cboProductType.SelectedValue.ToString());
            this.product_master_nameTableAdapter.Fill(masterDB1.product_master_name, typeId);
            dgvProductMasters.Refresh();
            dgvProductMasters.Invalidate();
        }
    }
}
