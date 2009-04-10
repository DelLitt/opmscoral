using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter;
using AppFrame.Utility;
using AppFrame.View.Reports;
using AppFrameClient;
using AppFrameClient.Common;
using AppFrameClient.View;
using AppFrameClient.View.GoodsIO.DepartmentStockData;
using AppFrameClient.View.GoodsIO.MainStock;
using AppFrameClient.View.GoodsSale;
using AppFrameClient.View.Reports;
using AppFrameClient.View.SalePoints;
using POSReports;
using Spring.Context;
using Spring.Context.Support;
using AppFrameClient.View.GoodsIO;

namespace AppFrame.View
{
    public partial class MainForm : Form
    {
        private IAuthService authService;
        private delegate void showProcess();

        public MainForm()
        {
            InitializeComponent();
        }

        public IAuthService AuthService
        {
            get { return authService; }
            set { authService = value; }
        }

        private void mnuFileExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuFileLogin_Click(object sender, EventArgs e)
        {
            this.AuthService.login();
        }

        private void mnuFileLogout_Click(object sender, EventArgs e)
        {
            this.AuthService.logout();

        }

        private void mnuCustomerNew_Click(object sender, EventArgs e)
        {
            //Form newCustomer = GlobalUtility.GetOnlyChildFormObject<NewCustomerForm>(this,FormConstants.NEW_CUSTOMER_FORM);
            //newCustomer.Show();
            

        }
        
        public void showProgressBar()
        {
            toolStripStatusLabel.Text = " Processing ";
            timerProgress.Start();    
        }
        public void stopProgressBar()
        {
            toolStripStatusLabel.Text = " Ready ";  
            timerProgress.Stop();
            toolStripProgressBar.Value = 0;
        }   
        

        private void timerProgress_Tick(object sender, EventArgs e)
        {
            int interval = toolStripProgressBar.Value; 
            interval +=  10;
            if(interval >100)
            {
                interval = 0;
            }
            toolStripProgressBar.Value = interval;
        }

        private void mnuCustomerEdit_Click(object sender, EventArgs e)
        {
            Form editCustomer = GlobalUtility.GetOnlyChildFormObject<EditCustomerForm>(this, FormConstants.EDIT_CUSTOMER_FORM);
            editCustomer.Show();
        }

        private void mnuImportGoods_Click(object sender, EventArgs e)
        {
            //Form importGoods = GlobalUtility.GetOnlyChildFormObject<GoodsInput>(this, FormConstants.IMPORT_GOODS_FORM);
            //importGoods.Show();
            //Form departmentStockIn = GlobalUtility.GetOnlyChildFormObject<MainStockInForm>(this, FormConstants.MAIN_STOCK_IN_FORM);
            Form departmentStockIn = GlobalUtility.GetOnlyChildFormObject<MainStockInExtraForm>(this, FormConstants.MAIN_STOCK_IN_EXTRA_FORM);
            departmentStockIn.Show();
        }

        private void defineSalepointToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SalePointForm salePointForm = GlobalUtility.GetOnlyChildFormObject<SalePointForm>(this, FormConstants.SALEPOINT_FORM);
            salePointForm.Status = ViewStatus.ADD;
            salePointForm.Show();
        }

