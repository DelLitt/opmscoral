using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.SalePoints;
using AppFrame.Utility;
using AppFrame.View.SalePoints;
using BarcodeLib;

namespace AppFrameClient.View.SalePoints
{
    public partial class EmployeeListForm : BaseForm,IEmployeeListView
    {
        private EmployeeInfoCollection empInfoList = null;
        private IEmployeeController employeeController;
        public IEmployeeController EmployeeController
        {
            get
            {
                return employeeController;
            }
            set
            {
                employeeController = value;
                employeeController.EmployeeListView = this;
            }
        }
        

        public EmployeeListForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region IEmployeeListView Members


        public event EventHandler<EmployeeEventArgs> LoadEmployeesEvent;

        public event EventHandler<EmployeeEventArgs> EditEmployeeEvent;

        public event EventHandler<EmployeeEventArgs> DeleteEmployeeEvent;

        #endregion

        private void EmployeeListForm_Load(object sender, EventArgs e)
        {
            empInfoList = new EmployeeInfoCollection(bdsEmployee);
            RefreshEmployeeList();

        }

        private void RefreshEmployeeList()
        {

            empInfoList.Clear();
            EmployeeEventArgs eventArgs = new EmployeeEventArgs();
            EventUtility.fireEvent(LoadEmployeesEvent, this, eventArgs);

            if (eventArgs.EmployeeList != null && eventArgs.EmployeeList.Count > 0)
            {
                foreach (EmployeeInfo employeeInfo in eventArgs.EmployeeList)
                {
                    empInfoList.Add(employeeInfo);
                }
                bdsEmployee.EndEdit();
                dgvEmployee.Refresh();
                dgvEmployee.Invalidate();
            }
        }

        private void dgvEmployee_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvEmployee.CurrentCell == null)
            {
                return;
            }
            int selectedIndex = dgvEmployee.CurrentCell.RowIndex;

            EmployeeEventArgs eventArgs = new EmployeeEventArgs();
            eventArgs.EmployeeInfo = empInfoList[selectedIndex];
            eventArgs.SelectedEmployee = selectedIndex;
            EventUtility.fireEvent(EditEmployeeEvent, this, eventArgs);
            RefreshEmployeeList();
        }

        private void dgvEmployee_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection selectedCollection = dgvEmployee.SelectedRows;
            if(selectedCollection == null || selectedCollection.Count == 0)
            {
                MessageBox.Show("Không có nhân viên nào được chọn");
            }
            if (barCodePrintDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    int count = selectedCollection.Count;
                    for (int i = 0; i < count; i += 3)
                    {
                        if (count - i > 3)
                        {
                            printArray = new EmployeeInfo[3];
                        }
                        else
                        {
                            printArray = new EmployeeInfo[count-i];
                        }
                        printArray[0] = empInfoList[selectedCollection[i].Index];
                        if (i + 1 < count)
                        {
                            printArray[1] = empInfoList[selectedCollection[i + 1].Index];
                        }
                        if (i + 2 < count)
                        {
                            printArray[2] = empInfoList[selectedCollection[i + 2].Index];
                        }
                        barCodeDocument.Print();
                    }

                }
                catch (Exception)
                {
                }
                finally
                {
                    printArray = null;
                }

            }
        }

        private EmployeeInfo[] printArray = null;
        private void barCodeDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            if(printArray == null)
            {
                return;
            }
            var height = 87;
            var numberToPrint = printArray.Count();
            for (int i = 0; i < numberToPrint; i++)
            {


            string code = printArray[i].EmployeePK.EmployeeId;
            BarcodeLib.Barcode barcode = new Barcode();
            string employeeName = printArray[i].EmployeeName;
            Image imageBC = barcode.Encode(BarcodeLib.TYPE.CODE39, code, Color.Black, Color.White, (int)(1.35 * e.Graphics.DpiX), (int)(0.45 * e.Graphics.DpiY));
            


            Bitmap bitmap1 = new Bitmap(imageBC);
            bitmap1.SetResolution(204, 204);
            
            e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
            e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

            // draw title string

            // calculate scale for title
            var titleStrSize = e.Graphics.MeasureString(employeeName+ "0000", new Font("Arial", 10));
            float currTitleSize = new Font("Arial", 10).Size;
            float scaledTitleSize = (150 * currTitleSize) / titleStrSize.Width;
            Font _empFont = null;
            if (employeeName.Length < 17)
            {
                _empFont = new Font("Arial", 7);
            }
            else
            {
                _empFont = new Font("Arial", scaledTitleSize);                
            }
            Font _titleFont = new Font("Arial", 7);

            var barCodeSize = e.Graphics.MeasureString(code, _titleFont);
            var empCodeSize = e.Graphics.MeasureString(employeeName, _empFont);
            /*Bitmap bitmapName = new Bitmap(nameString, true);
            Bitmap bitmapPrice = new Bitmap(priceString, true);*/
            

                System.Drawing.Rectangle rc = new System.Drawing.Rectangle((i % 3) * 135, 50, (int)(1.4 * 100), (int)(0.4 * 100));

                //(i % 3) * 124, (i / 3) * 87, 117, 79 
                /*e.Graphics.DrawString(nameString, _titleFont, new SolidBrush(Color.Black), (i % 3) * 135 + XCentered(nameSize.Width, 140), 25);
                e.Graphics.DrawString(priceString, _titleFont, new SolidBrush(Color.Black), (i % 3) * 135 + XCentered(priceSize.Width, 140), (float)22.5 + nameSize.Height);*/
                e.Graphics.DrawString(code, _titleFont, new SolidBrush(Color.Black), (i % 3) * 140 + XCentered(barCodeSize.Width, 140), (float)25);
                e.Graphics.DrawImage(bitmap1, new Rectangle((i % 3) * 140 + (int)XCentered((float)(1.35 * 100), 140), (int)(25 + barCodeSize.Height), (int)(1.35 * 100), (int)(0.45 * 100)));
                e.Graphics.DrawString(employeeName, _empFont, new SolidBrush(Color.Black), (i % 3) * 140 + XCentered(empCodeSize.Width, 140), (float)88);
                
                //e.Graphics.DrawImage(barcodeControl1.GetMetaFile(), new Rectangle((i % 3) * 135, 120, (i % 3) * 135 + (int)(1.4 * 100), (int)(0.75 * 100)));                    

            }
        }
        private float XCentered(float localWidth, float globalWidth)
        {
            return ((globalWidth - localWidth) / 2);
        }
    }
}
