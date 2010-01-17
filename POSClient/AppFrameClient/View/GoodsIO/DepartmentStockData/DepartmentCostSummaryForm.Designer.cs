namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    partial class DepartmentCostSummaryForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.masterDB = new AppFrameClient.MasterDB();
            this.btnCommit = new System.Windows.Forms.Button();
            this.rptDepartmentCost = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtoFrom = new System.Windows.Forms.DateTimePicker();
            this.dtoTo = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRunReport = new System.Windows.Forms.Button();
            this.departmentTableAdapter = new AppFrameClient.MasterDBTableAdapters.DepartmentTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.29412F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(296, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 21);
            this.label2.TabIndex = 32;
            this.label2.Text = "Từ:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 31;
            this.label1.Text = "Cửa hàng:";
            // 
            // cboDepartment
            // 
            this.cboDepartment.DataSource = this.departmentBindingSource;
            this.cboDepartment.DisplayMember = "DEPARTMENT_NAME";
            this.cboDepartment.Enabled = false;
            this.cboDepartment.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(85, 12);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(205, 25);
            this.cboDepartment.TabIndex = 25;
            this.cboDepartment.TabStop = false;
            this.cboDepartment.ValueMember = "DEPARTMENT_ID";
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataMember = "Department";
            this.departmentBindingSource.DataSource = this.masterDB;
            // 
            // masterDB
            // 
            this.masterDB.DataSetName = "MasterDB";
            this.masterDB.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // btnCommit
            // 
            this.btnCommit.Enabled = false;
            this.btnCommit.Font = new System.Drawing.Font("Tahoma", 11.29412F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCommit.Location = new System.Drawing.Point(653, 10);
            this.btnCommit.Name = "btnCommit";
            this.btnCommit.Size = new System.Drawing.Size(162, 60);
            this.btnCommit.TabIndex = 39;
            this.btnCommit.Text = "Chốt sổ";
            this.btnCommit.UseVisualStyleBackColor = true;
            this.btnCommit.Click += new System.EventHandler(this.btnCommit_Click);
            // 
            // rptDepartmentCost
            // 
            this.rptDepartmentCost.LocalReport.ReportEmbeddedResource = "AppFrameClient.DepartmentCostReport.rdlc";
            this.rptDepartmentCost.Location = new System.Drawing.Point(5, 84);
            this.rptDepartmentCost.Name = "rptDepartmentCost";
            this.rptDepartmentCost.Size = new System.Drawing.Size(810, 570);
            this.rptDepartmentCost.TabIndex = 40;
            // 
            // dtoFrom
            // 
            this.dtoFrom.CustomFormat = "dd/MM/yyyy";
            this.dtoFrom.Font = new System.Drawing.Font("Tahoma", 11.29412F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtoFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtoFrom.Location = new System.Drawing.Point(329, 10);
            this.dtoFrom.Name = "dtoFrom";
            this.dtoFrom.Size = new System.Drawing.Size(134, 27);
            this.dtoFrom.TabIndex = 41;
            // 
            // dtoTo
            // 
            this.dtoTo.CustomFormat = "dd/MM/yyyy";
            this.dtoTo.Font = new System.Drawing.Font("Tahoma", 11.29412F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtoTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtoTo.Location = new System.Drawing.Point(329, 43);
            this.dtoTo.Name = "dtoTo";
            this.dtoTo.Size = new System.Drawing.Size(134, 27);
            this.dtoTo.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 11.29412F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(285, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 21);
            this.label3.TabIndex = 43;
            this.label3.Text = "đến";
            // 
            // btnRunReport
            // 
            this.btnRunReport.Location = new System.Drawing.Point(469, 9);
            this.btnRunReport.Name = "btnRunReport";
            this.btnRunReport.Size = new System.Drawing.Size(140, 61);
            this.btnRunReport.TabIndex = 44;
            this.btnRunReport.Text = "Chạy báo cáo";
            this.btnRunReport.UseVisualStyleBackColor = true;
            this.btnRunReport.Click += new System.EventHandler(this.btnRunReport_Click);
            // 
            // departmentTableAdapter
            // 
            this.departmentTableAdapter.ClearBeforeFill = true;
            // 
            // DepartmentCostSummaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 666);
            this.Controls.Add(this.btnRunReport);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtoTo);
            this.Controls.Add(this.dtoFrom);
            this.Controls.Add(this.rptDepartmentCost);
            this.Controls.Add(this.btnCommit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboDepartment);
            this.Name = "DepartmentCostSummaryForm";
            this.Text = "DepartmentCostSummaryForm";
            this.Load += new System.EventHandler(this.DepartmentCostSummaryForm_Load);
            this.Controls.SetChildIndex(this.cboDepartment, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.btnCommit, 0);
            this.Controls.SetChildIndex(this.rptDepartmentCost, 0);
            this.Controls.SetChildIndex(this.dtoFrom, 0);
            this.Controls.SetChildIndex(this.dtoTo, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.btnRunReport, 0);
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.masterDB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.Button btnCommit;
        private Microsoft.Reporting.WinForms.ReportViewer rptDepartmentCost;
        private System.Windows.Forms.DateTimePicker dtoFrom;
        private System.Windows.Forms.DateTimePicker dtoTo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRunReport;
        private MasterDB masterDB;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private AppFrameClient.MasterDBTableAdapters.DepartmentTableAdapter departmentTableAdapter;
    }
}