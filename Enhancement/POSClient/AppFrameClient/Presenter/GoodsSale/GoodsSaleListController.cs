using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AppFrame;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter.GoodsSale;
using AppFrame.Utility;
using AppFrame.View.GoodsSale;
using AppFrameClient.ViewModel;

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
            SearchGoodsAndReturnsInRange(sender, e);
            
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
        public IReturnPoLogic ReturnPoLogic { get; set; }
        public IDepartmentPriceLogic DepartmentPriceLogic { get; set; }

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
            SearchGoodsAndReturnsInRange(sender,e);
        }

        private void SearchGoodsAndReturnsInRange(object sender, GoodsSaleListEventArgs args)
        {
            IList list = PurchaseOrderLogic.FindAll(args.PurchaseOrderSearchCriteria);
            IList collection = new ArrayList();
            foreach (PurchaseOrder order in list)
            {
                PurchaseOrderView view = new PurchaseOrderView();
                view.PurchaseOrder = order;
                view.PurchaseOrderId = order.PurchaseOrderPK.PurchaseOrderId;

                long SellAmount = 0;
                long SellQuantity = 0;
                string SellDescription = "";
                long RetAmount = 0;
                long RetQuantity = 0;
                string RetDescription = "";
                foreach (PurchaseOrderDetail detail in order.PurchaseOrderDetails)
                {
                    SellDescription += detail.Product.ProductMaster.ProductName + " ";
                    SellAmount += detail.Quantity*detail.Price;
                    SellQuantity += detail.Quantity;
                }
                
                ObjectCriteria criteria = new ObjectCriteria();
                criteria.AddEqCriteria("NextPurchaseOrderId", order.PurchaseOrderPK.PurchaseOrderId);
                criteria.AddEqCriteria("ReturnPoPK.DepartmentId", order.PurchaseOrderPK.DepartmentId);
                IList returnPOList = ReturnPoLogic.FindAll(criteria);
                foreach (ReturnPo returnPo in returnPOList)
                {
                    RetDescription += returnPo.Product.ProductMaster.ProductName + " ";
                    long retPrice = returnPo.Price;
                    if (retPrice == 0)
                    {
                        DepartmentPricePK deptPricePK = new DepartmentPricePK();
                        deptPricePK.DepartmentId = 0;
                        deptPricePK.ProductMasterId = returnPo.Product.ProductMaster.ProductMasterId;
                        DepartmentPrice price = DepartmentPriceLogic.FindById(deptPricePK);
                        if (price != null)
                        {
                            retPrice = price.Price;
                        }
                    }
                    RetAmount += returnPo.Quantity * retPrice;
                    RetQuantity += returnPo.Quantity;
                }

                view.ReturnPOList = returnPOList;
                view.SellDescription = SellDescription;
                view.SellAmount = SellAmount;
                view.SellQuantity = SellQuantity;
                view.ReturnAmount = RetAmount;
                view.ReturnDescription = RetDescription;
                view.ReturnQuantity = RetQuantity;
                view.IssueDate = order.CreateDate;
                collection.Add(view);
            }
            
            ObjectCriteria NAcriteria = new ObjectCriteria();
            NAcriteria.AddEqCriteria("ReturnPoPK.DepartmentId", CurrentDepartment.Get().DepartmentId);
            NAcriteria.AddGreaterOrEqualsCriteria("ReturnPoPK.CreateDate", args.FromDate)
                .AddLesserOrEqualsCriteria("ReturnPoPK.CreateDate", args.ToDate);
            IList allReturnPOList = ReturnPoLogic.FindAll(NAcriteria);
            
            IList legalReturnPOList = new ArrayList();
            if(allReturnPOList!= null)
            {
                foreach (ReturnPo returnPo in allReturnPOList)
                {
                    if(string.IsNullOrEmpty(returnPo.NextPurchaseOrderId))
                            legalReturnPOList.Add(returnPo);
                    
                }
            }
            

            string retNAPOId = "";
            PurchaseOrderView retNAView = new PurchaseOrderView();
            retNAView.ReturnPOList = new ArrayList();
            IList retNAList = new ArrayList();
            foreach (ReturnPo returnPo in legalReturnPOList)
            {
                if (!retNAPOId.Equals(returnPo.ReturnPoPK.PurchaseOrderId))
                {
                    if(!string.IsNullOrEmpty(retNAPOId))
                    {
                        collection.Add(retNAView); 
                        retNAView = new PurchaseOrderView();
                        retNAView.ReturnPOList = new ArrayList();
                    }
                    retNAPOId = returnPo.ReturnPoPK.PurchaseOrderId;
                    retNAView.PurchaseOrderId = retNAPOId;
                    retNAView.IssueDate = returnPo.ReturnPoPK.CreateDate;
                }
                retNAView.ReturnDescription += returnPo.Product.ProductMaster.ProductName + " ";
                long retPrice = returnPo.Price;
                    if (retPrice == 0)
                    {
                        DepartmentPricePK deptPricePK = new DepartmentPricePK();
                        deptPricePK.DepartmentId = 0;
                        deptPricePK.ProductMasterId = returnPo.Product.ProductMaster.ProductMasterId;
                        DepartmentPrice price = DepartmentPriceLogic.FindById(deptPricePK);
                        if (price != null)
                        {
                            retPrice = price.Price;
                        }
                    }
                retNAView.ReturnAmount += returnPo.Quantity * retPrice;
                retNAView.ReturnQuantity += returnPo.Quantity;
                retNAView.ReturnPOList.Add(returnPo);
            }
            collection.Add(retNAView);

            GoodsSaleListEventArgs goodsSaleListEventArgs = new GoodsSaleListEventArgs();
            goodsSaleListEventArgs.PurchaseOrderViewList = collection;
            EventUtility.fireEvent(CompletedGoodsSaleListSearchEvent, this, goodsSaleListEventArgs);
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
            SearchGoodsAndReturnsInRange(sender,e);
        }

        #endregion
    }
}
