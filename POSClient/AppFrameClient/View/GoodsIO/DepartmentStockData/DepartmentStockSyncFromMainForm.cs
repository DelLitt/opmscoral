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
using System.Threading;
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
    public partial class DepartmentStockSyncFromMainForm : BaseForm, IDepartmentStockInExtraView
    {
        public DepartmentStockSyncFromMainForm()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var fileOpen = new OpenFileDialog();
            fileOpen.InitialDirectory = ".\\";
            fileOpen.Filter = "POS (*.xac)|*.xac";
            fileOpen.FilterIndex = 0;
            fileOpen.RestoreDirectory = true;
            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = fileOpen.FileName;
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {

            
        }

        #region Implementation of IDepartmentStockInView

        private DepartmentStockInExtraController _departmentStockInController;
        public IDepartmentStockInController DepartmentStockInController
        {
            set
            {
                _departmentStockInController = (DepartmentStockInExtraController)value;
                _departmentStockInController.DepartmentStockInView = this;
                _departmentStockInController.DepartmentStockInExtraView = this;
                _departmentStockInController.CompletedFindByStockInEvent += new EventHandler<DepartmentStockInEventArgs>(_departmentStockInController_CompletedFindByStockInEvent);
            }
        }

        void _departmentStockInController_CompletedFindByStockInEvent(object sender, DepartmentStockInEventArgs e)
        {
            
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

        private void btnSyncToDept_Click(object sender, EventArgs e)
        {
            var configurationAppSettings = new AppSettingsReader();
            var exportPath = (string)configurationAppSettings.GetValue("SyncExportPath", typeof(String));
            if (string.IsNullOrEmpty(exportPath) || !Directory.Exists(exportPath))
            {
                MessageBox.Show("Không thể tìm thấy đường dẫn đến thư mục " + exportPath + "!Hãy kiễm tra file cấu hình phần SyncExportPath");
                return;
            }
            try
            {
                var deptEvent = new DepartmentStockInEventArgs();
                EventUtility.fireEvent(FillDepartmentEvent, this, deptEvent);

                IList departmentList = deptEvent.DepartmentList;
                foreach (Department department in departmentList)
                {
                    deptEvent = new DepartmentStockInEventArgs();
                    deptEvent.Department = department;
                    EventUtility.fireEvent(LoadDepartmentStockInForExportEvent, this, deptEvent);

                    if (deptEvent.DepartmentStockInList != null && deptEvent.DepartmentStockInList.Count > 0)
                    {
                        foreach (DepartmentStockIn stockIn in deptEvent.DepartmentStockInList)
                        {
                            string fileName = exportPath + "\\" + department.DepartmentName + "_" + department.Address + " - Ma lo_" + stockIn.DepartmentStockInPK.StockInId + "_" +
                                                              stockIn.StockInDate.ToString("yyyy_MM_dd_HH_mm_ss") + ".xac";
                            Stream stream = File.Open(fileName, FileMode.Create);
                            BinaryFormatter bf = new BinaryFormatter();
                            bf.Serialize(stream, stockIn);
                            stream.Close();

                            var eventArgs = new DepartmentStockInEventArgs();
                            eventArgs.DepartmentStockIn = stockIn;
                            EventUtility.fireEvent(UpdateDepartmentStockInForExportEvent, this, eventArgs);

                        }
                        CopyImage(exportPath);
                    }
                }
            }
            catch (Exception)
            {

            }
            MessageBox.Show("Đồng bộ hoàn tất !");
        }

        private void CopyImage(string path)
        {
            if (!Directory.Exists(Application.StartupPath + "\\ProductImages\\"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\ProductImages\\");
            }

            // copy image
            if (Directory.Exists(path + "\\ProductImages"))
            {
                string[] fileName = Directory.GetFiles(path + "\\ProductImages");

                foreach (string s in fileName)
                {
                    if (s.EndsWith(".jpg") || s.EndsWith(".JPG"))
                    {
                        File.Copy(path + "\\ProductImages\\" + s, Application.StartupPath + "\\ProductImages\\" + s);
                    }
                    
                }
            }
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
        private void DoSyncFromMain()
        {
            resultList = new ArrayList();
            if (!CheckPOSSyncDriveExist())
            {
                
                return;
            }

            string POSSyncDrive = ClientUtility.GetPOSSyncDrives()[0].ToString();
            DialogResult dResult = MessageBox.Show(
                "Bạn muốn nhập hàng cho cửa hàng ? ",
                "Nhập hàng cho cửa hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dResult == DialogResult.No)
            {
                return;
            }

            var configurationAppSettings = new AppSettingsReader();
            //var importPath = (string)configurationAppSettings.GetValue("SyncImportPath", typeof(String));
            var masterPath = POSSyncDrive + "\\POS";
            var importPath = POSSyncDrive + ClientSetting.SyncImportPath;
            var successPath = POSSyncDrive + ClientSetting.SyncSuccessPath;
            var errorPath = POSSyncDrive + ClientSetting.SyncErrorPath;
            // get import path of this department
            importPath = importPath + "\\" + CurrentDepartment.Get().DepartmentId;
            //errorPath = ClientUtility.EnsureSyncPath(errorPath, CurrentDepartment.Get());
            //successPath = ClientUtility.EnsureSyncPath(successPath, CurrentDepartment.Get()); 
            if (string.IsNullOrEmpty(masterPath) || !Directory.Exists(masterPath))
            {
                MessageBox.Show("Không thể tìm thấy đường dẫn đến thư mục " + masterPath + "!Hãy kiễm tra file cấu hình phần SyncImportPath");

                return;
            }
            if (string.IsNullOrEmpty(importPath) || !Directory.Exists(importPath))
            {
                MessageBox.Show("Không thể tìm thấy đường dẫn đến thư mục " + importPath + "!Hãy kiễm tra file cấu hình phần SyncImportPath");

                return;
            }

            if (string.IsNullOrEmpty(importPath) || !Directory.Exists(importPath))
            {
                MessageBox.Show("Không thể tìm thấy đường dẫn đến thư mục " + importPath + "!Hãy kiễm tra file cấu hình phần SyncImportPath");
                
                return;
            }
            //var successPath = (string)configurationAppSettings.GetValue("SyncImportSuccessPath", typeof(String));

            if (string.IsNullOrEmpty(successPath) || !Directory.Exists(successPath))
            {
                MessageBox.Show("Không thể tìm thấy đường dẫn đến thư mục " + successPath + "!Hãy kiễm tra file cấu hình phần SyncImportSuccessPath");
                
                return;
            }
            //var errorPath = (string)configurationAppSettings.GetValue("SyncImportErrorPath", typeof(String));

            if (string.IsNullOrEmpty(errorPath) || !Directory.Exists(errorPath))
            {
                MessageBox.Show("Không thể tìm thấy đường dẫn đến thư mục " + errorPath + "!Hãy kiễm tra file cấu hình phần SyncImportErrorPath");
                
                return;
            }


            // sync master data first
            string[] masterNames = Directory.GetFiles(masterPath, "*.zip");
            if (masterNames.Length > 0)
            {
                // get file name and sync master data
                string masterFileName = "";
                foreach (string masterName in masterNames)
                {
                    masterFileName = masterName;
                    if (!string.IsNullOrEmpty(masterFileName))
                    {
                        SyncResult result = new SyncResult();
                        result.FileName = masterFileName;

                        if (masterFileName.IndexOf("MasterData") < 0)
                        {
                            continue;
                        }
                        resultList.Add(result);
                        try
                        {
                            DatabaseUtils.SyncMasterData(masterFileName);
                            result.Status = "Thành công !";
                        }
                        catch (Exception ex )
                        {
                            MessageBox.Show(ex.Message);
                            result.Status = "Thất bại!";
                        }
                    }
                }
            }

                string[] fileNames = Directory.GetFiles(importPath, "*" + CommonConstants.SERVER_SYNC_FORMAT);
                
                IList fileNameList = new ArrayList();
                if (fileNames.Length == 0)
                {
                    if (resultList.Count == 0)
                    {
                        MessageBox.Show("Không thể tìm thấy file nào để đồng bộ");    
                    }
                    MessageBox.Show("Đồng bộ hoàn tất !");
                    return;
                }
                foreach (string fileName in fileNames)
                {
                    fileNameList.Add(fileName);
                }
                
                StringBuilder errorStr = new StringBuilder();
                foreach (string fileName in fileNameList)
                {
                    SyncResult result = new SyncResult();
                    result.FileName = fileName;
                    resultList.Add(result);
                    DepartmentStockIn deptStockIn = null;
                    Stream stream = null;
                    bool fail = true;
                    try
                    {
                        // need to put a part of master data syncing.

                        stream = File.Open(fileName, FileMode.Open);
                        BinaryFormatter bf = new BinaryFormatter();
                        SyncFromMainToDepartment syncFMTD = (SyncFromMainToDepartment) bf.Deserialize(stream);
                        Department dept;
                        if (syncFMTD == null || syncFMTD.Department == null)
                        {
                            fail = true;
                        }
                        else
                        {
                            if (CurrentDepartment.CurrentActiveDepartment(out dept)
                                && syncFMTD.Department.DepartmentId == CurrentDepartment.Get().DepartmentId)
                            {
                                var eventArgs = new DepartmentStockInEventArgs();
                                //eventArgs.DepartmentStockIn = deptStockIn;
                                eventArgs.SyncFromMainToDepartment = syncFMTD;
                                EventUtility.fireEvent(SyncDepartmentStockInEvent, this, eventArgs);
                                if (eventArgs.EventResult != null)
                                {
                                    fail = false;
                                }
                                else
                                {
                                    fail = true;
                                }
                            }
                        }
                    }
                    finally
                    {
                        if (stream != null)
                        {
                            stream.Close();
                        }
                        if (fail)
                        {
                            //File.Move(fileName, errorPath + "\\" + fileName.Substring(fileName.LastIndexOf("\\"), fileName.Length - fileName.LastIndexOf("\\")));
                            ClientUtility.MoveFileToSpecificDir(errorPath, fileName);
                            // errorStr.Append("   > " + fileName.Substring(fileName.LastIndexOf("\\"), fileName.Length - fileName.LastIndexOf("\\")) + "\r\n");
                            result.Status = "Thất bại";
                        }
                        else
                        {
                            //File.Move(fileName, successPath + "\\" + fileName.Substring(fileName.LastIndexOf("\\"), fileName.Length - fileName.LastIndexOf("\\")));
                            ClientUtility.MoveFileToSpecificDir(successPath, fileName);
                            string origFileName = fileName.Substring(fileName.LastIndexOf("\\") + 1,
                                                                     fileName.Length - (fileName.LastIndexOf("\\") + 1));
                            string[] separateFileNames = origFileName.Split('.');
                            string updateTimeStr =
                                separateFileNames[0].Substring(separateFileNames[0].IndexOf("_SyncDown_") + 10);
                            DateTime updateTime = DateTime.ParseExact(updateTimeStr, "yyyy_MM_dd_HH_mm_ss", null);
                            ClientUtility.WriteLastSyncTime(updateTime, importPath, CurrentDepartment.Get(),
                                                            ClientUtility.SyncType.SyncDown);
                            result.Status = "Thành công";
                        }
                    }
                }
            
            MessageBox.Show("Đồng bộ hoàn tất !");
            
            
        }

        private void btnSyncFromMain_Click(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            //Thread thread = new Thread(new ThreadStart(DoSyncFromMain));
            btnSyncToMain.Enabled = false;
            btnClose.Enabled = false;
            btnSyncToMain.Text = "Đang đồng bộ ... ";
            //thread.Start();
            backgroundWorker.RunWorkerAsync();
        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSyncToMain.Enabled = true;
            btnSyncToMain.Text = "Bắt đầu đồng bộ";
            btnClose.Enabled = true;
            if (resultList != null)
            {
                syncResultBindingSource.DataSource = resultList;
            }
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            DoSyncFromMain();

        }
    }
}
