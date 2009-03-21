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

        private void btnSyncToMain_Click(object sender, EventArgs e)
        {
            var configurationAppSettings = new AppSettingsReader();
            var exportPath = (string)configurationAppSettings.GetValue("SyncExportPath", typeof(String));
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
                    deptEvent = new DepartmentStockInEventArgs();
                    deptEvent.Department = department;
                    EventUtility.fireEvent(LoadDepartemntStockInForExportEvent, this, deptEvent);

                    if (deptEvent.DepartmentStockInList != null && deptEvent.DepartmentStockInList.Count > 0)
                    {
                        foreach (DepartmentStockIn stockIn in deptEvent.DepartmentStockInList)
                        {
                            string fileName = exportPath + "\\" + department.DepartmentName + "_" + department.Address + " - Ma lo_" + stockIn.DepartmentStockInPK.StockInId + "_" +
                                                              stockIn.StockInDate.ToString("yyyy_MM_dd_HH_mm_ss") + ".xac";
                            SyncResult result = new SyncResult();
                            result.FileName = fileName;
                            result.Status = "Thành công";
                            resultList.Add(result);
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
                throw;
            }
            MessageBox.Show("Đồng bộ hoàn tất !");
            syncResultBindingSource.DataSource = resultList;
        }
    }
}
