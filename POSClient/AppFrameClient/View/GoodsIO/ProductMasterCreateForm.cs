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
using AppFrameClient.View.Masters;

namespace AppFrameClient.View.GoodsIO
{
    public partial class ProductMasterCreateForm : BaseForm, IProductMasterView
    {
        #region Implementation of IProductMasterView

        private IProductMasterController _productMasterController;
        public IProductMasterController ProductMasterController
        {
            set
            {
                _productMasterController = value;
                _productMasterController.ProductMasterView = this;
            }
        }

        public event EventHandler<ProductMasterEventArgs> SaveProductMasterEvent;
        public event EventHandler<ProductMasterEventArgs> LoadProductMasterEvent;
        public event EventHandler<ProductMasterEventArgs> InitProductMasterEvent;

        #endregion

        public ProductMaster ProductMaster { get; set; }
        public IList OldColorList { get; set; }
        public IList OldSizeList { get; set; }

        public ProductMasterCreateForm()
        {
            InitializeComponent();
            productMasterControl.btnCreateType.Click += new EventHandler(btnCreateType_Click);
            productMasterControl.btnCreateSize.Click += new EventHandler(btnCreateSize_Click);
            productMasterControl.btnCreatePackager.Click += new EventHandler(btnCreatePackager_Click);
            productMasterControl.btnCreateManufacturer.Click += new EventHandler(btnCreateManufacturer_Click);
            productMasterControl.btnCreateDistributor.Click += new EventHandler(btnCreateDistributor_Click);
            productMasterControl.btnCreateCountry.Click += new EventHandler(btnCreateCountry_Click);
            productMasterControl.btnCreateColor.Click += new EventHandler(btnCreateColor_Click);
            productMasterControl.btnSelect.Click += new EventHandler(btnSelect_Click);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void productMasterUserControl_Load(object sender, EventArgs e)
        {
            LoadProductMaster();
        }

        private void btnCreateColor_Click(object sender, EventArgs e)
        {
            AddToDataToBindingSource(MasterType.PRODUCT_COLOR,
                productMasterControl.colorBindingSource,
                productMasterControl.lbxProductColor);
        }

        private void btnCreateCountry_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.COUNTRY,
                productMasterControl.cbbCountry, productMasterControl.countryBindingSource);
        }

