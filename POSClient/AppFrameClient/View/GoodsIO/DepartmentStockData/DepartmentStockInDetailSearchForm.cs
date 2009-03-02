using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;

namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    public partial class DepartmentStockInDetailSearchForm : BaseForm, IDepartmentStockDetailView
    {
        public DepartmentStockInDetailSearchForm()
        {
            InitializeComponent();
            dataTable.Columns.Add("Ngày nhập");
            dataTable.Columns.Add("Số lượng");
            dataTable.Columns.Add("Giá nhập vào");
            dataTable.Columns.Add("Giá bán");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var eventArgs = new DepartmentStockDetailEventArgs
                                {
                                    ProductMasterId = ProductMaster.ProductMasterId,
                                    StockInDateFrom = chkStockDateFrom.Checked ? DateUtility.ZeroTime(dtpStockDateFrom.Value) : DateTime.MinValue,
                                    StockInDateTo = chkStockDateTo.Checked ? DateUtility.MaxTime(dtpStockDateTo.Value) : DateTime.MaxValue

                                };
            SearchDepartmentStock(eventArgs);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string newPrice = txtSellPrice.Text;
            if (string.IsNullOrEmpty(newPrice))
            {
                errorProvider.SetError(txtSellPrice, "Giá niêm yết phải được nhập và lớn hơn 0");
            }
            else
            {
                long sellPrice = 0;
                if (!NumberUtility.CheckLong(newPrice.Replace(".", ""), out sellPrice))
                {
                    errorProvider.SetError(txtSellPrice, "Giá niêm yết phải là số nguyên");
                } 
                else
                {
                    var eventArgs = new DepartmentStockDetailEventArgs();
                    if (DepartmentPrice != null)
                    {
                        DepartmentPrice.Price = sellPrice;
                    }
                    else
                    {
                        eventArgs.IsNewPrice = true;
                        DepartmentPrice = new DepartmentPrice{DepartmentPricePK = new DepartmentPricePK{DepartmentId = 0, ProductMasterId = ProductMaster.ProductMasterId}, Price = sellPrice};
                    }
                    eventArgs.ProductPrice = DepartmentPrice;
                    EventUtility.fireEvent(SaveDepartmentPriceEvent, this, eventArgs);
                    MessageBox.Show("Lưu thành công");
                }
            }
        }

        private void DepartmentStockInDetailSearchForm_Load(object sender, EventArgs e)
        {
            productMasterSearchControl.txtProductMasterId.ReadOnly = true;
            productMasterSearchControl.txtProductName.ReadOnly = true;
            productMasterSearchControl.cbbProductType.Enabled = false;
            productMasterSearchControl.cbbProductSize.Enabled = false;
            productMasterSearchControl.cbbProductColor.Enabled = false;
            productMasterSearchControl.cbbPackager.Enabled = false;
            productMasterSearchControl.cbbManufacturer.Enabled = false;
            productMasterSearchControl.cbbDistributor.Enabled = false;
            productMasterSearchControl.cbbCountry.Enabled = false;

            productMasterSearchControl.txtProductMasterId.Text = ProductMaster.ProductMasterId;
            productMasterSearchControl.txtProductName.Text = ProductMaster.ProductName;
            if (ProductMaster.ProductType != null)
            {
                SetDataToCombo(productMasterSearchControl.cbbProductType, ProductMaster.ProductType.TypeName);
            }

            if (ProductMaster.ProductSize != null)
            {
                SetDataToCombo(productMasterSearchControl.cbbProductSize, ProductMaster.ProductSize.SizeName);
            }

            if (ProductMaster.ProductColor != null)
            {
                SetDataToCombo(productMasterSearchControl.cbbProductColor, ProductMaster.ProductColor.ColorName);
            }

            if (ProductMaster.Packager != null)
            {
                SetDataToCombo(productMasterSearchControl.cbbPackager, ProductMaster.Packager.PackagerName);
            }

            if (ProductMaster.Manufacturer != null)
            {
                SetDataToCombo(productMasterSearchControl.cbbManufacturer, ProductMaster.Manufacturer.ManufacturerName);
            }

            if (ProductMaster.Distributor != null)
            {
                SetDataToCombo(productMasterSearchControl.cbbDistributor, ProductMaster.Distributor.DistributorName);
            }

            if (ProductMaster.Country != null)
            {
                SetDataToCombo(productMasterSearchControl.cbbCountry, ProductMaster.Country.CountryName);
            }

            var eventArgs = new DepartmentStockDetailEventArgs
                                {
                                    ProductMasterId = ProductMaster.ProductMasterId,
                                    StockInDateFrom = DateTime.MinValue,
                                    StockInDateTo = DateTime.MaxValue

                                };
            SearchDepartmentStock(eventArgs);
        }

        private void chkStockDateFrom_CheckedChanged(object sender, EventArgs e)
        {
            dtpStockDateFrom.Enabled = chkStockDateFrom.Checked;
        }

        private void chkStockDateTo_CheckedChanged(object sender, EventArgs e)
        {
            dtpStockDateTo.Enabled = chkStockDateTo.Checked;
        }

        private void SearchDepartmentStock(DepartmentStockDetailEventArgs eventArgs)
        {
            EventUtility.fireEvent(SearchDepartmentStockInDetailEvent, this, eventArgs);
            DepartmentStockInDetailList = eventArgs.DepartmentStockInDetailList;
            DepartmentPrice = eventArgs.ProductPrice;
            if (eventArgs.ProductPrice != null)
            {
                txtSellPrice.Text = eventArgs.ProductPrice.Price.ToString();
            }
            PopulateDataGrid();
        }

        private static void SetDataToCombo(ComboBox cbb, string data)
        {
            cbb.Items.Add(data);
            cbb.SelectedIndex = 0;
        }

        private void PopulateDataGrid()
        {
            dataTable.Rows.Clear();
            long sumInQty = 0;
            for (int i = 0; i < DepartmentStockInDetailList.Count; i++)
            {
                var result = (DepartmentStockInDetail)DepartmentStockInDetailList[i];
                dataTable.Rows.Add(AddProductToDataGrid(result));
                sumInQty += result.Quantity;

            }
            dgvProduct.DataSource = dataTable;
            txtSumInQuantity.RightToLeft = RightToLeft.Yes;
            txtSumRemainQuantity.RightToLeft = RightToLeft.Yes;
            txtSumInQuantity.Text = sumInQty.ToString("#,##", CultureInfo.CreateSpecificCulture("de-DE"));
            txtSumRemainQuantity.Text = SumStock;
            txtSellPrice.RightToLeft = RightToLeft.Yes;

            dgvProduct.Columns[0].Width = 170;
            dgvProduct.Columns[1].Width = 170;
            dgvProduct.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProduct.Columns[2].Width = 170;
            dgvProduct.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvProduct.Columns[3].Width = 170;
            dgvProduct.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dgvProduct.Refresh();
        }

        private static object[] AddProductToDataGrid(DepartmentStockInDetail stockInDetail)
        {
            var obj = new object[4];
            obj[0] = stockInDetail.DepartmentStockIn.StockInDate.ToString("dd/MM/yyyy HH:mm:ss");
            obj[1] = stockInDetail.Quantity.ToString("#,##", CultureInfo.CreateSpecificCulture("de-DE"));
            obj[2] = stockInDetail.Price.ToString("#,##", CultureInfo.CreateSpecificCulture("de-DE"));
            obj[3] = stockInDetail.OnStorePrice.ToString("#,##", CultureInfo.CreateSpecificCulture("de-DE"));
            return obj;
        }

        #region Implementation of IDepartmentStockDetailView
        public DepartmentPrice DepartmentPrice { get; set; }
        public ProductMaster ProductMaster { get; set; }
        public string SumStock { get; set; }
        private readonly DataTable dataTable = new DataTable();
        public IList DepartmentStockInDetailList { get; set; }
        public IDepartmentStockDetailController _departmentStockDetailController; 
        public IDepartmentStockDetailController DepartmentStockDetailController { 
            set
            {
                _departmentStockDetailController = value;
                _departmentStockDetailController.DepartmentStockDetailView = this;
            }
            get
            {
                return _departmentStockDetailController;
            }
        }
        public event EventHandler<DepartmentStockDetailEventArgs> SaveDepartmentPriceEvent;
        public event EventHandler<DepartmentStockDetailEventArgs> SearchDepartmentStockInDetailEvent;

        #endregion
    }
}