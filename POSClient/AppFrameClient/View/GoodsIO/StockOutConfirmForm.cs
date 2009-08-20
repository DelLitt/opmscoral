using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Presenter.Report;
using AppFrame.Utility;
using AppFrame.View.GoodsIO;
using AppFrame.View.GoodsIO.MainStock;
using AppFrame.View.Reports;
using AppFrameClient.Presenter.GoodsIO.MainStock;
using AppFrameClient.ViewModel;
using BarcodeLib;

namespace AppFrameClient.View.GoodsIO
{
    public partial class StockOutConfirmForm : BaseForm,IStockOutConfirmView,IMainStockInView
    {
        private StockOutViewCollection deptStockOutList = null;
        private StockOutDetailViewCollection deptStockOutDetailList = null;
        
        public StockOutConfirmForm()
        {
            InitializeComponent();
        }

        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            confirm_stock_outTableAdapter.Fill(masterDB.confirm_stock_out, DateUtility.ZeroTime(dtpFrom.Value),
                                               DateUtility.MaxTime(dtpTo.Value));
            #region unused code
            /*
            deptStockOutList.Clear();
            StockOutConfirmEventArgs eventArgs = new StockOutConfirmEventArgs();
            eventArgs.ReportDateStockOutParam =
                new ReportDateStockOutParam
                {
                    FromDate = DateUtility.ZeroTime(dtpFrom.Value),
                    ToDate = DateUtility.MaxTime(dtpTo.Value)
                };
            EventUtility.fireEvent(LoadConfirmingStockOutsEvent, this, eventArgs);

            if (eventArgs.ResultStockOutList != null)
            {
                foreach (IList result in eventArgs.ResultStockOutList)
                {
                    StockOutView stockOutView = new StockOutView();
                    stockOutView.StockOut = (StockOut)result[0];
                    stockOutView.TotalQuantity = (long)result[1];
                    stockOutView.Department = (Department)result[3];
                    if (stockOutView.Department != null)
                    {
                        stockOutView.DepartmentName = stockOutView.Department.DepartmentName;
                    }
                    else
                    {
                        stockOutView.DepartmentName = " Kho chính";
                    }
                    stockOutView.CreateDate = stockOutView.StockOut.CreateDate;
                    deptStockOutList.Add(stockOutView);
                }
            }
            else
            {
                MessageBox.Show(" Không có hoá đơn xuất kho nào cần xác nhận.");
            }

            bdsDeptStockOut.EndEdit();*/
            #endregion
            dgvStockOutDetail.Refresh();
            dgvStockOutDetail.Invalidate();
            CreateCountOnList();
        }

        
            private void CreateCountOnList()
            {
            for (int i = 0; i < dgvStockOut.Rows.Count;i++ )
            {
                dgvStockOut[0, dgvStockOut.Rows[i].Index].Value = i + 1;
            }
            }
        

        
        private void DepartmentStockOutConfirmForm_Load(object sender, EventArgs e)
        {
           deptStockOutList = new StockOutViewCollection(bdsDeptStockOut);
            bdsDeptStockOut.DataSource = deptStockOutList;
            bdsDeptStockOut.ResetBindings(true);
            
            deptStockOutDetailList = new StockOutDetailViewCollection(bdsDeptStockOutDetail);
            bdsDeptStockOutDetail.DataSource = deptStockOutDetailList;
            bdsDeptStockOutDetail.ResetBindings(true);
        }

