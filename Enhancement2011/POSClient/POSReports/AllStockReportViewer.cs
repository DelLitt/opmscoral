using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;
using POSReports.posDataSetTableAdapters;

namespace POSReports
{
    public partial class AllStockReportViewer : FormBase
    {
        public AllStockReportViewer()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void AllStockReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.allStock' table. You can move, or remove it, as needed.
            //this.AllStockTableAdapter.Fill(this.posDataSet.allStock);

            //this.reportViewer1.RefreshReport();
            this.product_typeTableAdapter.Fill(this.posDataSet.product_type);
            cboProductTypes.Items.Add(new ProductType { TypeId = 0, TypeName = "Tất cả mặt hàng" });
            foreach (posDataSet.product_typeRow row in posDataSet.product_type)
            {
                cboProductTypes.Items.Add(new ProductType { TypeId = row.TYPE_ID, TypeName = row.TYPE_NAME });
            }

            cboProductTypes.DisplayMember = "TypeName";
            cboProductTypes.ValueMember = "TypeName";    
        }
        public static DateTime ZeroTime(DateTime value)
        {
            return new DateTime(
                value.Year,
                value.Month,
                value.Day,
                0,
                0,
                0,
                0);
        }

        public static DateTime MaxTime(DateTime value)
        {
            return new DateTime(
                value.Year,
                value.Month,
                value.Day,
                23,
                5,                59,
                999);
        }
        POSReports.posDataSet aSyncDS = new posDataSet();
        private DateTime reqFromDate, reqToDate;
        private void button1_Click(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            reqFromDate = ZeroTime(FromDate.Value);
            reqToDate = MaxTime(ToDate.Value);

            Enabled = false;

            if (!string.IsNullOrEmpty(txtProducts.Text))
            {
                string productNamesFilter = txtProducts.Text.Trim();
                string[] pmFilters = productNamesFilter.Split(',');
                if (pmFilters.Length <= 1)
                {
                    allStockBindingSource.Filter = "product_name like '%" + productNamesFilter + "%'";
                }
                else
                {
                    string startFilterStr = "";
                    int count = 0;
                    string endFilterStr = "";
                    string filter = "";

                    foreach (string pmFilter in pmFilters)
                    {
                        count += 1;
                        if (string.IsNullOrEmpty(filter))
                        {
                            startFilterStr = "( ";
                        }
                        else
                        {
                            startFilterStr = " ";
                        }

                        if (count == pmFilters.Length) endFilterStr = " ) ";
                        else
                        {
                            endFilterStr = " OR ";
                        }

                        filter += startFilterStr + " ( product_name like '%" + pmFilter.Trim() + "%') " + endFilterStr;

                    }
                    allStockBindingSource.Filter = filter;
                }
            }
            else
            {
                allStockBindingSource.Filter = "";
            }

            if (cboProductTypes.SelectedIndex > 0)
            {
                string extraFilterStr = "";
                if (!string.IsNullOrEmpty(allStockBindingSource.Filter))
                {
                    extraFilterStr += " AND ";
                }

                allStockBindingSource.Filter += extraFilterStr + " type_name = '" + ((ProductType)cboProductTypes.SelectedItem).TypeName + "'";
            }

            if (!chkZeroValue.Checked)
            {
                string extraFilterStr = "";
                if (!string.IsNullOrEmpty(allStockBindingSource.Filter))
                {
                    extraFilterStr += " AND ";
                }
                //=Fields!preqty.Value+Fields!dpreqty.Value+Fields!inqty.Value+Fields!mainrtn.Value+Fields!rtnpr.Value-Fields!moutqty.Value-Fields!maindmg.Value-Fields!dpoutqty.Value-Fields!dpdmg.Value-Fields!saleqty.Value
                allStockBindingSource.Filter += extraFilterStr + " ((preqty >0) " +
                    "OR (dpreqty <> 0)  OR (inqty <> 0) OR (mainrtn <> 0) " +
                    "OR (rtnpr <> 0) OR (moutqty <> 0) OR (dpoutqty <> 0 ) OR (saleqty <> 0) ) ";
            }
            else
            {
                //stockStatisticBindingSource.Filter = "";
            }

            backgroundWorker.RunWorkerAsync();
            StartShowProcessing();

        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Enabled = true;
            StopShowProcessing();
            posDataSet.allStock.DefaultView.RowFilter = allStockBindingSource.Filter;
            allStockBindingSource.RaiseListChangedEvents = true;
            allStockBindingSource.ResumeBinding();
            allStockBindingSource.DataSource = posDataSet.allStock.DefaultView;
            reportViewer1.RefreshReport(); 
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            aSyncDS.EnforceConstraints = false;
            aSyncDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            POSReports.posDataSetTableAdapters.AllStockTableAdapter adapter = new AllStockTableAdapter();
            adapter.ClearBeforeFill = true;
            //adapter.Fill(aSyncDS.StockStatistic, reqFromDate, reqToDate);
            adapter.Fill(posDataSet.allStock, reqFromDate, reqToDate);
        }
    }
}
