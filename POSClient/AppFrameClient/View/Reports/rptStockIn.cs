using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.Report;
using AppFrame.Utility;
using AppFrame.View.Reports;
using AppFrameClient.ViewModel;
//using Aspose.Cells;
using POSReports;

namespace AppFrameClient.View.Reports
{
    public partial class frmStockinStatistic : BaseForm,IReportStockInView
    {
        private StockInResultDetailCollection pSODetResultList = null;
        private StockInDetailCollection pSODetList = null;
        public frmStockinStatistic()
        {
            InitializeComponent();
            
        }

       #region IReportStockInView Members


        private AppFrame.Presenter.Report.IReportStockInController reportStockInController;
        public AppFrame.Presenter.Report.IReportStockInController ReportStockInController
        {
            get
            {
                return reportStockInController;
            }
            set
            {
                reportStockInController = value;
                reportStockInController.ReportStockInView = this;

            }
        }

        public ReportStockInParam ReportStockInParam
        {
            get;set;
        }

        #endregion

        private IList resultList = null;
        private void ok_Click(object sender, EventArgs e)
        {
            pSODetResultList.Clear();
           ReportStockInEventArgs eventArgs = new ReportStockInEventArgs();
            ReportStockInParam stockInParam = new ReportStockInParam();
            stockInParam.FromDate = DateUtility.ZeroTime(dtpFrom.Value);
            stockInParam.ToDate = DateUtility.MaxTime(dtpTo.Value);
            eventArgs.ReportStockInParam = stockInParam;
            EventUtility.fireEvent(LoadStockInByRangeEvent,this,eventArgs);

            // get result
            resultList = eventArgs.ResultStockInList;

            IList stockDetailByPMList = eventArgs.ProductMastersInList;
            
            if(stockDetailByPMList.Count == 0)
            {
                MessageBox.Show("Không tìm thấy hàng nào","Kết quả");
            }
            
            foreach (var o in stockDetailByPMList)
            {
                IList stockDetailByPM = (IList) o;
                ProductMasterGlobal productMasterGlobal = new ProductMasterGlobal();
                productMasterGlobal.ProductName = ((ProductMaster) stockDetailByPM[0]).ProductName;
                productMasterGlobal.ProductMaster = (ProductMaster)stockDetailByPM[0];
                StockInResultDetail stockInResultDetail = new StockInResultDetail();
                stockInResultDetail.ProductMasterGlobal = productMasterGlobal;
                stockInResultDetail.StockInQuantities = (long)stockDetailByPM[1];
                stockInResultDetail.StockInTotalAmounts = (long) stockDetailByPM[2];
                pSODetResultList.Add(stockInResultDetail);
            }
            bdsStockInResultPM.EndEdit();
            PopulateGrid();

        }

        private void PopulateGrid()
        {
            for(int i =0;i<dgvStockProducts.Rows.Count;i++)
            {
                dgvStockProducts[0, i].Value = i + 1;
            }


            for (int i = 0; i < dgvStockProductsDetail.Rows.Count; i++)
            {
                dgvStockProductsDetail[0, i].Value = i + 1;    
            }

        }

        #region IReportStockInView Members


        public event EventHandler<ReportStockInEventArgs> LoadStockInByRangeEvent;

        #endregion

        private void frmStockinStatistic_Load(object sender, EventArgs e)
        {
            pSODetResultList = new StockInResultDetailCollection(bdsStockInResultPM);
            bdsStockInResultPM.DataSource = pSODetResultList;

            pSODetList = new StockInDetailCollection(bdsStockInResultDetail);
            bdsStockInResultDetail.DataSource = pSODetList;
            dgvStockProductsDetail.Columns[1].DefaultCellStyle.Format = "dd/MM/yyyy hh:mm:ss";
        }

