using System;
using System.Collections;
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
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;

namespace AppFrameClient.View.GoodsIO.DepartmentStockData
{
    public partial class SyncToMainForm : BaseForm, IDepartmentStockOutView
    {
        public SyncToMainForm()
        {
            InitializeComponent();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            // Create new SaveFileDialog object
            SaveFileDialog DialogSave = new SaveFileDialog();

            // Default file extension
            DialogSave.DefaultExt = "xac";

            // Available file extensions
            DialogSave.Filter = "POS file (*.xac)|*.xac";

            // Adds a extension if the user does not
            DialogSave.AddExtension = true;

            // Restores the selected directory, next time
            DialogSave.RestoreDirectory = true;

            // Startup directory
            DialogSave.InitialDirectory = @"C:/";
            // Show the dialog and process the result
            if (DialogSave.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var eventArgs = new DepartmentStockOutEventArgs();
                    EventUtility.fireEvent(GetSyncDataEvent, this, eventArgs);
                    SyncFromDepartmentToMain syncData = eventArgs.SyncFromDepartmentToMain;
                    if (syncData != null)
                    {
                        Stream stream = File.Open(DialogSave.FileName, FileMode.Create);
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(stream, syncData);
                        stream.Close();
                        MessageBox.Show("Đồng bộ thành công");
                    }
                    else
                    {
                        MessageBox.Show("Đồng bộ thất bại");
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("Có lỗi xảy ra");
                    throw;
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

        private void btnSyncToMain_Click(object sender, EventArgs e)
        {
            var fileOpen = new OpenFileDialog();
            fileOpen.InitialDirectory = ".\\";
            fileOpen.Filter = "POS (*.xac)|*.xac";
            fileOpen.FilterIndex = 0;
            fileOpen.RestoreDirectory = true;
            if (fileOpen.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileOpen.FileName;
                if (String.IsNullOrEmpty(filePath))
                {
                    MessageBox.Show("Không tìm thấy file đồng bộ");
                    return;
                }
                if (!File.Exists(filePath))
                {
                    MessageBox.Show("File đồng bộ không tồn tại");
                    return;
                }
                SyncFromDepartmentToMain deptStockIn = null;
                try
                {
                    Stream stream = File.Open(filePath, FileMode.Open);
                    BinaryFormatter bf = new BinaryFormatter();
                    deptStockIn = (SyncFromDepartmentToMain)bf.Deserialize(stream);
                    stream.Close();

                    if (deptStockIn == null)
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
                    var eventArgs = new DepartmentStockOutEventArgs();
                    eventArgs.SyncFromDepartmentToMain = deptStockIn;
                    EventUtility.fireEvent(SyncToMainEvent, this, eventArgs);
                    if (eventArgs.EventResult != null)
                    {
                        MessageBox.Show("Đồng bộ hoàn tất !");
                    }
                    else
                    {
                        MessageBox.Show("Đồng bộ thất bại!");
                    }
                }
            }
        }
    }
}
