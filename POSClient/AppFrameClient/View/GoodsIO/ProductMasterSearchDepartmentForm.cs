using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Utility;
using AppFrame.View.GoodsIO;

namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    public partial class ProductMasterSearchDepartmentForm : BaseForm,IProductMasterSearchDepartmentView
    {
        private DepartmentStockInDetailCollection deptStockList = null;
        public ProductMasterSearchDepartmentForm()
        {
            InitializeComponent();
            deptStockList = new DepartmentStockInDetailCollection(deptStockBindingSource);
            deptStockBindingSource.DataSource = deptStockList;
            dgvProducts.DataError += new DataGridViewDataErrorEventHandler(dgvProducts_DataError);
            dgvProductMaster.DataError += new DataGridViewDataErrorEventHandler(dgvProductMaster_DataError);


            
        }

        void dgvProductMaster_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        void dgvProducts_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        private void productMasterSearchControl_Load(object sender, EventArgs e)
        {

        }

        #region IProductMasterSearchDepartmentView Members

       

        public event EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs> SaveProductMasterEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs> SearchProductMasterEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs> SelectProductMasterEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs> SearchProductsEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs> SelectProductEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs> InitProductMasterSearchDepartmentEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchDepartmentEventArgs> OpenProductMasterSearchDepartmentEvent;

        private AppFrame.Presenter.GoodsIO.IProductMasterSearchDepartmentController
            productMasterSearchDepartmentController;    
        public AppFrame.Presenter.GoodsIO.IProductMasterSearchDepartmentController ProductMasterSearchDepartmentController
        {
            get
            {
                return productMasterSearchDepartmentController;
            }
            set
            {
                productMasterSearchDepartmentController = value;

                productMasterSearchDepartmentController.ProductMasterSearchDepartmentView = this; 
            }
        }

        #endregion

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var eventArgs = new ProductMasterSearchDepartmentEventArgs
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
                Distributor = productMasterSearchControl.cbbDistributor.SelectedIndex > 0 ? ((Distributor)productMasterSearchControl.cbbDistributor.SelectedItem) : null
            };
            EventUtility.fireEvent(SearchProductMasterEvent, sender, eventArgs);
            IList ProductMasterList = eventArgs.ProductMasterList;
            if (ProductMasterList != null)
            {
                if(ProductMasterList.Count == 0)
                {
                    MessageBox.Show("Không tìm thấy mặt hàng nào!", "Kết quả");    
                }
                

                productMasterBindingSource.DataSource = ProductMasterList;
                productMasterBindingSource.ResetBindings(false);
            }
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProductMasterSearchDepartmentForm_Load(object sender, EventArgs e)
        {
            var eventArgs = new ProductMasterSearchDepartmentEventArgs();
            EventUtility.fireEvent(InitProductMasterSearchDepartmentEvent, this, eventArgs);

            AddListItemToCombo(productMasterSearchControl.cbbProductType,
                productMasterSearchControl.cbbProductType,
                eventArgs.ProductTypeList,
                "TypeName",
                productMasterSearchControl.cbbProductType.Text,
                productMasterSearchControl.cbbProductType.Text);

            AddListItemToCombo(productMasterSearchControl.cbbProductSize,
                productMasterSearchControl.cbbProductSize,
                eventArgs.ProductSizeList,
                "SizeName",
                productMasterSearchControl.cbbProductSize.Text,
                productMasterSearchControl.cbbProductSize.Text);


            AddListItemToCombo(productMasterSearchControl.cbbProductColor,
                productMasterSearchControl.cbbProductColor,
                eventArgs.ProductColorList,
                "ColorName",
                productMasterSearchControl.cbbProductColor.Text,
                productMasterSearchControl.cbbProductColor.Text);


            AddListItemToCombo(productMasterSearchControl.cbbCountry,
                productMasterSearchControl.cbbCountry,
                eventArgs.CountryList,
                "CountryName",
                productMasterSearchControl.cbbCountry.Text,
                productMasterSearchControl.cbbCountry.Text);


            AddListItemToCombo(productMasterSearchControl.cbbManufacturer,
                productMasterSearchControl.cbbManufacturer,
                eventArgs.ManufacturerList,
                "ManufacturerName",
                productMasterSearchControl.cbbManufacturer.Text,
                productMasterSearchControl.cbbManufacturer.Text);


            AddListItemToCombo(productMasterSearchControl.cbbDistributor,
                productMasterSearchControl.cbbDistributor,
                eventArgs.DistributorList,
                "DistributorName",
                productMasterSearchControl.cbbDistributor.Text,
                productMasterSearchControl.cbbDistributor.Text);


            AddListItemToCombo(productMasterSearchControl.cbbPackager,
                productMasterSearchControl.cbbPackager,
                eventArgs.PackagerList,
                "PackagerName",
                productMasterSearchControl.cbbPackager.Text,
                productMasterSearchControl.cbbPackager.Text);

            
            
        }

        /// <summary>
        /// Ham search ke thua tan du cua LinhNH1. khong dung box2 do khong xai Create
        /// </summary>
        /// <param name="box1"></param>
        /// <param name="box2"></param>
        /// <param name="data"></param>
        /// <param name="displayItemName"></param>
        /// <param name="currentText1"></param>
        /// <param name="currentText2"></param>
        private void AddListItemToCombo(ComboBox box1, ComboBox box2, IList data, string displayItemName, string currentText1, string currentText2)
        {
            box1.Items.Clear();
            //box2.Items.Clear();
            foreach (object type in data)
            {
                box1.Items.Add(type);
            //    box2.Items.Add(type);
            }
            box1.DisplayMember = displayItemName;
            //box2.DisplayMember = displayItemName;

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
            /*index = 1;
            if (!string.IsNullOrEmpty(box2.Text))
            {
                foreach (object type in data)
                {
                    if (currentText2.Equals(box2.Text))
                    {
                        box2.SelectedIndex = index;
                        box2.SelectedItem = type;
                        break;
                    }
                    index++;
                }
            }*/
        }
        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvProductMaster_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dgvProductMaster.SelectedRows;
            // if has row selected
            if(selectedRows.Count>0)
            {
                ProductMaster selectedProductMaster = productMasterBindingSource[selectedRows[0].Index] as ProductMaster;
                ProductMasterSearchDepartmentEventArgs eventArgs = new ProductMasterSearchDepartmentEventArgs();
                eventArgs.SelectedProductMaster = selectedProductMaster;
                EventUtility.fireEvent(SearchProductsEvent,this,eventArgs);
                IList productsInDepartment = eventArgs.ProductsInDepartment;
                deptStockList.Clear();
                foreach (DepartmentStockInDetail detail in productsInDepartment)
                {
                    deptStockList.Add(detail);
                }
                // TODO : add to detail list
                //deptStockBindingSource.DataSource = productsInDepartment;
                deptStockBindingSource.EndEdit();
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selection = dgvProducts.SelectedRows;
            if (SelectProductEvent != null)
            {
                ProductMasterSearchDepartmentEventArgs eventArgs = new ProductMasterSearchDepartmentEventArgs();
                eventArgs.ReturnProduct = deptStockList[selection[0].Index].Product;
                EventUtility.fireEvent(SelectProductEvent, this, eventArgs);
            }
            //Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
