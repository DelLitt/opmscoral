using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.MainStock;
using AppFrameClient.ViewModel;

namespace AppFrameClient.View.GoodsIO.MainStock
{
   
    public partial class BaseStockOutForm : AppFrame.Common.BaseForm,IBaseStockOutView
    {
        protected StockViewCollection stockViewList = null;
        protected StockDefectCollection stockDefectList = null;
        protected StockOutDetailCollection stockOutList = null;

        protected DepartmentStockDefectCollection deptStockDefectList = null;
        protected DepartmentStockOutDetailCollection deptStockOutList = null;
        
        public BaseStockOutForm()
        {
            InitializeComponent();
        }

        private void TemporaryStockOutForm_Load(object sender, EventArgs e)
        {
            stockViewList = new StockViewCollection(bdsProductMasters);
            bdsProductMasters.DataSource = stockViewList;

            if (!DepartmentReturnForm)
            {
                stockDefectList = new StockDefectCollection(bdsStockDefect);
                bdsStockDefect.DataSource = stockDefectList;
                bdsStockDefect.ResetBindings(true);

                stockOutList = new StockOutDetailCollection(bdsStockOut);
                bdsStockOut.DataSource = stockOutList;
                bdsStockOut.ResetBindings(true);
                LoadGoodsToCombo();
            }
            else
            {
                deptStockDefectList = new DepartmentStockDefectCollection(bdsStockDefect);
                bdsStockDefect.DataSource = deptStockDefectList;
                bdsStockDefect.ResetBindings(true);

                deptStockOutList = new DepartmentStockOutDetailCollection(bdsStockOut);
                bdsStockOut.DataSource = deptStockOutList;
                bdsStockOut.ResetBindings(true);

                rdoTraHang.Visible = false;
                rdoTamXuat.Visible = false;
                lblTitle.Text = " TRẢ HÀNG VỀ KHO CHÍNH";
                lblStockOut.Text = " Trả hàng về kho chính";
                LoadDeptGoodsToCombo();                         
            }
            
        }

        private void LoadDeptGoodsToCombo()
        {
            BaseStockOutEventArgs checkingEventArgs = new BaseStockOutEventArgs();
            EventUtility.fireEvent(FillDeptGoodsToCombo, this, checkingEventArgs);
            stockViewList.Clear();
            foreach (StockView obj in checkingEventArgs.ReturnStockViewList)
            {
                stockViewList.Add((StockView)obj);
            }

            bdsProductMasters.EndEdit();
        }

        public virtual void LoadGoodsToCombo()
        {
            BaseStockOutEventArgs checkingEventArgs = new BaseStockOutEventArgs();
            EventUtility.fireEvent(FillGoodsToCombo, this, checkingEventArgs);
            stockViewList.Clear();
            foreach (StockView obj in checkingEventArgs.ReturnStockViewList)
            {
                stockViewList.Add((StockView)obj);
            }
            
            bdsProductMasters.EndEdit();
        }

        #region IBaseStockOutView Members

