namespace POSReports
{
    partial class ProductMasterStatisticReportViewer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.ProductMasterStatisticExBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.posDataSet = new POSReports.posDataSet();
            this.ProductMasterStatisticBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.customizeReport = new Microsoft.Reporting.WinForms.ReportViewer();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrdFilter = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSizeFilter = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtColorFilter = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.departmentBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.producttypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.departmentTableAdapter1 = new POSReports.posDataSetTableAdapters.departmentTableAdapter();
            this.DepartmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.product_typeTableAdapter = new POSReports.posDataSetTableAdapters.product_typeTableAdapter();
            this.ProductMasterStatisticTableAdapter = new POSReports.posDataSetTableAdapters.ProductMasterStatisticTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.ProductMasterStatisticExBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductMasterStatisticBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.producttypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // ProductMasterStatisticExBindingSource
            // 
            this.ProductMasterStatisticExBindingSource.DataMember = "ProductMasterStatisticEx";
            this.ProductMasterStatisticExBindingSource.DataSource = this.posDataSet;
            // 
            // posDataSet
            // 
            this.posDataSet.DataSetName = "posDataSet";
            this.posDataSet.EnforceConstraints = false;
            this.posDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // ProductMasterStatisticBindingSource
            // 
            this.ProductMasterStatisticBindingSource.DataMember = "ProductMasterStatistic";
            this.ProductMasterStatisticBindingSource.DataSource = this.posDataSet;
            // 
            // customizeReport
            // 
            this.customizeReport.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "posDataSet_ProductMasterStatisticEx";
            reportDataSource1.Value = this.ProductMasterStatisticExBindingSource;
            this.customizeReport.LocalReport.DataSources.Add(reportDataSource1);
            this.customizeReport.LocalReport.ReportEmbeddedResource = "POSReports.ProductMasterStatisticEx.rdlc";
            this.customizeReport.Location = new System.Drawing.Point(0, 129);
            this.customizeReport.Name = "customizeReport";
            this.customizeReport.Size = new System.Drawing.Size(929, 406);
            this.customizeReport.TabIndex = 0;
            this.customizeReport.ZoomMode = Microsoft.Reporting.WinForms.ZoomMode.PageWidth;
            this.customizeReport.Load += new System.EventHandler(this.customizeReport_Load);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(526, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "BÁO CÁO THEO DÕI TÌNH TRẠNG MẶT HÀNG";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.83333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.16667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 67F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 168F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 179F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtPrdFilter, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtSizeFilter, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtColorFilter, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtResult, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 7, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 29);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(929, 100);
            this.tableLayoutPanel1.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9.176471F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(100, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 17);
            this.label3.TabIndex = 24;
            this.label3.Text = "Tên sản phẩm";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPrdFilter
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtPrdFilter, 2);
            this.txtPrdFilter.Font = new System.Drawing.Font("Tahoma", 9.176471F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrdFilter.Location = new System.Drawing.Point(241, 3);
            this.txtPrdFilter.Name = "txtPrdFilter";
            this.txtPrdFilter.Size = new System.Drawing.Size(218, 23);
            this.txtPrdFilter.TabIndex = 20;
            this.txtPrdFilter.TextChanged += new System.EventHandler(this.txtPrdFilter_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 9.176471F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(465, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(38, 17);
            this.label6.TabIndex = 25;
            this.label6.Text = "K.cỡ";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSizeFilter
            // 
            this.txtSizeFilter.Enabled = false;
            this.txtSizeFilter.Font = new System.Drawing.Font("Tahoma", 9.176471F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSizeFilter.Location = new System.Drawing.Point(532, 3);
            this.txtSizeFilter.Name = "txtSizeFilter";
            this.txtSizeFilter.Size = new System.Drawing.Size(162, 23);
            this.txtSizeFilter.TabIndex = 21;
            this.txtSizeFilter.TextChanged += new System.EventHandler(this.txtSizeFilter_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.176471F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(700, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 17);
            this.label8.TabIndex = 26;
            this.label8.Text = "Màu";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtColorFilter
            // 
            this.txtColorFilter.Enabled = false;
            this.txtColorFilter.Font = new System.Drawing.Font("Tahoma", 9.176471F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColorFilter.Location = new System.Drawing.Point(752, 3);
            this.txtColorFilter.Name = "txtColorFilter";
            this.txtColorFilter.Size = new System.Drawing.Size(164, 23);
            this.txtColorFilter.TabIndex = 22;
            this.txtColorFilter.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 15);
            this.label9.TabIndex = 27;
            this.label9.Text = "Lọc theo:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtResult
            // 
            this.txtResult.BackColor = System.Drawing.SystemColors.Control;
            this.txtResult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel1.SetColumnSpan(this.txtResult, 5);
            this.txtResult.Location = new System.Drawing.Point(100, 39);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(594, 20);
            this.txtResult.TabIndex = 23;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(752, 39);
            this.button1.Name = "button1";
            this.tableLayoutPanel1.SetRowSpan(this.button1, 2);
            this.button1.Size = new System.Drawing.Size(160, 51);
            this.button1.TabIndex = 28;
            this.button1.Text = "Chạy báo cáo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // departmentBindingSource1
            // 
            this.departmentBindingSource1.DataMember = "department";
            this.departmentBindingSource1.DataSource = this.posDataSet;
            // 
            // producttypeBindingSource
            // 
            this.producttypeBindingSource.DataMember = "product_type";
            this.producttypeBindingSource.DataSource = this.posDataSet;
            // 
            // departmentTableAdapter1
            // 
            this.departmentTableAdapter1.ClearBeforeFill = true;
            // 
            // DepartmentBindingSource
            // 
            this.DepartmentBindingSource.DataMember = "department";
            this.DepartmentBindingSource.DataSource = this.posDataSet;
            // 
            // product_typeTableAdapter
            // 
            this.product_typeTableAdapter.ClearBeforeFill = true;
            // 
            // ProductMasterStatisticTableAdapter
            // 
            this.ProductMasterStatisticTableAdapter.ClearBeforeFill = true;
            // 
            // ProductMasterStatisticReportViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 558);
            this.Controls.Add(this.customizeReport);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Name = "ProductMasterStatisticReportViewer";
            this.Text = "BÁO CÁO THEO DÕI TÌNH TRẠNG MẶT HÀNG";
            this.Load += new System.EventHandler(this.CustomizeReportViewer_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.tableLayoutPanel1, 0);
            this.Controls.SetChildIndex(this.customizeReport, 0);
            ((System.ComponentModel.ISupportInitialize)(this.ProductMasterStatisticExBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.posDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ProductMasterStatisticBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.producttypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartmentBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer customizeReport;
        private posDataSet posDataSet;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private POSReports.posDataSetTableAdapters.departmentTableAdapter departmentTableAdapter1;
        private System.Windows.Forms.BindingSource DepartmentBindingSource;
        private System.Windows.Forms.BindingSource departmentBindingSource1;
        private System.Windows.Forms.TextBox txtColorFilter;
        private System.Windows.Forms.TextBox txtPrdFilter;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtSizeFilter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.BindingSource producttypeBindingSource;
        private POSReports.posDataSetTableAdapters.product_typeTableAdapter product_typeTableAdapter;
        private System.Windows.Forms.BindingSource ProductMasterStatisticBindingSource;
        private POSReports.posDataSetTableAdapters.ProductMasterStatisticTableAdapter ProductMasterStatisticTableAdapter;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.BindingSource ProductMasterStatisticExBindingSource;

    }
}