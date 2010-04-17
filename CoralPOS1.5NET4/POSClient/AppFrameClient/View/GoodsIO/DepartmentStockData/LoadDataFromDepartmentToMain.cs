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
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Utility;
using AppFrame.View;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrameClient.Common;
using AppFrameClient.Utility;
using InfoBox;
using ArrayList=System.Collections.ArrayList;

namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    public partial class LoadDataFromDepartmentToMain : BaseForm, IDepartmentStockOutView
    {
        public LoadDataFromDepartmentToMain()
        {
            InitializeComponent();
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

        private void btnSyncToMain_Click(object sender, EventArgs e)
        {
            BackgroundWorker backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += new DoWorkEventHandler(backgroundWorker_DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker_RunWorkerCompleted);
            this.Enabled = false;
            backgroundWorker.RunWorkerAsync();
            
        }

        IList resultList = new ArrayList();

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Enabled = true;
            ((MainForm)GlobalCache.Instance().MainForm).stopProgressBar();
            InfoBox.InformationBox.Show("Đồng bộ hoàn tất !", new AutoCloseParameters(1));

            if (resultList != null)
            {
                syncResultBindingSource.DataSource = resultList;
            }
            
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            resultList = new ArrayList();
            if (!CheckPOSSyncDriveExist())
                return;
            string POSSyncDrive = ClientUtility.GetPOSSyncDrives()[0].ToString();
            DialogResult dResult = MessageBox.Show(
                "Bạn muốn đồng bộ từ cửa hàng ? ",
                "Đồng bộ", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (dResult == DialogResult.No)
            {
                return;
            }
            ((MainForm)GlobalCache.Instance().MainForm).showProgressBar();
            var configurationAppSettings = new AppSettingsReader();
            //var importPath = (string)configurationAppSettings.GetValue("SyncImportPath", typeof(String));
            var importPath = POSSyncDrive + ClientSetting.SyncImportPath;
            //var successPath = (string)configurationAppSettings.GetValue("SyncImportSuccessPath", typeof(String));
            //var errorPath = (string)configurationAppSettings.GetValue("SyncImportErrorPath", typeof(String));

            var successPath = POSSyncDrive + ClientSetting.SyncSuccessPath;
            var errorPath = POSSyncDrive + ClientSetting.SyncErrorPath;
            // get import path of this department

            if (string.IsNullOrEmpty(importPath) || !Directory.Exists(importPath))
            {
                MessageBox.Show("Không thể tìm thấy đường dẫn đến thư mục " + importPath + "!Hãy kiễm tra file cấu hình phần SyncImportPath");
                return;
            }

            if (string.IsNullOrEmpty(successPath) || !Directory.Exists(successPath))
            {
                MessageBox.Show("Không thể tìm thấy đường dẫn đến thư mục " + successPath + "!Hãy kiễm tra file cấu hình phần SyncImportSuccessPath");
                return;
            }

            if (string.IsNullOrEmpty(errorPath) || !Directory.Exists(errorPath))
            {
                MessageBox.Show("Không thể tìm thấy đường dẫn đến thư mục " + errorPath + "!Hãy kiễm tra file cấu hình phần SyncImportErrorPath");
                return;
            }

            //string[] fileNames = Directory.GetFiles(importPath, "*"+CommonConstants.CLIENT_SYNC_FORMAT);
            string[] syncDirs = Directory.GetDirectories(importPath);
            IList fileNames = new ArrayList();
            foreach (string syncDir in syncDirs)
            {
                string[] deptFileNames = Directory.GetFiles(syncDir, "*" + CommonConstants.CLIENT_SYNC_FORMAT);
                foreach (string deptFileName in deptFileNames)
                {
                    fileNames.Add(deptFileName);
                }
            }
            if (fileNames.Count == 0)
            {
                MessageBox.Show("Không thể tìm thấy file nào để đồng bộ");
                return;
            }

            StringBuilder errorStr = new StringBuilder();
            foreach (string fileName in fileNames)
            {
                SyncResult result = new SyncResult();
                result.FileName = fileName;
                resultList.Add(result);
                SyncFromDepartmentToMain deptStockIn = null;
                Stream stream = null;
                bool fail = true;
                try
                {
                    stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    deptStockIn = (SyncFromDepartmentToMain)bf.Deserialize(stream);

                    if (deptStockIn == null)
                    {
                        fail = true;
                    }
                    else
                    {
                        var eventArgs = new DepartmentStockOutEventArgs();
                        eventArgs.SyncFromDepartmentToMain = deptStockIn;
                        EventUtility.fireEvent(SyncToMainEvent, this, eventArgs);
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
                        //                        errorStr.Append("   > " + fileName.Substring(fileName.LastIndexOf("\\"), fileName.Length - fileName.LastIndexOf("\\")) + "\r\n");
                        result.Status = "Thất bại";
                    }
                    else
                    {
                        //File.Move(fileName, successPath + "\\" + fileName.Substring(fileName.LastIndexOf("\\"), fileName.Length - fileName.LastIndexOf("\\")));
                        ClientUtility.MoveFileToSpecificDir(successPath, fileName);
                        string origFileName = fileName.Substring(fileName.LastIndexOf("\\") + 1, fileName.Length - (fileName.LastIndexOf("\\") + 1));
                        string[] separateFileNames = origFileName.Split('.');
                        string updateTimeStr =
                            separateFileNames[0].Substring(separateFileNames[0].IndexOf("_SyncUp_") + 8);
                        DateTime updateTime = DateTime.ParseExact(updateTimeStr, "yyyy_MM_dd_HH_mm_ss", null);
                        string syncPath = fileName.Substring(0, fileName.LastIndexOf("\\"));
                        long deptId = Int32.Parse(origFileName.Substring(0, origFileName.IndexOf("_")));
                        Department department = new Department { DepartmentId = deptId };
                        ClientUtility.WriteLastSyncTime(updateTime, syncPath, department, ClientUtility.SyncType.SyncUp);
                        result.Status = "Thành công";
                    }
                }
            }
            
        }

        #region Implementation of IDepartmentStockOutView

        public event EventHandler<DepartmentStockOutEventArgs> FindBarcodeEvent;
        public event EventHandler<DepartmentStockOutEventArgs> SaveStockOutEvent;
        public event EventHandler<DepartmentStockOutEventArgs> FillProductToComboEvent;
        public event EventHandler<DepartmentStockOutEventArgs> LoadGoodsByNameEvent;
        public event EventHandler<DepartmentStockOutEventArgs> LoadProductColorEvent;
        public event EventHandler<DepartmentStockOutEventArgs> LoadProductSizeEvent;
        public event EventHandler<DepartmentStockOutEventArgs> LoadStockStatusEvent;
        public event EventHandler<DepartmentStockOutEventArgs> LoadGoodsByNameColorSizeEvent;
        public event EventHandler<DepartmentStockOutEventArgs> GetSyncDataEvent;
        public event EventHandler<DepartmentStockOutEventArgs> SyncToMainEvent;
        public event EventHandler<DepartmentStockOutEventArgs> LoadAllDepartments;
        public event EventHandler<DepartmentStockOutEventArgs> DispatchDepartmentStockOut;
        public event EventHandler<DepartmentStockOutEventArgs> PrepareDepartmentStockOutForPrintEvent;
        public event EventHandler<DepartmentStockOutEventArgs> FindByStockInIdEvent;

        private IDepartmentStockOutController _mainStockOutController;
        public IDepartmentStockOutController DepartmentStockOutController
        {
            set
            {
                _mainStockOutController = value;
                _mainStockOutController.DepartmentStockOutView = this;
            }
        }
        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
