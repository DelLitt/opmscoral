using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;
using Microsoft.Reporting.WinForms;
using POSReports.posDataSetTableAdapters;

namespace POSReports
{
    public partial class StockStatisticReportViewer : FormBase
    {
        public StockStatisticReportViewer()
        {
            InitializeComponent();
        }

        private void StockStatisticReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.product_type' table. You can move, or remove it, as needed.
            this.product_typeTableAdapter.Fill(this.posDataSet.product_type);
            // TODO: This line of code loads data into the 'posDataSet.department' table. You can move, or remove it, as needed.
            cboProductTypes.Items.Add(new ProductType { TypeId = 0, TypeName = "Tất cả mặt hàng" });
            foreach (posDataSet.product_typeRow row in posDataSet.product_type)
            {
                cboProductTypes.Items.Add(new ProductType { TypeId = row.TYPE_ID, TypeName = row.TYPE_NAME });
            }

            cboProductTypes.DisplayMember = "TypeName";
            cboProductTypes.ValueMember = "TypeName";    
            // TODO: This line of code loads data into the 'posDataSet.stockStatistic' table. You can move, or remove it, as needed.
         //   this.StockStatisticTableAdapter.Fill(this.posDataSet.stockStatistic);

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
                59,
                59,
                999);
        }


        private Stopwatch watcher = null;
        private void button1_Click(object sender, EventArgs e)
        {           
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            reqFromDate = ZeroTime(ToDate.Value);
            reqToDate = MaxTime(ToDate.Value);
            if(!string.IsNullOrEmpty(txtProducts.Text))
            {
                stockStatisticBindingSource.Filter = "product_name like '%" + txtProducts.Text + "%'";
            }
            else
            {
                stockStatisticBindingSource.Filter = "";
            }

            if(cboProductTypes.SelectedIndex > 0)
            {
                string extraFilterStr = "";
                if (!string.IsNullOrEmpty(stockStatisticBindingSource.Filter))
                {
                    extraFilterStr += " AND ";
                }

                stockStatisticBindingSource.Filter += extraFilterStr + " type_name = '" + ((ProductType)cboProductTypes.SelectedItem).TypeName + "'";
            }

            if (!chkZeroValue.Checked)
            {
                string extraFilterStr = "";
                if (!string.IsNullOrEmpty(stockStatisticBindingSource.Filter))
                {
                    extraFilterStr += " AND ";
                }

                stockStatisticBindingSource.Filter += extraFilterStr + " ((prestk_qty >0) " + 
                    "OR (instock_qty <> 0)  OR (mainrtnqty <> 0) OR (stkout_qty <> 0) " + 
                    "OR (destroy_qty <> 0) OR (tmpout_qty <> 0) OR (rtn_qty <> 0 )) ";
            }
            else
            {
                //stockStatisticBindingSource.Filter = "";
            }

            stockStatisticBindingSource.SuspendBinding();
            stockStatisticBindingSource.RaiseListChangedEvents = false;
            
            Enabled = false;
            watcher = new Stopwatch();
            watcher.Start();
            backgroundWorker.RunWorkerAsync();
            StartShowProcessing();
            
        }

        POSReports.posDataSet aSyncDS = new posDataSet();
        private DateTime reqFromDate, reqToDate;
        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            watcher.Stop();
            ShowMessage("Queries run in " + watcher.ElapsedMilliseconds/ 1000 + " seconds ..");
            
            Enabled = true;
            StopShowProcessing();
            posDataSet.StockStatistic.DefaultView.RowFilter = stockStatisticBindingSource.Filter;
            stockStatisticBindingSource.RaiseListChangedEvents = true;
            stockStatisticBindingSource.ResumeBinding();
            stockStatisticBindingSource.DataSource = posDataSet.StockStatistic.DefaultView;
            reportViewer1.RefreshReport();
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            aSyncDS.EnforceConstraints = false;
            aSyncDS.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            POSReports.posDataSetTableAdapters.StockStatisticTableAdapter adapter = new StockStatisticTableAdapter();
            
            adapter.ClearBeforeFill = true;
            //adapter.Fill(aSyncDS.StockStatistic, reqFromDate, reqToDate);
            adapter.Fill(posDataSet.StockStatistic, reqFromDate, reqToDate);
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
