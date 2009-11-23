using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;

namespace AppFrameClient.View
{
    public partial class DeptStockEvaluationComparingForm : Form
    {
        public DeptStockEvaluationComparingForm()
        {
            InitializeComponent();
        }

        private void DeptStockEvaluationComparingForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'masterDB2.product_type' table. You can move, or remove it, as needed.
            this.product_typeTableAdapter.Fill(this.masterDB2.product_type);
            // TODO: This line of code loads data into the 'masterDB.Department' table. You can move, or remove it, as needed.
            this.departmentTableAdapter.Fill(this.masterDB.Department);

            Department mainStock = new Department
            {
                DepartmentId = 0,
                DepartmentName = "KHO CHINH"
            };
            departmentBindingSource.Add(mainStock);
            foreach (MasterDB.DepartmentRow row in masterDB.Department)
            {
                Department department = new Department
                {
                    DepartmentId = row.DEPARTMENT_ID,
                    DepartmentName = row.DEPARTMENT_NAME
                };
                departmentBindingSource.Add(department);
            }
            departmentBindingSource.ResetBindings(false);

            ProductType allTypes = new ProductType
            {
                TypeId = 0,
                TypeName = "-- TẤT CẢ MẶT HÀNG --"
            };
            cboTypeBds.Add(allTypes);
            foreach (MasterDB.product_typeRow row in masterDB2.product_type)
            {
                ProductType productType = new ProductType
                {
                    TypeId = row.TYPE_ID,
                    TypeName = row.TYPE_NAME
                };
                cboTypeBds.Add(productType);
            }
            cboTypeBds.ResetBindings(false);


            this.masterDB1.EnforceConstraints = false;
        }

        private void cboDepartments_SelectedIndexChanged(object sender, EventArgs e)
        {
            int deptId = Int32.Parse(cboDepartments.SelectedValue.ToString());
            if(deptId > 0)
            {
                dgvDeptStock.Visible = true;
                dgvStock.Visible = false;
                this.stockqtyTableAdapter.Fill(masterDB1.stockqty, deptId);
                stockqtyBindingSource.ResetBindings(false);
                dgvDeptStock.Refresh();
                dgvDeptStock.Invalidate();
            }
        }

        private void cboTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterDataset();
        }

        private void FilterDataset()
        {
            int typeId = Int32.Parse(cboTypes.SelectedValue.ToString());
            if (typeId != 0)
            {
                stockqtyBindingSource.Filter = "type_id = " + typeId;
            }
            if (chkDifferent.Checked)
            {
                string strAnd = "";
                if (!string.IsNullOrEmpty(stockqtyBindingSource.Filter))
                {
                    strAnd= " AND ";
                }
                stockqtyBindingSource.Filter += strAnd + " quantity <> realquantity ";    
            }

            stockqtyBindingSource.ResetBindings(false);
            dgvDeptStock.Refresh();
            dgvDeptStock.Invalidate();
        }

        private ErrorForm _errorForm = null;
        private void btnImportResult_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.CheckFileExists = true;
            fileDialog.CheckPathExists = true;
            fileDialog.Filter = "Text Files|*.txt";
            DialogResult result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {

                Dictionary<string, int> list = new Dictionary<string, int>();
                string path = fileDialog.FileName;
                StreamReader fileReader = new StreamReader(File.OpenRead(path));

                while (!fileReader.EndOfStream)
                {
                    string line = fileReader.ReadLine();
                    string[] parseLines = line.Split(',');

                    try
                    {
                        if (parseLines.Length == 2)
                        {
                            if (list.ContainsKey(parseLines[0].Trim()))
                            {
                                list[parseLines[0].Trim()] += Int32.Parse(parseLines[1].Trim());
                            }
                            else
                            {
                                list.Add(parseLines[0].Trim(), Int32.Parse(parseLines[1].Trim()));
                            }

                        }
                        else
                        {
                            if (list.ContainsKey(parseLines[0].Trim()))
                            {
                                list[parseLines[0].Trim()] += 1;
                            }
                            else
                            {
                                list.Add(parseLines[0].Trim(), 1);
                            }

                        }
                    }
                    catch (Exception)
                    {
                        if (_errorForm == null)
                        {
                            _errorForm = new ErrorForm();
                            _errorForm.Caption = "Lỗi";
                            _errorForm.ErrorString = "Các mã vạch bị lỗi khi nhập mã vạch từ file text";
                        }
                        _errorForm.ErrorDetails.Add(line);
                        continue;
                    }
                }
                foreach (KeyValuePair<string, int> barCodeLine in list)
                {
                    foreach (MasterDB.stockqtyRow stockqtyRow in masterDB1.stockqty)
                    {
                        if(barCodeLine.Key.Equals(stockqtyRow["PRODUCT_ID"].ToString()))
                        {
                            stockqtyRow.realquantity = barCodeLine.Value;
                            break;
                        }
                    }
                }
                stockqtyBindingSource.ResetBindings(false);
                dgvDeptStock.Refresh();
                dgvDeptStock.Invalidate();
            }
        }

        private void chkDifferent_CheckedChanged(object sender, EventArgs e)
        {
            FilterDataset();
        }
    }
}
