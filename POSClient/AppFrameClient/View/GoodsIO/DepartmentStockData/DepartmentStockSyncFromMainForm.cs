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
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrameClient.Presenter.GoodsIO.DepartmentStockData;

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
                    EventUtility.fireEvent(LoadDepartemntStockInForExportEvent, this, deptEvent);

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
                            EventUtility.fireEvent(UpdateDepartemntStockInForExportEvent, this, eventArgs);

                        }
                    }
                }
            }
            catch (Exception)
            {

            }
            MessageBox.Show("Đồng bộ hoàn tất !");
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
        public event EventHandler<DepartmentStockInEventArgs> LoadDepartemntStockInForExportEvent;
        public event EventHandler<DepartmentStockInEventArgs> UpdateDepartemntStockInForExportEvent;

        #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSyncToMain_Click(object sender, EventArgs e)
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
            IList resultList = new ArrayList();
            StringBuilder errorStr = new StringBuilder();
            foreach (string fileName in fileNames)
            {
                SyncResult result = new SyncResult();
                result.FileName = fileName;
                resultList.Add(result);
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
//                        errorStr.Append("   > " + fileName.Substring(fileName.LastIndexOf("\\"), fileName.Length - fileName.LastIndexOf("\\")) + "\r\n");
                        result.Status = "Thất bại";
                    }
                    else
                    {
                        File.Move(fileName, successPath + "\\" + fileName.Substring(fileName.LastIndexOf("\\"), fileName.Length - fileName.LastIndexOf("\\")));
                        result.Status = "Thành công";
                    }
                }
            }
            MessageBox.Show("Đồng bộ hoàn tất !");
            syncResultBindingSource.DataSource = resultList;
//            if (errorStr.Length > 0)
//            {
//                MessageBox.Show("Có lỗi diễn ra: \r\n" + errorStr.ToString());
//            }
//            else
//            {
//                
//            }

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
    }
}
