using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Exceptions;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrameClient.Common;
using AppFrameClient.Presenter.GoodsIO.DepartmentStockData;
using AppFrameClient.Utility;

namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    public partial class LoadDatabaseImageForm : BaseForm, IDepartmentStockInExtraView
    {
        #region Implementation of IDepartmentStockInView

        private DepartmentStockInExtraController _departmentStockInController;
        public IDepartmentStockInController DepartmentStockInController
        {
            set
            {
                _departmentStockInController = (DepartmentStockInExtraController)value;
                _departmentStockInController.DepartmentStockInView = this;
                _departmentStockInController.DepartmentStockInExtraView = this;
            }
        }

        public IProductMasterSearchOrCreateController ProductMasterSearchOrCreateController { set; private get; }
        public event EventHandler<DepartmentStockInEventArgs> InitDepartmentStockInEvent;
        public event EventHandler<ProductMasterSearchOrCreateEventArgs> OpenProductMasterSearchEvent;
        public event EventHandler<DepartmentStockInEventArgs> SaveDepartmentStockInEvent;
        public event EventHandler<DepartmentStockInEventArgs> FindProductMasterEvent;
        public event EventHandler<DepartmentStockInEventArgs> SyncDepartmentStockInEvent;

        #endregion

        #region IDepartmentStockInView Members


        public event EventHandler<DepartmentStockInEventArgs> FindByBarcodeEvent;

        #endregion

        #region IDepartmentStockInView Members


        public event EventHandler<DepartmentStockInEventArgs> SaveReDepartmentStockInEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadAllDepartments;
        public event EventHandler<DepartmentStockInEventArgs> FindBarcodeEvent;
        public event EventHandler<DepartmentStockInEventArgs> SaveStockInBackEvent;
        public event EventHandler<DepartmentStockInEventArgs> DispatchDepartmentStockIn;
        public event EventHandler<DepartmentStockInEventArgs> FindByStockInIdEvent;

        #endregion

        public LoadDatabaseImageForm()
        {
            InitializeComponent();
        }

        #region Implementation of IDepartmentStockInExtraView

        public event EventHandler<DepartmentStockInEventArgs> FillProductToComboEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadGoodsByIdEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadGoodsByNameEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadProductColorEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadProductSizeEvent;
        public event EventHandler<DepartmentStockInEventArgs> FillDepartmentEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadGoodsByNameColorEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadGoodsByNameColorSizeEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadPriceAndStockEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadDepartmentStockInForExportEvent;
        public event EventHandler<DepartmentStockInEventArgs> UpdateDepartmentStockInForExportEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadMasterDataForExportEvent;
        public event EventHandler<DepartmentStockInEventArgs> SyncExportedMasterDataEvent;
        public event EventHandler<DepartmentStockInEventArgs> LoadStockInByProductMaster;
        public event EventHandler<DepartmentStockInEventArgs> UpdateStockOutEvent;
        public event EventHandler<DepartmentStockInEventArgs> FindRemainsQuantity;
        public event EventHandler<DepartmentStockInEventArgs> FindBarcodeInMainStockEvent;
        public event EventHandler<DepartmentStockInEventArgs> RefreshStockQuantityEvent;

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool CheckPOSSyncDriveExist()
        {
            IList list = ClientUtility.GetPOSSyncDrives();
            if (list.Count == 0)
            {
                MessageBox.Show("Không có USB đồng bộ nào");
                return false;
            }
            if (list.Count > 1)
            {
                MessageBox.Show("Có nhiều hơn 1 USB đồng bộ.Bạn hãy để lại một USB đồng bộ thôi");
                return false;
            }
            return true;
        }

        private IList resultList = null;
        private void doSync()
        {

            if (!CheckPOSSyncDriveExist())
                return;
            string POSSyncDrive = ClientUtility.GetPOSSyncDrives()[0].ToString();
            DialogResult dResult = MessageBox.Show(
                "Bạn muốn tạo hình ảnh dữ liệu ? ",
                "Tạo hình ảnh dữ liệu", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dResult == DialogResult.No)
            {
                return;
            }

            var configurationAppSettings = new AppSettingsReader();
            //var exportPath = (string)configurationAppSettings.GetValue("SyncExportPath", typeof(String));
            var configExportPath = POSSyncDrive + ClientSetting.SyncExportPath;
            if (string.IsNullOrEmpty(configExportPath) || !Directory.Exists(configExportPath))
            {
                MessageBox.Show("Không thể tìm thấy đường dẫn đến thư mục " + configExportPath + "!Hãy kiễm tra file cấu hình phần SyncExportPath");
                return;
            }
            resultList = new ArrayList();
            try
            {

                DatabaseUtils.LoadMasterData(chkPrdMaster.Checked, chkDepartments.Checked, chkPrice.Checked);
                SyncResult mstResult = new SyncResult();
                mstResult.FileName = "HINH ANH DU LIEU";
                mstResult.Status = "Thành công";
                resultList.Add(mstResult);
                // sync master data first
                /*Department mstDataDept = new Department
                {
                    DepartmentId = 0,
                    DepartmentName = "DataImage"
                };
                //DateTime lastMasterDataSyncTime = ClientUtility.GetLastSyncTime(configExportPath, mstDataDept, ClientUtility.SyncType.SyncDown);
                var masterDataEvent = new DepartmentStockInEventArgs();
                masterDataEvent.LastSyncTime = DateTime.MinValue;
                if(chkMasterData.Checked)
                {
                    masterDataEvent.SyncProductMasters = chkPrdMaster.Checked;
                    masterDataEvent.SyncPrice = chkPrice.Checked;
                    masterDataEvent.SyncDepartments = chkDepartments.Checked;
                }
                
                EventUtility.fireEvent(LoadMasterDataForExportEvent, this, masterDataEvent);
                if (masterDataEvent.HasMasterDataToSync)
                {
                    string masterDataFileName = configExportPath + "\\" + "DataImage_SyncDown_" +
                                                DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") +
                                                CommonConstants.SERVER_SYNC_FORMAT;
                    
                    Stream mstStream = File.Open(masterDataFileName, FileMode.Create);
                    BinaryFormatter mstBf = new BinaryFormatter();
                    mstBf.Serialize(mstStream, masterDataEvent.SyncFromMainToDepartment);
                    mstStream.Flush();
                    mstStream.Close();
                    SyncResult mstResult = new SyncResult();
                    mstResult.FileName = masterDataFileName;
                    mstResult.Status = "Thành công";
                    resultList.Add(mstResult);
                }*/

            }
            catch (Exception)
            {
                SyncResult mstResult = new SyncResult();
                mstResult.FileName = "Chưa tạo được file image";
                mstResult.Status = "Thất bại";
                resultList.Add(mstResult);
            }
            MessageBox.Show("Đồng bộ hoàn tất !");
            
        }
        private void btnSyncToDept_Click(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            this.Enabled = false;
            backgroundWorker.RunWorkerAsync();
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Enabled = true;
            if (resultList != null)
            {
                syncResultBindingSource.DataSource = resultList;
            }
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            doSync();
        }

        private void chkMasterData_CheckedChanged(object sender, EventArgs e)
        {
            if(chkMasterData.Checked)
            {
                grpMasterData.Enabled = true;
            }
            else
            {
                grpMasterData.Enabled = false;
            }
        }
    }
}
