using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.Model;
using AppFrame.Presenter.Masters;
using AppFrame.Utility;
using AppFrame.View.Masters;

namespace AppFrameClient.View.Masters
{
    public partial class UniversalMasterCreateForm : Form, IUniversalMasterSaveView
    {
        #region Members
        public MasterType MasterType { get; set; }
        public long Id { get; set; }
        public object CreatedItem { get; set; }
        public bool IsNeedClosing { get; set; }
        #endregion

        public UniversalMasterCreateForm()
        {
            InitializeComponent();
        }

        private void UniversalMasterCreateForm_Load(object sender, EventArgs e)
        {
            switch (MasterType)
            {
                case MasterType.PRODUCT_TYPE:
                    lblLabel.Text = "Nhập loại sản phẩm";
                    break;
                case MasterType.PRODUCT_SIZE:
                    lblLabel.Text = "Nhập kích thước";
                    break;
                case MasterType.PRODUCT_COLOR:
                    lblLabel.Text = "Nhập màu sắc";
                    break;
                case MasterType.COUNTRY:
                    lblLabel.Text = "Nhập xuất xứ";
                    break;
                case MasterType.DISTRIBUTOR:
                    lblLabel.Text = "Nhập nhà phân phối";
                    break;
                case MasterType.MANUFACTURER:
                    lblLabel.Text = "Nhập nhà sản xuất";
                    break;
                case MasterType.PACKAGER:
                    lblLabel.Text = "Nhập nhà đóng gói";
                    break;
                default:
                    break;
            }
            if (Id != 0)
            {
                txtId.Text = Id + "";
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var eventArgs = new UniversalMasterSaveEventArgs {Id = Id, MasterType = MasterType, Name = textBox1.Text};
            EventUtility.fireEvent(SaveUniversalMasterEvent, this, eventArgs);
            CreatedItem = eventArgs.CreatedData;
            if (IsNeedClosing)
            {
                Close();
            }
        }

        public IUniversalMasterSaveController _universalMasterSaveController;
        public IUniversalMasterSaveController UniversalMasterSaveController 
        { 
            get
            {
                return _universalMasterSaveController;
            }
            set
            {
                _universalMasterSaveController = value;
                _universalMasterSaveController.UniversalMasterSaveView = this;
            } 
        }
        public event EventHandler<UniversalMasterSaveEventArgs> SaveUniversalMasterEvent;
    }
}
