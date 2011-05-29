using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
    public partial class ProductMasterExtraForm : BaseForm, IProductMasterView
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
        public event EventHandler<ProductMasterEventArgs> CloseProductMasterEvent;

        #endregion

        public ProductMaster ProductMaster { get; set; }
        public IList OldColorList { get; set; }
        public IList OldSizeList { get; set; }
        public IList OldProductMasterList { get; set; }


        public ProductMasterExtraForm()
        {
            InitializeComponent();
        }

        private void ProductMasterExtraForm_Load(object sender, EventArgs e)
        {
            var eventArgs = new ProductMasterEventArgs();
            eventArgs.ProductMasterForInit = ProductMaster;
            EventUtility.fireEvent(InitProductMasterEvent, this, eventArgs);

            if (eventArgs.ProductTypeList.Count > 1)
            {
                eventArgs.ProductTypeList.RemoveAt(0);
                typeBindingSource.DataSource = eventArgs.ProductTypeList;
                cbbProductType.DisplayMember = "TypeName";
            }

            if (eventArgs.ProductSizeList.Count > 1)
            {
                eventArgs.ProductSizeList.RemoveAt(0);
                sizeBindingSource.DataSource = eventArgs.ProductSizeList;

            }
            //productMasterControl.cbbProductSize.DisplayMember = "SizeName";

            if (eventArgs.ProductColorList.Count > 1)
            {
                eventArgs.ProductColorList.RemoveAt(0);
                colorBindingSource.DataSource = eventArgs.ProductColorList;

            }
            //productMasterControl.cbbProductColor.DisplayMember = "ColorName";

            countryBindingSource.DataSource = eventArgs.CountryList;
            cbbCountry.DisplayMember = "CountryName";

            distributorBindingSource.DataSource = eventArgs.DistributorList;
            cbbDistributor.DisplayMember = "DistributorName";

            manufacturerBindingSource.DataSource = eventArgs.ManufacturerList;
            cbbManufacturer.DisplayMember = "ManufacturerName";

            packagerBindingSource.DataSource = eventArgs.PackagerList;
            cbbPackager.DisplayMember = "PackagerName";

            if (ProductMaster != null)
            {
                OldProductMasterList = new ArrayList();
                OldColorList = new ArrayList();
                OldSizeList = new ArrayList();
                txtDescription.Text = ProductMaster.Description;
                txtProductMasterId.Text = ProductMaster.ProductMasterId;
                txtProductName.Text = ProductMaster.ProductName;
                int i = 0;
                if (ProductMaster.Country != null)
                {
                    foreach (Country country in eventArgs.CountryList)
                    {
                        if (country.CountryId == ProductMaster.Country.CountryId)
                        {
                            cbbCountry.SelectedIndex = i;
                        }
                        i++;
                    }
                }
                cbbCountry.Enabled = false;

                i = 0;
                if (ProductMaster.Distributor != null)
                {
                    foreach (Distributor distributor in eventArgs.DistributorList)
                    {
                        if (distributor.DistributorId == ProductMaster.Distributor.DistributorId)
                        {
                            cbbDistributor.SelectedIndex = i;
                        }
                        i++;
                    }
                }
                cbbDistributor.Enabled = false;

                i = 0;
                if (ProductMaster.ProductType != null)
                {
                    foreach (ProductType productType in eventArgs.ProductTypeList)
                    {
                        if (productType.TypeId == ProductMaster.ProductType.TypeId)
                        {
                            cbbProductType.SelectedIndex = i;
                        }
                        i++;
                    }
                }
                cbbProductType.Enabled = false;

                i = 0;
                if (ProductMaster.Manufacturer != null)
                {
                    foreach (Manufacturer manufacturer in eventArgs.ManufacturerList)
                    {
                        if (manufacturer.ManufacturerId == ProductMaster.Manufacturer.ManufacturerId)
                        {
                            cbbManufacturer.SelectedIndex = i;
                        }
                        i++;
                    }
                }
                cbbManufacturer.Enabled = false;

                i = 0;
                if (ProductMaster.Packager != null)
                {
                    foreach (Packager packager in eventArgs.PackagerList)
                    {
                        if (packager.PackagerId == ProductMaster.Packager.PackagerId)
                        {
                            cbbPackager.SelectedIndex = i;
                        }
                        i++;
                    }
                }
                cbbPackager.Enabled = false;

                i = 0;
                if (ProductMaster.Packager != null)
                {
                    foreach (Packager packager in eventArgs.PackagerList)
                    {
                        if (packager.PackagerId == ProductMaster.Packager.PackagerId)
                        {
                            cbbPackager.SelectedIndex = i;
                        }
                        i++;
                    }
                }
                if (eventArgs.SameProductMasterList != null && eventArgs.SameProductMasterList.Count > 0)
                {
                    IList disableColorList = new ArrayList();
                    IList disableSizeList = new ArrayList();
                    foreach (ProductMaster master in eventArgs.SameProductMasterList)
                    {
                        if (!ExistInList(OldProductMasterList, master))
                        {
                            OldProductMasterList.Add(master);
                        }
                        if (!ExistInList(OldColorList, master.ProductColor))
                        {
                            OldColorList.Add(master.ProductColor);
                        }

                        if (!ExistInList(OldSizeList, master.ProductSize))
                        {
                            OldSizeList.Add(master.ProductSize);
                        }

                        disableColorList.Add(master.ProductColor);
                        disableSizeList.Add(master.ProductSize);
                    }
                    bdsColors.DataSource = OldColorList;
                    lstProductColors.DisplayMember = "ColorName";
                    lstProductColors.DisabledRows = disableColorList;
                    lstProductSizes.DisabledRows = disableSizeList;
                    lstProductSizes.DisplayMember = "SizeName";
                    bdsSizes.DataSource = OldSizeList;

                    bdsColors.ResetBindings(false);
                    bdsSizes.ResetBindings(false);
                    lstProductColors.Refresh();
                    lstProductColors.Invalidate();
                    lstProductSizes.Refresh();
                    lstProductSizes.Invalidate();
                }

                btnCreateCountry.Enabled = false;
                btnCreateDistributor.Enabled = false;
                btnCreateManufacturer.Enabled = false;
                btnCreatePackager.Enabled = false;
                btnCreateType.Enabled = false;
                btnCreateType.Enabled = false;
                btnSelect.Enabled = true;
                txtImagePath.Text = ProductMaster.ImagePath;
                ShowProductImage();
            }

        }

        private bool ExistInList(IList OldProductMasterList, ProductMaster master)
        {
            foreach (ProductMaster productMaster in OldProductMasterList)
            {
                if (productMaster.ProductMasterId.Equals(master.ProductMasterId))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ExistInList(IList colorList, ProductColor color)
        {
            foreach (ProductColor list in colorList)
            {
                if (list.ColorName.Equals(color.ColorName))
                {
                    return true;
                }
            }
            return false;
        }
        private bool ExistInList(IList sizeList, ProductSize size)
        {
            foreach (ProductSize list in sizeList)
            {
                if (list.SizeName.Equals(size.SizeName))
                {
                    return true;
                }
            }
            return false;
        }

        private void btnAddColor_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedColors = lbxProductColor.SelectedItems;

            foreach (ProductColor color in selectedColors)
            {
                int index = -1;
                if (NotInList(bdsColors, color, out index))
                {
                    bdsColors.Add(color);
                }
            }
            bdsColors.ResetBindings(false);
            lstProductColors.Refresh();
        }

        private bool NotInList(BindingSource source, ProductColor color, out int index)
        {
            int count = 0;
            foreach (ProductColor productColor in source)
            {
                if (productColor.ColorName.Equals(color.ColorName))
                {
                    index = count;
                    return false;
                }
                count++;
            }
            index = -1;
            return true;
        }

        private void btnRemoveColor_Click(object sender, EventArgs e)
        {
            if (lstProductColors.Items.Count == 0)
            {
                return;
            }
            IList list = lstProductColors.SelectedIndices;
            int i = list.Count - 1;
            while (i >= 0)
            {
                bdsColors.RemoveAt((int)list[i]);
                i--;
            }
            bdsColors.ResetBindings(false);
            lstProductColors.Refresh();
        }

        private void btnAddSize_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selectedSizes = lbxProductSize.SelectedItems;

            foreach (ProductSize size in selectedSizes)
            {
                int index = -1;
                if (NotInList(bdsSizes, size, out index))
                {
                    bdsSizes.Add(size);
                }
            }
            bdsSizes.ResetBindings(false);
            lstProductSizes.Refresh();
        }

        private bool NotInList(BindingSource source, ProductSize size, out int index)
        {
            int count = 0;
            foreach (ProductSize productColor in source)
            {
                if (productColor.SizeName.Equals(size.SizeName))
                {
                    index = count;
                    return false;
                }
            }
            index = -1;
            return true;
        }

        private void btnRemoveSize_Click(object sender, EventArgs e)
        {
            if (lstProductSizes.Items.Count == 0)
            {
                return;
            }

            IList list = lstProductSizes.SelectedIndices;
            int i = list.Count - 1;
            while (i >= 0)
            {
                bdsSizes.RemoveAt((int)list[i]);
                i--;
            }
            bdsSizes.ResetBindings(false);
            lstProductSizes.Refresh();
        }

        private void cbbProductType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                txtProductType.Text = ((ProductType)cbbProductType.SelectedItem).TypeName;
            }
            catch (Exception)
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            IList productSizeList = lstProductSizes.Items;
            IList productColorList = lstProductColors.Items;
            var productMasters = new List<ProductMaster>();
            if (string.IsNullOrEmpty(txtProductName.Text))
            {
                MessageBox.Show("Hãy nhập tên sản phẩm !");
                return;
            }
            if (cbbProductType.SelectedIndex < 0)
            {
                MessageBox.Show("Hãy chọn loại sản phẩm !");
                return;
            }
            if (Status == ViewStatus.ADD || Status == ViewStatus.OPENDIALOG)
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
            else // update ProductMasters
            {
                // make sure that the product master can not be deleted
                int count = 0;
                IList newColorList = new ArrayList();
                IList newSizeList = new ArrayList();

                newColorList = lstProductColors.EnabledItems;
                newSizeList = lstProductSizes.EnabledItems;

                if (newColorList.Count > 0)
                {
                    foreach (ProductColor color in newColorList)
                    {
                        foreach (ProductSize size in OldSizeList)
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

            var eventArgs = new ProductMasterEventArgs { CreatedProductMasterList = productMasters };
            // get old product master
            if (OldProductMasterList != null)
            {
                foreach (ProductMaster master in OldProductMasterList)
                {
                    master.ProductName = txtProductName.Text.Trim();
                    master.Description = txtDescription.Text.Trim();
                    master.ImagePath = txtImagePath.Text;
                }
                eventArgs.UpdateProductMasterList = OldProductMasterList;
            }


            EventUtility.fireEvent(SaveProductMasterEvent, sender, eventArgs);
            if (eventArgs.EventResult != null)
            {
                MessageBox.Show("Lưu thành công");
                if (Status == ViewStatus.OPENDIALOG || Status == ViewStatus.EDIT)
                {
                    EventUtility.fireEvent(CloseProductMasterEvent, this, eventArgs);
                }
                else
                {
                    ClearForm();
                }
            }

        }

        private void ClearForm()
        {
            txtDescription.Text = "";
            txtProductMasterId.Text = "";
            txtProductName.Text = "";
            cbbCountry.SelectedIndex = 0;
            cbbDistributor.SelectedIndex = 0;
            cbbManufacturer.SelectedIndex = 0;
            cbbProductType.SelectedIndex = 0;
            cbbPackager.SelectedIndex = 0;

            bdsColors.Clear();
            bdsColors.ResetBindings(false);
            lstProductColors.Refresh();
            lbxProductColor.SelectedIndices.Clear();
            lbxProductSize.SelectedIndices.Clear();
            bdsSizes.Clear();
            bdsSizes.ResetBindings(false);
            lstProductSizes.Refresh();

            txtImagePath.Text = "";
            picProduct.Image = null;
        }

        private ProductMaster CreateProductMaster(ProductSize size, ProductColor color)
        {
            return new ProductMaster
            {
                ProductName = txtProductName.Text,
                ImagePath = txtImagePath.Text,
                Description = txtDescription.Text,
                Packager = cbbPackager.SelectedIndex > 0 ? ((Packager)cbbPackager.SelectedItem) : null,
                ProductSize = size,
                ProductType = (ProductType)cbbProductType.SelectedItem,
                ProductColor = color,
                Country = cbbCountry.SelectedIndex > 0 ? ((Country)cbbCountry.SelectedItem) : null,
                Manufacturer = cbbManufacturer.SelectedIndex > 0 ? ((Manufacturer)cbbManufacturer.SelectedItem) : null,
                Distributor = cbbDistributor.SelectedIndex > 0 ? ((Distributor)cbbDistributor.SelectedItem) : null
            };
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string imagePath = "";
            DialogResult result = imagePathFileDialog.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                imagePath = imagePathFileDialog.FileName;
            }
            txtImagePath.Text = imagePath;
            ShowPreviewImage();
        }

        private void ShowPreviewImage()
        {
            try
            {
                int newWidth = picProduct.Width;
                int maxHeight = picProduct.Height;
                Image fullsizeImage = Image.FromFile(txtImagePath.Text);
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
                picProduct.Refresh();

            }
            catch (Exception ex)
            {
                //throw ex; Ignore
            }
        }

        private void ShowProductImage()
        {
            try
            {
                int newWidth = picProduct.Width;
                int maxHeight = picProduct.Height;
                Image fullsizeImage = Image.FromFile(Application.StartupPath + "\\ProductImages\\" + txtImagePath.Text);
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
                picProduct.Refresh();
            }
            catch (Exception ex)
            {
                //throw ex; Ignore
            }
        }

        private void btnCreateType_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.PRODUCT_TYPE,
                cbbProductType, typeBindingSource);
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

        private void btnCreateColor_Click(object sender, EventArgs e)
        {
            AddToDataToBindingSource(MasterType.PRODUCT_COLOR,
                colorBindingSource,
                lbxProductColor);
        }

        private void btnCreateSize_Click(object sender, EventArgs e)
        {
            AddToDataToBindingSource(MasterType.PRODUCT_SIZE,
                sizeBindingSource,
                lbxProductSize);
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

        private void btnCreateCountry_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.COUNTRY,
                 cbbCountry, countryBindingSource);
        }

        private void btnCreateManufacturer_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.MANUFACTURER,
               cbbManufacturer, manufacturerBindingSource);
        }

        private void btnCreatePackager_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.PACKAGER,
              cbbPackager, packagerBindingSource);
        }

        private void btnCreateDistributor_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.DISTRIBUTOR,
                cbbDistributor, distributorBindingSource);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ProductMasterExtraForm_LocationChanged(object sender, EventArgs e)
        {

        }
    }
}
