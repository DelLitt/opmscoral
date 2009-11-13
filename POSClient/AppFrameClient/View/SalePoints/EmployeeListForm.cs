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
                    
                    int index = 0;
                    int collectCount = selectedCollection.Count;
                    foreach (DataGridViewRow row in selectedCollection)
                    {
                        if(index == 0)
                        {
                            if(collectCount > 6 )
                            {
                                printArray = new EmployeeInfo[6];            
                            }
                            else
                            {
                                printArray = new EmployeeInfo[collectCount];
                            }
                        }

                        EmployeeInfo info = empInfoList[row.Index];
                        printArray[index] = info;
                        index += 1;
                        collectCount -= 1;
                        if(index > 5 || collectCount <= 0)
                        {
                            barCodeDocument.Print();
                            index = 0;
                        }
                        
                    }
                    

                }
                catch (Exception exception)
                {
                    printArray = null;
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
            var rowsToPrint = numberToPrint / 3;
            if( numberToPrint % 3 > 0)
            {
                rowsToPrint += 1;
            }
            for (int j = 0; j < 3; j++)
            {
                
                for (int i = 0; i < 2; i++)
                {
                    int index = (j*2) + i;
                    if(index > (printArray.Count() - 1))
                    {
                        break;
                    }
                    string code = printArray[index].EmployeePK.EmployeeId;
                    
                    BarcodeLib.Barcode barcode = new Barcode();
                    string employeeName = printArray[index].EmployeeName;
                    Image imageBC = barcode.Encode(BarcodeLib.TYPE.CODE128, code, Color.Black, Color.White,
                                                   (int) (2.35*e.Graphics.DpiX), (int) (0.4*e.Graphics.DpiY));

                    Bitmap bitmapBarcode = new Bitmap(imageBC);
                    bitmapBarcode.SetResolution(204, 204);

                    e.Graphics.SmoothingMode = SmoothingMode.HighQuality;
                    e.Graphics.CompositingQuality = CompositingQuality.HighQuality;

                    // draw title string

                    // calculate scale for title
                    var titleStrSize = e.Graphics.MeasureString(employeeName + "0000", new Font("Arial", 10));
                    float currTitleSize = new Font("Arial", 10).Size;
                    float scaledTitleSize = (220*currTitleSize)/titleStrSize.Width;
                    Font _empFont = null;
                    
                    if (employeeName.Length < 17)
                    {
                        _empFont = new Font("Arial", 8);
                    }
                    else
                    {
                        _empFont = new Font("Arial", scaledTitleSize);
                    }

                    Font _titleFont = new Font("Arial", 7);
                    
                    var barCodeSize = e.Graphics.MeasureString(code, _titleFont);
                    var empCodeSize = e.Graphics.MeasureString(employeeName, _empFont);
                    Bitmap logoAChay = new Bitmap(AppFrameClient.Properties.Resources.AChayLogo);

                    
                    Rectangle boundRec = new Rectangle((i%2)*(int) (3.6*100)+ 50 , (j%3)*(int)(2.3*100)+ 50 , (int) (3.45*100), (int) (2.15*100));
                    e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black)), boundRec);

                    
                    e.Graphics.DrawImage(bitmapBarcode,
                                         new Rectangle((i % 2) * 360 + (int)XCentered((float)(2.35 * 100), 360) + 50,
                                                       (int)((j%3)*230 + 25) + 190 , (int)(2.35 * 100),(int)(0.4 * 100)));
                    System.Drawing.Rectangle rc = new System.Drawing.Rectangle((i % 3) * 135, 50, (int)(1.4 * 100), (int)(0.4 * 100));
                    
                    e.Graphics.DrawImage(logoAChay, (i % 2) * 360 + 70 + 160, ((j % 3) * 230) + 52);
                    e.Graphics.DrawRectangle(new Pen(new SolidBrush(Color.Black)), (i % 2) * (int)(3.6 * 100) + 52, (j % 3) * (int)(2.3 * 100) + 52,
                                                (int)(1.18 * 100), (int)(1.57 * 100));
                    e.Graphics.DrawString(employeeName, _empFont, new SolidBrush(Color.Black),
                        (i % 2) * 360 + +70 + XCentered(empCodeSize.Width, 345) + 50,
                        (float)((j % 3) * 230 + 60 + _titleFont.Height + 70));

                    e.Graphics.DrawString("QUẢN LÝ", _empFont, new SolidBrush(Color.Black),
                        (i % 2) * 360 + +70 + XCentered(empCodeSize.Width, 138) + 207,
                        (float)((j % 3) * 230 + 60 + _titleFont.Height + 90));



                }
            }
        }
        private float XCentered(float localWidth, float globalWidth)
        {
            return ((globalWidth - localWidth) / 2);
        }
    }
}
