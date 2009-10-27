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
using AppFrameClient.Common;
using AppFrameClient.Presenter.GoodsIO.MainStock;
using AppFrameClient.View.GoodsIO.MainStock;
using AppFrameClient.ViewModel;
using BarcodeLib;

namespace AppFrameClient.View.GoodsIO
{
    public partial class StockInConfirmForm : BaseForm,IStockInConfirmView
    {
        private StockOutViewCollection deptStockOutList = null;
        private StockOutDetailViewCollection deptStockOutDetailList = null;

        public StockInConfirmForm()
        {
            InitializeComponent();
        }

        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            confirm_stock_inTableAdapter.Fill(masterDB.confirm_stock_in, 1, DateUtility.ZeroTime(dtpFrom.Value), DateUtility.MaxTime(dtpTo.Value));
            confirmstockinBindingSource.ResetBindings(false);
            dgvStockIn.Refresh();
            dgvStockIn.Invalidate();
/*
            deptStockOutList.Clear();
            StockInConfirmEventArgs eventArgs = new StockInConfirmEventArgs();
            eventArgs.ReportDateStockOutParam =
                new ReportDateStockOutParam
                {
                    FromDate = DateUtility.ZeroTime(dtpFrom.Value),
                    ToDate = DateUtility.MaxTime(dtpTo.Value)
                };
            EventUtility.fireEvent(LoadStockInsEvent, this, eventArgs);

            if (eventArgs.ResultStockInList != null)
            {
                foreach (IList result in eventArgs.ResultStockInList)
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

            bdsDeptStockOut.EndEdit();
            dgvStockInDetail.Refresh();
            dgvStockInDetail.Invalidate();
            CreateCountOnList();*/
        }

        
            private void CreateCountOnList()
            {
            for (int i = 0; i < dgvStockIn.Rows.Count;i++ )
            {
                dgvStockIn[0, dgvStockIn.Rows[i].Index].Value = i + 1;
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
            if(dgvStockIn.CurrentCell == null)
            {
                return;
            }
            string stockInId = dgvStockIn[0, dgvStockIn.CurrentCell.OwningRow.Index].Value.ToString();
            confirm_stock_in_detailTableAdapter.Fill(masterDB.confirm_stock_in_detail,stockInId);
            confirmstockindetailBindingSource.ResetBindings(false);
            dgvStockInDetail.Refresh();
            dgvStockInDetail.Invalidate();
            #region old code
            /*if (dgvStockIn.CurrentCell == null)
            {
                return;
            }
            deptStockOutDetailList.Clear();
            StockOutView stockOut = deptStockOutList[dgvStockIn.CurrentCell.OwningRow.Index];
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
            dgvStockInDetail.Refresh();
            dgvStockInDetail.Invalidate();
            CalculateGrandTotalCount();*/
            #endregion
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
            
            DataGridViewSelectedRowCollection selectedRows = dgvStockIn.SelectedRows;
            if (!(selectedRows.Count > 0))
            {
                return;
            }

            StockInConfirmEventArgs eventArgs = new StockInConfirmEventArgs();

            IList list = new ArrayList();
            foreach (DataGridViewRow row in selectedRows)
            {
                list.Add(dgvStockIn[0,row.Index].Value.ToString());
            }

            eventArgs.ConfirmStockInList = list;
            EventUtility.fireEvent(ConfirmStockInEvent, this, eventArgs);
            if (!eventArgs.HasErrors)
            {
                MessageBox.Show("Lưu thành công!");
                // reload db
                confirm_stock_in_detailTableAdapter.Fill(masterDB.confirm_stock_in_detail, "");
                confirmstockindetailBindingSource.ResetBindings(false);
                dgvStockInDetail.Refresh();
                dgvStockInDetail.Invalidate();
                confirm_stock_inTableAdapter.Fill(masterDB.confirm_stock_in, 1, DateUtility.ZeroTime(dtpFrom.Value), DateUtility.MaxTime(dtpTo.Value));
                confirmstockinBindingSource.ResetBindings(false);
                dgvStockIn.Refresh();
                dgvStockIn.Invalidate();
            }
            else
            {
                MessageBox.Show("Lưu thất bại!");
            }
            ClearForm();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedRows = dgvStockIn.SelectedRows;
            if (!(selectedRows.Count > 0))
            {
                return;
            }

            StockInConfirmEventArgs eventArgs = new StockInConfirmEventArgs();

            IList list = new ArrayList();
            foreach (DataGridViewRow row in selectedRows)
            {
                list.Add(dgvStockIn[0, row.Index].Value.ToString());
            }

            eventArgs.DenyStockInList = list;
            EventUtility.fireEvent(DenyStockInEvent, this, eventArgs);
            if (!eventArgs.HasErrors)
            {
                MessageBox.Show("Lưu thành công!");
                // reload db
                confirm_stock_in_detailTableAdapter.Fill(masterDB.confirm_stock_in_detail, "");
                confirmstockindetailBindingSource.ResetBindings(false);
                dgvStockInDetail.Refresh();
                dgvStockInDetail.Invalidate();
                confirm_stock_inTableAdapter.Fill(masterDB.confirm_stock_in, 1, DateUtility.ZeroTime(dtpFrom.Value), DateUtility.MaxTime(dtpTo.Value));
                confirmstockinBindingSource.ResetBindings(false);
                dgvStockIn.Refresh();
                dgvStockIn.Invalidate();
            }
            else
            {
                MessageBox.Show("Lưu thất bại!");
            }
            ClearForm();

        }

        private void ClearForm()
        {
            deptStockOutList.Clear();
            deptStockOutDetailList.Clear();
        }

        #region Implementation of IStockOutConfirmView

        private IStockInConfirmController stockInConfirmController;
        public IStockInConfirmController StockInConfirmController
        {
            get
            {
                return stockInConfirmController;
            }
            set
            {
                stockInConfirmController = value;
                stockInConfirmController.StockInConfirmView = this;
            }
        }

        public event EventHandler<StockInConfirmEventArgs> ConfirmStockInEvent;
        public event EventHandler<StockInConfirmEventArgs> DenyStockInEvent;
        public event EventHandler<StockInConfirmEventArgs> LoadStockInsEvent;
        public event EventHandler<StockInConfirmEventArgs> LoadStockInEvent;
        
        #endregion

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dgvStockOutDetail_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            /*if (deptStockOutDetailList != null && deptStockOutDetailList.Count > 0)
            {
                if (dgvStockInDetail.CurrentRow == null)
                {
                    MessageBox.Show("Hãy chọn 1 hàng để in mã vạch");
                    return;
                }
                var selectedIndex = dgvStockInDetail.CurrentRow.Index;
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
                    DataGridViewSelectedRowCollection selectedRows = dgvStockInDetail.SelectedRows;
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

            }*/
        }
        private IList<Product> printList = null;

