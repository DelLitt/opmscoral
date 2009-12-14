using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Utility;
using AppFrame.View.GoodsIO;
using AppFrame.View.GoodsIO.MainStock;
using AppFrameClient.Common;
using AppFrameClient.Presenter.GoodsIO.MainStock;
using BarcodeLib;

namespace AppFrameClient.View.GoodsIO
{
    public partial class ProductMasterSearchForm : BaseForm, IProductMasterSearchOrCreateView,IMainStockInView
    {
        public IList ProductMasterList { get; set; }
        public ProductMasterSearchOrCreateEventArgs CurrentProductMasterSearchOrCreateEventArgs { get; set; }
        private ProductCollection ProductList = null;
        public ProductMasterSearchForm()
        {
            InitializeComponent();
        }

        private void ProductMasterSearchForm_Load(object sender, EventArgs e)
        {
            ProductList = new ProductCollection(bdsProduct);
            bdsProduct.ResetBindings(true);

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
        public event EventHandler<ProductMasterSearchOrCreateEventArgs> SearchCommonProductMasterEvent;
        public event EventHandler<ProductMasterSearchOrCreateEventArgs> SearchRelevantProductsEvent;
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
            EventUtility.fireEvent(SearchCommonProductMasterEvent, sender, eventArgs);
            ProductMasterList = eventArgs.ProductMasterList;
            dgvProductMaster.DataSource = ProductMasterList;
            CurrentProductMasterSearchOrCreateEventArgs = eventArgs;
        }

        private void dgvProductMaster_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < dgvProductMaster.Rows.Count && e.RowIndex >= 0)
            {
                string productMasterId =
                    dgvProductMaster.Rows[e.RowIndex].Cells["productMasterIdDataGridViewTextBoxColumn"].Value.ToString();
                SelectProductMaster(productMasterId);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (ProductList != null && ProductList.Count > 0)
            {
                    if (dgvProduct.CurrentRow == null)
                    {
                        MessageBox.Show("Hãy chọn 1 hàng để in mã vạch");
                        return;
                    }
                    var selectedIndex = dgvProduct.CurrentRow.Index;
                    if (selectedIndex < 0 || selectedIndex >= ProductList.Count)
                    {
                        return;
                    }
                    // normal print
                    if (!chkContinuePrint.Checked)
                    {
                        Product detail = ProductList[selectedIndex];
                        barcodePrintDialog.Document = barcodePrintDocument;
                            if (barcodePrintDialog.ShowDialog() == DialogResult.OK)
                            {
                                try
                                {
                                    var numberToPrint = (int)numericUpDownBarcode.Value;
                                    var count = numberToPrint / 3;
                                    if ((numberToPrint % 3) != 0)
                                    {
                                        count += 1;
                                    }
                                    for (int i = 0; i < count; i++)
                                    {
                                        barcodePrintDocument.Print();
                                    }

                                }
                                catch (Exception)
                                {
                                }
                                finally
                                {
                                    numericUpDownBarcode.Value = 3;
                                }

                            }
                    }
                    else // continous print
                    {
                        DataGridViewSelectedRowCollection selectedRows = dgvProduct.SelectedRows;
                        if (selectedRows.Count > 3)
                        {
                            MessageBox.Show("Chỉ có thể in liên tiếp 3 mã vạch");

                        }
                        printList = new List<Product>();
                        foreach (DataGridViewRow selectedRow in selectedRows)
                        {
                            printList.Add(ProductList[selectedRow.Index]);
                        }
                        if (barcodePrintDialog.ShowDialog() == DialogResult.OK)
                        {
                            try
                            {
                                barcodePrintDocument.Print();
                            }
                            catch (Exception)
                            {
                                
                                
                            }
                            finally
                            {
                                numericUpDownBarcode.Value = 3;
                            }
                            
                        }
                    }
                
            }
        }

