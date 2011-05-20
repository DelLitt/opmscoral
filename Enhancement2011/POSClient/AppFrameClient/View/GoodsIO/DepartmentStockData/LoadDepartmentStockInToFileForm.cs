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
using Ionic.Zip;

namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    public partial class LoadDepartmentStockInToFileForm : BaseForm, IDepartmentStockInExtraView
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

        public LoadDepartmentStockInToFileForm()
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
                "Bạn muốn xuất hàng cho cửa hàng ? ",
                "Xuất hàng cho cửa hàng", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
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
                if(chkMasterData.Checked)
                {
                    if(!chkDepartments.Checked && !chkPrdMaster.Checked && !chkPrice.Checked)
                    {
                        MessageBox.Show("Bạn phải chọn ít nhất một thông tin chung để đồng bộ.");
                        return;
                    }
                    DatabaseUtils.LoadMasterData(chkPrdMaster.Checked,chkDepartments.Checked,chkPrice.Checked);
                }

                // sync stock-out to dept
                var deptEvent = new DepartmentStockInEventArgs();
                EventUtility.fireEvent(FillDepartmentEvent, this, deptEvent);

                IList departmentList = deptEvent.DepartmentList;
                foreach (Department department in departmentList)
                {
                    CleanUSBDrive(POSSyncDrive);
                    if(department.DepartmentId != syncDeptId) continue;

                    var exportPath = ClientUtility.EnsureSyncPath(configExportPath, department);
                    DateTime lastSyncTime = ClientUtility.GetLastSyncTime(exportPath, department, ClientUtility.SyncType.SyncDown);
                    deptEvent = new DepartmentStockInEventArgs();
                    deptEvent.LastSyncTime = lastSyncTime;
                    deptEvent.Department = department;
                    EventUtility.fireEvent(LoadDepartmentStockInForExportEvent, this, deptEvent);

                    int countSyncFile = 1;
                    if (deptEvent.SyncFromMainToDepartment != null)
                        //&& deptEvent.SyncFromMainToDepartment.StockOutList != null
                        //&& deptEvent.SyncFromMainToDepartment.StockOutList.Count > 0)
                    {

                        // ++ AMEND : SEPARATE STOCKOUTS AND COMMON INFO
                        
                        //var exportPath = ClientUtility.EnsureSyncPath(configExportPath, department);
                        #region oldsynccode
                        /*string fileName = exportPath + "\\" + department.DepartmentId                                           
                                          + "_SyncDown_"  
                                          + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") 
                                          + CommonConstants.SERVER_SYNC_FORMAT;
                        SyncResult result = new SyncResult();
                        result.FileName = fileName;
                        result.Status = "Thành công";
                        resultList.Add(result);
                        Stream stream = File.Open(fileName, FileMode.Create);
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(stream, deptEvent.SyncFromMainToDepartment);
                        stream.Flush();
                        stream.Close();*/
                        
                        #endregion

                        SyncFromMainToDepartment common = new SyncFromMainToDepartment();
                        
                            common.Department = deptEvent.SyncFromMainToDepartment.Department;
                            common.DepartmentList = deptEvent.SyncFromMainToDepartment.DepartmentList;
                            common.EmployeeList = deptEvent.SyncFromMainToDepartment.EmployeeList;
                            common.DepartmentPriceMasterList =
                                deptEvent.SyncFromMainToDepartment.DepartmentPriceMasterList;
                            common.DepartmentStockTemps = deptEvent.SyncFromMainToDepartment.DepartmentStockTemps;
                            common.ProductMasterList = deptEvent.SyncFromMainToDepartment.ProductMasterList;
                            common.UserInfoList = deptEvent.SyncFromMainToDepartment.UserInfoList;

                            string fileName = exportPath + "\\" + department.DepartmentId
                                              + "_" + countSyncFile.ToString()
                                              + "_SyncDown_"
                                              + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")
                                              + CommonConstants.SERVER_SYNC_FORMAT;
                            SyncResult result = new SyncResult();
                            result.FileName = fileName;
                            result.Status = "Thành công";
                            resultList.Add(result);
                            Stream stream = File.Open(fileName, FileMode.Create);
                            BinaryFormatter bf = new BinaryFormatter();
                            bf.Serialize(stream, deptEvent.SyncFromMainToDepartment);
                            stream.Flush();
                            stream.Close();
                        
                        // write each stock out to a sync file for avoiding duplicate update
                        if(deptEvent.SyncFromMainToDepartment.StockOutList!=null 
                           && deptEvent.SyncFromMainToDepartment.StockOutList.Count > 0 )
                        {
                            foreach (StockOut stockOut in deptEvent.SyncFromMainToDepartment.StockOutList)
                            {
                                countSyncFile += 1;
                                SyncFromMainToDepartment soSync = new SyncFromMainToDepartment();
                                soSync.Department = deptEvent.SyncFromMainToDepartment.Department;
                                soSync.StockOutList = new ArrayList();
                                soSync.StockOutList.Add(stockOut);

                                string soFileName = exportPath + "\\" + department.DepartmentId
                                              + "_" + countSyncFile.ToString()
                                              + "_SyncDown_"
                                              + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss")
                                              + CommonConstants.SERVER_SYNC_FORMAT;
                                SyncResult soResult = new SyncResult();
                                soResult.FileName = soFileName;
                                soResult.Status = "Thành công";
                                resultList.Add(soResult);
                                Stream soStream = File.Open(soFileName, FileMode.Create);
                                BinaryFormatter soBf = new BinaryFormatter();
                                soBf.Serialize(soStream, soSync);
                                soStream.Flush();
                                soStream.Close();
                            }
                        }


                        // -- AMEND : SEPARATE STOCKOUTS AND COMMON INFO
                        // write last sync time
                        //ClientUtility.WriteLastSyncTime(exportPath,department,ClientUtility.SyncType.SyncDown);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            MessageBox.Show("Đồng bộ hoàn tất !");
            
        }

        private void CleanUSBDrive(string drive)
        {
            string successPath = drive + ClientSetting.SyncSuccessPath;
            string errorPath = drive + ClientSetting.SyncErrorPath;
            string backupDBPath = drive + ClientSetting.DBBackupPath;
            string appPath = Application.ExecutablePath;
            appPath = appPath.Substring(0, appPath.LastIndexOf("\\"));
            
            string localSuccessPath = appPath + ClientSetting.SyncSuccessPath;
            if (!Directory.Exists(localSuccessPath)) Directory.CreateDirectory(localSuccessPath);
            
            string localErrorPath = appPath + ClientSetting.SyncErrorPath;
            if (!Directory.Exists(localErrorPath)) Directory.CreateDirectory(localErrorPath);

            string localBackupDBPath = appPath + ClientSetting.DBBackupPath;
            if (!Directory.Exists(localBackupDBPath)) Directory.CreateDirectory(localBackupDBPath);

            if(Directory.Exists(successPath))
            {
                string zipFileName = string.Format("success_zip_files_{0}.zip", DateTime.Now.ToString("yyyyMMddHHmmss"));

                CompressAllFiles(successPath, zipFileName);
                /*string[] successFiles = Directory.GetFiles(successPath);
                using (ZipFile zip = new ZipFile())
                {
                    zip.Password = ClientSetting.ZIP_PASSWORD;
                    zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                    bool hasData = false;
                    foreach (string successFile in successFiles)
                    {
                        if(successFile.EndsWith("zip")) continue;
                        zip.AddFile(successFile, "");
                        if (!hasData) hasData = true;
                    }
                    
                    if (hasData) zip.Save(successPath + "\\" + zipFileName);
                }
                // delete all files which compressed.
                foreach (string successFile in successFiles)
                {
                    if (successFile.EndsWith("zip")) continue;
                    File.Delete(successFile);
                }*/
            
                // move all zip files to local successPath
                /*foreach (string file in Directory.GetFiles(successPath))
                {
                    File.Move(file,localSuccessPath + "\\" + file.Substring(file.LastIndexOf("\\")+1));
                }
                foreach (string directory in Directory.GetDirectories(successPath))
                {
                    Directory.Move(directory, localSuccessPath + "\\" + directory.Substring(directory.LastIndexOf("\\") + 1));
                }*/
                ClientUtility.MoveDirectory(successPath,localSuccessPath,false);

            }
            if (Directory.Exists(errorPath))
            {
                string zipFileName = string.Format("error_zip_files_{0}.zip", DateTime.Now.ToString("yyyyMMddHHmmss"));
                CompressAllFiles(errorPath,zipFileName);
                /*
                string[] errorFiles = Directory.GetFiles(errorPath);
                using (ZipFile zip = new ZipFile())
                {
                    zip.Password = ClientSetting.ZIP_PASSWORD;
                    zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                    bool hasData = false;
                    foreach (string errorFile in errorFiles)
                    {
                        if (errorFile.EndsWith("zip")) continue;
                        zip.AddFile(errorFile, "");
                        if (!hasData) hasData = true;
                    }

                    
                    if(hasData) zip.Save(errorPath + "\\" + zipFileName);
                }
                // delete all files
                foreach (string errorFile in errorFiles)
                {
                    if (errorFile.EndsWith("zip")) continue;
                    File.Delete(errorFile);
                }*/

                // move all zip files to local errorPath
                /*foreach (string file in Directory.GetFiles(errorPath))
                {
                    File.Move(file, localErrorPath + "\\" + file.Substring(file.LastIndexOf("\\") + 1));
                }
                foreach (string directory in Directory.GetDirectories(errorPath))
                {
                    Directory.Move(directory, localErrorPath + "\\" + directory.Substring(directory.LastIndexOf("\\") + 1));
                }*/
                ClientUtility.MoveDirectory(successPath, localSuccessPath,false);
            }

            if(Directory.Exists(backupDBPath))
            {
                string[] backupDBFiles = Directory.GetFiles(backupDBPath);

                foreach (string backupDbFile in backupDBFiles)
                {
                    File.Move(backupDbFile,localBackupDBPath + "\\" + backupDbFile.Substring(backupDbFile.LastIndexOf("\\")+1));
                }
            }
        }

        private void CompressAllFiles(string path, string fileName)
        {

            string[] files = Directory.GetFiles(path);
            using (ZipFile zip = new ZipFile())
            {
                zip.Password = ClientSetting.ZIP_PASSWORD;
                zip.Encryption = EncryptionAlgorithm.WinZipAes256;
                bool hasData = false;
                foreach (string file in files)
                {
                    if (file.EndsWith("zip")) continue;
                       
                    zip.AddFile(file, "");
                    if (!hasData) hasData = true;
                }

                if (hasData) zip.Save(path + "\\" + fileName);
            }
            // delete all files which compressed.
            foreach (string successFile in files)
            {
                if (successFile.EndsWith("zip")) continue;
                File.Delete(successFile);
            }

            string[] subDirs = Directory.GetDirectories(path);
            foreach (string subDir in subDirs)
            {
                CompressAllFiles(subDir,fileName);
            }
        }

        private void CopyMasterImage(IList productMasterList, DateTime lastSyncDate, string path)
        {
            if (!Directory.Exists(path + "\\ProductImages\\"))
            {
                Directory.CreateDirectory(path + "\\ProductImages\\");
            }

            // copy image
            foreach (ProductMaster master in productMasterList)
            {
                string fileName = Application.StartupPath + "\\ProductImages\\" + master.ImagePath;
                if (File.Exists(fileName)
                    && File.GetLastAccessTime(fileName).CompareTo(lastSyncDate) >= 0)
                {
                    File.Copy(fileName, path + "\\ProductImages\\");
                }                
            }
        }

        private long syncDeptId = 0;
        private void btnSyncToDept_Click(object sender, EventArgs e)
        {
            syncDeptId = Int64.Parse(cboDepartments.SelectedValue.ToString());
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

        private void LoadDepartmentStockInToFileForm_Load(object sender, EventArgs e)
        {
            
            this.departmentTableAdapter.Fill(this.masterDB.Department);

        }
    }
}
