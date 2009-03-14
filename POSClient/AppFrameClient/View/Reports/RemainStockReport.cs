using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.Report;
using AppFrame.Utility;
using AppFrame.View.GoodsIO;
using AppFrame.View.Reports;
using Aspose.Cells;

namespace AppFrameClient.View.Reports
{
    public partial class RemainStockReport : BaseForm, IStockSearchView
    {
        public RemainStockReport()
        {
            InitializeComponent();
        }

       

        #region IReportStockInParamView Members

        private IStockSearchController reportStockInController;
        public IStockSearchController StockSearchController
        {
            get
            {
                return reportStockInController;
            }
            set
            {
                reportStockInController = value;
                reportStockInController.StockSearchView = this;

            }
        }

        public event EventHandler<StockSearchEventArgs> InitStockSearchEvent;
        public event EventHandler<StockSearchEventArgs> SearchStockEvent;
        public event EventHandler<StockSearchEventArgs> RemainSearchStockEvent;

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            string fileName = saveFileDialog1.FileName;

            Workbook workbook = new Workbook();
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\Templates\\Tonkho.xls";
            workbook.Open(path);
            //workbook.Open("g:\\Book1.xls");
            Worksheet sheet = workbook.Worksheets[0];
            sheet.Name = "Sheet1";

            sheet.Cells[6, 4].PutValue(DateTime.Now.ToString("dd/MM/yyyy"));
            sheet.Cells[6, 7].PutValue(dtpReportTimeFrom.Value.ToString("dd/MM/yyyy"));
            sheet.Cells[6, 9].PutValue(dtpReportTimeTo.Value.ToString("dd/MM/yyyy"));
            var eventArgs = new StockSearchEventArgs();
            eventArgs.FromDate = DateUtility.ZeroTime(dtpReportTimeFrom.Value);
            eventArgs.ToDate = DateUtility.MaxTime(dtpReportTimeTo.Value);
            EventUtility.fireEvent(RemainSearchStockEvent, this, eventArgs);


            int count = 0;
            IDictionary<string, IDictionary<string, IDictionary<string, IDictionary<string, UniversalStockReportObject>>>> map = new Dictionary<string, IDictionary<string, IDictionary<string, IDictionary<string, UniversalStockReportObject>>>>();
            //            for (int i = 0; i < dgvStockProducts.RowCount; i++)
            //            {
            //                if (i == pSODetResultList.Count)
            //                {
            //                    break;
            //                }
            //                StockInResultDetail siRetDetail = pSODetResultList[i];