        private void dgvStockOut_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvStockOut.CurrentCell == null)
            {
                return;
            }
            deptStockOutDetailList.Clear();
            StockOutView stockOut = deptStockOutList[dgvStockOut.CurrentCell.OwningRow.Index];
            IList stockOutDetails = stockOut.StockOut.StockOutDetails;
            foreach (StockOutDetail stockOutDetail in stockOutDetails)
            {
                if (!HasCreatedView(stockOutDetail))
                {
                    StockOutDetailView stockOutDetailView = new StockOutDetailView();

                    stockOutDetailView.StockOutDetail = stockOutDetail;
                    stockOutDetailView.TotalCount = stockOutDetail.Quantity;
                    stockOutDetailView.GoodCount = stockOutDetail.GoodQuantity;
                    stockOutDetailView.DamageCount = stockOutDetail.DamageQuantity;
                    stockOutDetailView.ErrorCount = stockOutDetail.ErrorQuantity;
                    stockOutDetailView.LostCount = stockOutDetail.LostQuantity;
                    stockOutDetailView.UnconfirmCount = stockOutDetail.UnconfirmQuantity;
                    deptStockOutDetailList.Add(stockOutDetailView);
                }

            }
            bdsDeptStockOutDetail.EndEdit();
            dgvStockOutDetail.Refresh();
            dgvStockOutDetail.Invalidate();
            CalculateGrandTotalCount();
        }

        private void CalculateGrandTotalCount()
        {
            long grandTotal = 0;
            foreach (StockOutDetailView detailView in deptStockOutDetailList)
            {
                grandTotal += detailView.TotalCount;
            }
            txtGrandTotalCount.Text = grandTotal.ToString("##,##0");
        }

        private bool HasCreatedView(StockOutDetail detail)
        {
            foreach (StockOutDetailView outDetailView in deptStockOutDetailList)
            {
                if (outDetailView.StockOutDetail.Product.ProductId == detail.Product.ProductId
                    && outDetailView.StockOutDetail.StockOutDetailId == detail.StockOutDetailId)
                    //&& outDetailView.StockOutDetail.DepartmentId == detail.DepartmentStockOut.DepartmentStockOutPK.DepartmentId)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            
            DataGridViewSelectedRowCollection selectedRows = dgvStockOut.SelectedRows;
            if (!(selectedRows.Count > 0))
            {
                return;
            }

            StockOutConfirmEventArgs eventArgs = new StockOutConfirmEventArgs();

            IList list = new ArrayList();
            foreach (DataGridViewRow row in selectedRows)
            {
                list.Add(deptStockOutList[row.Index].StockOut);
            }

            eventArgs.ConfirmStockInList = list;
            EventUtility.fireEvent(ConfirmStockOutEvent, this, eventArgs);
            if (!eventArgs.HasErrors)
            {

            }
            ClearForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dgvStockOut.SelectedRows;
            if(!(selectedRows.Count >0) )
            {
                return;                
            }

            StockOutConfirmEventArgs eventArgs = new StockOutConfirmEventArgs();

            IList list = new ArrayList();
            foreach (DataGridViewRow row in selectedRows)
            {
                list.Add(deptStockOutList[row.Index].StockOut);          
            }

            eventArgs.DenyStockInList = list;
            EventUtility.fireEvent(DenyStockOutEvent,this,eventArgs);
            if(!eventArgs.HasErrors)
            {
                
            }
            ClearForm();

        }

        private void ClearForm()
        {
            deptStockOutList.Clear();
            deptStockOutDetailList.Clear();
        }

        #region Implementation of IStockOutConfirmView

        private IStockOutConfirmController stockOutConfirmController;
        public IStockOutConfirmController StockOutConfirmController
        {
            get
            {
                return stockOutConfirmController;
            }
            set
            {
                stockOutConfirmController = value;
                stockOutConfirmController.MainStockOutReportView = this;
            }
        }
        public event EventHandler<StockOutConfirmEventArgs> ConfirmStockOutEvent;
        public event EventHandler<StockOutConfirmEventArgs> DenyStockOutEvent;
        public event EventHandler<StockOutConfirmEventArgs> LoadStockOutsEvent;
        public event EventHandler<StockOutConfirmEventArgs> LoadConfirmingStockOutsEvent;
        public event EventHandler<MainStockInEventArgs> FillProductToComboEvent;
        public event EventHandler<MainStockInEventArgs> LoadGoodsByIdEvent;
        public event EventHandler<MainStockInEventArgs> LoadGoodsByNameEvent;
        public event EventHandler<MainStockInEventArgs> LoadProductColorEvent;
        public event EventHandler<MainStockInEventArgs> LoadProductSizeEvent;
        public event EventHandler<MainStockInEventArgs> LoadGoodsByNameColorEvent;
        public event EventHandler<MainStockInEventArgs> LoadGoodsByNameColorSizeEvent;
        public event EventHandler<MainStockInEventArgs> SaveStockInEvent;
        public event EventHandler<MainStockInEventArgs> LoadAllGoodsByNameEvent;
        public event EventHandler<MainStockInEventArgs> FindByBarcodeEvent;
        public event EventHandler<MainStockInEventArgs> SaveReStockInEvent;
        public event EventHandler<MainStockInEventArgs> LoadStockInEvent;
        public event EventHandler<MainStockInEventArgs> UpdateStockInEvent;
        public event EventHandler<MainStockInEventArgs> GetPriceEvent;

        #endregion

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dgvStockOutDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (deptStockOutDetailList != null && deptStockOutDetailList.Count > 0)
            {
                if (dgvStockOutDetail.CurrentRow == null)
                {
                    MessageBox.Show("Hãy chọn 1 hàng để in mã vạch");
                    return;
                }
                var selectedIndex = dgvStockOutDetail.CurrentRow.Index;
                if (selectedIndex < 0 || selectedIndex >= deptStockOutDetailList.Count)
                {
                    return;
                }
                // normal print
                if (!chkContinuePrint.Checked)
                {
                    Product detail = deptStockOutDetailList[selectedIndex].StockOutDetail.Product;
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
                    DataGridViewSelectedRowCollection selectedRows = dgvStockOutDetail.SelectedRows;
                    if (selectedRows.Count > 3)
                    {
                        MessageBox.Show("Chỉ có thể in liên tiếp 3 mã vạch");

                    }
                    printList = new List<Product>();
                    foreach (DataGridViewRow selectedRow in selectedRows)
                    {
                        printList.Add(deptStockOutDetailList[selectedRow.Index].StockOutDetail.Product);
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

        private void barcodePrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if (!chkContinuePrint.Checked)
            {
                var height = 87;
                var numberToPrint = (int)numericUpDownBarcode.Value;
                string code = deptStockOutDetailList[dgvStockOutDetail.CurrentRow.Index].StockOutDetail.Product.ProductId;

                if (numberToPrint > 3)
                {
                    height = (numberToPrint / 3) * 87;
                    numberToPrint = 3;
                }
                var eventArgs = new MainStockInEventArgs
                {
                    ProductMasterIdForPrice = deptStockOutDetailList[dgvStockOutDetail.CurrentRow.Index].StockOutDetail.ProductMaster.ProductMasterId
                };
                EventUtility.fireEvent(GetPriceEvent, this, eventArgs);
                string titleString = "";
                string name = deptStockOutDetailList[dgvStockOutDetail.CurrentRow.Index].StockOutDetail.ProductMaster.ProductName;
                if (chkPricePrint.Checked && eventArgs.DepartmentPrice != null)
                {
                    titleString = name + " - " + eventArgs.DepartmentPrice.Price.ToString() + ".00 ";
                }
                else
                {
                    titleString = name;
                }

                BarcodeLib.Barcode barcode = new Barcode();
                string barCodeStr = deptStockOutDetailList[dgvStockOutDetail.CurrentRow.Index].StockOutDetail.Product.ProductId;
                string colorSize = "";
                if (deptStockOutDetailList[dgvStockOutDetail.CurrentRow.Index].StockOutDetail.ProductMaster.ProductColor.ColorId > 0)
                {
                    colorSize += "M:" +
                                 deptStockOutDetailList[dgvStockOutDetail.CurrentRow.Index].StockOutDetail.ProductMaster.ProductColor.
                                     ColorName;
                }
                if (deptStockOutDetailList[dgvStockOutDetail.CurrentRow.Index].StockOutDetail.ProductMaster.ProductSize.SizeId > 0)
                {
                    if (colorSize.Length > 0)
                    {
                        colorSize += " - ";
                    }
                    colorSize += "S:" +
                                 deptStockOutDetailList[dgvStockOutDetail.CurrentRow.Index].StockOutDetail.ProductMaster.ProductSize.
                                     SizeName;
                }
                Image imageBC = barcode.Encode(BarcodeLib.TYPE.CODE39, barCodeStr, Color.Black, Color.White,
                                               (int)(1.35 * e.Graphics.DpiX), (int)(0.3 * e.Graphics.DpiY));

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
                                          (i % 3) * 140 + XCentered(priceTotalSize.Width, 140), (float)25);
                    e.Graphics.DrawImage(bitmap1,
                                         new Rectangle((i % 3) * 140 + (int)XCentered((float)(1.35 * 100), 140),
                                                       (int)(25 + priceTotalSize.Height), (int)(1.35 * 100),
                                                       (int)(0.3 * 100)));
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
                    Image imageBC = barcode.Encode(BarcodeLib.TYPE.CODE39, barCodeStr, Color.Black, Color.White,
                                                   (int)(1.35 * e.Graphics.DpiX), (int)(0.3 * e.Graphics.DpiY));

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
                                          (i % 3) * 140 + XCentered(priceTotalSize.Width, 140), (float)25);
                    e.Graphics.DrawImage(bitmap1,
                                         new Rectangle((i % 3) * 140 + (int)XCentered((float)(1.35 * 100), 140),
                                                       (int)(25 + priceTotalSize.Height), (int)(1.35 * 100),
                                                       (int)(0.3 * 100)));
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
    }

    
}
