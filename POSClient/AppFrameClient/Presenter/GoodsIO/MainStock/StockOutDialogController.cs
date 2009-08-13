using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.View.GoodsIO.MainStock;

namespace AppFrameClient.Presenter.GoodsIO.MainStock
{
    public class StockOutDialogController : IStockOutDialogController
    {
        private IStockOutDialogView stockOutDialogView;
        public IStockOutDialogView StockOutDialogView
        {
            get
            {
                return stockOutDialogView;
            }
            set
            {
                stockOutDialogView = value;
                stockOutDialogView.InitDialogEvent += new EventHandler<StockOutDialogEventArgs>(stockOutDialogView_InitDialogEvent);
            }
        }

        void stockOutDialogView_InitDialogEvent(object sender, StockOutDialogEventArgs e)
        {
            ObjectCriteria objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);

            e.ProductSizeList = ProductSizeLogic.FindAll(objectCriteria);
            e.ProductColorList = ProductColorLogic.FindAll(objectCriteria);
            e.ProductTypeList = ProductTypeLogic.FindAll(objectCriteria);
            e.DepartmentsList = DepartmentLogic.FindAll(objectCriteria);
            e.ProductMastersList = ProductMasterLogic.FindDistinctNames();
            
        }

        public IProductMasterLogic ProductMasterLogic { get; set; }
        public IProductLogic ProductLogic { get; set; }
        public IProductColorLogic ProductColorLogic { get; set; }
        public IProductTypeLogic ProductTypeLogic { get; set; }
        public IProductSizeLogic ProductSizeLogic { get; set; }
        public IStockLogic StockLogic { get; set; }
        public IStockOutLogic StockOutLogic { get; set; }
        public IStockOutDetailLogic StockOutDetailLogic { get; set; }
        public IDepartmentLogic DepartmentLogic { get; set; }
    }
}