        private void dgvStockProducts_SelectionChanged(object sender, EventArgs e)
        {
            pSODetList.Clear();
            if(resultList == null)
            {
                return;
            }
            DataGridViewSelectedRowCollection selectedRows = dgvStockProducts.SelectedRows;
            if(selectedRows.Count > 0)
            {
                StockInResultDetail siRetDetail = pSODetResultList[selectedRows[0].Index];

                foreach (StockIn stockIn in resultList)
                {
                    foreach (StockInDetail stockInDetail in stockIn.StockInDetails)
                    {
                        if(stockInDetail.Product.ProductMaster.ProductName.Equals(siRetDetail.ProductMasterGlobal.ProductName))
                        {
                            pSODetList.Add(stockInDetail);
                        }
                    }    
                }
                bdsStockInResultDetail.EndEdit();
                PopulateGrid();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvStockProductsDetail_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            
        }

        private void view_group_Click(object sender, EventArgs e)
        {
            /*if (resultList == null || resultList.Count == 0)
            {
                MessageBox.Show("Không có thông tin để báo cáo");
                return;
            }
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            string fileName = saveFileDialog1.FileName;

            Workbook workbook = new Workbook();
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Templates\\GoodsMainStockInReportTemplate.xls";
            //string path = "Templates\\GoodsSaleMainStockInReportTemplate.xls";
            workbook.Open(path);
            //workbook.Open("g:\\Book1.xls");
            Worksheet sheet = workbook.Worksheets[0];
            sheet.Name = "Sheet1";
//            DataTable test = ObjectConverter.ConvertToDataTable(dgvProduct);

            sheet.Cells[6, 3].PutValue(dtpFrom.Value.ToString("dd/MM/yyyy"));
            sheet.Cells[6, 5].PutValue(dtpTo.Value.ToString("dd/MM/yyyy"));
            // put department name
            //sheet.Cells[5, 3].PutValue(CurrentDepartment.Get().DepartmentName);
            int count = 0;
            IDictionary<string, IDictionary<string, StockInDetail>> map = new Dictionary<string, IDictionary<string, StockInDetail>>();
            for (int i = 0; i < dgvStockProducts.RowCount; i++ )
            {
                if (i == pSODetResultList.Count)
                {
                    break;
                }
                StockInResultDetail siRetDetail = pSODetResultList[i];

                foreach (StockIn stockIn in resultList)
                {
                    foreach (StockInDetail stockInDetail in stockIn.StockInDetails)
                    {
                        if (stockInDetail.Product.ProductMaster.ProductType.TypeId == siRetDetail.ProductMasterGlobal.ProductMaster.ProductType.TypeId)
                        {
                            if (stockInDetail.Product.ProductMaster.ProductName.Equals(siRetDetail.ProductMasterGlobal.ProductName))
                            {
                                IDictionary<string, StockInDetail> detailMap = null;
                                StockInDetail detailInMap = null;
                                map.TryGetValue(stockInDetail.Product.ProductMaster.ProductType.TypeName, out detailMap);
                                if (detailMap == null)
                                {
                                    detailMap = new Dictionary<string, StockInDetail>();
                                    detailMap.Add(stockInDetail.Product.ProductMaster.ProductName, stockInDetail);
                                    map.Add(stockInDetail.Product.ProductMaster.ProductType.TypeName, detailMap);
                                }
                                else
                                {
                                    detailMap.TryGetValue(stockInDetail.Product.ProductMaster.ProductName, out detailInMap);
                                    if (detailInMap == null)
                                    {
                                        detailMap[stockInDetail.Product.ProductMaster.ProductName] = stockInDetail;
                                    }
                                    else
                                    {
                                        detailInMap.Quantity += stockInDetail.Quantity;
                                        detailInMap.Price += stockInDetail.Quantity * stockInDetail.Price;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            int stt = 1;
            int j = 0;
            long totalQty = 0;
            long totalPrice = 0;
            foreach (string key in map.Keys)
            {
                sheet.Cells[11 + j + count, 1].PutValue((j + 1) + "");
                sheet.Cells[11 + j + count, 2].PutValue(key);
                int row = 11 + j + count;
                long sumQty = 0;
                long sumPrice = 0;
                count++;

                var detailMap = map[key];
                foreach (string key1 in detailMap.Keys)
                {
                    StockInDetail detailInMap = detailMap[key1];
                    // STT
                    sheet.Cells[11 + j + count, 1].PutValue((j + 1) + "." + stt++);
                    // ten hang
                    sheet.Cells[11 + j + count, 3].PutValue(detailInMap.Product.ProductMaster.ProductName);
                    // quantity
                    sheet.Cells[11 + j + count, 4].PutValue(detailInMap.Quantity);
                    // Price
                    sheet.Cells[11 + j + count, 5].PutValue(detailInMap.Price);

                    sumQty += detailInMap.Quantity;
                    sumPrice += detailInMap.Price;
                    totalQty += sumQty;
                    totalPrice += sumPrice;
                    count++;
                }
                sheet.Cells[row, 4].PutValue(sumQty);
                sheet.Cells[row, 5].PutValue(sumPrice);
                j++;
            }


            // put total amount
            sheet.Cells[11 + j + count, 2].PutValue("Tổng cộng");
            sheet.Cells[11 + j + count, 4].PutValue(totalQty);
            sheet.Cells[11 + j + count, 5].PutValue(totalPrice);
                //sheet.Cells[14, 3].PutValue(txtTotalAmount.Text);

                //            sheet.Cells.ImportDataTable(test, true, 10, 1);

            for (int row = 0; row < count + j + 2; row++)
            {
                for (int col = 0; col < 5; col++)
                {
                    sheet.Cells[11 + row - 1, col + 1].Style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
                    sheet.Cells[11 + row - 1, col + 1].Style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                    sheet.Cells[11 + row - 1, col + 1].Style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                    sheet.Cells[11 + row - 1, col + 1].Style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                }
            }

            workbook.Save(fileName);
            MessageBox.Show("Xuất ra tập tin báo cáo thành công!");*/
            new StockInReportViewer().ShowDialog();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void view_detail_Click(object sender, EventArgs e)
        {
            /*if (resultList == null || resultList.Count == 0)
            {
                MessageBox.Show("Không có thông tin để báo cáo");
                return;
            }
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            string fileName = saveFileDialog1.FileName;

            Workbook workbook = new Workbook();
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Templates\\GoodsMainStockInDetailReportTemplate.xls";
            //string path = "Templates\\GoodsSaleMainStockInReportTemplate.xls";
            workbook.Open(path);
            //workbook.Open("g:\\Book1.xls");
            Worksheet sheet = workbook.Worksheets[0];
            sheet.Name = "Sheet1";
            //            DataTable test = ObjectConverter.ConvertToDataTable(dgvProduct);

            sheet.Cells[6, 3].PutValue(dtpFrom.Value.ToString("dd/MM/yyyy"));
            sheet.Cells[6, 5].PutValue(dtpTo.Value.ToString("dd/MM/yyyy"));
            // put department name
            //sheet.Cells[5, 3].PutValue(CurrentDepartment.Get().DepartmentName);
            int count = 0;
            IDictionary<string, IDictionary<DateTime, IDictionary<string, IDictionary<string, IDictionary<string, StockInDetail>>>>> map = new Dictionary<string, IDictionary<DateTime, IDictionary<string, IDictionary<string, IDictionary<string, StockInDetail>>>>>();
//            for (int i = 0; i < dgvStockProducts.RowCount; i++)
//            {
//                if (i == pSODetResultList.Count)
//                {
//                    break;
//                }
//                StockInResultDetail siRetDetail = pSODetResultList[i];

                foreach (StockIn stockIn in resultList)
                {
                    foreach (StockInDetail stockInDetail in stockIn.StockInDetails)
                    {
//                        if (stockInDetail.Product.ProductMaster.ProductType.TypeId == siRetDetail.ProductMasterGlobal.ProductMaster.ProductType.TypeId
//                          && stockInDetail.Product.ProductMaster.ProductName.Equals(siRetDetail.ProductMasterGlobal.ProductName)
//                          && stockInDetail.Product.ProductMaster.ProductColor.ColorId == siRetDetail.ProductMasterGlobal.ProductMaster.ProductColor.ColorId
//                          && stockInDetail.Product.ProductMaster.ProductSize.SizeId == siRetDetail.ProductMasterGlobal.ProductMaster.ProductSize.SizeId)
//                        {
//                        }
                        IDictionary<DateTime, IDictionary<string, IDictionary<string, IDictionary<string, StockInDetail>>>> dateTimeMap = null;
                        map.TryGetValue(stockInDetail.Product.ProductMaster.ProductType.TypeName, out dateTimeMap);
                        if (dateTimeMap == null)
                        {
                            dateTimeMap = new Dictionary<DateTime, IDictionary<string, IDictionary<string, IDictionary<string, StockInDetail>>>>();
                            IDictionary<string, StockInDetail> map1 = new Dictionary<string, StockInDetail>();
                            map1.Add(stockInDetail.Product.ProductMaster.ProductSize.SizeName, stockInDetail);
                            IDictionary<string, IDictionary<string, StockInDetail>> map2 = new Dictionary<string, IDictionary<string, StockInDetail>>();
                            map2.Add(stockInDetail.Product.ProductMaster.ProductColor.ColorName, map1);
                            IDictionary<string, IDictionary<string, IDictionary<string, StockInDetail>>> map3 = new Dictionary<string, IDictionary<string, IDictionary<string, StockInDetail>>>();
                            map3.Add(stockInDetail.Product.ProductMaster.ProductName, map2);
                            dateTimeMap.Add(stockInDetail.CreateDate, map3);
                            map.Add(stockInDetail.Product.ProductMaster.ProductType.TypeName, dateTimeMap);
                        }
                        else
                        {
                            IDictionary<string, IDictionary<string, IDictionary<string, StockInDetail>>> proNameMap =
                                null;
                            dateTimeMap.TryGetValue(stockInDetail.CreateDate, out proNameMap);
                            if (proNameMap == null)
                            {
                                proNameMap = new Dictionary<string, IDictionary<string, IDictionary<string, StockInDetail>>>();
                                IDictionary<string, StockInDetail> map1 = new Dictionary<string, StockInDetail>();
                                map1.Add(stockInDetail.Product.ProductMaster.ProductSize.SizeName, stockInDetail);
                                IDictionary<string, IDictionary<string, StockInDetail>> map2 = new Dictionary<string, IDictionary<string, StockInDetail>>();
                                map2.Add(stockInDetail.Product.ProductMaster.ProductColor.ColorName, map1);
                                proNameMap.Add(stockInDetail.Product.ProductMaster.ProductName, map2);
                                dateTimeMap.Add(stockInDetail.CreateDate, proNameMap);
                            }
                            else
                            {
                                IDictionary<string, IDictionary<string, StockInDetail>> colorMap = null;
                                proNameMap.TryGetValue(stockInDetail.Product.ProductMaster.ProductName, out colorMap);
                                if (colorMap == null)
                                {
                                    colorMap = new Dictionary<string, IDictionary<string, StockInDetail>>();
                                    IDictionary<string, StockInDetail> map1 = new Dictionary<string, StockInDetail>();
                                    map1.Add(stockInDetail.Product.ProductMaster.ProductSize.SizeName, stockInDetail);
                                    colorMap.Add(stockInDetail.Product.ProductMaster.ProductColor.ColorName, map1);
                                    proNameMap.Add(stockInDetail.Product.ProductMaster.ProductName, colorMap);
                                }
                                else
                                {
                                    IDictionary<string, StockInDetail> sizeMap = null;
                                    colorMap.TryGetValue(stockInDetail.Product.ProductMaster.ProductColor.ColorName, out sizeMap);
                                    if (sizeMap == null)
                                    {
                                        sizeMap = new Dictionary<string, StockInDetail>();
                                        sizeMap.Add(stockInDetail.Product.ProductMaster.ProductSize.SizeName, stockInDetail);
                                        colorMap.Add(stockInDetail.Product.ProductMaster.ProductColor.ColorName, sizeMap);
                                    }
                                    else
                                    {
                                        StockInDetail detailInMap = null;
                                        sizeMap.TryGetValue(stockInDetail.Product.ProductMaster.ProductSize.SizeName, out detailInMap);
                                        if (detailInMap == null)
                                        {
                                            detailInMap = new StockInDetail{Quantity = stockInDetail.Quantity, Price = stockInDetail.Quantity * stockInDetail.Price};
                                            sizeMap.Add(stockInDetail.Product.ProductMaster.ProductSize.SizeName,detailInMap);
                                        }
                                        else
                                        {
                                            detailInMap.Quantity += stockInDetail.Quantity;
                                            detailInMap.Price += stockInDetail.Quantity * stockInDetail.Price;
                                        }
                                    }
                                }
                            }
                        //}

//                        StockInDetail detailInMap = null;
//                        if (detailMap == null)
//                        {
//                            detailMap = new Dictionary<string, StockInDetail>();
//                            detailMap.Add(stockInDetail.Product.ProductMaster.ProductName, stockInDetail);
//                            map.Add(stockInDetail.Product.ProductMaster.ProductType.TypeName, detailMap);
//                        }
//                        else
//                        {
//                            detailMap.TryGetValue(stockInDetail.Product.ProductMaster.ProductName, out detailInMap);
//                            if (detailInMap == null)
//                            {
//                                detailMap[stockInDetail.Product.ProductMaster.ProductName] = stockInDetail;
//                            }
//                            else
//                            {
//                                detailInMap.Quantity += stockInDetail.Quantity;
//                                detailInMap.Price += stockInDetail.Quantity * stockInDetail.Price;
//                            }
//                        }
                    }
                }
            }
            int stt = 1;
            int j = 0;
            long totalQty = 0;
            long totalPrice = 0;
            foreach (string key in map.Keys)
            {
                // STT 1
                sheet.Cells[11 + j + count, 1].PutValue((j + 1) + "");
                sheet.Cells[11 + j + count, 2].PutValue(key);
                int row = 11 + j + count;
                long sumQty = 0;
                long sumPrice = 0;
                count++;

                var dateTimeMap = map[key];
                foreach (DateTime dateTimeKey in dateTimeMap.Keys)
                {
                    // STT 1.1
                    sheet.Cells[11 + j + count, 1].PutValue((j + 1) + "." + stt);
                    sheet.Cells[11 + j + count, 3].PutValue(dateTimeKey.ToString("dd/MM/yyyy hh:mm:ss"));
                    count++;
                    int stt2 = 1;
                    var proNameMap = dateTimeMap[dateTimeKey];
                    foreach (string proNameKey in proNameMap.Keys)
                    {
                        // STT 1.1.1
                        sheet.Cells[11 + j + count, 1].PutValue((j + 1) + "." + stt + "." + stt2);
                        sheet.Cells[11 + j + count, 4].PutValue(proNameKey);
                        count++;
                        int stt3 = 1;
                        var colorMap = proNameMap[proNameKey];
                        foreach (string colorKey in colorMap.Keys)
                        {
                            // STT 1.1.1.1
                            var sizeMap = colorMap[colorKey];
                            foreach (string sizeKey in sizeMap.Keys)
                            {
                                // STT 1.1.1.1
                                sheet.Cells[11 + j + count, 1].PutValue((j + 1) + "." + stt + "." + stt2 + "." + stt3);
                                sheet.Cells[11 + j + count, 5].PutValue(colorKey);
                                sheet.Cells[11 + j + count, 6].PutValue(sizeKey);
                                
                                StockInDetail detailInMap = sizeMap[sizeKey];
                                sheet.Cells[11 + j + count, 7].PutValue(detailInMap.Quantity);
                                sheet.Cells[11 + j + count, 8].PutValue(detailInMap.Price);
                                totalQty += detailInMap.Quantity;
                                totalPrice += detailInMap.Price;
                                count++;
                                stt3++;
                            }
                        }
                        stt2++;
                    }

//                    StockInDetail detailInMap = detailMap[key1];
//
//                    // ten hang
//                    sheet.Cells[11 + j + count, 3].PutValue(detailInMap.Product.ProductMaster.ProductName);
//                    // quantity
//                    sheet.Cells[11 + j + count, 4].PutValue(detailInMap.Quantity);
//                    // Price
//                    sheet.Cells[11 + j + count, 5].PutValue(detailInMap.Price);
//
//                    sumQty += detailInMap.Quantity;
//                    sumPrice += detailInMap.Price;
//                    totalQty += sumQty;
//                    totalPrice += sumPrice;
//                    count++;
                }
//                sheet.Cells[row, 4].PutValue(sumQty);
//                sheet.Cells[row, 5].PutValue(sumPrice);
                j++;

            }


            // put total amount
            sheet.Cells[11 + j + count, 2].PutValue("Tổng cộng");
            sheet.Cells[11 + j + count, 7].PutValue(totalQty);
            sheet.Cells[11 + j + count, 8].PutValue(totalPrice);

            for (int row = 0; row < count + j + 2; row++)
            {
                for (int col = 0 ; col < 8; col++)
                {
                    sheet.Cells[11 + row - 1, col + 1].Style.Borders[BorderType.BottomBorder].LineStyle = CellBorderType.Thin;
                    sheet.Cells[11 + row - 1, col + 1].Style.Borders[BorderType.TopBorder].LineStyle = CellBorderType.Thin;
                    sheet.Cells[11 + row - 1, col + 1].Style.Borders[BorderType.LeftBorder].LineStyle = CellBorderType.Thin;
                    sheet.Cells[11 + row - 1, col + 1].Style.Borders[BorderType.RightBorder].LineStyle = CellBorderType.Thin;
                }
            }
            //sheet.Cells[14, 3].PutValue(txtTotalAmount.Text);

            //            sheet.Cells.ImportDataTable(test, true, 10, 1);


            workbook.Save(fileName);
            MessageBox.Show("Xuất ra tập tin báo cáo thành công!");*/
        }
    }
}
