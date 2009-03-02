using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Utility;
using AppFrame.View.GoodsIO;
using AppFrameClient.Common;

namespace AppFrameClient.View.GoodsIO
{
    public partial class ProductMasterSearchForm : BaseForm, IProductMasterSearchOrCreateView
    {
        public IList ProductMasterList { get; set; }
        public ProductMasterSearchOrCreateEventArgs CurrentProductMasterSearchOrCreateEventArgs { get; set; }
        public ProductMasterSearchForm()
        {
            InitializeComponent();
        }

        private void ProductMasterSearchForm_Load(object sender, EventArgs e)
        {
            var eventArgs = new ProductMasterSearchOrCreateEventArgs();
            EventUtility.fireEvent(InitProductMasterSearchOrCreateEvent, sender, eventArgs);

            AddListItemToCombo(
                productMasterSearchControl.cbbProductType,
                eventArgs.ProductTypeList,
                "TypeName",
                productMasterSearchControl.cbbProductType.Text);

            AddListItemToCombo(
                productMasterSearchControl.cbbProductSize,
                eventArgs.ProductSizeList,
                "SizeName",
                productMasterSearchControl.cbbProductSize.Text);


            AddListItemToCombo(
                productMasterSearchControl.cbbProductColor,
                eventArgs.ProductColorList,
                "ColorName",
                productMasterSearchControl.cbbProductColor.Text);


            AddListItemToCombo(
                productMasterSearchControl.cbbCountry,
                eventArgs.CountryList,
                "CountryName",
                productMasterSearchControl.cbbCountry.Text);


            AddListItemToCombo(
                productMasterSearchControl.cbbManufacturer,
                eventArgs.ManufacturerList,
                "ManufacturerName",
                productMasterSearchControl.cbbManufacturer.Text);


            AddListItemToCombo(
                productMasterSearchControl.cbbDistributor,
                eventArgs.DistributorList,
                "DistributorName",
                productMasterSearchControl.cbbDistributor.Text);


            AddListItemToCombo(
                productMasterSearchControl.cbbPackager,
                eventArgs.PackagerList,
                "PackagerName",
                productMasterSearchControl.cbbPackager.Text);
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgvProductMaster.SelectedCells.Count > 0)
            {
                string productMasterId =
                    dgvProductMaster.Rows[dgvProductMaster.SelectedCells[0].RowIndex].Cells["productMasterIdDataGridViewTextBoxColumn"].Value.ToString();
                SelectProductMaster(productMasterId);
            }
        }

        private void SelectProductMaster(string productMasterId)
        {
            var productMasterForm = GlobalUtility.GetFormObject<ProductMasterForm>(FormConstants.PRODUCT_MASTER_FORM);
            productMasterForm.ProductMasterId = productMasterId;
            productMasterForm.ShowDialog();
            if (CurrentProductMasterSearchOrCreateEventArgs != null)
            {
                EventUtility.fireEvent(SearchProductMasterEvent, this, CurrentProductMasterSearchOrCreateEventArgs);
                ProductMasterList = CurrentProductMasterSearchOrCreateEventArgs.ProductMasterList;
                dgvProductMaster.DataSource = ProductMasterList;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Implementation of IProductMasterSearchOrCreateView
        private IProductMasterSearchOrCreateController _productMasterSearchOrCreateController;
        public IProductMasterSearchOrCreateController ProductMasterSearchOrCreateController
        {
            set
            {
                _productMasterSearchOrCreateController = value;
                _productMasterSearchOrCreateController.ProductMasterSearchOrCreateView = this;
            }
        }
        public event EventHandler<ProductMasterSearchOrCreateEventArgs> SaveProductMasterEvent;
        public event EventHandler<ProductMasterSearchOrCreateEventArgs> SearchProductMasterEvent;
        public event EventHandler<ProductMasterSearchOrCreateEventArgs> SelectProductMasterEvent;
        public event EventHandler<ProductMasterSearchOrCreateEventArgs> InitProductMasterSearchOrCreateEvent;
        public event EventHandler<ProductMasterSearchOrCreateEventArgs> OpenProductMasterSearchOrCreateEvent;

        #endregion

        private void AddListItemToCombo(ComboBox box1, IList data, string displayItemName, string currentText1)
        {
            box1.Items.Clear();
            foreach (object type in data)
            {
                box1.Items.Add(type);
            }
            box1.DisplayMember = displayItemName;

            int index = 1;
            if (!string.IsNullOrEmpty(box1.Text))
            {
                foreach (object type in data)
                {
                    if (currentText1.Equals(box1.Text))
                    {
                        box1.SelectedIndex = index;
                        box1.SelectedItem = type;
                        break;
                    }
                    index++;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var eventArgs = new ProductMasterSearchOrCreateEventArgs
            {
                ProductMasterId = productMasterSearchControl.txtProductMasterId.Text,
                Packager = productMasterSearchControl.cbbPackager.SelectedIndex > 0 ? ((Packager)productMasterSearchControl.cbbPackager.SelectedItem) : null,
                ProductMasterName = productMasterSearchControl.txtProductName.Text,
                ProductSize = productMasterSearchControl.cbbProductSize.SelectedIndex > 0 ? ((ProductSize)productMasterSearchControl.cbbProductSize.SelectedItem) : null,
                ProductType = productMasterSearchControl.cbbProductType.SelectedIndex > 0 ? ((ProductType)productMasterSearchControl.cbbProductType.SelectedItem) : null,
                ProductColor = productMasterSearchControl.cbbProductColor.SelectedIndex > 0 ?
                    ((ProductColor)productMasterSearchControl.cbbProductColor.SelectedItem) : null,
                Country = productMasterSearchControl.cbbCountry.SelectedIndex > 0 ? ((Country)productMasterSearchControl.cbbCountry.SelectedItem) : null,
                Manufacturer = productMasterSearchControl.cbbManufacturer.SelectedIndex > 0 ? ((Manufacturer)productMasterSearchControl.cbbManufacturer.SelectedItem) : null,
                Distributor = productMasterSearchControl.cbbDistributor.SelectedIndex > 0 ? ((Distributor)productMasterSearchControl.cbbDistributor.SelectedItem) : null,
                Barcode = productMasterSearchControl.txtBarcode.Text
            };
            EventUtility.fireEvent(SearchProductMasterEvent, sender, eventArgs);
            ProductMasterList = eventArgs.ProductMasterList;
            dgvProductMaster.DataSource = ProductMasterList;
            CurrentProductMasterSearchOrCreateEventArgs = eventArgs;
        }

        private void dgvProductMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < dgvProductMaster.Rows.Count)
            {
                string productMasterId =
                    dgvProductMaster.Rows[e.RowIndex].Cells["productMasterIdDataGridViewTextBoxColumn"].Value.ToString();
                SelectProductMaster(productMasterId);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (ProductMasterList != null && ProductMasterList.Count > 0)
            {
                //productPrintDialog.Document = productPrintDocument;
                //productPrintDialog.ShowDialog();
            }
        }
    }
}
