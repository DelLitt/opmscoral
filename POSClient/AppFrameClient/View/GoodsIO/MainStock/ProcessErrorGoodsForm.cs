using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Exceptions;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.MainStock;
using AppFrameClient.ViewModel;

namespace AppFrameClient.View.GoodsIO.MainStock
{
    public partial class ProcessErrorGoodsForm : BaseForm,IProcessErrorGoodsView
    {
        private StockOutDetailCollection returnGoodsList;
        private StockOutDetailCollection tempStockOutList;
        private StockOutDetailCollection destroyGoodsList;
        private StockCollection stockDefectList;

        private DepartmentStockOutDetailCollection deptReturnGoodsList;
        private DepartmentStockOutDetailCollection deptTempStockOutList;
        private DepartmentStockOutDetailCollection deptDestroyGoodsList;
        private DepartmentStockCollection deptStockDefectList;

        public bool DepartmentProcessing
        {
            get;
            set;
        }
        public ProcessErrorGoodsForm()
        {
            InitializeComponent();
        }

        #region IProcessErrorGoodsView Members

        private AppFrame.Presenter.GoodsIO.MainStock.IProcessErrorGoodsController processErrorGoodsController;
        public AppFrame.Presenter.GoodsIO.MainStock.IProcessErrorGoodsController ProcessErrorGoodsController
        {
            get
            {
                return processErrorGoodsController;
            }
            set
            {
                processErrorGoodsController = value;
                processErrorGoodsController.ProcessErrorGoodsView = this;
            }
        }

        public event EventHandler<AppFrame.Presenter.GoodsIO.MainStock.ProcessErrorGoodsEventArgs> LoadAllStockDefects;

        public event EventHandler<AppFrame.Presenter.GoodsIO.MainStock.ProcessErrorGoodsEventArgs> SaveStockDefects;

        #endregion

        private void ProcessErrorGoodsForm_Load(object sender, EventArgs e)
        {
            if (!DepartmentProcessing)
            {
                returnGoodsList = new StockOutDetailCollection(bdsReturnGoods);
                tempStockOutList = new StockOutDetailCollection(bdsTempStockOut);
                destroyGoodsList = new StockOutDetailCollection(bdsDestroyGoods);
                stockDefectList = new StockCollection(bdsStockDefect);

                bdsReturnGoods.ResetBindings(true);
                bdsTempStockOut.ResetBindings(true);
                bdsDestroyGoods.ResetBindings(true);
                bdsStockDefect.ResetBindings(true);
                
                LoadStockDefects();
            }
            else
            {
                deptReturnGoodsList= new DepartmentStockOutDetailCollection(bdsReturnGoods);
                deptTempStockOutList= new DepartmentStockOutDetailCollection(bdsTempStockOut);
                deptDestroyGoodsList= new DepartmentStockOutDetailCollection(bdsDestroyGoods);
                deptStockDefectList= new DepartmentStockCollection(bdsStockDefect);
                bdsReturnGoods.ResetBindings(true);
                bdsTempStockOut.ResetBindings(true);
                bdsDestroyGoods.ResetBindings(true);
                bdsStockDefect.ResetBindings(true);
                lblReturnGoods.Text = "Trả hàng lỗi về cho kho chính";    
                LoadDepartmentStockDefects();
            }
        }

        private void LoadDepartmentStockDefects()
        {
            ProcessErrorGoodsEventArgs eventArgs = new ProcessErrorGoodsEventArgs();
            EventUtility.fireEvent(LoadAllDepartmentStockDefects, this, eventArgs);
            IList list = eventArgs.StockList;
            if (list == null)
            {
                return;
            }
            deptStockDefectList.Clear();
            foreach (DepartmentStock defect in list)
            {
                deptStockDefectList.Add(defect);
            }
            bdsStockDefect.EndEdit();
            dgvStockDefect.Refresh();
            dgvStockDefect.Invalidate();
        }

