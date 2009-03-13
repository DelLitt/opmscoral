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
            returnGoodsList= new StockOutDetailCollection(bdsReturnGoods);
            tempStockOutList= new StockOutDetailCollection(bdsTempStockOut);
            destroyGoodsList = new StockOutDetailCollection(bdsDestroyGoods);
            stockDefectList = new StockCollection(bdsStockDefect);

            LoadStockDefects();
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
            foreach (DataGridViewRow row in selection)
            {
                Stock defect = stockDefectList[row.Index];
                StockOutDetail detail = new StockOutDetail();
                detail.Product = defect.Product;
                detail.ProductMaster = defect.ProductMaster;
                detail.Quantity = defect.ErrorQuantity;
                detail.ErrorQuantity = defect.ErrorQuantity;
                detail.DamageQuantity = defect.DamageQuantity;
                returnGoodsList.Add(detail);
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
            foreach (DataGridViewRow row in selection)
            {
                Stock defect = stockDefectList[row.Index];
                StockOutDetail detail = new StockOutDetail();
                detail.Product = defect.Product;
                detail.ProductMaster = defect.ProductMaster;
                detail.ErrorQuantity = defect.ErrorQuantity;
                detail.Quantity = detail.ErrorQuantity;
                tempStockOutList.Add(detail);
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
            foreach (DataGridViewRow row in selection)
            {
                Stock defect = stockDefectList[row.Index];
                StockOutDetail detail = new StockOutDetail();
                detail.Product = defect.Product;
                detail.ProductMaster = defect.ProductMaster;
                detail.LostQuantity = defect.LostQuantity;
                detail.DamageQuantity = defect.DamageQuantity;
                detail.Quantity = detail.LostQuantity + detail.DamageQuantity;
                destroyGoodsList.Add(detail);
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
                returnGoodsList.RemoveAt(row.Index);
            }
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
                tempStockOutList.RemoveAt(row.Index);
            }
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
                destroyGoodsList.RemoveAt(row.Index);
            }
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
            eventArgs.ReturnStockOutList = ObjectConverter.ConvertToNonGenericList(returnGoodsList);
            eventArgs.TempStockOutList = ObjectConverter.ConvertToNonGenericList(tempStockOutList);
            eventArgs.DestroyUnusedGoodsList = ObjectConverter.ConvertToNonGenericList(destroyGoodsList);
            eventArgs.StockList = ObjectConverter.ConvertToNonGenericList(stockDefectList);
            EventUtility.fireEvent(SaveStockDefects,this,eventArgs);
            if(!eventArgs.HasErrors)
            {
                MessageBox.Show("Lưu thành công !");
                ClearForm();
                LoadStockDefects();
            }                      
        }

        private void ClearForm()
        {
            stockDefectList.Clear();
            tempStockOutList.Clear();
            returnGoodsList.Clear();
            destroyGoodsList.Clear();
        }

        private bool CheckIntegrityData()
        {
            foreach (Stock stock in stockDefectList)
            {
                StockOutDetail tempStockOut = GetFromStockOutList(stock,tempStockOutList);
                StockOutDetail returnStockOut = GetFromStockOutList(stock, returnGoodsList);
                long tempQuantity = tempStockOut != null ? tempStockOut.ErrorQuantity : 0;
                long returnQuantity = returnStockOut != null ? returnStockOut.ErrorQuantity : 0;
                if(stock.ErrorQuantity < (tempQuantity + returnQuantity))
                {
                    throw new BusinessException("Số hàng lỗi được trả lớn hơn số hàng lỗi thực tại mã vạch " + stock.Product.ProductId);
                    return false;
                }

            }
            return true;
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
    }
}
