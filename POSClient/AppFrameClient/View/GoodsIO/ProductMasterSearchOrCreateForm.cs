using System;
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
using System.Collections;
using AppFrameClient.Common;
using AppFrameClient.View.Masters;

namespace AppFrameClient.View.GoodsIO
{
    public partial class ProductMasterSearchOrCreateForm : BaseForm, IProductMasterSearchOrCreateView
    {
        private ProductMasterControl productMasterControl = new ProductMasterControl();
        public ProductMasterSearchOrCreateForm()
        {
            InitializeComponent();
            productMasterControl.btnCreateType.Click += new EventHandler(btnCreateType_Click);
            productMasterControl.btnCreateSize.Click += new EventHandler(btnCreateSize_Click);
            productMasterControl.btnCreatePackager.Click += new EventHandler(btnCreatePackager_Click);
            productMasterControl.btnCreateManufacturer.Click += new EventHandler(btnCreateManufacturer_Click);
            productMasterControl.btnCreateDistributor.Click += new EventHandler(btnCreateDistributor_Click);
            productMasterControl.btnCreateCountry.Click += new EventHandler(btnCreateCountry_Click);
            productMasterControl.btnCreateColor.Click += new EventHandler(btnCreateColor_Click);
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
        public event EventHandler<ProductMasterSearchOrCreateEventArgs> SearchCommonProductMasterEvent;
        public event EventHandler<ProductMasterSearchOrCreateEventArgs> SearchRelevantProductsEvent;
        public event EventHandler<ProductMasterSearchOrCreateEventArgs> SelectProductMasterEvent;
        public event EventHandler<ProductMasterSearchOrCreateEventArgs> InitProductMasterSearchOrCreateEvent;
        public event EventHandler<ProductMasterSearchOrCreateEventArgs> OpenProductMasterSearchOrCreateEvent;

        #endregion

        private void ProductMasterSearchOrCreateForm_Load(object sender, EventArgs e)
        {
            var eventArgs = new ProductMasterSearchOrCreateEventArgs();
            EventUtility.fireEvent(InitProductMasterSearchOrCreateEvent, sender, eventArgs);

            AddListItemToCombo(productMasterControl.cbbProductType,
                productMasterSearchControl.cbbProductType,
                eventArgs.ProductTypeList,
                "TypeName",
                productMasterControl.cbbProductType.Text,
                productMasterSearchControl.cbbProductType.Text);

            AddListItemToCombo(productMasterControl.cbbProductSize,
                productMasterSearchControl.cbbProductSize,
                eventArgs.ProductSizeList,
                "SizeName",
                productMasterControl.cbbProductSize.Text,
                productMasterSearchControl.cbbProductSize.Text);


            AddListItemToCombo(productMasterControl.cbbProductColor,
                productMasterSearchControl.cbbProductColor,
                eventArgs.ProductColorList,
                "ColorName",
                productMasterControl.cbbProductColor.Text,
                productMasterSearchControl.cbbProductColor.Text);


            AddListItemToCombo(productMasterControl.cbbCountry,
                productMasterSearchControl.cbbCountry,
                eventArgs.CountryList,
                "CountryName",
                productMasterControl.cbbCountry.Text,
                productMasterSearchControl.cbbCountry.Text);


            AddListItemToCombo(productMasterControl.cbbManufacturer,
                productMasterSearchControl.cbbManufacturer,
                eventArgs.ManufacturerList,
                "ManufacturerName",
                productMasterControl.cbbManufacturer.Text,
                productMasterSearchControl.cbbManufacturer.Text);


            AddListItemToCombo(productMasterControl.cbbDistributor,
                productMasterSearchControl.cbbDistributor,
                eventArgs.DistributorList,
                "DistributorName",
                productMasterControl.cbbDistributor.Text,
                productMasterSearchControl.cbbDistributor.Text);


            AddListItemToCombo(productMasterControl.cbbPackager,
                productMasterSearchControl.cbbPackager,
                eventArgs.PackagerList,
                "PackagerName",
                productMasterControl.cbbPackager.Text,
                productMasterSearchControl.cbbPackager.Text);


            SelectedProductMaster = null;
            dgvProductMaster.DataSource = null;
            if (ProductMasterList != null && ProductMasterList.Count > 0)
            {
                dgvProductMaster.DataSource = ProductMasterList;
                for (int i = 0; i < ProductMasterList.Count; i++)
                {
                    dgvProductMaster[0, i].Value = i;
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var eventArgs = new ProductMasterSearchOrCreateEventArgs
                                {
                                    ProductMasterId = productMasterSearchControl.txtProductMasterId.Text,
                                    Packager = productMasterControl.cbbPackager.SelectedIndex > 0 ? ((Packager)productMasterControl.cbbPackager.SelectedItem) : null,
                                    ProductMasterName = productMasterSearchControl.txtProductName.Text,
                                    ProductSize = productMasterSearchControl.cbbProductSize.SelectedIndex > 0 ? ((ProductSize)productMasterControl.cbbProductSize.SelectedItem) : null,
                                    ProductType = productMasterSearchControl.cbbProductType.SelectedIndex > 0 ? ((ProductType)productMasterControl.cbbProductType.SelectedItem) : null,
                                    ProductColor = productMasterSearchControl.cbbProductColor.SelectedIndex > 0 ?
                                        ((ProductColor)productMasterSearchControl.cbbProductColor.SelectedItem) : null,
                                    Country = productMasterControl.cbbCountry.SelectedIndex > 0 ? ((Country)productMasterControl.cbbCountry.SelectedItem) : null,
                                    Manufacturer = productMasterControl.cbbManufacturer.SelectedIndex > 0 ? ((Manufacturer)productMasterControl.cbbManufacturer.SelectedItem) : null,
                                    Distributor = productMasterControl.cbbDistributor.SelectedIndex > 0 ? ((Distributor)productMasterControl.cbbDistributor.SelectedItem) : null
                                };
            EventUtility.fireEvent(SearchProductMasterEvent, sender, eventArgs);
            ProductMasterList = eventArgs.ProductMasterList;
            dgvProductMaster.DataSource = ProductMasterList;
            /*for (int i = 0; i < ProductMasterList.Count; i++)
            {
                dgvProductMaster[0, i].Value = i;
            }*/
        }

        public IList ProductMasterList { get; set; }
        public ProductMaster SelectedProductMaster { get; set; }
        public bool IsCallFromMenu { get; set; }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection rows = dgvProductMaster.SelectedRows;
            
            if(rows.Count>0)
            {
                var rowIndex = rows[0].Index;
                string productMasterId = dgvProductMaster[0, rowIndex].Value.ToString();
                foreach (ProductMaster productMaster in ProductMasterList)
                {
                    if (productMaster.ProductMasterId.Equals(productMasterId))
                    {
                        SelectedProductMaster = productMaster;
                        break;
                    }
                }
                if (!IsCallFromMenu)
                {
                    Close();
                } 
            }

            /*if (ProductMasterList != null && dgvProductMaster.SelectedCells.Count > 0
                && dgvProductMaster.SelectedCells[0].RowIndex <= ProductMasterList.Count
                && dgvProductMaster.SelectedCells[0].RowIndex >= 0)
            {
                var rowIndex = dgvProductMaster.SelectedCells[0].RowIndex;
                string productMasterId = dgvProductMaster[0, rowIndex].Value.ToString();
                foreach (ProductMaster productMaster in ProductMasterList)
                {
                    if (productMaster.ProductMasterId.Equals(productMasterId))
                    {
                        SelectedProductMaster = productMaster;
                        break;
                    }
                }
                if (!IsCallFromMenu)
                {
                    Close();
                }
            }*/
        }

        private void dgvProductMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (ProductMasterList != null && e.RowIndex <= ProductMasterList.Count && e.RowIndex >= 0)
            {
                string productMasterId = dgvProductMaster[0, e.RowIndex].Value.ToString();
                foreach (ProductMaster productMaster in ProductMasterList)
                {
                    if (productMaster.ProductMasterId.Equals(productMasterId))
                    {
                        SelectedProductMaster = productMaster;
                    }
                }
                if (!IsCallFromMenu)
                {
                    Close();
                }
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            var productMaster = new ProductMaster
                                    {
                                        ProductName = productMasterControl.txtProductName.Text,
                                        Packager = productMasterControl.cbbPackager.SelectedIndex > 0 ? ((Packager) productMasterControl.cbbPackager.SelectedItem) : null,
                                        ProductSize = productMasterControl.cbbProductSize.SelectedIndex > 0 ? ((ProductSize) productMasterControl.cbbProductSize.SelectedItem) : null,
                                        ProductType = productMasterControl.cbbProductType.SelectedIndex > 0 ? ((ProductType) productMasterControl.cbbProductType.SelectedItem) : null,
                                        ProductColor = productMasterControl.cbbProductColor.SelectedIndex > 0 ? 
                                            ((ProductColor) productMasterControl.cbbProductColor.SelectedItem) : null,
                                        Country = productMasterControl.cbbCountry.SelectedIndex > 0 ? ((Country) productMasterControl.cbbCountry.SelectedItem) : null,
                                        Manufacturer = productMasterControl.cbbManufacturer.SelectedIndex > 0 ? ((Manufacturer)productMasterControl.cbbManufacturer.SelectedItem) : null,
                                        Distributor = productMasterControl.cbbDistributor.SelectedIndex > 0 ? ((Distributor)productMasterControl.cbbDistributor.SelectedItem) : null
                                    };

            var eventArgs = new ProductMasterSearchOrCreateEventArgs { ProductMaster = productMaster };
            EventUtility.fireEvent(SaveProductMasterEvent, sender, eventArgs);
            SelectedProductMaster = productMaster;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCancel1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddToDataToComboBox(MasterType masterType, ComboBox cbb1, ComboBox cbb2)
        {
            var universalMasterCreateForm = GlobalUtility.GetFormObject<UniversalMasterCreateForm>(FormConstants.UNIVERASAL_MASTER_CREATE_FORM);
            universalMasterCreateForm.IsNeedClosing = true;
            universalMasterCreateForm.MasterType = masterType;
            universalMasterCreateForm.ShowDialog();

            object obj = universalMasterCreateForm.CreatedItem;
            if (obj != null)
            {
                int index = 0;
                switch (masterType)
                {
                    case MasterType.PRODUCT_TYPE:
                        foreach (ProductType type in cbb1.Items)
                        {
                            if (type.TypeId.Equals(((ProductType) obj).TypeId))
                            {
                                cbb1.SelectedIndex = index;
                                cbb2.SelectedIndex = index;
                                return;
                            }
                            index++;
                        }
                        break;
                    case MasterType.PRODUCT_SIZE:
                        foreach (ProductSize type in cbb1.Items)
                        {
                            if (type.SizeId.Equals(((ProductSize)obj).SizeId))
                            {
                                cbb1.SelectedIndex = index;
                                cbb2.SelectedIndex = index;
                                return;
                            }
                            index++;
                        }
                        break;
                    case MasterType.PRODUCT_COLOR:
                        foreach (ProductColor type in cbb1.Items)
                        {
                            if (type.ColorId.Equals(((ProductColor)obj).ColorId))
                            {
                                cbb1.SelectedIndex = index;
                                cbb2.SelectedIndex = index;
                                return;
                            }
                            index++;
                        }
                        break;
                    case MasterType.COUNTRY:
                        foreach (Country type in cbb1.Items)
                        {
                            if (type.CountryId.Equals(((Country)obj).CountryId))
                            {
                                cbb1.SelectedIndex = index;
                                cbb2.SelectedIndex = index;
                                return;
                            }
                            index++;
                        }
                        break;
                    case MasterType.DISTRIBUTOR:
                        foreach (Distributor type in cbb1.Items)
                        {
                            if (type.DistributorId.Equals(((Distributor)obj).DistributorId))
                            {
                                cbb1.SelectedIndex = index;
                                cbb2.SelectedIndex = index;
                                return;
                            }
                            index++;
                        }
                        break;
                    case MasterType.MANUFACTURER:
                        foreach (Manufacturer type in cbb1.Items)
                        {
                            if (type.ManufacturerId.Equals(((Manufacturer)obj).ManufacturerId))
                            {
                                cbb1.SelectedIndex = index;
                                cbb2.SelectedIndex = index;
                                return;
                            }
                            index++;
                        }
                        break;
                    case MasterType.PACKAGER:
                        foreach (Packager type in cbb1.Items)
                        {
                            if (type.PackagerId.Equals(((Packager)obj).PackagerId))
                            {
                                cbb1.SelectedIndex = index;
                                cbb2.SelectedIndex = index;
                                return;
                            }
                            index++;
                        }
                        break;
                }
                cbb1.Items.Add(obj);
                cbb2.Items.Add(obj);
                cbb1.SelectedIndex = cbb1.Items.Count - 1;
                cbb2.SelectedIndex = cbb2.Items.Count - 1;
                Refresh();
            }
        }

        private void AddListItemToCombo(ComboBox box1, ComboBox box2, IList data, string displayItemName, string currentText1, string currentText2)
        {
            box1.Items.Clear();
            box2.Items.Clear();
            foreach (object type in data)
            {
                box1.Items.Add(type);
                box2.Items.Add(type);
            }
            box1.DisplayMember = displayItemName;
            box2.DisplayMember = displayItemName;

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
            index = 1;
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
            }
        }

        private void btnCreateColor_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.PRODUCT_COLOR, 
                productMasterControl.cbbProductColor,
                productMasterSearchControl.cbbProductColor);
        }

        private void btnCreateCountry_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.COUNTRY,
                productMasterControl.cbbCountry,
                productMasterSearchControl.cbbCountry);
        }

        private void btnCreateDistributor_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.DISTRIBUTOR,
                productMasterControl.cbbDistributor,
                productMasterSearchControl.cbbDistributor);
        }

        private void btnCreateManufacturer_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.MANUFACTURER,
                productMasterControl.cbbManufacturer,
                productMasterSearchControl.cbbManufacturer);
        }

        private void btnCreatePackager_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.PACKAGER,
                productMasterControl.cbbPackager,
                productMasterSearchControl.cbbPackager);
        }

        private void btnCreateSize_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.PRODUCT_SIZE,
                productMasterControl.cbbProductSize,
                productMasterSearchControl.cbbProductSize);
        }

        private void btnCreateType_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.PRODUCT_TYPE,
                productMasterControl.cbbProductType,
                productMasterSearchControl.cbbProductType);
        }
    }
}
