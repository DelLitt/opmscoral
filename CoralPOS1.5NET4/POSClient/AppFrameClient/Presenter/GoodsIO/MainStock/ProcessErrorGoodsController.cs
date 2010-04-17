using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame;
using AppFrame.Logic;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.View.GoodsIO.MainStock;

namespace AppFrameClient.Presenter.GoodsIO.MainStock
{
    public class ProcessErrorGoodsController : IProcessErrorGoodsController
    {
        private IProcessErrorGoodsView processErrorGoodsView;
        public IProcessErrorGoodsView ProcessErrorGoodsView
        {
            get { return processErrorGoodsView; }
            set
            {
                processErrorGoodsView = value;
                processErrorGoodsView.LoadAllStockDefects += new EventHandler<ProcessErrorGoodsEventArgs>(processErrorGoodsView_LoadAllStockDefects);
                processErrorGoodsView.SaveStockDefects += new EventHandler<ProcessErrorGoodsEventArgs>(processErrorGoodsView_SaveStockDefects);

                processErrorGoodsView.LoadAllDepartmentStockDefects += new EventHandler<ProcessErrorGoodsEventArgs>(processErrorGoodsView_LoadAllDepartmentStockDefects);
                processErrorGoodsView.SaveDepartmentStockDefects += new EventHandler<ProcessErrorGoodsEventArgs>(processErrorGoodsView_SaveDepartmentStockDefects);
            }
        }

        void processErrorGoodsView_SaveDepartmentStockDefects(object sender, ProcessErrorGoodsEventArgs e)
        {
            DepartmentStockOutLogic.ProcessErrorGoods(e.StockList, e.ReturnStockOutList, e.TempStockOutList,
                                                   e.DestroyUnusedGoodsList);
        }

        void processErrorGoodsView_LoadAllDepartmentStockDefects(object sender, ProcessErrorGoodsEventArgs e)
        {
            IList stockDefectList = DepartmentStockLogic.FindAllErrors();
            e.StockList = stockDefectList;
        }

        void processErrorGoodsView_SaveStockDefects(object sender, ProcessErrorGoodsEventArgs e)
        {
            try
            {
                StockOutLogic.ProcessErrorGoods(e.StockList, e.ReturnStockOutList, e.TempStockOutList,
                                                    e.DestroyUnusedGoodsList);
                e.HasErrors = false;

            }
            catch (System.Exception ex)
            {
                e.HasErrors = true;
            }
        }

        void processErrorGoodsView_LoadAllStockDefects(object sender, ProcessErrorGoodsEventArgs e)
        {
            IList stockDefectList = StockLogic.FindAllErrors();
            e.StockList = stockDefectList;
        }

        public IStockOutLogic StockOutLogic
        {
            get;
            set;
        }

        public IStockOutDetailLogic StockOutDetailLogic
        {
            get;
            set;
        }

        public IStockLogic StockLogic
        {
            get;
            set;
        }

        #region IProcessErrorGoodsController Members


        public IDepartmentStockOutLogic DepartmentStockOutLogic
        {
            get;set;
        }

        public IDepartmentStockOutDetailLogic DepartmentStockOutDetailLogic
        {
            get;set;
        }

        public IDepartmentStockLogic DepartmentStockLogic
        {
            get;set;
        }

        #endregion
    }
}
