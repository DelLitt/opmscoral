using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrameClient.Presenter.GoodsIO.DepartmentStockData;

namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    public partial class DepartmentStockInExtraForm : BaseForm, IDepartmentStockInExtraView
    {
        private DepartmentStockInDetailCollection deptSIDetailList;
        private DepartmentStockIn deptSI;
        public DepartmentStockInExtraForm()
        {
            InitializeComponent();
        }

        private void ctxMenuDept_Opening(object sender, CancelEventArgs e)
        {

        }

        private void nhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DepartmentStockInDetail detail = deptSIDetailList[dgvDeptStockIn.CurrentCell.OwningRow.Index];
            // deep copy in separeate memory space
            DepartmentStockInDetail newDetail = CreateNewStockInDetail();
            ProductMaster newPM = (ProductMaster)detail.Product.ProductMaster.Clone();
            newDetail.Product.ProductMaster = newPM;
            bdsDeptStockIn.EndEdit();
        }

        private DepartmentStockInDetail CreateNewStockInDetail()
        {
            DepartmentStockInDetail deptSIDet = deptSIDetailList.AddNew();
            deptSIDet.Product = new Product();
            deptSIDet.Product.ProductMaster = new ProductMaster();
            deptSIDet.Product.ProductMaster.ProductName = "";
            deptSIDet.Product.ProductMaster.ProductColor = new ProductColor { ColorName = "" };
            deptSIDet.Product.ProductMaster.ProductSize = new ProductSize { SizeName = "" };
            
            deptSIDetailList.EndNew(deptSIDetailList.Count - 1);
            return deptSIDet;
        }
        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            // create DepartmentStockIn
            if(deptSI==null)
            {
                deptSI = new DepartmentStockIn();
            }
            deptSI.CreateDate = DateTime.Now;
            deptSI.UpdateDate = DateTime.Now;
            deptSI.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            deptSI.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            deptSI.ExclusiveKey = 0;
            int maxAddedItemsCount = int.Parse(numericUpDown.Text);
            for (int i = 0; i < maxAddedItemsCount; i++)
            {
                DepartmentStockInDetail deptSIDet = CreateNewStockInDetail();
                
            }

            deptSI.DepartmentStockInDetails =
                    ObjectConverter.ConvertToNonGenericList<DepartmentStockInDetail>(deptSIDetailList);
            bdsDeptStockIn.EndEdit();
        }

        #region Load products to combo box for select
        private void dgvDeptStockIn_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            string columnName = dgvDeptStockIn.CurrentCell.OwningColumn.Name;
            if (columnName.Equals("columnProductId")
                || columnName.Equals("columnProductName"))
            {


                ComboBox comboBox = ((ComboBox)e.Control);

                // firstly, remove event regard to cell 
                comboBox.DropDown -= new EventHandler(comboBox_DropDown);
                comboBox.KeyUp -= new KeyEventHandler(Control_KeyUp);

                comboBox.DroppedDown = false;

                comboBox.DataSource = null;
                comboBox.Text = (string)dgvDeptStockIn.CurrentCell.Value;
                comboBox.DropDown += new EventHandler(comboBox_DropDown);
                comboBox.KeyUp += new KeyEventHandler(Control_KeyUp);
            }

            DepartmentStockInEventArgs mainStockInEventArgs = new DepartmentStockInEventArgs();
            int selectedIndex = dgvDeptStockIn.CurrentRow.Index;
            mainStockInEventArgs.SelectedIndex = selectedIndex;
            mainStockInEventArgs.SelectedDepartmentStockInDetail = deptSIDetailList[selectedIndex];

            if(columnName.Equals("columnColor") )
            {
                // put colors to list
                EventUtility.fireEvent(LoadProductColorEvent, this, mainStockInEventArgs);
                if (mainStockInEventArgs.ProductColorList != null)
                {
                    ComboBox comboBox = ((ComboBox)e.Control);
                    comboBox.DataSource = mainStockInEventArgs.ProductColorList;
                    comboBox.DisplayMember = "ColorName";
                    comboBox.ValueMember = "ColorName";
                }
                mainStockInEventArgs.ProductColorList = null;
            }
            

            if( columnName.Equals("columnSize"))
            {
                // put size to list
                EventUtility.fireEvent(LoadProductSizeEvent, this, mainStockInEventArgs);
                if (mainStockInEventArgs.ProductSizeList != null)
                {
                    ComboBox comboBox = ((ComboBox)e.Control);
                    comboBox.DataSource = mainStockInEventArgs.ProductSizeList;
                    comboBox.DisplayMember = "SizeName";
                    comboBox.ValueMember = "SizeName";
                }
                mainStockInEventArgs.ProductSizeList = null;
            }

        }

        void Control_KeyUp(object sender, KeyEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            int currentColumnIndex = dgvDeptStockIn.CurrentCell.OwningColumn.Index;
            if (currentColumnIndex == 1 || currentColumnIndex == 2)
            {
                if (e.KeyCode == Keys.F3 || comboBox.DroppedDown)
                {
                    ((ComboBox) sender).DataSource = null;
                    comboBox_DropDown(sender, null);
                }
            }
        }

        void comboBox_DropDown(object sender, EventArgs e)
        {

            if (!(sender is ComboBox))
            {
                return;
            }
            // set empty current datasource

            //MessageBox.Show(dgvBill.CurrentCell.ColumnIndex.ToString());
            int currentColumnIndex = dgvDeptStockIn.CurrentCell.OwningColumn.Index;
            int currentRowIndex = dgvDeptStockIn.CurrentCell.OwningRow.Index;
            if (currentColumnIndex == 1) // ProductId
            {
                deptSIDetailList[currentRowIndex].Product.ProductMaster.ProductMasterId =
                    ((ComboBox)sender).Text;
            }
            if (currentColumnIndex == 2)   // ProductName
            {
                deptSIDetailList[currentRowIndex].Product.ProductMaster.ProductName =
                    ((ComboBox)sender).Text;
            }


            if (((ComboBox)sender).DataSource == null)
            {
                FillProductToComboBox(sender, dgvDeptStockIn.CurrentCell.OwningColumn.Name);
            }
        }

        private void FillProductToComboBox(object sender, string name)
        {
            DepartmentStockInEventArgs mainStockInEventArgs = new DepartmentStockInEventArgs();
            int selectedIndex = dgvDeptStockIn.CurrentRow.Index;
            mainStockInEventArgs.SelectedIndex = selectedIndex;
            mainStockInEventArgs.SelectedDepartmentStockInDetail = deptSIDetailList[selectedIndex];
            mainStockInEventArgs.IsFillToComboBox = true;
            if (name.Equals("columnProductName"))
            {
                mainStockInEventArgs.ComboBoxDisplayMember = "ProductName";
            }
            if (name.Equals("columnProductId"))
            {
                mainStockInEventArgs.ComboBoxDisplayMember = "ProductMasterId";
            }
            EventUtility.fireEvent<DepartmentStockInEventArgs>(FillProductToComboEvent, sender, mainStockInEventArgs);
        }

        #endregion

        private void dgvDeptStockIn_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DepartmentStockInEventArgs mainStockInEventArgs = new DepartmentStockInEventArgs();
                int selectedIndex = dgvDeptStockIn.CurrentRow.Index;
                mainStockInEventArgs.SelectedIndex = selectedIndex;
                mainStockInEventArgs.SelectedDepartmentStockInDetail = deptSIDetailList[selectedIndex];

                if (e.ColumnIndex == 1 || e.ColumnIndex == 2)
                {
                    mainStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster.ProductMasterId =
                        dgvDeptStockIn.CurrentCell.Value as string;
                    if (e.ColumnIndex == 1)
                    {
                        EventUtility.fireEvent(LoadGoodsByIdEvent, this, mainStockInEventArgs);
                    }
                    else
                    {
                        EventUtility.fireEvent(LoadGoodsByNameEvent, this, mainStockInEventArgs);
                    }

                    // load goods to current row
                    ProductMaster loadGoods =
                        mainStockInEventArgs.SelectedDepartmentStockInDetail.Product.ProductMaster;
                    deptSIDetailList[selectedIndex] = mainStockInEventArgs.SelectedDepartmentStockInDetail;
                    bdsDeptStockIn.EndEdit();

                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Mã sản phẩm không hợp lệ hoặc lỗi khi nhập");
            }
        }

        private void DepartmentStockInExtra_Load(object sender, EventArgs e)
        {
            deptSIDetailList = new DepartmentStockInDetailCollection(bdsDeptStockIn);
            bdsDeptStockIn.DataSource = deptSIDetailList;
            dgvDeptStockIn.DataError += new DataGridViewDataErrorEventHandler(dgvDeptStockIn_DataError);
            

            // create DepartmentStockIn
            if (deptSI == null)
            {
                deptSI = new DepartmentStockIn();
            }
            Department currentDepartment = CurrentDepartment.Get();
            deptSI.CreateDate = DateTime.Now;
            deptSI.UpdateDate = DateTime.Now;
            deptSI.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            deptSI.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            deptSI.ExclusiveKey = 0;
            CreateNewStockInDetail();
            deptSI.DepartmentStockInDetails =
                    ObjectConverter.ConvertToNonGenericList<DepartmentStockInDetail>(deptSIDetailList);
        }

        void dgvDeptStockIn_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            
        }

        #region IDepartmentStockInView Members

        private DepartmentStockInExtraController departmentStockInController;
        public AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.IDepartmentStockInController DepartmentStockInController
        {
            get
            {
                return departmentStockInController;
            }   
            set
            {
                departmentStockInController = (DepartmentStockInExtraController)value;
                departmentStockInController.DepartmentStockInView = this;
                departmentStockInController.DepartmentStockInExtraView = this;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        
        private IProductMasterSearchOrCreateController productMasterSearchOrCreateController;
        public AppFrame.Presenter.GoodsIO.IProductMasterSearchOrCreateController ProductMasterSearchOrCreateController
        {
            set
            {
                productMasterSearchOrCreateController=value;    
            }
        }

        public event EventHandler<DepartmentStockInEventArgs> InitDepartmentStockInEvent;

        public event EventHandler<AppFrame.Presenter.GoodsIO.ProductMasterSearchOrCreateEventArgs> OpenProductMasterSearchEvent;

        public event EventHandler<DepartmentStockInEventArgs> SaveDepartmentStockInEvent;

        public event EventHandler<DepartmentStockInEventArgs> FindProductMasterEvent;
        public event EventHandler<DepartmentStockInEventArgs> SyncDepartmentStockInEvent;
        public event EventHandler<DepartmentStockInEventArgs> FillProductToComboEvent;

        #endregion

        

        #region IDepartmentStockInView Members

        public event EventHandler<DepartmentStockInEventArgs> LoadGoodsByIdEvent;

        public event EventHandler<DepartmentStockInEventArgs> LoadGoodsByNameEvent;

        public event EventHandler<DepartmentStockInEventArgs> LoadProductColorEvent;

        public event EventHandler<DepartmentStockInEventArgs> LoadProductSizeEvent;
        public event EventHandler<DepartmentStockInEventArgs> FillDepartmentEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadGoodsByNameColorEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadGoodsByNameColorSizeEvent;

        #endregion

        private void mnuCreateNewItem_Click(object sender, EventArgs e)
        {
            btnAddProduct_Click(sender, null);
        }
    }
}
