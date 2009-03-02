using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AppFrame.Collection;
using AppFrame.Model;
using AppFrame.Presenter.GoodsSale;
using AppFrame.Utility;
using AppFrame.View.GoodsSale;

namespace AppFrameClient.Presenter.GoodsSale
{
    public class GoodsSaleListController : IGoodsSaleListController
    {
        #region IGoodsSaleListController Members

        private IGoodsSaleListView goodsSaleListView;
        public AppFrame.View.GoodsSale.IGoodsSaleListView GoodsSaleListView
        {
            get
            {
                return goodsSaleListView;
            }
            set
            {
                goodsSaleListView = value;
                goodsSaleListView.GoodsSaleListSearchEvent += new EventHandler<GoodsSaleListEventArgs>(goodsSaleListView_GoodsSaleListSearchEvent);
            }
        }

        void goodsSaleListView_GoodsSaleListSearchEvent(object sender, GoodsSaleListEventArgs e)
        {
            SearchGoods(sender, e);
            
        }

        private void SearchGoods(object sender, GoodsSaleListEventArgs e)
        {
            IList list = PurchaseOrderLogic.FindAll(e.PurchaseOrderSearchCriteria);
            PurchaseOrderCollection collection = new PurchaseOrderCollection();
            foreach (PurchaseOrder order in list)
            {
                collection.Add(order);
            }
            GoodsSaleListEventArgs goodsSaleListEventArgs = new GoodsSaleListEventArgs();
            goodsSaleListEventArgs.PurchaseOrders = collection;
            EventUtility.fireEvent(CompletedGoodsSaleListSearchEvent, this, goodsSaleListEventArgs);
        }

        public AppFrame.Logic.IPurchaseOrderLogic PurchaseOrderLogic
        {
            get;set;
        }

        public AppFrame.Logic.IPurchaseOrderDetailLogic PurchaseOrderDetailLogic
        {
            get;set;
        }

        public AppFrame.Logic.IProductMasterLogic ProductMasterLogic
        {
            get;set;
        }

        public AppFrame.Collection.PurchaseOrderCollection PurchaseOrders
        {
            get;set;
        }

        public event EventHandler<GoodsSaleListEventArgs> CompletedGoodsSaleListSearchEvent;

        #endregion

        #region IGoodsSaleListController Members


        public AppFrame.ObjectCriteria PurchaseOrderCriteria
        {
            get;set;
        }

        #endregion

        #region IGoodsSaleListController Members

        private IDayGoodsSaleListView dayGoodsSaleListView;
        public IDayGoodsSaleListView DayGoodsSaleListView
        {
            get
            {
                return dayGoodsSaleListView;
            }
            set
            {
                dayGoodsSaleListView = value;
                dayGoodsSaleListView.GoodsSaleListSearchEvent += new EventHandler<GoodsSaleListEventArgs>(dayGoodsSaleListView_GoodsSaleListSearchEvent);  
            }
        }

        void dayGoodsSaleListView_GoodsSaleListSearchEvent(object sender, GoodsSaleListEventArgs e)
        {
            SearchGoods(sender,e);
        }

        private IMonthGoodsSaleListView monthGoodsSaleListView;
        public IMonthGoodsSaleListView MonthGoodsSaleListView
        {
            get
            {
                return monthGoodsSaleListView;
            }
            set
            {
                monthGoodsSaleListView = value;
                monthGoodsSaleListView.GoodsSaleListSearchEvent += new EventHandler<GoodsSaleListEventArgs>(monthGoodsSaleListView_GoodsSaleListSearchEvent);
            }
        }

        void monthGoodsSaleListView_GoodsSaleListSearchEvent(object sender, GoodsSaleListEventArgs e)
        {
            SearchGoods(sender,e);
        }

        #endregion
    }
}