        private void btnCreateDistributor_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.DISTRIBUTOR,
                productMasterControl.cbbDistributor, productMasterControl.distributorBindingSource);
        }

        private void btnCreateManufacturer_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.MANUFACTURER,
                productMasterControl.cbbManufacturer, productMasterControl.manufacturerBindingSource);
        }

        private void btnCreatePackager_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.PACKAGER,
                productMasterControl.cbbPackager, productMasterControl.packagerBindingSource);
        }

        private void btnCreateSize_Click(object sender, EventArgs e)
        {
            AddToDataToBindingSource(MasterType.PRODUCT_SIZE,
                productMasterControl.sizeBindingSource,
                productMasterControl.lbxProductSize);
        }

        private void btnCreateType_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.PRODUCT_TYPE,
                productMasterControl.cbbProductType, productMasterControl.typeBindingSource);
        }

        private void AddToDataToBindingSource(MasterType masterType, BindingSource source, ListBox listBox)
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
                    case MasterType.PRODUCT_COLOR:
                        foreach (ProductColor type in source)
                        {
                            if (type.ColorId.Equals(((ProductColor)obj).ColorId))
                            {
                                listBox.SelectedIndex = index;
                                return;
                            }
                            index++;
                        }
                        break;
                    case MasterType.PRODUCT_SIZE:
                        foreach (ProductSize type in source)
                        {
                            if (type.SizeId.Equals(((ProductSize)obj).SizeId))
                            {
                                listBox.SelectedIndex = index;
                                return;
                            }
                            index++;
                        }
                        break;
                }
                source.Add(obj);
                listBox.SelectedIndex = source.Count - 1;
                Refresh();
            }
        }

        private void AddToDataToComboBox(MasterType masterType, ComboBox cbb1, BindingSource s)
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
                            if (type.TypeId.Equals(((ProductType)obj).TypeId))
                            {
                                cbb1.SelectedIndex = index;
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
                                return;
                            }
                            index++;
                        }
                        break;
                }
                s.Add(obj);
                cbb1.SelectedIndex = s.Count - 1;
                Refresh();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IList productSizeList = productMasterControl.lbxProductSize.SelectedItems;
            IList productColorList = productMasterControl.lbxProductColor.SelectedItems;
            var productMasters = new List<ProductMaster>();
            if (ProductMaster == null)
            {
                if (productSizeList.Count == 0 || productColorList.Count == 0)
                {
                    MessageBox.Show("Hãy chọn màu sắc và kích cỡ sản phẩm");
                    return;
                }

                if (productSizeList.Count > 0)
                {
                    foreach (ProductSize size in productSizeList)
                    {
                        bool addFlag = false;
                        foreach (ProductColor color in productColorList)
                        {
                            productMasters.Add(CreateProductMaster(size, color));
                            addFlag = true;
                        }
                        if (!addFlag)
                        {
                            productMasters.Add(CreateProductMaster(size, null));
                        }
                    }
                }
                else if (productColorList.Count > 0)
                {
                    foreach (ProductColor color in productColorList)
                    {
                        productMasters.Add(CreateProductMaster(null, color));
                    }
                }
                else
                {
                    productMasters.Add(CreateProductMaster(null, null));
                }
            }
            else
            {
                // make sure that the product master can not be deleted
                int count = 0;
                IList newColorList = new ArrayList();
                IList newSizeList = new ArrayList();
                foreach (ProductColor colorNew in productMasterControl.lbxProductColor.SelectedItems)
                {
                    bool found = false;
                    foreach (ProductColor color in OldColorList)
                    {
                        if (color.ColorId == colorNew.ColorId)
                        {
                            count++;
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        newColorList.Add(colorNew);
                    }
                }

                if (count != OldColorList.Count)
                {
                    MessageBox.Show("Không thể bỏ đi màu sắc sản phẩm.Bấm nút Trở về như cũ để hiển thị lại");
                    return;
                }

                count = 0;
                foreach (ProductSize sizeNew in productMasterControl.lbxProductSize.SelectedItems)
                {
                    bool found = false;
                    foreach (ProductSize size in OldSizeList)
                    {
                        if (size.SizeId == sizeNew.SizeId)
                        {
                            count++;
                            found = true;
                            break;
                        }
                    }
                    if (!found)
                    {
                        newSizeList.Add(sizeNew);
                    }
                }

                if (count != OldSizeList.Count)
                {
                    MessageBox.Show("Không thể bỏ đi kích cỡ sản phẩm.Bấm nút Trở về như cũ để hiển thị lại");
                    return;
                }

                if (newColorList.Count > 0)
                {
                    foreach (ProductColor color in newColorList)
                    {
                        foreach (ProductSize size in OldSizeList)
                        {
                            productMasters.Add(CreateProductMaster(size, color));
                        }
                        foreach (ProductSize size in newSizeList)
                        {
                            productMasters.Add(CreateProductMaster(size, color));
                        }
                    }
                }
                if (newSizeList.Count > 0) 
                {
                    foreach (ProductSize size in newSizeList)
                    {
                        foreach (ProductColor color in OldColorList)
                        {
                            productMasters.Add(CreateProductMaster(size, color));
                        }
                    }
                }
            }
            var eventArgs = new ProductMasterEventArgs { CreatedProductMasterList = productMasters};
            EventUtility.fireEvent(SaveProductMasterEvent, sender, eventArgs);
            if (eventArgs.EventResult != null)
            {
                MessageBox.Show("Lưu thành công");
                ClearForm();
                if (Status == ViewStatus.OPENDIALOG)
                {
                    EventUtility.fireEvent(CloseProductMasterEvent, this, eventArgs);
                }
            }
        }

        private void ClearForm()
        {
            productMasterControl.txtDescription.Text = "";
            productMasterControl.txtProductMasterId.Text = "";
            productMasterControl.txtProductName.Text = "";
            productMasterControl.cbbCountry.SelectedIndex = -1;
            productMasterControl.cbbDistributor.SelectedIndex = -1;
            productMasterControl.cbbManufacturer.SelectedIndex = -1;
            productMasterControl.cbbProductType.SelectedIndex = -1;
            productMasterControl.cbbPackager.SelectedIndex = -1;
            foreach (int selectedIndex in productMasterControl.lbxProductColor.SelectedIndices)
            {
                productMasterControl.lbxProductColor.SetSelected(selectedIndex,false);                
            }
            foreach (int selectedIndex in productMasterControl.lbxProductSize.SelectedIndices)
            {
                
                productMasterControl.lbxProductSize.SetSelected(selectedIndex, false);
            }
            productMasterControl.txtImagePath.Text = "";
            picProduct.Image = null;
        }

        private ProductMaster CreateProductMaster(ProductSize size, ProductColor color)
        {
            return new ProductMaster
            {
                ProductName = productMasterControl.txtProductName.Text,
                ImagePath = productMasterControl.txtImagePath.Text,
                Description = productMasterControl.txtDescription.Text,
                Packager = productMasterControl.cbbPackager.SelectedIndex > 0 ? ((Packager)productMasterControl.cbbPackager.SelectedItem) : null,
                ProductSize = size,
                ProductType = productMasterControl.cbbProductType.SelectedIndex > 0 ? ((ProductType)productMasterControl.cbbProductType.SelectedItem) : null,
                ProductColor = color,
                Country = productMasterControl.cbbCountry.SelectedIndex > 0 ? ((Country)productMasterControl.cbbCountry.SelectedItem) : null,
                Manufacturer = productMasterControl.cbbManufacturer.SelectedIndex > 0 ? ((Manufacturer)productMasterControl.cbbManufacturer.SelectedItem) : null,
                Distributor = productMasterControl.cbbDistributor.SelectedIndex > 0 ? ((Distributor)productMasterControl.cbbDistributor.SelectedItem) : null
            };
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            var fileOpen = new OpenFileDialog();
            fileOpen.InitialDirectory = ".\\";
            fileOpen.Filter = "Image Files|*.jpg;*.gif;*.bmp;*.png;*.jpeg;*.png|All Files|*.*";
            fileOpen.FilterIndex = 0;
            fileOpen.RestoreDirectory = true;
            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                productMasterControl.txtImagePath.Text = fileOpen.FileName;
                ShowProductImage();
            }
        }

        private void ShowProductImage()
        {
            try
            {
                int newWidth = picProduct.Width;
                int maxHeight = picProduct.Height;
                Image fullsizeImage = Image.FromFile(productMasterControl.txtImagePath.Text);
                // Prevent using images internal thumbnail
                fullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
                fullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

                if (fullsizeImage.Width <= newWidth)
                {
                    newWidth = fullsizeImage.Width;
                }
                int newHeight = fullsizeImage.Height * newWidth / fullsizeImage.Width;
                if (newHeight > maxHeight)
                {
                    // Resize with height instead
                    //newWidth = fullsizeImage.Width * maxHeight / fullsizeImage.Height;
                    newHeight = maxHeight;
                }

                System.Drawing.Image newImage = fullsizeImage.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);

                // Clear handle to original file so that we can overwrite it if necessary
                fullsizeImage.Dispose();


                picProduct.Image = newImage;
            }
            catch (Exception ex)
            {
                //throw ex; Ignore
            }
        }


        #region IProductMasterView Members


        public event EventHandler<ProductMasterEventArgs> CloseProductMasterEvent;

        #endregion

        private void btnRevert_Click(object sender, EventArgs e)
        {
            LoadProductMaster();
        }

        private void LoadProductMaster()
        {
            var eventArgs = new ProductMasterEventArgs();
            eventArgs.ProductMasterForInit = ProductMaster;
            EventUtility.fireEvent(InitProductMasterEvent, this, eventArgs);

            productMasterControl.typeBindingSource.DataSource = eventArgs.ProductTypeList;
            productMasterControl.cbbProductType.DisplayMember = "TypeName";

            if (eventArgs.ProductSizeList.Count > 1)
            {
                eventArgs.ProductSizeList.RemoveAt(0);
                productMasterControl.sizeBindingSource.DataSource = eventArgs.ProductSizeList;
            }
            //productMasterControl.cbbProductSize.DisplayMember = "SizeName";

            if (eventArgs.ProductColorList.Count > 1)
            {
                eventArgs.ProductColorList.RemoveAt(0);
                productMasterControl.colorBindingSource.DataSource = eventArgs.ProductColorList;
            }
            //productMasterControl.cbbProductColor.DisplayMember = "ColorName";

            productMasterControl.countryBindingSource.DataSource = eventArgs.CountryList;
            productMasterControl.cbbCountry.DisplayMember = "CountryName";

            productMasterControl.distributorBindingSource.DataSource = eventArgs.DistributorList;
            productMasterControl.cbbDistributor.DisplayMember = "DistributorName";

            productMasterControl.manufacturerBindingSource.DataSource = eventArgs.ManufacturerList;
            productMasterControl.cbbManufacturer.DisplayMember = "ManufacturerName";

            productMasterControl.packagerBindingSource.DataSource = eventArgs.PackagerList;
            productMasterControl.cbbPackager.DisplayMember = "PackagerName";

            if (ProductMaster != null)
            {
                btnRevert.Visible = true;
                OldColorList = new ArrayList();
                OldSizeList = new ArrayList();
                productMasterControl.txtDescription.Text = ProductMaster.Description;
                productMasterControl.txtProductMasterId.Text = ProductMaster.ProductMasterId;
                productMasterControl.txtProductName.Text = ProductMaster.ProductName;
                int i = 0;
                if (ProductMaster.Country != null)
                {
                    foreach (Country country in eventArgs.CountryList)
                    {
                        if (country.CountryId == ProductMaster.Country.CountryId)
                        {
                            productMasterControl.cbbCountry.SelectedIndex = i;
                        }
                        i++;
                    }
                }
                productMasterControl.cbbCountry.Enabled = false;

                i = 0;
                if (ProductMaster.Distributor != null)
                {
                    foreach (Distributor distributor in eventArgs.DistributorList)
                    {
                        if (distributor.DistributorId == ProductMaster.Distributor.DistributorId)
                        {
                            productMasterControl.cbbDistributor.SelectedIndex = i;
                        }
                        i++;
                    }
                }
                productMasterControl.cbbDistributor.Enabled = false;

                i = 0;
                if (ProductMaster.ProductType != null)
                {
                    foreach (ProductType productType in eventArgs.ProductTypeList)
                    {
                        if (productType.TypeId == ProductMaster.ProductType.TypeId)
                        {
                            productMasterControl.cbbProductType.SelectedIndex = i;
                        }
                        i++;
                    }
                }
                productMasterControl.cbbProductType.Enabled = false;

                i = 0;
                if (ProductMaster.Manufacturer != null)
                {
                    foreach (Manufacturer manufacturer in eventArgs.ManufacturerList)
                    {
                        if (manufacturer.ManufacturerId == ProductMaster.Manufacturer.ManufacturerId)
                        {
                            productMasterControl.cbbManufacturer.SelectedIndex = i;
                        }
                        i++;
                    }
                }
                productMasterControl.cbbManufacturer.Enabled = false;

                i = 0;
                if (ProductMaster.Packager != null)
                {
                    foreach (Packager packager in eventArgs.PackagerList)
                    {
                        if (packager.PackagerId == ProductMaster.Packager.PackagerId)
                        {
                            productMasterControl.cbbPackager.SelectedIndex = i;
                        }
                        i++;
                    }
                }
                productMasterControl.cbbPackager.Enabled = false;

                i = 0;
                if (ProductMaster.Packager != null)
                {
                    foreach (Packager packager in eventArgs.PackagerList)
                    {
                        if (packager.PackagerId == ProductMaster.Packager.PackagerId)
                        {
                            productMasterControl.cbbPackager.SelectedIndex = i;
                        }
                        i++;
                    }
                }
                if (eventArgs.SameProductMasterList != null && eventArgs.SameProductMasterList.Count > 0)
                {

                    foreach (ProductMaster master in eventArgs.SameProductMasterList)
                    {
                        i = 0;
                        foreach (ProductColor color in eventArgs.ProductColorList)
                        {
                            if (master.ProductColor != null && master.ProductColor.ColorId == color.ColorId)
                            {
                                productMasterControl.lbxProductColor.SetSelected(i, true);
                                bool add = true;
                                foreach (ProductColor oldColor in OldColorList)
                                {
                                    if (oldColor.ColorId == master.ProductColor.ColorId)
                                    {
                                        add = false;
                                        break;
                                    }
                                }
                                if (add)
                                {
                                    OldColorList.Add(master.ProductColor);
                                }
                                break;
                            }
                            i++;
                        }

                        i = 0;
                        foreach (ProductSize size in eventArgs.ProductSizeList)
                        {
                            if (master.ProductSize != null && master.ProductSize.SizeId == size.SizeId)
                            {
                                productMasterControl.lbxProductSize.SetSelected(i, true);
                                bool add = true;
                                foreach (ProductSize oldSize in OldSizeList)
                                {
                                    if (oldSize.SizeId == master.ProductSize.SizeId)
                                    {
                                        add = false;
                                        break;
                                    }
                                }
                                if (add)
                                {
                                    OldSizeList.Add(master.ProductSize);
                                }
                                break;
                            }
                            i++;
                        }
                    }
                }
                productMasterControl.btnCreateCountry.Enabled = false;
                productMasterControl.btnCreateDistributor.Enabled = false;
                productMasterControl.btnCreateManufacturer.Enabled = false;
                productMasterControl.btnCreatePackager.Enabled = false;
                productMasterControl.btnCreateType.Enabled = false;
                productMasterControl.btnSelect.Enabled = false;
                productMasterControl.txtImagePath.Text = ProductMaster.ImagePath;
                ShowProductImage();
            }
        }
    }
}
