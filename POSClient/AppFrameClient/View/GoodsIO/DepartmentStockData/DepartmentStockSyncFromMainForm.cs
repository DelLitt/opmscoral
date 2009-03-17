using System;
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
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;

namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    public partial class DepartmentStockSyncFromMainForm : BaseForm, IDepartmentStockInView
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

            var configurationAppSettings = new AppSettingsReader();
            var importPath = (string)configurationAppSettings.GetValue("SyncImportPath", typeof(String));
            if (string.IsNullOrEmpty(importPath) || !Directory.Exists(importPath))
            {
                MessageBox.Show("Không thể tìm thấy đường dẫn đến thư mục " + importPath + "!Hãy kiễm tra file cấu hình phần SyncImportPath");
                return;
            }
            var successPath = (string)configurationAppSettings.GetValue("SyncImportSuccessPath", typeof(String));
            if (string.IsNullOrEmpty(successPath) || !Directory.Exists(successPath))
            {
                MessageBox.Show("Không thể tìm thấy đường dẫn đến thư mục " + successPath + "!Hãy kiễm tra file cấu hình phần SyncImportSuccessPath");
                return;
            }
            var errorPath = (string)configurationAppSettings.GetValue("SyncImportErrorPath", typeof(String));
            if (string.IsNullOrEmpty(errorPath) || !Directory.Exists(errorPath))
            {
                MessageBox.Show("Không thể tìm thấy đường dẫn đến thư mục " + errorPath + "!Hãy kiễm tra file cấu hình phần SyncImportErrorPath");
                return;
            }

            string[] fileNames = Directory.GetFiles(importPath, "*.xac");

            if (fileNames.Length == 0)
            {
                MessageBox.Show("Không thể tìm thấy file nào để đồng bộ");
                return;
            }
            StringBuilder errorStr = new StringBuilder();
            foreach (string fileName in fileNames)
            {
                DepartmentStockIn deptStockIn = null;
                Stream stream = null;
                bool fail = true;
                try
                {
                    stream = File.Open(fileName, FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    deptStockIn = (DepartmentStockIn)bf.Deserialize(stream);
                    if (deptStockIn == null
                    || deptStockIn.DepartmentStockInPK == null
                    || deptStockIn.DepartmentStockInPK.DepartmentId != CurrentDepartment.Get().DepartmentId)
                    {
                        fail = true;
                    }
                    else
                    {
                        var eventArgs = new DepartmentStockInEventArgs();
                        eventArgs.DepartmentStockIn = deptStockIn;
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
                finally
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                    if (fail)
                    {
                        File.Move(importPath, errorPath + "\\" + fileName.Substring(fileName.LastIndexOf("\\"), fileName.Length - fileName.LastIndexOf("\\")));
                        errorStr.Append("   > " + fileName.Substring(fileName.LastIndexOf("\\"), fileName.Length - fileName.LastIndexOf("\\")) + "\r\n");
                    }
                    else
                    {
                        File.Move(fileName, successPath + "\\" + fileName.Substring(fileName.LastIndexOf("\\"), fileName.Length - fileName.LastIndexOf("\\")));
                    }
                }
            }
            if (errorStr.Length > 0)
            {
                MessageBox.Show("Có lỗi diễn ra: \r\n" + errorStr.ToString());
            }
            else
            {
                MessageBox.Show("Đồng bộ hoàn tất !");
            }

//            if (String.IsNullOrEmpty(txtFilePath.Text))
//            {
//                MessageBox.Show("Không tìm thấy file đồng bộ");
//                return;
//            }
//            if (!File.Exists(txtFilePath.Text))
//            {
//                MessageBox.Show("File đồng bộ không tồn tại");
//                return;
//            }
//            DepartmentStockIn deptStockIn = null;
//            try
//            {
//                Stream stream = File.Open(txtFilePath.Text, FileMode.Open);
//                BinaryFormatter bf = new BinaryFormatter();
//                deptStockIn = (DepartmentStockIn)bf.Deserialize(stream);
//                stream.Close();
//
//                if (deptStockIn == null 
//                    || deptStockIn.DepartmentStockInPK == null 
//                    || deptStockIn.DepartmentStockInPK.DepartmentId != CurrentDepartment.Get().DepartmentId)
//                {
//                    MessageBox.Show("File đồng bộ bị lỗi");
//                    return;
//                }
//            }
//            catch (Exception)
//            {
//                MessageBox.Show("File đồng bộ bị lỗi");
//            }
//            if (deptStockIn != null)
//            {
//                var eventArgs = new DepartmentStockInEventArgs();
//                eventArgs.DepartmentStockIn = deptStockIn;
//                EventUtility.fireEvent(SyncDepartmentStockInEvent, this, eventArgs);
//                MessageBox.Show("Đồng bộ hoàn tất !");
//            }
        }

        #region Implementation of IDepartmentStockInView

        private IDepartmentStockInController _departmentStockInController;
        public IDepartmentStockInController DepartmentStockInController
        {
            set
            {
                _departmentStockInController = value;
                _departmentStockInController.DepartmentStockInView = this;
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

        #endregion
    }
}
