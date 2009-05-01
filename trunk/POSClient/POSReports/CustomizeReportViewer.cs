﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace POSReports
{
    public partial class CustomizeReportViewer : Form
    {
        public CustomizeReportViewer()
        {
            InitializeComponent();
        }

        private void CustomizeReportViewer_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'posDataSet.CustomizeReport' table. You can move, or remove it, as needed.
            //this.CustomizeReportTableAdapter.Fill(this.posDataSet.CustomizeReport);
            this.customizeReport.RefreshReport();
            cboReportType.SelectedIndex = 0;
            cboSortOrder.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int ReportType = cboReportType.SelectedIndex + 1;
                int SortOrder = cboSortOrder.SelectedIndex;
                DateTime fromDate = dtpFromDate.Value;
                DateTime toDate = dtpToDate.Value;
                int limit = Int32.Parse(txtTotalRecord.Text);
                CustomizeReportTableAdapter.Fill(posDataSet.CustomizeReport, ReportType, SortOrder,limit, fromDate, toDate);
                this.customizeReport.RefreshReport();
            }
            catch (Exception exception)
            {

                MessageBox.Show(" Có lỗi khi tạo báo cáo");
            }
            

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void customizeReport_Load(object sender, EventArgs e)
        {

        }
    }
}