        private void LoadStockDefects()
        {
            ProcessErrorGoodsEventArgs eventArgs = new ProcessErrorGoodsEventArgs();
            EventUtility.fireEvent(LoadAllStockDefects,this,eventArgs);
            IList list = eventArgs.StockList;
            if(list ==null)
            {
                return;
            }
            stockDefectList.Clear();
            foreach (Stock defect in list)
            {
                stockDefectList.Add(defect);                
            }
            bdsStockDefect.EndEdit();
            dgvStockDefect.Refresh();
            dgvStockDefect.Invalidate();
        }

        private void btnError_Click(object sender, EventArgs e)
        {
            if( dgvStockDefect.SelectedRows.Count == 0)
            {
                return;                
            }
            DataGridViewSelectedRowCollection selection = dgvStockDefect.SelectedRows;
            if (!DepartmentProcessing)
            {
                foreach (DataGridViewRow row in selection)
                {
                    Stock defect = stockDefectList[row.Index];
                    StockOutDetail detail = new StockOutDetail();
                    detail.Product = defect.Product;
                    detail.ProductMaster = defect.ProductMaster;
                    detail.Quantity = defect.ErrorQuantity;
                    detail.ErrorQuantity = defect.ErrorQuantity;
                    //detail.DamageQuantity = defect.DamageQuantity;
                    detail.DefectStatus = new StockDefectStatus{ DefectStatusId = 5}; // trả về nhà sản xuất
                    returnGoodsList.Add(detail);
                }
            }
            else
            {
                foreach (DataGridViewRow row in selection)
                {
                    DepartmentStock defect = deptStockDefectList[row.Index];
                    DepartmentStockOutDetail detail = new DepartmentStockOutDetail();
                    detail.DepartmentStockOutDetailPK = new DepartmentStockOutDetailPK();
                    detail.Product = defect.Product;
                    detail.ProductMaster = defect.ProductMaster;
                    detail.Quantity = defect.ErrorQuantity;
                    detail.ErrorQuantity = defect.ErrorQuantity;
                    //detail.DamageQuantity = defect.DamageQuantity;
                    detail.DefectStatus = new StockDefectStatus { DefectStatusId = 6 }; // trả về kho chính
                    deptReturnGoodsList.Add(detail);
                }
            }
            bdsReturnGoods.EndEdit();
            dgvReturnStockOut.Refresh();
            dgvReturnStockOut.Invalidate();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvStockDefect.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewSelectedRowCollection selection = dgvStockDefect.SelectedRows;
            if (!DepartmentProcessing)
            {
                foreach (DataGridViewRow row in selection)
                {
                    Stock defect = stockDefectList[row.Index];
                    StockOutDetail detail = new StockOutDetail();
                    detail.Product = defect.Product;
                    detail.ProductMaster = defect.ProductMaster;
                    detail.ErrorQuantity = defect.ErrorQuantity;
                    detail.Quantity = detail.ErrorQuantity;
                    detail.DefectStatus = new StockDefectStatus { DefectStatusId = 4 }; // trả về nhà sản xuất
                    tempStockOutList.Add(detail);
                }
            }
            else
            {
                foreach (DataGridViewRow row in selection)
                {
                    DepartmentStock defect = deptStockDefectList[row.Index];
                    DepartmentStockOutDetail detail = new DepartmentStockOutDetail();
                    detail.DepartmentStockOutDetailPK = new DepartmentStockOutDetailPK();
                    detail.Product = defect.Product;
                    detail.ProductMaster = defect.ProductMaster;
                    detail.ErrorQuantity = defect.ErrorQuantity;
                    detail.Quantity = detail.ErrorQuantity;
                    detail.DefectStatus = new StockDefectStatus { DefectStatusId = 4 }; // trả về nhà sản xuất
                    deptTempStockOutList.Add(detail);
                }
            }
            bdsTempStockOut.EndEdit();
            dgvTempStockOut.Refresh();
            dgvTempStockOut.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgvStockDefect.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewSelectedRowCollection selection = dgvStockDefect.SelectedRows;
            if (!DepartmentProcessing)
            {
                foreach (DataGridViewRow row in selection)
                {
                    Stock defect = stockDefectList[row.Index];
                    StockOutDetail detail = new StockOutDetail();
                    detail.Product = defect.Product;
                    detail.ProductMaster = defect.ProductMaster;
                    detail.LostQuantity = defect.LostQuantity;
                    detail.DamageQuantity = defect.DamageQuantity;
                    detail.Quantity = detail.LostQuantity + detail.DamageQuantity;
                    detail.DefectStatus = new StockDefectStatus { DefectStatusId = 8 }; // hủy hàng
                    destroyGoodsList.Add(detail);
                }
            }
            else
            {
                foreach (DataGridViewRow row in selection)
                {
                    DepartmentStock defect = deptStockDefectList[row.Index];
                    DepartmentStockOutDetail detail = new DepartmentStockOutDetail();
                    detail.DepartmentStockOutDetailPK = new DepartmentStockOutDetailPK();
                    detail.Product = defect.Product;
                    detail.ProductMaster = defect.ProductMaster;
                    detail.LostQuantity = defect.LostQuantity;
                    detail.DamageQuantity = defect.DamageQuantity;
                    detail.Quantity = detail.LostQuantity + detail.DamageQuantity;
                    detail.DefectStatus = new StockDefectStatus { DefectStatusId = 8 }; // hủy hàng
                    deptDestroyGoodsList.Add(detail);
                }
            }
            bdsDestroyGoods.EndEdit();
            dgvGoodsDestroy.Refresh();
            dgvGoodsDestroy.Invalidate();            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (dgvReturnStockOut.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewSelectedRowCollection selection = dgvReturnStockOut.SelectedRows;
            foreach (DataGridViewRow row in selection)
            {
                if(!DepartmentProcessing)
                {
                    returnGoodsList.RemoveAt(row.Index);    
                }
                
                else
                {
                    deptReturnGoodsList.RemoveAt(row.Index);                    
                }
            }
            bdsReturnGoods.EndEdit();
            dgvReturnStockOut.Refresh();
            dgvReturnStockOut.Invalidate();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (dgvTempStockOut.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewSelectedRowCollection selection = dgvTempStockOut.SelectedRows;
            foreach (DataGridViewRow row in selection)
            {
                if (!DepartmentProcessing)
                {
                    tempStockOutList.RemoveAt(row.Index);    
                }
                else
                {
                    deptTempStockOutList.RemoveAt(row.Index);                        
                }
            }
            bdsTempStockOut.EndEdit();
            dgvTempStockOut.Refresh();
            dgvTempStockOut.Invalidate();
        }

        private void dgvGoodsDestroy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGoodsDestroy.SelectedRows.Count == 0)
            {
                return;
            }
            DataGridViewSelectedRowCollection selection = dgvGoodsDestroy.SelectedRows;
            foreach (DataGridViewRow row in selection)
            {
                if(!DepartmentProcessing)
                {
                    destroyGoodsList.RemoveAt(row.Index);    
                }
                else
                {
                    deptDestroyGoodsList.RemoveAt(row.Index);                        
                }
                
            }
            bdsDestroyGoods.EndEdit();
            dgvGoodsDestroy.Refresh();
            dgvGoodsDestroy.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            returnGoodsList.Clear();
            destroyGoodsList.Clear();
            tempStockOutList.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(!CheckIntegrityData())
            {
                return; 
            }
            ProcessErrorGoodsEventArgs eventArgs = new ProcessErrorGoodsEventArgs();
            if (!DepartmentProcessing)
            {
                eventArgs.ReturnStockOutList = ObjectConverter.ConvertToNonGenericList(returnGoodsList);
                eventArgs.TempStockOutList = ObjectConverter.ConvertToNonGenericList(tempStockOutList);
                eventArgs.DestroyUnusedGoodsList = ObjectConverter.ConvertToNonGenericList(destroyGoodsList);
                eventArgs.StockList = ObjectConverter.ConvertToNonGenericList(stockDefectList);
                EventUtility.fireEvent(SaveStockDefects, this, eventArgs);
            }
            else
            {
                eventArgs.ReturnStockOutList = ObjectConverter.ConvertToNonGenericList(deptReturnGoodsList);
                eventArgs.TempStockOutList = ObjectConverter.ConvertToNonGenericList(deptTempStockOutList);
                eventArgs.DestroyUnusedGoodsList = ObjectConverter.ConvertToNonGenericList(deptDestroyGoodsList);
                eventArgs.StockList = ObjectConverter.ConvertToNonGenericList(deptStockDefectList);
                EventUtility.fireEvent(SaveDepartmentStockDefects, this, eventArgs);
            }
            if(!eventArgs.HasErrors)
            {
                MessageBox.Show("Lưu thành công !");
                ClearForm();
                if(!DepartmentProcessing)
                {
                    LoadStockDefects();    
                }
                else
                {
                    LoadDepartmentStockDefects();
                }
            }                      
        }

