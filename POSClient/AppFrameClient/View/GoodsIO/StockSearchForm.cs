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
using Aspose.Cells;

namespace AppFrameClient.View.GoodsIO
{
    public partial class StockSearchForm : BaseForm, IStockSearchView
    {
        private const int MAX_COLUMN = 8;
        private const int PRODUCT_MASTER_ID_POS = 0;
        private const int PRODUCT_MASTER_NAME_POS = 1;
        private const int PRODUCT_QUANTITY_POS = 2;
        private const int PRODUCT_SUM_POS = 3;
        private const int PRODUCT_TYPE_POS = 4;
        private const int PRODUCT_COLOR_POS = 5;
        private const int PRODUCT_SIZE_POS = 6;

        public StockSearchForm()
        {
            InitializeComponent();
//            dataTable.Columns.Add("Mã sản phẩm");
//            dataTable.Columns.Add("Tên sản phẩm");
//            dataTable.Columns.Add("Số lượng trong kho");
//            dataTable.Columns.Add("Tổng giá trị");
//            dataTable.Columns.Add("Chủng loại");
//            dataTable.Columns.Add("Màu sắc");
//            dataTable.Columns.Add("Kích cỡ");
//            dataTable.Columns.Add("Index");
        }

        private void StockSearchForm_Load(object sender, EventArgs e)
        {
            var eventArgs = new StockSearchEventArgs();
            EventUtility.fireEvent(InitStockSearchEvent, this, eventArgs);

            productMasterControl.cbbProductType.DataSource = eventArgs.ProductTypeList;
            productMasterControl.cbbProductType.DisplayMember = "TypeName";

            productMasterControl.cbbProductSize.DataSource = eventArgs.ProductSizeList;
            productMasterControl.cbbProductSize.DisplayMember = "SizeName";

            productMasterControl.cbbProductColor.DataSource = eventArgs.ProductColorList;
            productMasterControl.cbbProductColor.DisplayMember = "ColorName";

            productMasterControl.cbbCountry.DataSource = eventArgs.CountryList;
            productMasterControl.cbbCountry.DisplayMember = "CountryName";

            productMasterControl.cbbPackager.DataSource = eventArgs.PackagerList;
            productMasterControl.cbbPackager.DisplayMember = "PackagerName";

            productMasterControl.cbbDistributor.DataSource = eventArgs.DistributorList;
            productMasterControl.cbbDistributor.DisplayMember = "DistributorName";

            productMasterControl.cbbManufacturer.DataSource = eventArgs.ManufacturerList;
            productMasterControl.cbbManufacturer.DisplayMember = "ManufacturerName";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var eventArgs = new StockSearchEventArgs
            {
                ProductMasterId = productMasterControl.txtProductMasterId.Text,
                ProductMasterName = productMasterControl.txtProductName.Text,
                ProductSize = productMasterControl.cbbProductSize.SelectedIndex > 0 ? ((ProductSize)productMasterControl.cbbProductSize.SelectedItem) : null,
                ProductType = productMasterControl.cbbProductType.SelectedIndex > 0 ? ((ProductType)productMasterControl.cbbProductType.SelectedItem) : null,
                ProductColor = productMasterControl.cbbProductColor.SelectedIndex > 0 ?
                    ((ProductColor)productMasterControl.cbbProductColor.SelectedItem) : null,
                Country = productMasterControl.cbbCountry.SelectedIndex > 0 ? 
                    ((Country)productMasterControl.cbbCountry.SelectedItem) : null,
                Packager = productMasterControl.cbbPackager.SelectedIndex > 0 ? ((Packager)productMasterControl.cbbPackager.SelectedItem) : null,
                Manufacturer = productMasterControl.cbbManufacturer.SelectedIndex > 0 ?
                    ((Manufacturer)productMasterControl.cbbManufacturer.SelectedItem) : null,
                Distributor = productMasterControl.cbbDistributor.SelectedIndex > 0 ?
                    ((Distributor)productMasterControl.cbbDistributor.SelectedItem) : null
            };
            EventUtility.fireEvent(SearchStockEvent, sender, eventArgs);

            stockBindingSource.DataSource = eventArgs.StockList;
            long sumQty = 0;
            foreach (Stock stock in eventArgs.StockList)
            {
                sumQty += stock.Quantity;
            }
            txtSumQty.Text = sumQty.ToString();
        }

        public IList StockList { get; set; }
        private IStockSearchController _stockSearchController;
        public IStockSearchController StockSearchController
        {
            set
            {
                _stockSearchController = value;
                _stockSearchController.StockSearchView = this;
            }
        }

        public event EventHandler<StockSearchEventArgs> InitStockSearchEvent;
        public event EventHandler<StockSearchEventArgs> SearchStockEvent;
        public event EventHandler<StockSearchEventArgs> RemainSearchStockEvent;
        public event EventHandler<StockSearchEventArgs> BarcodeSearchStockEvent;
        private readonly DataTable dataTable = new DataTable();

        public void PopulateDataGrid()
        {
            if (StockList != null)
            {
                dataTable.Rows.Clear();
                for (int i = 0; i < StockList.Count; i++)
                {
                    var stock = (Stock)StockList[i];
                    dataTable.Rows.Add(AddBlockToDataGrid(stock, i));
                }
                dgvStockList.DataSource = dataTable;
                dgvStockList.Refresh();
            }
        }

        private static object[] AddBlockToDataGrid(Stock stock, int rowIndex)
        {
            var obj = new object[MAX_COLUMN];
            obj[PRODUCT_MASTER_ID_POS] = stock.Product.ProductMaster.ProductMasterId;
            obj[PRODUCT_MASTER_NAME_POS] = stock.Product.ProductMaster.ProductName;
            obj[PRODUCT_QUANTITY_POS] = stock.Quantity;
            obj[PRODUCT_SUM_POS] = 0;
            obj[MAX_COLUMN - 1] = rowIndex;
            return obj;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnExcel_Click(object sender, EventArgs e)
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
            sheet.Cells[6, 7].PutValue(new DateTime(2009,03,04).ToString("dd/MM/yyyy"));
            sheet.Cells[6, 9].PutValue(new DateTime(2009,03,10).ToString("dd/MM/yyyy"));
            var eventArgs = new StockSearchEventArgs();
            eventArgs.FromDate = new DateTime(2009, 03, 04);
            eventArgs.ToDate = new DateTime(2009,03,10);
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

                int stt2 = 1;
                    var proNameMap = map[key];
                    foreach (string proNameKey in proNameMap.Keys)
                    {
                        // STT 1.1.1
//                        sheet.Cells[11 + j + count, 1].PutValue((j + 1) + "." + stt + "." + stt2);
                        sheet.Cells[11 + j + count, 3].PutValue(proNameKey);
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
                for (int col = 0; col < 13; col++)
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
    }
}
