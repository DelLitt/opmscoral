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
        public event EventHandler<DepartmentStockInEventArgs> LoadDepartemntStockInForExportEvent;
        public event EventHandler<DepartmentStockInEventArgs> UpdateDepartemntStockInForExportEvent;

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
        private void btnSyncToMain_Click(object sender, EventArgs e)
        {
            if(!CheckPOSSyncDriveExist())
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
            var exportPath = POSSyncDrive + ClientSetting.SyncExportPath;
            if (string.IsNullOrEmpty(exportPath) || !Directory.Exists(exportPath))
            {
                MessageBox.Show("Không thể tìm thấy đường dẫn đến thư mục " + exportPath + "!Hãy kiễm tra file cấu hình phần SyncExportPath");
                return;
            }
            IList resultList = new ArrayList();
            try
            {
                var deptEvent = new DepartmentStockInEventArgs();
                EventUtility.fireEvent(FillDepartmentEvent, this, deptEvent);

                IList departmentList = deptEvent.DepartmentList;
                foreach (Department department in departmentList)
                {
                    exportPath = ClientUtility.EnsureExportPath(exportPath, department);
                    DateTime lastSyncTime = ClientUtility.GetLastSyncTime(exportPath,department);
                    deptEvent = new DepartmentStockInEventArgs();
                    deptEvent.LastSyncTime = lastSyncTime;
                    deptEvent.Department = department;
                    EventUtility.fireEvent(LoadDepartemntStockInForExportEvent, this, deptEvent);

                    if(deptEvent.SyncFromMainToDepartment!=null 
                        && deptEvent.SyncFromMainToDepartment.StockOutList!=null
                        && deptEvent.SyncFromMainToDepartment.StockOutList.Count > 0 )
                    {
                        string fileName = exportPath + "\\" + department.DepartmentId + "_SyncDown_" + 
                                                              DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + CommonConstants.SERVER_SYNC_FORMAT;
                        SyncResult result = new SyncResult();
                        result.FileName = fileName;
                        result.Status = "Thành công";
                        resultList.Add(result);
                        Stream stream = File.Open(fileName, FileMode.Create);
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(stream, deptEvent.SyncFromMainToDepartment);
                        stream.Close();    
                        // write last sync time
                        ClientUtility.WriteLastSyncTime(exportPath,department);
                    }
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
            MessageBox.Show("Đồng bộ hoàn tất !");
            syncResultBindingSource.DataSource = resultList;
        }
    }
}
