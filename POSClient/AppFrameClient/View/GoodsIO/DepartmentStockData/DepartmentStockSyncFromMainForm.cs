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
            if (String.IsNullOrEmpty(txtFilePath.Text))
            {
                MessageBox.Show("Không tìm thấy file đồng bộ");
                return;
            }
            if (!File.Exists(txtFilePath.Text))
            {
                MessageBox.Show("File đồng bộ không tồn tại");
                return;
            }
            DepartmentStockIn deptStockIn = null;
            try
            {
                Stream stream = File.Open(txtFilePath.Text, FileMode.Open);
                BinaryFormatter bf = new BinaryFormatter();
                deptStockIn = (DepartmentStockIn)bf.Deserialize(stream);
                stream.Close();

                if (deptStockIn == null 
                    || deptStockIn.DepartmentStockInPK == null 
                    || deptStockIn.DepartmentStockInPK.DepartmentId != CurrentDepartment.Get().DepartmentId)
                {
                    MessageBox.Show("File đồng bộ bị lỗi");
                    return;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("File đồng bộ bị lỗi");
            }
            if (deptStockIn != null)
            {
                var eventArgs = new DepartmentStockInEventArgs();
                eventArgs.DepartmeneStockIn = deptStockIn;
                EventUtility.fireEvent(SyncDepartmentStockInEvent, this, eventArgs);
                MessageBox.Show("Đồng bộ hoàn tất !");
            }
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
    }
}
