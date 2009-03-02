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
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void productMasterUserControl_Load(object sender, EventArgs e)
        {
            var eventArgs = new ProductMasterEventArgs();
            EventUtility.fireEvent(InitProductMasterEvent, sender, eventArgs);

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

            var eventArgs = new ProductMasterEventArgs { CreatedProductMasterList = productMasters};
            EventUtility.fireEvent(SaveProductMasterEvent, sender, eventArgs);
            MessageBox.Show("Lưu thành công");
            ClearForm();
            if(Status == ViewStatus.OPENDIALOG)
            {   
                EventUtility.fireEvent(CloseProductMasterEvent,this,eventArgs);
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
            txtImagePath.Text = "";
            picProduct.Image = null;
        }

        private ProductMaster CreateProductMaster(ProductSize size, ProductColor color)
        {
            return new ProductMaster
            {
                ProductName = productMasterControl.txtProductName.Text,
                ImagePath = txtImagePath.Text,
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
                txtImagePath.Text = fileOpen.FileName;
                ShowProductImage();
            }
        }

        private void ShowProductImage()
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
            }
            catch (Exception ex)
            {
                //throw ex; Ignore
            }
        }


        #region IProductMasterView Members


        public event EventHandler<ProductMasterEventArgs> CloseProductMasterEvent;

        #endregion
    }
}
