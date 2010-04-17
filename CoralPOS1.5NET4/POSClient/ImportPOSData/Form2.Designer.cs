namespace ImportPOSData
{
    partial class Form2
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
            this.lblFile = new System.Windows.Forms.Label();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnInput = new System.Windows.Forms.Button();
            this.dgvError = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.errorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rowNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.errorMessageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(12, 38);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(24, 14);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "File";
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(52, 35);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(498, 22);
            this.txtFilePath.TabIndex = 1;
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(556, 34);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(45, 23);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "...";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnInput
            // 
            this.btnInput.Location = new System.Drawing.Point(250, 63);
            this.btnInput.Name = "btnInput";
            this.btnInput.Size = new System.Drawing.Size(75, 23);
            this.btnInput.TabIndex = 3;
            this.btnInput.Text = "Nhập";
            this.btnInput.UseVisualStyleBackColor = true;
            this.btnInput.Click += new System.EventHandler(this.btnInput_Click);
            // 
            // dgvError
            // 
            this.dgvError.AutoGenerateColumns = false;
            this.dgvError.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvError.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rowNumberDataGridViewTextBoxColumn,
            this.errorMessageDataGridViewTextBoxColumn});
            this.dgvError.DataSource = this.errorBindingSource;
            this.dgvError.Location = new System.Drawing.Point(12, 117);
            this.dgvError.Name = "dgvError";
            this.dgvError.Size = new System.Drawing.Size(647, 393);
            this.dgvError.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 100);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kết quả";
            // 
            // errorBindingSource
            // 
            this.errorBindingSource.DataSource = typeof(ErrorObject);
            // 
            // rowNumberDataGridViewTextBoxColumn
            // 
            this.rowNumberDataGridViewTextBoxColumn.DataPropertyName = "RowNumber";
            this.rowNumberDataGridViewTextBoxColumn.HeaderText = "Dòng số";
            this.rowNumberDataGridViewTextBoxColumn.Name = "rowNumberDataGridViewTextBoxColumn";
            // 
            // errorMessageDataGridViewTextBoxColumn
            // 
            this.errorMessageDataGridViewTextBoxColumn.DataPropertyName = "ErrorMessage";
            this.errorMessageDataGridViewTextBoxColumn.HeaderText = "Lỗi";
            this.errorMessageDataGridViewTextBoxColumn.Name = "errorMessageDataGridViewTextBoxColumn";
            this.errorMessageDataGridViewTextBoxColumn.Width = 500;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 522);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvError);
            this.Controls.Add(this.btnInput);
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.lblFile);
            this.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnInput;
        private System.Windows.Forms.DataGridView dgvError;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource errorBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn rowNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorMessageDataGridViewTextBoxColumn;
    }
}