        private IList<Product> printList = null;
        private void dgvProductMaster_SelectionChanged(object sender, EventArgs e)
        {
            ProductList.Clear();
            if (dgvProductMaster.CurrentRow != null)
            {
                DataGridViewRow row = dgvProductMaster.CurrentRow;
                var eventArgs = new ProductMasterSearchOrCreateEventArgs
                {
                    ProductMasterName = row.Cells["ProductName"].Value.ToString()
                };
                EventUtility.fireEvent(SearchRelevantProductsEvent, this, eventArgs);
                if (eventArgs.ProductList != null && eventArgs.ProductList.Count > 0)
                {
                    foreach (Product product in eventArgs.ProductList)
                    {
                        ProductList.Add(product);
                    }
                    bdsProduct.ResetBindings(false);
                    dgvProduct.Refresh();
                    dgvProduct.Invalidate();
                }
            }
        }

        private void dgvProductMaster_CurrentCellChanged(object sender, EventArgs e)
        {
            
        }

        private void barcodePrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (!chkContinuePrint.Checked)
            {
                var height = 87;
                var numberToPrint = (int)numericUpDownBarcode.Value;
                string code = ProductList[dgvProduct.CurrentRow.Index].ProductId;

                if (numberToPrint > 3)
                {
                    height = (numberToPrint / 3) * 87;
                    numberToPrint = 3;
                }
                var eventArgs = new MainStockInEventArgs
                {
                    ProductMasterIdForPrice = ProductList[dgvProduct.CurrentRow.Index].ProductMaster.ProductMasterId
                };
                EventUtility.fireEvent(GetPriceEvent, this, eventArgs);
                string titleString = "";
                string name = ProductList[dgvProduct.CurrentRow.Index].ProductMaster.ProductName;
                if (chkPricePrint.Checked && eventArgs.DepartmentPrice != null)
                {
                    titleString = name + " - " + eventArgs.DepartmentPrice.Price.ToString() + ".00 ";
                }
                else
                {
                    titleString = name;
                }

                BarcodeLib.Barcode barcode = new Barcode();
                string barCodeStr = ProductList[dgvProduct.CurrentRow.Index].ProductId;
                string colorSize = "";
                if (ProductList[dgvProduct.CurrentRow.Index].ProductMaster.ProductColor.ColorId > 0)
                {
                    colorSize += "M:" +
                                 ProductList[dgvProduct.CurrentRow.Index].ProductMaster.ProductColor.
                                     ColorName;
                }
                if (ProductList[dgvProduct.CurrentRow.Index].ProductMaster.ProductSize.SizeId > 0)
                {
                    if (colorSize.Length > 0)
                    {
                        colorSize += " - ";
                    }
                    colorSize += "S:" +
                                 ProductList[dgvProduct.CurrentRow.Index].ProductMaster.ProductSize.
                                     SizeName;
                }

                Image imageBC = null;
                if (ClientSetting.BarcodeType == BarcodeLib.TYPE.CODE128)
                {
                    imageBC = barcode.Encode(ClientSetting.BarcodeType, barCodeStr, Color.Black, Color.White,
                                                    (int)(1.25 * e.Graphics.DpiX), (int)(0.3 * e.Graphics.DpiY));
                }
                else
                {
                    imageBC = barcode.Encode(ClientSetting.BarcodeType, barCodeStr, Color.Black, Color.White,
                                                   (int)(1.35 * e.Graphics.DpiX), (int)(0.3 * e.Graphics.DpiY));
                }

                Bitmap bitmap1 = new Bitmap(imageBC);
                bitmap1.SetResolution(204, 204);
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

                // draw title string

                // calculate scale for title
                var titleStrSize = e.Graphics.MeasureString(titleString.PadRight(25), new Font("Arial", 10));
                float currTitleSize = new Font("Arial", 10).Size;
                float scaledTitleSize = (150 * currTitleSize) / titleStrSize.Width;
                Font _titleFont = new Font("Arial", 7);
                var priceTotalSize = e.Graphics.MeasureString(titleString, _titleFont);
                var colorSizeSize = e.Graphics.MeasureString(colorSize, _titleFont);
                var barCodeSize = e.Graphics.MeasureString(barCodeStr, _titleFont);
                for (int i = 0; i < numberToPrint; i++)
                {

                    System.Drawing.Rectangle rc = new System.Drawing.Rectangle((i % 3) * 135, 50, (int)(1.4 * 100),
                                                                               (int)(0.4 * 100));

                    //(i % 3) * 124, (i / 3) * 87, 117, 79 
                    e.Graphics.DrawString(titleString, _titleFont, new SolidBrush(Color.Black),
                                          (i % 3) * 135 + XCentered(priceTotalSize.Width, 140), (float)25);

                    if (ClientSetting.BarcodeType == BarcodeLib.TYPE.CODE39)
                    {
                        e.Graphics.DrawImage(bitmap1,
                                             new Rectangle((i % 3) * 140 + (int)XCentered((float)(1.25 * 100), 140),
                                                           (int)(25 + priceTotalSize.Height), (int)(1.25 * 100),
                                                           (int)(0.3 * 100)));
                    }
                    else
                    {
                        e.Graphics.DrawImage(bitmap1,
                                             new Rectangle((i % 3) * 140 + (int)XCentered((float)(1.35 * 100), 140),
                                                           (int)(25 + priceTotalSize.Height), (int)(1.35 * 100),
                                                           (int)(0.3 * 100)));
                    }
                    e.Graphics.DrawString(barCodeStr, _titleFont, new SolidBrush(Color.Black),
                                          (i % 3) * 140 + XCentered(barCodeSize.Width, 140), (float)72);
                    e.Graphics.DrawString(colorSize, _titleFont, new SolidBrush(Color.Black),
                                          (i % 3) * 140 + XCentered(colorSizeSize.Width, 140), (float)88);
                    

                }
            }
            else // continue printing
            {
                var height = 87;
                if (printList == null || printList.Count == 0)
                {
                    return;
                }
                var numberToPrint = printList.Count;

                for (int i = 0; i < numberToPrint; i++)
                {
                    string code = printList[i].ProductId;
                    var eventArgs = new MainStockInEventArgs
                    {
                        ProductMasterIdForPrice = printList[i].ProductMaster.ProductMasterId
                    };
                    EventUtility.fireEvent(GetPriceEvent, this, eventArgs);
                    string titleString = "";
                    string name = printList[i].ProductMaster.ProductName;
                    if (chkPricePrint.Checked && eventArgs.DepartmentPrice != null)
                    {
                        titleString = name + " - " + eventArgs.DepartmentPrice.Price.ToString() + ".00 ";
                    }
                    else
                    {
                        titleString = name;
                    }

                    BarcodeLib.Barcode barcode = new Barcode();
                    string barCodeStr = printList[i].ProductId;
                    string colorSize = "";
                    if (printList[i].ProductMaster.ProductColor.ColorId > 0)
                    {
                        colorSize += "M:" +
                                     printList[i].ProductMaster.ProductColor.ColorName;
                    }
                    if (printList[i].ProductMaster.ProductSize.SizeId > 0)
                    {
                        if (colorSize.Length > 0)
                        {
                            colorSize += " - ";
                        }
                        colorSize += "S:" +
                                     printList[i].ProductMaster.ProductSize.SizeName;
                    }
                    Image imageBC = null;
                    if (ClientSetting.BarcodeType == BarcodeLib.TYPE.CODE128)
                    {
                        imageBC = barcode.Encode(ClientSetting.BarcodeType, barCodeStr, Color.Black, Color.White,
                                                        (int)(1.25 * e.Graphics.DpiX), (int)(0.3 * e.Graphics.DpiY));
                    }
                    else
                    {
                        imageBC = barcode.Encode(ClientSetting.BarcodeType, barCodeStr, Color.Black, Color.White,
                                                       (int)(1.35 * e.Graphics.DpiX), (int)(0.3 * e.Graphics.DpiY));
                    }

                    Bitmap bitmap1 = new Bitmap(imageBC);
                    bitmap1.SetResolution(204, 204);
                    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                    e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

                    // draw title string

                    // calculate scale for title
                    var titleStrSize = e.Graphics.MeasureString(titleString.PadRight(25), new Font("Arial", 10));
                    float currTitleSize = new Font("Arial", 10).Size;
                    float scaledTitleSize = (150 * currTitleSize) / titleStrSize.Width;
                    Font _titleFont = new Font("Arial", 7);
                    Font _barCodeFont = new Font("Arial", 8);
                    var priceTotalSize = e.Graphics.MeasureString(titleString, _titleFont);
                    var colorSizeSize = e.Graphics.MeasureString(colorSize, _titleFont);
                    var barCodeSize = e.Graphics.MeasureString(barCodeStr, _barCodeFont);


                    System.Drawing.Rectangle rc = new System.Drawing.Rectangle((i % 3) * 135, 50, (int)(1.4 * 100),
                                                                               (int)(0.4 * 100));


                    e.Graphics.DrawString(titleString, _titleFont, new SolidBrush(Color.Black),
                                          (i % 3) * 135 + XCentered(priceTotalSize.Width, 140), (float)25);

                    if (ClientSetting.BarcodeType == BarcodeLib.TYPE.CODE39)
                    {
                        e.Graphics.DrawImage(bitmap1,
                                             new Rectangle((i % 3) * 140 + (int)XCentered((float)(1.25 * 100), 140),
                                                           (int)(25 + priceTotalSize.Height), (int)(1.25 * 100),
                                                           (int)(0.3 * 100)));
                    }
                    else
                    {
                        e.Graphics.DrawImage(bitmap1,
                                             new Rectangle((i % 3) * 140 + (int)XCentered((float)(1.35 * 100), 140),
                                                           (int)(25 + priceTotalSize.Height), (int)(1.35 * 100),
                                                           (int)(0.3 * 100)));
                    }
                    e.Graphics.DrawString(barCodeStr, _barCodeFont, new SolidBrush(Color.Black),
                                          (i % 3) * 140 + XCentered(barCodeSize.Width, 140), (float)72);
                    e.Graphics.DrawString(colorSize, _titleFont, new SolidBrush(Color.Black),
                                          (i % 3) * 140 + XCentered(colorSizeSize.Width, 140), (float)88);

                }
            }
        }
        private float XCentered(float localWidth, float globalWidth)
        {
            return ((globalWidth - localWidth) / 2);
        }
        private MainStockInController mainStockInController;
        public MainStockInController MainStockInController
        {
            get
            {
                return mainStockInController;
            }
            set
            {
                mainStockInController = value;
                mainStockInController.MainStockInView = this;
            }
        }
#region unused event
        public event EventHandler<MainStockInEventArgs> FillProductToComboEvent;
        public event EventHandler<MainStockInEventArgs> LoadGoodsByIdEvent;
        public event EventHandler<MainStockInEventArgs> LoadGoodsByNameEvent;
        public event EventHandler<MainStockInEventArgs> LoadProductColorEvent;
        public event EventHandler<MainStockInEventArgs> LoadProductSizeEvent;
        public event EventHandler<MainStockInEventArgs> LoadGoodsByNameColorEvent;
        public event EventHandler<MainStockInEventArgs> LoadGoodsByNameColorSizeEvent;
        public event EventHandler<MainStockInEventArgs> SaveStockInEvent;
        public event EventHandler<MainStockInEventArgs> GetPriceEvent;
        public event EventHandler<MainStockInEventArgs> LoadAllGoodsByNameEvent;
        public event EventHandler<MainStockInEventArgs> FindByBarcodeEvent;
        public event EventHandler<MainStockInEventArgs> SaveReStockInEvent;
        public event EventHandler<MainStockInEventArgs> LoadStockInEvent;
        public event EventHandler<MainStockInEventArgs> UpdateStockInEvent;

        #endregion

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