        private void productMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form productMasterCreateForm = GlobalUtility.GetOnlyChildFormObject<ProductMasterCreateForm>(this, FormConstants.PRODUCT_MASTER_CREATE_FORM);
            productMasterCreateForm.Show();
        }

        private void mnuHelpAbout_Click(object sender, EventArgs e)
        {
            new MainAbout().ShowDialog();
        }

        private void testProductMasterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form productMasterForm = GlobalUtility.GetOnlyChildFormObject<ProductMasterSearchForm>(this, FormConstants.PRODUCT_MASTER_SEARCH_FORM);
            productMasterForm.Show();
        }

        private void searchBlockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Form searchBlockForm = GlobalUtility.GetOnlyChildFormObject<GoodsIOSearchForm>(this, FormConstants.SEARCH_BLOCK_FORM);
            //searchBlockForm.Show();
            Form departmentStockIn = GlobalUtility.GetOnlyChildFormObject<MainStockInSearchForm>(this, FormConstants.MAIN_STOCK_IN_SEARCH_FORM);
            departmentStockIn.Show();
        }

        private void mnuGoodsSale_Click(object sender, EventArgs e)
        {
            Form goodsSale = GlobalUtility.GetOnlyChildFormObject<GoodsSaleForm>(this, FormConstants.GOODS_SALE_FORM);
            Department department = null;
            // if it does not have active department or department is HQ
            if (!CurrentDepartment.CurrentActiveDepartment(out department))
            {
                MessageBox.Show("Cửa hàng chính chưa được thiết lập! Xin vui lòng thiết lập cửa hàng chính trước.", "Lỗi",
                                MessageBoxButtons.OK);
                goodsSale.Close();
            }
            else
            {
                goodsSale.Show();    
            }
            
        }
        
        private void mnuGoodsSaleList_Click(object sender, EventArgs e)
        {
            Form goodsSaleList = GlobalUtility.GetOnlyChildFormObject<GoodsSaleListForm>(this, FormConstants.GOODS_SALE_LIST_FORM);
            Department department = null;
            
            // if it does not have active department or department is HQ
            if (!CurrentDepartment.CurrentActiveDepartment(out department))
            {
                MessageBox.Show("Cửa hàng chính chưa được thiết lập! Xin vui lòng thiết lập cửa hàng chính trước.", "Lỗi",
                                MessageBoxButtons.OK);
                goodsSaleList.Close();
            }
            else
            {
                goodsSaleList.Show();
            }
            
        }

        private void approveStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form stockCreate = GlobalUtility.GetOnlyChildFormObject<StockCreateForm>(this, FormConstants.STOCK_CREATE_FORM);
            stockCreate.Show();
        }

        private void searchStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form stockSearch = GlobalUtility.GetOnlyChildFormObject<StockSearchForm>(this, FormConstants.STOCK_SEARCH_FORM);
            stockSearch.Show();
        }

        
        private void mnuListSalePoints_Click(object sender, EventArgs e)
        {
            Form listSalePoints = GlobalUtility.GetOnlyChildFormObject<SalePointListForm>(this,FormConstants.SALEPOINT_LIST_FORM);
            listSalePoints.Show();
        }

        private void departmentStockInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form departmentStockIn = GlobalUtility.GetOnlyChildFormObject<DepartmentStockInForm>(this, FormConstants.DEPARTMENT_STOCK_IN_FORM);
            departmentStockIn.Show();
        }

        private void searchDepartmentStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form departmentStockIn = GlobalUtility.GetOnlyChildFormObject<DepartmentStockSearchForm>(this, FormConstants.SEARCH_DEPARTMENT_STOCK_IN_FORM);
            departmentStockIn.Show();
        }

        private void updatePriceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form departmentStockIn = GlobalUtility.GetOnlyChildFormObject<DepartmentPriceUpdateForm>(this, FormConstants.DEPARTMENT_PRICE_UPDATE_FORM);
            departmentStockIn.Show();
        }

        private void searchDepartmentStockInMenuItem_Click(object sender, EventArgs e)
        {
            Form departmentStockIn = GlobalUtility.GetOnlyChildFormObject<DepartmentStockInSearchForm>(this, FormConstants.DEPARTMENT_STOCK_IN_SEARCH_FORM);
            departmentStockIn.Show();
        }

        private void mnuDayGoodsSaleList_Click(object sender, EventArgs e)
        {
            Form dayGoodsSaleList = GlobalUtility.GetOnlyChildFormObject<DayGoodsSaleListForm>(this,
                                                                                               FormConstants.
                                                                                                   DAY_GOODS_SALE_LIST_FORM);

            Department department = null;
            // if it does not have active department or department is HQ
            if (!CurrentDepartment.CurrentActiveDepartment(out department))
            {
                MessageBox.Show("Cửa hàng chính chưa được thiết lập! Xin vui lòng thiết lập cửa hàng chính trước.", "Lỗi",
                                MessageBoxButtons.OK);
                dayGoodsSaleList.Close();
            }
            else
            {
                dayGoodsSaleList.Show();
            }
        }

        private void mnuMonthGoodsSaleList_Click(object sender, EventArgs e)
        {
            Form monthGoodsSaleList = GlobalUtility.GetOnlyChildFormObject<MonthGoodsSaleListForm>(this,
                                                                                                   FormConstants.
                                                                                                       MONTH_GOODS_SALE_LIST_FORM);
            Department department = null;
            // if it does not have active department or department is HQ
            if (!CurrentDepartment.CurrentActiveDepartment(out department))
            {
                MessageBox.Show("Cửa hàng chính chưa được thiết lập! Xin vui lòng thiết lập cửa hàng chính trước.", "Lỗi",
                                MessageBoxButtons.OK);
                monthGoodsSaleList.Close();
            }
            else
            {
                monthGoodsSaleList.Show();
            }
        }
        
        public void setMenuPermissions()
        {
            MenuUtility.setPermission(this, ClientInfo.getInstance());
            this.Refresh();
            this.MainMenuStrip.Refresh();
        }

        private void lblStatus_Click(object sender, EventArgs e)
        {

        }
        private void ShowFormWithActiveDepartment(Form form,Department activeDepartment)
        {
            if (!CurrentDepartment.CurrentActiveDepartment(out activeDepartment))
            {
                MessageBox.Show("Cửa hàng chính chưa được thiết lập! Xin vui lòng thiết lập cửa hàng chính trước.", "Lỗi",
                                MessageBoxButtons.OK);
                form.Close();
            }
            else
            {
                form.Show();
            }
        }
        private void mnuDepartmentStockInExtra_Click(object sender, EventArgs e)
        {
            Form departmentStockIn = GlobalUtility.GetOnlyChildFormObject<MainStockInForm>(this, FormConstants.MAIN_STOCK_IN_FORM);
            departmentStockIn.Show();
            //ShowFormWithActiveDepartment(departmentStockIn,new Department());
        }

        private void mainStockInSearchStripMenuItem_Click(object sender, EventArgs e)
        {
            Form departmentStockIn = GlobalUtility.GetOnlyChildFormObject<MainStockInSearchForm>(this, FormConstants.MAIN_STOCK_IN_SEARCH_FORM);
            departmentStockIn.Show();
        }

        private void mnuPhieuXuatKho_Click(object sender, EventArgs e)
        {
            Form departmentStockIn = GlobalUtility.GetOnlyChildFormObject<DepartmentStockInFromMainForm>(this, FormConstants.DEPARTMENT_STOCK_IN_EXTRA_FORM);
            departmentStockIn.Show();
        }

        private void mnuGoodsSaleReturn_Click(object sender, EventArgs e)
        {
            Form goodsSaleReturnForm = GlobalUtility.GetOnlyChildFormObject<GoodsSaleReturnForm>(this,
                                                                                                 FormConstants.
                                                                                                     GOODS_SALE_RETURN_FORM);
            ShowFormWithActiveDepartment(goodsSaleReturnForm, new Department());
            //goodsSaleReturnForm.Show();
        }

        private void wareHouseStockIn_Click(object sender, EventArgs e)
        {
            Form departmentStockIn = GlobalUtility.GetOnlyChildFormObject<MainStockInForm>(this, FormConstants.MAIN_STOCK_IN_FORM);
            departmentStockIn.Show();
        }

        private void mnuGoodsImportReport_Click(object sender, EventArgs e)
        {
            /*Form stockInReportForm = GlobalUtility.GetOnlyChildFormObject<frmStockinStatistic>(this, FormConstants.REPORT_STOCK_IN_FORM);
            stockInReportForm.Show();*/

        //            Form stockInReportForm = GlobalUtility.GetOnlyChildFormObject<MainStockInSearchReportForm>(this, FormConstants.MAIN_STOCK_IN_SEARCH_REPORT_FORM);
        //            stockInReportForm.Show();
            new StockInReportViewer().ShowDialog();

        }


        private void mnuSynchronizeData_Click(object sender, EventArgs e)
        {
            Form departmentStockIn = GlobalUtility.GetFormObject<DepartmentStockSyncFromMainForm>(FormConstants.DEPARTMENT_STOCK_SYNC_FROM_MAIN_FORM);
            departmentStockIn.ShowDialog();
        }

        private void mnuWarehouseRemains_Click(object sender, EventArgs e)
        {

        }

        private void mnuGoodsExportReport_Click(object sender, EventArgs e)
        {
            /*Form stockOutReportForm = GlobalUtility.GetOnlyChildFormObject<DepartmentStockOutReportForm>(this, FormConstants.REPORT_STOCK_OUT_FORM);
            stockOutReportForm.Show();*/
            Form stockOutReportForm = GlobalUtility.GetOnlyChildFormObject<MainStockOutReportForm>(this,
                                                                                                   FormConstants.
                                                                                                       MAIN_STOCK_OUT_REPORT_FORM);
            stockOutReportForm.Show();

        }

        private void mnuInventoryChecking_Click(object sender, EventArgs e)
        {
            Form inventoryCheckingForm = GlobalUtility.GetOnlyChildFormObject<InventoryCheckingForm>(this,
                                                                                                     FormConstants.
                                                                                                         INVENTORY_CHECKING_FORM);
            inventoryCheckingForm.Show();
        }

        private void mnuDeptStockChecking_Click(object sender, EventArgs e)
        {
            Form deptStockCheckingForm = GlobalUtility.GetOnlyChildFormObject<DepartmentStockCheckingForm>(this,
                                                                                                     FormConstants.
                                                                                                         DEPARTMENT_STOCK_CHECKING_FORM);
            //deptStockCheckingForm.Show();
            ShowFormWithActiveDepartment(deptStockCheckingForm, new Department());
        }

        private void mnuTemporaryStockOut_Click(object sender, EventArgs e)
        {
//            Form baseStockOutForm = GlobalUtility.GetOnlyChildFormObject<BaseStockOutForm>(this,FormConstants.BASE_STOCK_OUT_FORM);
//            baseStockOutForm.Show();
            Form baseStockOutForm = GlobalUtility.GetOnlyChildFormObject<MainStockOutExtraForm>(this, FormConstants.MAIN_STOCK_OUT_EXTRA_FORM);
            baseStockOutForm.Show();

        }

        private void mnuDepartmentReturnGoods_Click(object sender, EventArgs e)
        {
            DepartmentStockOutExtraForm baseStockOutForm = GlobalUtility.GetOnlyChildFormObject<DepartmentStockOutExtraForm>(this, FormConstants.DEPARTMENT_STOCK_OUT_FORM);
            //baseStockOutForm.Show();
            ShowFormWithActiveDepartment(baseStockOutForm, new Department());
        }

        private void mnuDepartmentStockOutConfirm_Click(object sender, EventArgs e)
        {
            DepartmentStockOutConfirmForm form =
                GlobalUtility.GetOnlyChildFormObject<DepartmentStockOutConfirmForm>(this,
                                                                                    FormConstants.
                                                                                        DEPARTMENT_STOCK_OUT_CONFIRM_FORM);
            form.Show();
        }

        private void mnuProcessStockDefect_Click(object sender, EventArgs e)
        {
            Form form =
                GlobalUtility.GetOnlyChildFormObject<ProcessErrorGoodsForm>(this,FormConstants.PROCESS_ERROR_GOODS_FORM);
            form.Show();
        }

        private void mnuMainReStockIn_Click(object sender, EventArgs e)
        {
            Form form =
                GlobalUtility.GetOnlyChildFormObject<MainReStockInExtraForm>(this, FormConstants.MAIN_RE_STOCK_IN_EXTRA_FORM);
            form.Show();
        }

        private void mnuDeptStockInReport_Click(object sender, EventArgs e)
        {
            /*Form form = GlobalUtility.GetOnlyChildFormObject<DepartmentStockInReportForm>(this,
                                                                                          FormConstants.
                                                                                              DEPARTMENT_STOCK_IN_REPORT_FORM);
            form.Show();*/
            new Stock2DeptReportViewer().ShowDialog();
        }

        private void mnuProcessDepartmentStockDefect_Click(object sender, EventArgs e)
        {
            ProcessErrorGoodsForm form =
                 GlobalUtility.GetOnlyChildFormObject<ProcessErrorGoodsForm>(this, FormConstants.PROCESS_ERROR_GOODS_FORM);
            form.DepartmentProcessing = true;
            //            form.Show();
            ShowFormWithActiveDepartment(form, new Department());
            
        }

        private void mnuDepartmentReStockIn_Click(object sender, EventArgs e)
        {
            Form form = GlobalUtility.GetOnlyChildFormObject<DepartmentReStockInForm>(this,
                                                                                      FormConstants.
                                                                                          DEPARTMENT_RESTOCK_IN_FORM);
            //form.Show();
            ShowFormWithActiveDepartment(form, new Department());
        }

        private void mnuStockCollection_Click(object sender, EventArgs e)
        {
            /*Form form = GlobalUtility.GetOnlyChildFormObject<RemainStockReport>(this,
                                                                          FormConstants.
                                                                              MAIN_REMAIN_STOCK_REPORT_FORM);
            form.Show();*/
            new StockStatisticReportViewer().ShowDialog();
        }

        private void mnuFindStockByBarcode_Click(object sender, EventArgs e)
        {
            Form form = GlobalUtility.GetOnlyChildFormObject<MainStockSearchByBarcodeForm>(this,
                                                                          FormConstants.
                                                                              MAIN_STOCK_SEARCH_BY_BARCODE_FORM);
            form.Show();
        }

        private void mnuSyncToMainForm_Click(object sender, EventArgs e)
        {
            Form form = GlobalUtility.GetOnlyChildFormObject<SyncToMainForm>(this,
                                                                          FormConstants.
                                                                              SYNC_TO_MAIN_FORM);
            form.Show();
        }


        private void mnuUserAccount_Click(object sender, EventArgs e)
        {
            
        }


        private void mnuLoadToMain_Click(object sender, EventArgs e)
        {
            Form form = GlobalUtility.GetOnlyChildFormObject<LoadDataFromDepartmentToMain>(this,
                                                                          FormConstants.
                                                                              LOAD_DATA_TO_MAIN_STOCK_FORM);
            form.Show();
        }

        private void mnuLoadToDept_Click(object sender, EventArgs e)
        {
            Form form = GlobalUtility.GetOnlyChildFormObject<LoadDepartmentStockInToFileForm>(this,
                                                                          FormConstants.
                                                                              LOAD_DATA_FROM_MAIN_STOCK_TO_FILE_FORM);
            form.Show();
        }

        private void mnuGoodsSaleDepartmentReport_Click(object sender, EventArgs e)
        {
            new PurchaseOrderReportViewer().ShowDialog();
        }

        private void mnuGoodsSendbackReport_Click(object sender, EventArgs e)
        {
            new SupplierStockoutReportViewer().ShowDialog();
        }

        private void mnuRestockinReport_Click(object sender, EventArgs e)
        {
            new RestockinReportViewer().ShowDialog();
        }

        private void mnuTempStockoutReport_Click(object sender, EventArgs e)
        {
            new TempStockoutReportViewer().ShowDialog();
        }

        private void mnuGoodsSaleDepartmentDetail_Click(object sender, EventArgs e)
        {
            new PurchaseDetailsReportViewer().ShowDialog();
        }

        private void mnuUserAccount_Click_1(object sender, EventArgs e)
        {
            Form form = GlobalUtility.GetOnlyChildFormObject<SecuritySettingsForm>(this,
                                                                                    FormConstants.SECURITY_SETTINGS_FORM);
            form.Show();
        }

        private void mnuReturnPOReport_Click(object sender, EventArgs e)
        {
            Department department = null;
            // if it does not have active department or department is HQ
            if (!CurrentDepartment.CurrentActiveDepartment(out department))
            {
                MessageBox.Show("Cửa hàng chính chưa được thiết lập! Xin vui lòng thiết lập cửa hàng chính trước.", "Lỗi",
                                MessageBoxButtons.OK);
                return;
            }
            new ReturnPOrderReportViewer().ShowDialog();
        }

        private void mnuDeptStockStatisticReport_Click(object sender, EventArgs e)
        {
            Department department = null;
            // if it does not have active department or department is HQ
            if (!CurrentDepartment.CurrentActiveDepartment(out department))
            {
                MessageBox.Show("Cửa hàng chính chưa được thiết lập! Xin vui lòng thiết lập cửa hàng chính trước.", "Lỗi",
                                MessageBoxButtons.OK);
                return;
            }
            new DeptStockStatisticReportViewer().ShowDialog();
        }

        private void mnuMainDeptStockStatisticReport_Click(object sender, EventArgs e)
        {
            new DeptStockStatisticReportViewer().ShowDialog();
        }

        private void mnuMainReturnPOReport_Click(object sender, EventArgs e)
        {
            new ReturnPOrderReportViewer().ShowDialog();
        }

        private void mnuAllStockReturnReport_Click(object sender, EventArgs e)
        {
            //new AllStockReportViewer().ShowDialog();
            new MainStockReturnReportViewer().ShowDialog();
        }

        private void mnuReturnMainStockReport_Click(object sender, EventArgs e)
        {
            new MainStockReturnReportViewer().ShowDialog();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Stream inStream = null;
            if(ClientSetting.IsClient())
            {
                inStream = this.GetType().Assembly.GetManifestResourceStream("AppFrameClient.ClientMenuPermissions.xml");    
            }
            else
            {
                if(ClientSetting.IsServer())
                {
                    inStream = this.GetType().Assembly.GetManifestResourceStream("AppFrameClient.ServerMenuPermissions.xml");    
                }
                else
                {
                    inStream = this.GetType().Assembly.GetManifestResourceStream("AppFrameClient.NAMenuPermissions.xml");    
                }
            }

            // load menu permission
            MenuItemPermission menuItemPermission = new MenuItemPermission(MenuItemPermission.INVISIBLE);
            menuItemPermission.loadRoles(inStream);
            ClientInfo clientInfo = ClientInfo.getInstance();
            clientInfo.MenuPermissions = menuItemPermission;

            // register main form
            GlobalCache.Instance().MainForm = this;

            // check menu permission
            MenuUtility.setPermission(clientInfo.LoggedUser, ref this.mnuMenu, menuItemPermission);
            //CheckClientServer();
        }

        private void CheckClientServer()
        {
            if(!ClientSetting.IsClient() && !ClientSetting.IsServer())
            {
                new ClientServerSettingForm().ShowDialog();                
            }
        }

        private void mnuAllStock_Click(object sender, EventArgs e)
        {
            new AllStockReportViewer().ShowDialog();
        }

        private void mnuAddEmployee_Click(object sender, EventArgs e)
        {
            Form form = GlobalUtility.GetOnlyChildFormObject<EmployeeForm>(this, FormConstants.EMPLOYEE_FORM);
            form.Show();
        }

        private void mnuEmployeeManagement_Click(object sender, EventArgs e)
        {
            Form form = GlobalUtility.GetOnlyChildFormObject<EmployeeListForm>(this, FormConstants.EMPLOYEE_LIST_FORM);
            form.Show();
        }

        private void mnuDeptReStockReport_Click(object sender, EventArgs e)
        {
            new DeptReStockReportViewer().ShowDialog();
        }

        private void mnuDeptTempStockOutReport_Click(object sender, EventArgs e)
        {
            new  DeptTempStockoutReportViewer().ShowDialog();
        }

        private void mnuSalePoint_Click(object sender, EventArgs e)
        {

        }

        private void mnuDepartmentStockIn_Click(object sender, EventArgs e)
        {
            new DepartmentStockinReportViewer().ShowDialog();
        }
    }
}
