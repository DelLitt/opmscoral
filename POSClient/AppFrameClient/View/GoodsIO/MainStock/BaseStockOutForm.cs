using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.MainStock;
using AppFrameClient.ViewModel;

namespace AppFrameClient.View.GoodsIO.MainStock
{
   
    public partial class BaseStockOutForm : AppFrame.Common.BaseForm,IBaseStockOutView
    {
        StockViewCollection stockViewList = null;
        public BaseStockOutForm()
        {
            InitializeComponent();
        }

        private void TemporaryStockOutForm_Load(object sender, EventArgs e)
        {
            stockViewList = new StockViewCollection(bdsProductMasters);
            bdsProductMasters.DataSource = stockViewList;

            LoadGoodsToCombo();
        }

        public virtual void LoadGoodsToCombo()
        {
            BaseStockOutEventArgs checkingEventArgs = new BaseStockOutEventArgs();
            EventUtility.fireEvent(FillGoodsToCombo, this, checkingEventArgs);
            stockViewList.Clear();
            foreach (var obj in checkingEventArgs.ReturnStockViewList)
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
    }
}