        private void ClearForm()
        {
            if (!DepartmentProcessing)
            {
                stockDefectList.Clear();
                tempStockOutList.Clear();
                returnGoodsList.Clear();
                destroyGoodsList.Clear();
            }
            else
            {
                deptStockDefectList.Clear();
                deptTempStockOutList.Clear();
                deptReturnGoodsList.Clear();
                deptDestroyGoodsList.Clear();    
            }
        }

        private bool CheckIntegrityData()
        {
            if (!DepartmentProcessing)
            {
                foreach (Stock stock in stockDefectList)
                {
                    StockOutDetail tempStockOut = GetFromStockOutList(stock, tempStockOutList);
                    StockOutDetail returnStockOut = GetFromStockOutList(stock, returnGoodsList);
                    long tempQuantity = tempStockOut != null ? tempStockOut.ErrorQuantity : 0;
                    long returnQuantity = returnStockOut != null ? returnStockOut.ErrorQuantity : 0;
                    if (stock.ErrorQuantity < (tempQuantity + returnQuantity))
                    {
                        throw new BusinessException("Số hàng lỗi được trả lớn hơn số hàng lỗi thực tại mã vạch " +
                                                    stock.Product.ProductId);
                        return false;
                    }

                }
                return true;
            }
            else
            {
                foreach (DepartmentStock stock in deptStockDefectList)
                {
                    DepartmentStockOutDetail tempStockOut = GetFromDepartmentStockOutList(stock, deptTempStockOutList);
                    DepartmentStockOutDetail returnStockOut = GetFromDepartmentStockOutList(stock, deptReturnGoodsList);
                    long tempQuantity = tempStockOut != null ? tempStockOut.ErrorQuantity : 0;
                    long returnQuantity = returnStockOut != null ? returnStockOut.ErrorQuantity : 0;
                    if (stock.ErrorQuantity < (tempQuantity + returnQuantity))
                    {
                        throw new BusinessException("Số hàng lỗi được trả lớn hơn số hàng lỗi thực tại mã vạch " +
                                                    stock.Product.ProductId);
                        return false;
                    }

                }
                return true;  
            }
            
        }

        private DepartmentStockOutDetail GetFromDepartmentStockOutList(DepartmentStock stock, DepartmentStockOutDetailCollection list)
        {
            foreach (DepartmentStockOutDetail detail in list)
            {
                if (detail.Product.ProductId == stock.Product.ProductId)
                {
                    return detail;
                }
            }
            return null;
        }

        private StockOutDetail GetFromStockOutList(Stock stock, StockOutDetailCollection list)
        {
            foreach (StockOutDetail detail in list)
            {
                if(detail.Product.ProductId == stock.Product.ProductId)
                {
                    return detail;
                }
            }
            return null;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region IProcessErrorGoodsView Members


        public event EventHandler<ProcessErrorGoodsEventArgs> LoadAllDepartmentStockDefects;

        public event EventHandler<ProcessErrorGoodsEventArgs> SaveDepartmentStockDefects;

        #endregion
    }
}
