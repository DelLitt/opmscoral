using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter.Inventory;
using AppFrame.View.Inventory;
using AppFrameClient.ViewModel;
using Spring.Transaction.Interceptor;

namespace AppFrameClient.Presenter.Inventory
{
    public class DepartmentStockFixingController : IDepartmentStockFixingController
    {
        #region Implementation of IDepartmentStockAdhocProcessingController

        private IDepartmentStockFixingView _departmentStockFixingView;

        public IDepartmentStockFixingView DepartmentStockFixingView
        {
            get
            {
                return _departmentStockFixingView;
            }
            set
            {
                _departmentStockFixingView = value;
                _departmentStockFixingView.LoadAdhocStocksEvent += new EventHandler<DepartmentStockFixingEventArgs>(DepartmentStockAdhocProcessingViewLoadAdhocStocksEvent);
                _departmentStockFixingView.ProcessAdhocStocksEvent += new EventHandler<DepartmentStockFixingEventArgs>(DepartmentStockAdhocProcessingViewProcessAdhocStocksEvent);
            }
        }

        [Transaction(ReadOnly=false)]
        void DepartmentStockAdhocProcessingViewProcessAdhocStocksEvent(object sender, DepartmentStockFixingEventArgs e)
        {
            try
            {

                long departmentId = -1;
                StockOut stockOut = null;
                StockIn stockIn = new StockIn();
                
                stockIn.CreateDate = DateTime.Now;
                stockIn.UpdateDate = DateTime.Now;
                stockIn.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                stockIn.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                stockIn.StockInType = 2; // fixing stockin
                stockIn.StockInDate = DateTime.Now;
                stockIn.StockInId = StockInLogic.FindMaxId();
                stockIn.StockInDetails = new ArrayList();
        
                long stockOutDetailMaxId = StockOutDetailLogic.FindMaxId() + 1;
                long stockOutMaxId = StockOutLogic.FindMaxId()+1;

                for (int i=0; i< e.DeptStockProcessedList.Count;i++)
                {
                    DepartmentStock stockTemp = (DepartmentStock)e.DeptStockProcessedList[i];
                    if(stockTemp.DepartmentStockPK.DepartmentId != departmentId)
                    {
                        departmentId = stockTemp.DepartmentStockPK.DepartmentId;

                        if (stockOut != null && stockOut.StockOutDetails.Count > 0 )
                        {
                            StockOutLogic.AddFixedStockOut(stockOut);            
                        }
                        stockOut = new StockOut();
                        stockOut.CreateDate = DateTime.Now;
                        stockOut.UpdateDate = DateTime.Now;
                        stockOut.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                        stockOut.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        stockOut.StockOutDate = DateTime.Now;
                        stockOut.StockOutDetails = new ArrayList();
                        stockOut.DepartmentId = departmentId;
                        stockOut.DefectStatus = new StockDefectStatus{ DefectStatusId = 0};
                        
                        stockOut.StockoutId =  stockOutMaxId++;
                    }

                    /*stockTemp.Fixed = 1;*/
                    /*stockTemp.UpdateDate = DateTime.Now;
                    stockTemp.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    DepartmentStockLogic.Update(stockTemp);*/
                    long realQty = stockTemp.GoodQuantity + stockTemp.ErrorQuantity + stockTemp.DamageQuantity +
                                   stockTemp.LostQuantity + stockTemp.UnconfirmQuantity;
                    if(stockTemp.GoodQuantity < 0)
                    {
                        long needStockMoreQty = 0 - stockTemp.GoodQuantity;
                        StockOutDetail stockOutDetail = new StockOutDetail();
                        stockOutDetail.CreateDate = DateTime.Now;
                        stockOutDetail.UpdateDate = DateTime.Now;
                        stockOutDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                        stockOutDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        stockOutDetail.Quantity = needStockMoreQty;
                        stockOutDetail.Product = stockTemp.Product;
                        stockOutDetail.StockOutId = stockOut.StockoutId;
                        stockOutDetail.StockOut = stockOut;
                        stockOutDetail.DefectStatus = new StockDefectStatus{DefectStatusId = 0};
                        stockOutDetail.Description = "Export goods";
                        stockOutDetail.ProductMaster = stockTemp.ProductMaster;
                        stockOutDetail.StockOutDetailId = stockOutDetailMaxId++;
                        stockOut.StockOutDetails.Add(stockOutDetail);

                        StockInDetail stockInDetail = new StockInDetail();
                        stockInDetail.CreateDate = DateTime.Now;
                        stockInDetail.UpdateDate = DateTime.Now;
                        stockInDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                        stockInDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        stockInDetail.StockInType = 0;
                        stockInDetail.StockIn = stockIn;

                        stockInDetail.Quantity = needStockMoreQty;
                        stockInDetail.Product = stockTemp.Product;
                        stockInDetail.ProductMaster = stockTemp.ProductMaster;
                        stockInDetail.StockInDetailPK = new StockInDetailPK
                                                            {
                                                                ProductId = stockTemp.Product.ProductId,
                                                                StockInId = stockIn.StockInId
                                                            };
                        stockIn.StockInDetails.Add(stockInDetail);
                        if(i == e.DeptStockProcessedList.Count -1)
                        {
                            StockOutLogic.AddFixedStockOut(stockOut);
                        }
                        stockTemp.GoodQuantity += needStockMoreQty;
                        stockTemp.Quantity += needStockMoreQty;
                        DepartmentStockLogic.Update(stockTemp);
                    }

                }

                if (stockIn.StockInDetails.Count > 0)
                {
                    StockInLogic.AddFixedStockIn(stockIn);
                }

            }
            catch (Exception)
            {
                e.HasErrors = true;
                throw;
            }
            
        }

        void DepartmentStockAdhocProcessingViewLoadAdhocStocksEvent(object sender, DepartmentStockFixingEventArgs e)
        {
            ObjectCriteria criteria = new ObjectCriteria();
            criteria.AddLesserCriteria("GoodQuantity", (long)0);
            criteria.AddEqCriteria("DelFlg", (long)0);
            criteria.AddOrder("DepartmentStockPK.DepartmentId", true);
            IList list = DepartmentStockLogic.FindAll(criteria);
            if (list != null && list.Count > 0)
            {
                 
                e.DeptStockAdhocList = list;
            }

        }

        private bool HasInList(DepartmentStockTemp temp, IList list, out int index)
        {
            bool hasInList = false;
            index = 0;
            for(int i = 0;i < list.Count; i++)
            {
                index = i;
                DepartmentStockTempView view = (DepartmentStockTempView)list[i];
                if(view.ProductMaster.ProductMasterId.Equals(
                                    temp.ProductMaster.ProductMasterId))
                {
                    hasInList = true;
                    break;
                }
            }

            return hasInList;
        }

        public IProductLogic ProductLogic
        {
            get; set;
        }

        public IProductMasterLogic ProductMasterLogic
        {
            get; set;
        }

        public IDepartmentStockLogic DepartmentStockLogic
        {
            get; set;
        }

        public IStockOutLogic StockOutLogic
        {
            get; set;
        }
        public IStockInLogic StockInLogic
        {
            get;
            set;
        }

        public IStockOutDetailLogic StockOutDetailLogic
        {
            get;
            set;
        }
        public IStockInDetailLogic StockInDetailLogic
        {
            get;
            set;
        }
        
        #endregion
    }
}