        private void barcodePrintDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            /*if (!chkContinuePrint.Checked)
            {
                var height = 87;
                var numberToPrint = (int)numericUpDownBarcode.Value;
                string code = deptStockOutDetailList[dgvStockInDetail.CurrentRow.Index].StockOutDetail.Product.ProductId;

                if (numberToPrint > 3)
                {
                    height = (numberToPrint / 3) * 87;
                    numberToPrint = 3;
                }
                var eventArgs = new MainStockInEventArgs
                {
                    ProductMasterIdForPrice = deptStockOutDetailList[dgvStockInDetail.CurrentRow.Index].StockOutDetail.ProductMaster.ProductMasterId
                };
                EventUtility.fireEvent(GetPriceEvent, this, eventArgs);
                string titleString = "";
                string name = deptStockOutDetailList[dgvStockInDetail.CurrentRow.Index].StockOutDetail.ProductMaster.ProductName;
                if (chkPricePrint.Checked && eventArgs.DepartmentPrice != null)
                {
                    titleString = name + " - " + eventArgs.DepartmentPrice.Price.ToString() + ".00 ";
                }
                else
                {
                    titleString = name;
                }

                BarcodeLib.Barcode barcode = new Barcode();
                string barCodeStr = deptStockOutDetailList[dgvStockInDetail.CurrentRow.Index].StockOutDetail.Product.ProductId;
                string colorSize = "";
                if (deptStockOutDetailList[dgvStockInDetail.CurrentRow.Index].StockOutDetail.ProductMaster.ProductColor.ColorId > 0)
                {
                    colorSize += "M:" +
                                 deptStockOutDetailList[dgvStockInDetail.CurrentRow.Index].StockOutDetail.ProductMaster.ProductColor.
                                     ColorName;
                }
                if (deptStockOutDetailList[dgvStockInDetail.CurrentRow.Index].StockOutDetail.ProductMaster.ProductSize.SizeId > 0)
                {
                    if (colorSize.Length > 0)
                    {
                        colorSize += " - ";
                    }
                    colorSize += "S:" +
                                 deptStockOutDetailList[dgvStockInDetail.CurrentRow.Index].StockOutDetail.ProductMaster.ProductSize.
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
            }*/
        }
        private float XCentered(float localWidth, float globalWidth)
        {
            return ((globalWidth - localWidth) / 2);
        }
        
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStockIn.CurrentCell == null)
            {
                return;
            }
            string stockInId = dgvStockIn[0, dgvStockIn.CurrentCell.OwningRow.Index].Value.ToString();
            StockInConfirmEventArgs eventArgs = new StockInConfirmEventArgs();
            eventArgs.StockInId = stockInId;
            EventUtility.fireEvent(LoadStockInEvent,this,eventArgs);

            MainStockInEditExtraForm editExtraForm =
                GlobalUtility.GetFormObject<MainStockInEditExtraForm>(FormConstants.MAIN_STOCK_IN_EDIT_EXTRA_FORM);

            editExtraForm.StockIn = eventArgs.StockIn;
            editExtraForm.Closed += new EventHandler(editExtraForm_Closed);
            editExtraForm.ShowDialog();
        }

        void editExtraForm_Closed(object sender, EventArgs e)
        {
            dgvStockOut_SelectionChanged(null,null);
        }

        #region Implementation of IStockInConfirmView

        

        #endregion
    }
}