        private AppFrame.Presenter.GoodsIO.MainStock.IBaseStockOutController baseStockOutController;
        public AppFrame.Presenter.GoodsIO.MainStock.IBaseStockOutController BaseStockOutController
        {
            get
            {
                return baseStockOutController;
            }
            set
            {
                baseStockOutController = value;
                baseStockOutController.BaseStockOutView = this;
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            if (!DepartmentReturnForm)
            {
                if (stockOutList.Count == 0)
                {
                    MessageBox.Show("Không có hàng để xuất");
                    return;
                }
                BaseStockOutEventArgs checkingEventArgs = new BaseStockOutEventArgs();
                checkingEventArgs.SaveStockDefectList = ObjectConverter.ConvertToNonGenericList(stockDefectList);
                checkingEventArgs.SaveStockOutList = ObjectConverter.ConvertToNonGenericList(stockOutList);

                foreach (StockOutDetail stockOutDetail in checkingEventArgs.SaveStockOutList)
                {
                    if (rdoTamXuat.Checked)
                    {
                        stockOutDetail.DefectStatus = new StockDefectStatus {DefectStatusId = 4};
                    }
                    else
                    {
                        stockOutDetail.DefectStatus = new StockDefectStatus {DefectStatusId = 5};
                    }
                }

                EventUtility.fireEvent(SaveTempStockOut, this, checkingEventArgs);
                StockOutDetail detail =
                    (StockOutDetail) checkingEventArgs.SaveStockOutList[checkingEventArgs.SaveStockOutList.Count - 1];
                if (detail.StockOutDetailId > 0)
                {
                    MessageBox.Show("Lưu thành công !");
                    ClearForm();
                }
            }
            else // department return form
            {
                if (deptStockOutList.Count == 0)
                {
                    MessageBox.Show("Không có hàng để xuất");
                    return;
                }
                BaseStockOutEventArgs checkingEventArgs = new BaseStockOutEventArgs();
                checkingEventArgs.SaveDeptStockDefectList = ObjectConverter.ConvertToNonGenericList(deptStockDefectList);
                checkingEventArgs.SaveDeptStockOutList = ObjectConverter.ConvertToNonGenericList(deptStockOutList);
                
                EventUtility.fireEvent(SaveDeptTempStockOut, this, checkingEventArgs);
                DepartmentStockOutDetail detail =
                    (DepartmentStockOutDetail)checkingEventArgs.SaveDeptStockOutList[checkingEventArgs.SaveDeptStockOutList.Count - 1];
                if (detail.DepartmentStockOutDetailPK.StockOutId > 0)
                {
                    MessageBox.Show("Lưu thành công !");
                    ClearForm();
                }
            }
        }

        private void ClearForm()
        {
            txtDescription.Text = "";
            txtProductName.Text = "";
            txtProductType.Text = "";
            txtStockQuantity.Text = "";
            pictureBox1.ImageLocation = "";
            deptStockDefectList.Clear();
            deptStockOutList.Clear();
            bdsStockDefect.EndEdit();
            bdsStockOut.EndEdit();
            dgvTempStockOut.Refresh();
            dgvTempStockOut.Invalidate();
            dgvStockDefect.Refresh();
            dgvStockDefect.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region IBaseStockOutView Members


        public event EventHandler<BaseStockOutEventArgs> FillGoodsToCombo;
        

        public event EventHandler<BaseStockOutEventArgs> SaveTempStockOut;

        #endregion

        private void cboProductMasters_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboProductMasters.SelectedIndex <0)
                return;
            
                StockView stockView = (StockView) bdsProductMasters[cboProductMasters.SelectedIndex];
                ProductMaster master = stockView.ProductMaster;
                if (master.ProductType != null)
                    txtProductType.Text = master.ProductType.TypeName;

                txtDescription.Text = master.Description;
                txtStockQuantity.Text = stockView.StockQuantity.ToString();
                txtProductName.Text = stockView.ProductDisplayName;
                pictureBox1.ImageLocation = master.ImagePath;
                
                LoadGoodsByName(master);
                
        }

        private void LoadGoodsByName(ProductMaster master)
        {
            if (!DepartmentReturnForm)
            {
                stockDefectList.Clear();
                BaseStockOutEventArgs eventArgs = new BaseStockOutEventArgs();
                eventArgs.RequestProductMaster = master;
                EventUtility.fireEvent(LoadGoodsByNameEvent, this, eventArgs);

                foreach (StockDefect stockDefect in eventArgs.ReturnStockDefectList)
                {
                    stockDefectList.Add(stockDefect);
                }
            }
            else
            {
                deptStockDefectList.Clear();
                BaseStockOutEventArgs eventArgs = new BaseStockOutEventArgs();
                eventArgs.RequestProductMaster = master;
                EventUtility.fireEvent(LoadDeptGoodsByNameEvent, this, eventArgs);

                foreach (DepartmentStockDefect stockDefect in eventArgs.ReturnDeptStockDefectList)
                {
                    deptStockDefectList.Add(stockDefect);
                }
                
            }
            bdsStockDefect.EndEdit();
            bdsStockDefect.ResetBindings(true);
            dgvStockDefect.Refresh();
            dgvStockDefect.Invalidate();

        }

        #region IBaseStockOutView Members