            foreach (UniversalStockReportObject stockInDetail in eventArgs.ReportList)
            {
                IDictionary<string, IDictionary<string, IDictionary<string, UniversalStockReportObject>>> proNameMap =
                        null;
                map.TryGetValue(stockInDetail.ProductMaster.ProductType.TypeName, out proNameMap);
                if (proNameMap == null)
                {
                    proNameMap = new Dictionary<string, IDictionary<string, IDictionary<string, UniversalStockReportObject>>>();
                    IDictionary<string, UniversalStockReportObject> map1 = new Dictionary<string, UniversalStockReportObject>();
                    map1.Add(stockInDetail.ProductMaster.ProductSize.SizeName, stockInDetail);
                    IDictionary<string, IDictionary<string, UniversalStockReportObject>> map2 = new Dictionary<string, IDictionary<string, UniversalStockReportObject>>();
                    map2.Add(stockInDetail.ProductMaster.ProductColor.ColorName, map1);
                    proNameMap.Add(stockInDetail.ProductMaster.ProductName, map2);
                    map.Add(stockInDetail.ProductMaster.ProductType.TypeName, proNameMap);
                }
                else
                {
                    IDictionary<string, IDictionary<string, UniversalStockReportObject>> colorMap = null;
                    proNameMap.TryGetValue(stockInDetail.ProductMaster.ProductName, out colorMap);
                    if (colorMap == null)
                    {
                        colorMap = new Dictionary<string, IDictionary<string, UniversalStockReportObject>>();
                        IDictionary<string, UniversalStockReportObject> map1 = new Dictionary<string, UniversalStockReportObject>();
                        map1.Add(stockInDetail.ProductMaster.ProductSize.SizeName, stockInDetail);
                        colorMap.Add(stockInDetail.ProductMaster.ProductColor.ColorName, map1);
                        proNameMap.Add(stockInDetail.ProductMaster.ProductName, colorMap);
                    }
                    else
                    {
                        IDictionary<string, UniversalStockReportObject> sizeMap = null;
                        colorMap.TryGetValue(stockInDetail.ProductMaster.ProductColor.ColorName, out sizeMap);
                        if (sizeMap == null)
                        {
                            sizeMap = new Dictionary<string, UniversalStockReportObject>();
                            sizeMap.Add(stockInDetail.ProductMaster.ProductSize.SizeName, stockInDetail);
                            colorMap.Add(stockInDetail.ProductMaster.ProductColor.ColorName, sizeMap);
                        }
                        else
                        {
                            UniversalStockReportObject detailInMap = null;
                            sizeMap.TryGetValue(stockInDetail.ProductMaster.ProductSize.SizeName, out detailInMap);
                            if (detailInMap == null)
                            {
                                sizeMap.Add(stockInDetail.ProductMaster.ProductSize.SizeName, stockInDetail);
                            }
                            //                                else
                            //                                {
                            //                                    detailInMap.Quantity += stockInDetail.Quantity;
                            //                                    detailInMap.Price += stockInDetail.Quantity * stockInDetail.Price;
                            //                                }
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
            int stt = 1;
            int j = 0;
            long totalTypeTonDauKiQty = 0;
            long totalTypeNhapTrongKiQty = 0;
            long totalTypeXuatTrongKiQty = 0;
            long totalTypeTonCuoiQty = 0;
            foreach (string key in map.Keys)
            {
                // STT 1
                sheet.Cells[11 + j + count, 1].PutValue((stt) + "");
                for (int col = 0; col < 10; col++)
                {
                    sheet.Cells[11 + j + count, col + 1].Style.ForegroundColor = Color.LightBlue;
                }
                
                stt++;
                sheet.Cells[11 + j + count, 2].PutValue(key);
                int row = 11 + j + count;
                long sumTypeTonDauKiQty = 0;
                long sumTypeNhapTrongKiQty = 0;
                long sumTypeXuatTrongKiQty = 0;
                long sumTypeTonCuoiQty = 0;
                int pos2 = 11 + j + count;
                count++;
                
                int stt2 = 1;
                var proNameMap = map[key];
                foreach (string proNameKey in proNameMap.Keys)
                {
                    // STT 1.1.1
                    //                        sheet.Cells[11 + j + count, 1].PutValue((j + 1) + "." + stt + "." + stt2);
                    sheet.Cells[11 + j + count, 3].PutValue(proNameKey);
                    for (int col = 0; col < 10; col++)
                    {
                        sheet.Cells[11 + j + count, col + 1].Style.ForegroundColor = Color.LightGray;
                    }
                    int pos3 = 11 + j + count;
                    count++;
                    int stt3 = 1;
                    long sumNameTonDauKiQty = 0;
                    long sumNameNhapTrongKiQty = 0;
                    long sumNameXuatTrongKiQty = 0;
                    long sumNameTonCuoiQty = 0;
                    var colorMap = proNameMap[proNameKey];
                    foreach (string colorKey in colorMap.Keys)
                    {
                        // STT 1.1.1.1
                        var sizeMap = colorMap[colorKey];
                        foreach (string sizeKey in sizeMap.Keys)
                        {
                            // STT 1.1.1.1
                            //                                sheet.Cells[11 + j + count, 1].PutValue((j + 1) + "." + stt + "." + stt2 + "." + stt3);
                            sheet.Cells[11 + j + count, 4].PutValue(colorKey);
                            sheet.Cells[11 + j + count, 5].PutValue(sizeKey);
                            sheet.Cells[11 + j + count, 6].PutValue("Cái");

                            UniversalStockReportObject detailInMap = sizeMap[sizeKey];
                            sheet.Cells[11 + j + count, 7].PutValue(detailInMap.StockStartQuantity);
                            sheet.Cells[11 + j + count, 8].PutValue(detailInMap.StockInEndQuantity - detailInMap.StockInStartQuantity);
                            sheet.Cells[11 + j + count, 9].PutValue(detailInMap.DepartmentStockInEndQuantity - detailInMap.DepartmentStockInStartQuantity);
                            sheet.Cells[11 + j + count, 10].PutValue(detailInMap.StockEndQuantity);
                            //                                totalQty += detailInMap.Quantity;
                            //                                totalPrice += detailInMap.Price;
                            count++;
                            stt3++;

                            totalTypeTonDauKiQty += detailInMap.StockStartQuantity;
                            sumTypeTonDauKiQty += detailInMap.StockStartQuantity;
                            sumNameTonDauKiQty += detailInMap.StockStartQuantity;

                            totalTypeNhapTrongKiQty += detailInMap.StockInEndQuantity - detailInMap.StockInStartQuantity;
                            sumTypeNhapTrongKiQty += detailInMap.StockInEndQuantity - detailInMap.StockInStartQuantity;
                            sumNameNhapTrongKiQty += detailInMap.StockInEndQuantity - detailInMap.StockInStartQuantity;

                            totalTypeTonCuoiQty += detailInMap.StockEndQuantity;
                            sumTypeTonCuoiQty += detailInMap.StockEndQuantity;
                            sumNameTonCuoiQty += detailInMap.StockEndQuantity;

                            totalTypeXuatTrongKiQty += detailInMap.DepartmentStockInEndQuantity - detailInMap.DepartmentStockInStartQuantity;
                            sumTypeXuatTrongKiQty += detailInMap.DepartmentStockInEndQuantity - detailInMap.DepartmentStockInStartQuantity;
                            sumNameXuatTrongKiQty += detailInMap.DepartmentStockInEndQuantity - detailInMap.DepartmentStockInStartQuantity;
                        }
                    }
                    stt2++;
                    count++;
                    sheet.Cells[pos3, 7].PutValue(sumNameTonDauKiQty);
                    sheet.Cells[pos3, 8].PutValue(sumNameNhapTrongKiQty);
                    sheet.Cells[pos3, 9].PutValue(sumNameXuatTrongKiQty);
                    sheet.Cells[pos3, 10].PutValue(sumNameTonCuoiQty);
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
                //                sheet.Cells[row, 4].PutValue(sumQty);
                //                sheet.Cells[row, 5].PutValue(sumPrice);
//                j++;

                sheet.Cells[pos2, 7].PutValue(sumTypeTonDauKiQty);
                sheet.Cells[pos2, 8].PutValue(sumTypeNhapTrongKiQty);
                sheet.Cells[pos2, 9].PutValue(sumTypeXuatTrongKiQty);
                sheet.Cells[pos2, 10].PutValue(sumTypeTonCuoiQty);
            }



            // put total amount
            sheet.Cells[11 + j + count, 2].PutValue("Tổng cộng");
            sheet.Cells[11 + j + count, 7].PutValue(totalTypeTonDauKiQty);
            sheet.Cells[11 + j + count, 8].PutValue(totalTypeNhapTrongKiQty);
            sheet.Cells[11 + j + count, 9].PutValue(totalTypeXuatTrongKiQty);
            sheet.Cells[11 + j + count, 10].PutValue(totalTypeTonCuoiQty);

            for (int row = 0; row < count + j + 2; row++)
            {
                for (int col = 0; col < 10; col++)
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
            MessageBox.Show("Xuất ra tập tin báo cáo thành công!");

            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
