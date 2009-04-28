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
    public class DepartmentStockAdhocProcessingController : IDepartmentStockAdhocProcessingController
    {
        #region Implementation of IDepartmentStockAdhocProcessingController

        private IDepartmentStockAdhocProcessingView _departmentStockAdhocProcessingView;

        private IProductLogic _productLogic;

        private IProductMasterLogic _productMasterLogic;

        private IDepartmentStockTempLogic _departmentStockTempLogic;

        public IDepartmentStockAdhocProcessingView DepartmentStockAdhocProcessingView
        {
            get { return _departmentStockAdhocProcessingView; }
            set
            {
                _departmentStockAdhocProcessingView = value;
                _departmentStockAdhocProcessingView.LoadAdhocStocksEvent += new EventHandler<DepartmentStockAdhocProcessingEventArgs>(_departmentStockAdhocProcessingView_LoadAdhocStocksEvent);
                _departmentStockAdhocProcessingView.ProcessAdhocStocksEvent += new EventHandler<DepartmentStockAdhocProcessingEventArgs>(_departmentStockAdhocProcessingView_ProcessAdhocStocksEvent);
            }
        }

        [Transaction(ReadOnly=false)]
        void _departmentStockAdhocProcessingView_ProcessAdhocStocksEvent(object sender, DepartmentStockAdhocProcessingEventArgs e)
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
                stockIn.StockInDate = DateTime.Now;
                stockIn.StockInId = StockInLogic.FindMaxId();
                stockIn.StockInDetails = new ArrayList();        
                long stockOutDetailMaxId = StockOutDetailLogic.FindMaxId() + 1;
                long stockOutMaxId = StockOutLogic.FindMaxId()+1;
                for (int i=0; i< e.DeptStockProcessedList.Count;i++)
                {
                    DepartmentStockTemp stockTemp = (DepartmentStockTemp) e.DeptStockProcessedList[i];
                    if(stockTemp.DepartmentStockTempPK.DepartmentId != departmentId)
                    {
                        departmentId = stockTemp.DepartmentStockTempPK.DepartmentId;

                        if (stockOut != null)
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

                    stockTemp.Fixed = 1;
                    stockTemp.UpdateDate = DateTime.Now;
                    stockTemp.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    DepartmentStockTempLogic.Update(stockTemp);
                    long realQty = stockTemp.GoodQuantity + stockTemp.ErrorQuantity + stockTemp.DamageQuantity +
                                   stockTemp.LostQuantity + stockTemp.UnconfirmQuantity;
                    if(stockTemp.Quantity < realQty)
                    {
                        long stockInQty = realQty - stockTemp.Quantity;
                        StockOutDetail stockOutDetail = new StockOutDetail();
                        stockOutDetail.CreateDate = DateTime.Now;
                        stockOutDetail.UpdateDate = DateTime.Now;
                        stockOutDetail.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                        stockOutDetail.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        stockOutDetail.Quantity = stockInQty;
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

                        stockInDetail.Quantity = stockInQty;
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
                    }

                }
                StockInLogic.AddFixedStockIn(stockIn);            
                
            }
            catch (Exception)
            {
                e.HasErrors = true;
                throw;
            }
            
        }

        void _departmentStockAdhocProcessingView_LoadAdhocStocksEvent(object sender, DepartmentStockAdhocProcessingEventArgs e)
        {
            ObjectCriteria criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddEqCriteria("Fixed", CommonConstants.DEL_FLG_NO);    
            criteria.AddOrder("ProductMaster.ProductMasterId", true);
            IList list = DepartmentStockTempLogic.FindAll(criteria);
            IList deptStockTempList = null;
            if (list != null & list.Count > 0)
            {
                 deptStockTempList = new ArrayList();
                
                foreach (DepartmentStockTemp stockTemp in list)
                {
                    int viewIndex = -1;
                    if(HasInList(stockTemp,deptStockTempList,out viewIndex))
                    {
                        DepartmentStockTempView view = (DepartmentStockTempView) deptStockTempList[viewIndex];
                        view.Quantity += stockTemp.Quantity;
                        
                        view.GoodQuantity += stockTemp.GoodQuantity;
                        view.ErrorQuantity += stockTemp.ErrorQuantity;
                        view.DamageQuantity += stockTemp.DamageQuantity;
                        view.LostQuantity += stockTemp.LostQuantity;
                        view.UnconfirmQuantity += stockTemp.UnconfirmQuantity;
                        view.RealQuantity += stockTemp.GoodQuantity + stockTemp.ErrorQuantity + stockTemp.DamageQuantity +
                                        stockTemp.LostQuantity + stockTemp.UnconfirmQuantity;
                        view.DepartmentStockTemps.Add(stockTemp);
                    }
                    else
                    {
                        DepartmentStockTempView view = new DepartmentStockTempView();
                        view.Quantity += stockTemp.Quantity;
                        view.GoodQuantity += stockTemp.GoodQuantity;
                        view.ErrorQuantity += stockTemp.ErrorQuantity;
                        view.DamageQuantity += stockTemp.DamageQuantity;
                        view.LostQuantity += stockTemp.LostQuantity;
                        view.UnconfirmQuantity += stockTemp.UnconfirmQuantity;
                        view.RealQuantity += stockTemp.GoodQuantity + stockTemp.ErrorQuantity + stockTemp.DamageQuantity +
                                        stockTemp.LostQuantity + stockTemp.UnconfirmQuantity;

                        view.ProductMaster = stockTemp.ProductMaster;
                        view.DepartmentStockTemps = new ArrayList();
                        view.DepartmentStockTemps.Add(stockTemp);
                        deptStockTempList.Add(view);
                    }
                }

            }

            e.DeptStockAdhocList = deptStockTempList;



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
            get { return _productLogic; }
            set { _productLogic = value; }
        }

        public IProductMasterLogic ProductMasterLogic
        {
            get { return _productMasterLogic; }
            set { _productMasterLogic = value; }
        }

        public IDepartmentStockTempLogic DepartmentStockTempLogic
        {
            get { return _departmentStockTempLogic; }
            set { _departmentStockTempLogic = value; }
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