        public event EventHandler<BaseStockOutEventArgs> LoadGoodsByNameEvent;

        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!DepartmentReturnForm)
            {
                if (dgvStockDefect.CurrentCell == null)
                    return;

                if (HasInList(stockDefectList[dgvStockDefect.CurrentCell.OwningRow.Index], stockOutList))
                {
                    return;
                }
                if (stockDefectList[dgvStockDefect.CurrentCell.OwningRow.Index].ErrorCount == 0)
                {
                    MessageBox.Show("Lượng lỗi của mặt hàng này là không");
                    return;
                }
                StockOutDetail soDetail = stockOutList.AddNew();
                soDetail.Product = stockDefectList[dgvStockDefect.CurrentCell.OwningRow.Index].Product;
                soDetail.DelFlg = 0;
                soDetail.Quantity = stockDefectList[dgvStockDefect.CurrentCell.OwningRow.Index].ErrorCount;
                soDetail.CreateDate = DateTime.Now;
                soDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                soDetail.UpdateDate = DateTime.Now;
                soDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

                // 4 : Xuat tam de sua hang
                soDetail.DefectStatus = new StockDefectStatus {DefectStatusId = 4};
                soDetail.ProductId = soDetail.Product.ProductId;

                bdsStockOut.EndEdit();
                dgvTempStockOut.Refresh();
                dgvTempStockOut.Invalidate();
            }
            else    // department return form
            {
                if (dgvStockDefect.CurrentCell == null)
                    return;

                if (HasInDeptList(deptStockDefectList[dgvStockDefect.CurrentCell.OwningRow.Index], deptStockOutList))
                {
                    return;
                }
                if (deptStockDefectList[dgvStockDefect.CurrentCell.OwningRow.Index].ErrorCount == 0)
                {
                    MessageBox.Show("Lượng lỗi của mặt hàng này là không");
                    return;
                }
                DepartmentStockOutDetail soDetail = deptStockOutList.AddNew();
                soDetail.Product = deptStockDefectList[dgvStockDefect.CurrentCell.OwningRow.Index].Product;
                soDetail.DelFlg = 0;
                soDetail.Quantity = deptStockDefectList[dgvStockDefect.CurrentCell.OwningRow.Index].ErrorCount;
                soDetail.CreateDate = DateTime.Now;
                soDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                soDetail.UpdateDate = DateTime.Now;
                soDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                soDetail.DepartmentId = CurrentDepartment.Get().DepartmentId;
                soDetail.DepartmentStockOutDetailPK = new DepartmentStockOutDetailPK { DepartmentId = soDetail.DepartmentId,ProductId = soDetail.Product.ProductId};
                // 6 : Xuat tam de sua hang
                //soDetail.DefectStatus = new StockDefectStatus { DefectStatusId = 6 };
                soDetail.ProductId = soDetail.Product.ProductId;

                bdsStockOut.EndEdit();
                dgvTempStockOut.Refresh();
                dgvTempStockOut.Invalidate();                
            }
        }

        private bool HasInDeptList(DepartmentStockDefect defect, DepartmentStockOutDetailCollection list)
        {
            foreach (DepartmentStockOutDetail detail in list)
            {
                if (detail.Product.ProductId == defect.Product.ProductId)
                {
                    return true;
                }
            }
            return false;
        }

        private bool HasInList(StockDefect defect, StockOutDetailCollection list)
        {
            foreach (StockOutDetail detail in list)
            {
                if(detail.Product.ProductId == defect.Product.ProductId)
                {
                    return true;
                }
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
            if (dgvTempStockOut.CurrentCell == null)
                return;
            if (!DepartmentReturnForm)
            {
                stockOutList.RemoveAt(dgvTempStockOut.CurrentCell.OwningRow.Index);
                
            }
            else
            {
                deptStockOutList.RemoveAt(dgvTempStockOut.CurrentCell.OwningRow.Index);
            }
            bdsStockOut.EndEdit();
            dgvTempStockOut.Refresh();
            dgvTempStockOut.Invalidate();
        }

        private void btnLoadDefect_Click(object sender, EventArgs e)
        {

        }

        private void btnUncheckAll_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckAll_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        #region IBaseStockOutView Members


        public bool DepartmentReturnForm
        {
            get;set;
            
        }

        #endregion

        #region IBaseStockOutView Members


        public event EventHandler<BaseStockOutEventArgs> FillDeptGoodsToCombo;

        public event EventHandler<BaseStockOutEventArgs> SaveDeptTempStockOut;

        public event EventHandler<BaseStockOutEventArgs> LoadDeptGoodsByNameEvent;

        #endregion
    }
}
