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
        private StockDefectCollection stockDefectList;

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
            stockDefectList = new StockDefectCollection(bdsStockDefect);

            LoadStockDefects();
        }

        private void LoadStockDefects()
        {
            ProcessErrorGoodsEventArgs eventArgs = new ProcessErrorGoodsEventArgs();
            EventUtility.fireEvent(LoadAllStockDefects,this,eventArgs);
            IList list = eventArgs.StockDefectList;
            foreach (StockDefect defect in list)
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
                StockDefect defect = stockDefectList[row.Index];
                StockOutDetail detail = new StockOutDetail();
                detail.Product = defect.Product;
                detail.ProductMaster = defect.ProductMaster;
                detail.Quantity = defect.ErrorCount+defect.DamageCount;
                detail.ErrorQuantity = defect.ErrorCount;
                detail.DamageQuantity = defect.DamageCount;
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
                StockDefect defect = stockDefectList[row.Index];
                StockOutDetail detail = new StockOutDetail();
                detail.Product = defect.Product;
                detail.ProductMaster = defect.ProductMaster;
                detail.Quantity = defect.ErrorCount;
                detail.ErrorQuantity = defect.ErrorCount;
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
                StockDefect defect = stockDefectList[row.Index];
                StockOutDetail detail = new StockOutDetail();
                detail.Product = defect.Product;
                detail.ProductMaster = defect.ProductMaster;
                detail.LostQuantity = defect.LostCount;
                detail.DamageQuantity = defect.DamageCount;
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
                
            }
            ProcessErrorGoodsEventArgs eventArgs = new ProcessErrorGoodsEventArgs();
            eventArgs.ReturnStockOutList = ObjectConverter.ConvertToNonGenericList(returnGoodsList);
            eventArgs.TempStockOutList = ObjectConverter.ConvertToNonGenericList(tempStockOutList);
            eventArgs.DestroyUnusedGoodsList = ObjectConverter.ConvertToNonGenericList(destroyGoodsList);
            eventArgs.StockDefectList = ObjectConverter.ConvertToNonGenericList(stockDefectList);
            EventUtility.fireEvent(SaveStockDefects,this,eventArgs);
            if(!eventArgs.HasErrors)
            {
                MessageBox.Show("Lưu thành công !");
                LoadStockDefects();
            }                      
        }

        private bool CheckIntegrityData()
        {

            foreach (StockOutDetail detail in tempStockOutList)
            {
                
            }
            return true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
