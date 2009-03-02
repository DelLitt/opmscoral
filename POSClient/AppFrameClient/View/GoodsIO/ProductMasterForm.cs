using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
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
    public partial class ProductMasterForm : BaseForm, IProductMasterView
    {
        private bool isNeedClosing = false;
        public bool IsNeedClosing
        {
            set
            {
                isNeedClosing = value;
            }
        }

        public string ProductMasterId { get; set; }
        public DepartmentPrice DepartmentPrice { get; set; }
        public ProductMasterForm()
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

        private void ProductMasterForm_Load(object sender, EventArgs e)
        {
            var eventArgs = new ProductMasterEventArgs {ProductMasterId = ProductMasterId};
            EventUtility.fireEvent(InitProductMasterEvent, sender, eventArgs);

            productMasterControl.cbbProductType.DataSource = eventArgs.ProductTypeList;
            productMasterControl.cbbProductType.DisplayMember = "TypeName";

            productMasterControl.cbbProductSize.DataSource = eventArgs.ProductSizeList;
            productMasterControl.cbbProductSize.DisplayMember = "SizeName";

            productMasterControl.cbbProductColor.DataSource = eventArgs.ProductColorList;
            productMasterControl.cbbProductColor.DisplayMember = "ColorName";

            productMasterControl.cbbCountry.DataSource = eventArgs.CountryList;
            productMasterControl.cbbCountry.DisplayMember = "CountryName";

            productMasterControl.cbbDistributor.DataSource = eventArgs.DistributorList;
            productMasterControl.cbbDistributor.DisplayMember = "DistributorName";

            productMasterControl.cbbManufacturer.DataSource = eventArgs.ManufacturerList;
            productMasterControl.cbbManufacturer.DisplayMember = "ManufacturerName";

            productMasterControl.cbbPackager.DataSource = eventArgs.PackagerList;
            productMasterControl.cbbPackager.DisplayMember = "PackagerName";

            if (!string.IsNullOrEmpty(ProductMasterId))
            {
                eventArgs = new ProductMasterEventArgs { ProductMasterId = ProductMasterId };
                EventUtility.fireEvent(LoadProductMasterEvent, sender, eventArgs);

                if (eventArgs.ProductMaster != null)
                {
                    productMasterControl.txtProductMasterId.Text = ProductMasterId;
                    productMasterControl.txtProductName.Text = eventArgs.ProductMaster.ProductName;
                    productMasterControl.txtDescription.Text = eventArgs.ProductMaster.Description;
                    productMasterControl.txtImagePath.Text = eventArgs.ProductMaster.ImagePath;
                    SetSelectedValuedForCombo(MasterType.PRODUCT_TYPE, productMasterControl.cbbProductType, eventArgs.ProductMaster.ProductType);
                    SetSelectedValuedForCombo(MasterType.PRODUCT_SIZE, productMasterControl.cbbProductSize, eventArgs.ProductMaster.ProductSize);
                    SetSelectedValuedForCombo(MasterType.PRODUCT_COLOR, productMasterControl.cbbProductColor, eventArgs.ProductMaster.ProductColor);
                    SetSelectedValuedForCombo(MasterType.COUNTRY, productMasterControl.cbbCountry, eventArgs.ProductMaster.Country);
                    SetSelectedValuedForCombo(MasterType.DISTRIBUTOR, productMasterControl.cbbDistributor, eventArgs.ProductMaster.Distributor);
                    SetSelectedValuedForCombo(MasterType.MANUFACTURER, productMasterControl.cbbManufacturer, eventArgs.ProductMaster.Manufacturer);
                    SetSelectedValuedForCombo(MasterType.PACKAGER, productMasterControl.cbbPackager, eventArgs.ProductMaster.Packager);

                    ShowProductImage();
                    //DrawBarcode(eventArgs.ProductMaster.Barcode);

                    //DepartmentPrice = eventArgs.DepartmentPrice;
                    if (ClientInfo.getInstance().LoggedUser.Name.Equals("admin"))
                    {
                        btnDelete.Visible = true;
                    }
                }
            }
            else
            {
                btnDelete.Visible = false;
            }
        }

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
        public event EventHandler<ProductMasterEventArgs> DeleteProductMasterEvent;

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            var productMaster = new ProductMaster
                                    {
                                        ProductMasterId = ProductMasterId,
                                        ProductName = productMasterControl.txtProductName.Text,
                                        Description = productMasterControl.txtDescription.Text,
                                        ImagePath = productMasterControl.txtImagePath.Text,
                                        Packager = productMasterControl.cbbPackager.SelectedIndex > 0 ? ((Packager)productMasterControl.cbbPackager.SelectedItem) : null,
                                        ProductSize = productMasterControl.cbbProductSize.SelectedIndex > 0 ? ((ProductSize)productMasterControl.cbbProductSize.SelectedItem) : null,
                                        ProductType = productMasterControl.cbbProductType.SelectedIndex > 0 ? ((ProductType)productMasterControl.cbbProductType.SelectedItem) : null,
                                        ProductColor = productMasterControl.cbbProductColor.SelectedIndex > 0 ?
                                            ((ProductColor)productMasterControl.cbbProductColor.SelectedItem) : null,
                                        Country = productMasterControl.cbbCountry.SelectedIndex > 0 ? ((Country)productMasterControl.cbbCountry.SelectedItem) : null,
                                        Manufacturer = productMasterControl.cbbManufacturer.SelectedIndex > 0 ? ((Manufacturer)productMasterControl.cbbManufacturer.SelectedItem) : null,
                                        Distributor = productMasterControl.cbbDistributor.SelectedIndex > 0 ? ((Distributor)productMasterControl.cbbDistributor.SelectedItem) : null
                                    };

            var eventArgs = new ProductMasterEventArgs {ProductMaster = productMaster};
            EventUtility.fireEvent(SaveProductMasterEvent, sender, eventArgs);
            productMaster.ProductMasterId = eventArgs.ProductMaster.ProductMasterId;
            productMasterControl.txtProductMasterId.Text = productMaster.ProductMasterId;
            //DrawBarcode(productMaster.Barcode);
            if (isNeedClosing)
            {
                this.Close();
            }
            if (ClientInfo.getInstance().LoggedUser.Name.Equals("admin"))
            {
                btnDelete.Visible = true;
            }
        }

        /*private void DrawBarcode(string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
            {
                return;
            }
            var code39 = new Code39
                             {
                                 FontFamilyName = "Free 3 of 9",
                                 FontFileName = "Common\\FREE3OF9.TTF",
                                 ShowCodeString = true,
                                 FontSize = 60
                             };

            Bitmap codeGen = code39.GenerateBarcode(barcode);

            //Ean13 ean13 = new Ean13(barcode.Substring(0, 2), barcode.Substring(2, 7), barcode.Substring(7, 6));
            //Ean13 ean13 = new Ean13("12", "34567", "89012");
            

            if (codeGen != null)
            {
                picBarcode.Image = codeGen;
                //picBarcode.Image = ean13.CreateBitmap();
            }
        }*/

        private void btnReset_Click(object sender, EventArgs e)
        {

        }

        private void SetSelectedValuedForCombo(MasterType masterType, ComboBox cbb1, object obj)
        {
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
                Refresh();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (DepartmentPrice == null)
            {
                MessageBox.Show("Không thể in mã vạch khi chưa nhập hàng vào kho");
                return;
            }
            barcodePrintDialog.Document = barcodePrintDocument;
            if (barcodePrintDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    barcodePrintDocument.Print();    
                } 
                catch (Exception)
                {
                }
                
            }
        }

        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (DepartmentPrice == null)
            {
                MessageBox.Show("Không thể in mã vạch khi chưa nhập hàng vào kho");
                return;
            }

            var printPreviewDialog1 = new PrintPreviewDialog(); // instantiate new print preview dialog
            printPreviewDialog1.Document = this.barcodePrintDocument;
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
            printPreviewDialog1.ShowDialog(); 
        }

        private void barcodePrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            /*var height = 87;
            var numberToPrint = (int)numericUpDown.Value;

            if (numberToPrint > 3)
            {
                height = (numberToPrint / 3) * 87;
            }
            var fullImg = new Bitmap(416, height);
            var code39 = new Code39
            {
                FontFamilyName = "Free 3 of 9",
                FontFileName = "Common\\FREE3OF9.TTF",
                ShowCodeString = true,
                FontSize = 25,
                Title = "Giá " + DepartmentPrice.Price.ToString("##,#00") + " VND"
            };

            var codeGen = code39.GenerateBarcode(txtBarcode.Text);
            for (int i = 0; i < numericUpDown.Value; i++)
            {
                e.Graphics.DrawImage(codeGen, (i % 3) * 124, (i / 3) * 87, 117, 79);
            }*/
        }

        private void btnCreateColor_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.PRODUCT_COLOR,
                productMasterControl.cbbProductColor);
        }

        private void btnCreateCountry_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.COUNTRY,
                productMasterControl.cbbCountry);
        }

        private void btnCreateDistributor_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.DISTRIBUTOR,
                productMasterControl.cbbDistributor);
        }

        private void btnCreateManufacturer_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.MANUFACTURER,
                productMasterControl.cbbManufacturer);
        }

        private void btnCreatePackager_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.PACKAGER,
                productMasterControl.cbbPackager);
        }

        private void btnCreateSize_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.PRODUCT_SIZE,
                productMasterControl.cbbProductSize);
        }

        private void btnCreateType_Click(object sender, EventArgs e)
        {
            AddToDataToComboBox(MasterType.PRODUCT_TYPE,
                productMasterControl.cbbProductType);
        }

        private void AddToDataToComboBox(MasterType masterType, ComboBox cbb1)
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
                cbb1.Items.Add(obj);
                cbb1.SelectedIndex = cbb1.Items.Count - 1;
                Refresh();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ProductMasterId))
            {
                DialogResult result = MessageBox.Show("Bạn có muốn xóa không?", "", MessageBoxButtons.YesNo);
                if (result.Equals(DialogResult.Yes))
                {
                    var eventArgs = new ProductMasterEventArgs{ProductMasterId = ProductMasterId};
                    EventUtility.fireEvent(DeleteProductMasterEvent, this, eventArgs);
                    MessageBox.Show("Xóa thành công");
                    Close();
                }
            }
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
                int newWidth = productMasterControl.picProduct.Width;
                int maxHeight = productMasterControl.picProduct.Height;
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


                productMasterControl.picProduct.Image = newImage;
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
