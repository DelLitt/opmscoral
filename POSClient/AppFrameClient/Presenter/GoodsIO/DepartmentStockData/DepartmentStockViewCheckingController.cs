using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame;
using AppFrame.Common;
using AppFrame.Exceptions;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Utility.Mapper;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrameClient.ViewModel;
using Spring.Transaction.Interceptor;

namespace AppFrameClient.Presenter.GoodsIO.DepartmentStockData
{
    public class DepartmentStockViewCheckingController : IDepartmentStockCheckingController
    {
        private IDepartmentStockCheckingView departmentStockCheckingView;
        public IDepartmentStockCheckingView DepartmentStockCheckingView
        {
            get
            {
                return departmentStockCheckingView;
            }
            set
            {
                departmentStockCheckingView = value;
                departmentStockCheckingView.LoadGoodsByProductIdEvent += new EventHandler<AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.DepartmentStockCheckingEventArgs>(departmentStockCheckingView_LoadGoodsByProductIdEvent);
                departmentStockCheckingView.SaveInventoryCheckingEvent += new EventHandler<AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.DepartmentStockCheckingEventArgs>(departmentStockCheckingView_SaveInventoryCheckingEvent);
                departmentStockCheckingView.SaveTempInventoryCheckingEvent += new EventHandler<DepartmentStockCheckingEventArgs>(departmentStockCheckingView_SaveTempInventoryCheckingEvent);
                departmentStockCheckingView.LoadTempInventoryCheckingEvent += new EventHandler<DepartmentStockCheckingEventArgs>(departmentStockCheckingView_LoadTempInventoryCheckingEvent);
            }
        }

        void departmentStockCheckingView_LoadTempInventoryCheckingEvent(object sender, DepartmentStockCheckingEventArgs e)
        {
            // search in temp stock
            ObjectCriteria criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DepartmentStockTempPK.DepartmentId", CurrentDepartment.Get().DepartmentId);
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddEqCriteria("Fixed", CommonConstants.DEL_FLG_NO);
            criteria.AddEqCriteria("TempSave", CommonConstants.DEL_FLG_NO);
            criteria.AddOrder("ProductMaster.ProductMasterId", true);
            IList list = DepartmentStockTempLogic.FindAll(criteria);
            IList deptStockTempList = null;
            if (list != null && list.Count > 0)
            {
                deptStockTempList = new ArrayList();

                foreach (DepartmentStockTemp stockTempSave in list)
                {
                    int viewIndex = -1;
                    DepartmentStock stockTemp = new DepartmentStockMapper().Convert(stockTempSave);
                    if (HasInList(stockTemp, deptStockTempList, out viewIndex))
                    {
                        DepartmentStockView view = (DepartmentStockView)deptStockTempList[viewIndex];

                        view.Quantity += stockTemp.Quantity;
                        view.GoodQuantity += stockTemp.GoodQuantity;
                        view.ErrorQuantity += stockTemp.ErrorQuantity;
                        view.DamageQuantity += stockTemp.DamageQuantity;
                        view.LostQuantity += stockTemp.LostQuantity;
                        view.UnconfirmQuantity += stockTemp.UnconfirmQuantity;
                        view.DepartmentStocks.Add(stockTemp);
                    }
                    else
                    {
                        DepartmentStockView view = new DepartmentStockView();
                        
                        view.Quantity += stockTemp.Quantity;
                        view.GoodQuantity += stockTemp.GoodQuantity;
                        view.ErrorQuantity += stockTemp.ErrorQuantity;
                        view.DamageQuantity += stockTemp.DamageQuantity;
                        view.LostQuantity += stockTemp.LostQuantity;
                        view.UnconfirmQuantity += stockTemp.UnconfirmQuantity;
                        view.ProductMaster = stockTemp.ProductMaster;
                        view.DepartmentStocks = new ArrayList();
                        view.DepartmentStocks.Add(stockTemp);
                        deptStockTempList.Add(view);
                    }
                }

            }

            e.ReturnStockViewList = deptStockTempList;
        }

        private bool HasInList(DepartmentStock temp, IList list, out int index)
        {
            bool hasInList = false;
            index = 0;
            for (int i = 0; i < list.Count; i++)
            {
                index = i;
                DepartmentStockView view = (DepartmentStockView)list[i];
                if (view.ProductMaster.ProductMasterId.Equals(
                                    temp.Product.ProductMaster.ProductMasterId))
                {
                    hasInList = true;
                    break;
                }
            }

            return hasInList;
        }

        void departmentStockCheckingView_SaveTempInventoryCheckingEvent(object sender, DepartmentStockCheckingEventArgs e)
        {
            try
            {
                DepartmentStockTempLogic.TempSave(e.SaveStockViewList);     
            }
            catch (Exception)
            {

                e.HasErrors = true;
            }
            
        }

        [Transaction(ReadOnly = false)]
        void departmentStockCheckingView_SaveInventoryCheckingEvent(object sender, AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.DepartmentStockCheckingEventArgs e)
        {
            foreach (DepartmentStockView stockView in e.SaveStockViewList)
            {
                long checkedGoodQty = stockView.GoodQuantity;
                long checkedErrorQty = stockView.ErrorQuantity;
                long checkedLostQty = stockView.LostQuantity;
                long checkedDamageQty = stockView.DamageQuantity;
                long checkedUnconfirmQty = stockView.UnconfirmQuantity;
                long goodQuantity, errorQuantity, lostQuantity, damageQuantity, unconfirmQuantity;
                GetCheckingQuantities(stockView.DepartmentStocks, out goodQuantity, out errorQuantity, out lostQuantity, out damageQuantity, out unconfirmQuantity);
                bool NeedFixing = false;
                if (checkedGoodQty != goodQuantity
                       || checkedErrorQty != errorQuantity
                       || checkedLostQty != lostQuantity
                       || checkedDamageQty != damageQuantity
                       || checkedUnconfirmQty != unconfirmQuantity)
                {
                    NeedFixing = true;
                }

                // if after checking quantity is equal with checked values
                if(stockView.Quantity == 
                    (stockView.GoodQuantity+stockView.ErrorQuantity+
                     stockView.DamageQuantity+stockView.LostQuantity+stockView.UnconfirmQuantity))
                {
                    
                    
                    foreach (DepartmentStock stock in stockView.DepartmentStocks)
                    {
                        if(NeedFixing)
                        {
                            stock.GoodQuantity = stock.Quantity;
                            AutoFixing(stock, ref checkedErrorQty, ref checkedDamageQty, ref checkedLostQty, ref checkedUnconfirmQty);
                        }
                        stock.UpdateDate = DateTime.Now;
                        stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        DepartmentStockLogic.Update(stock);
                    }
                    
                }
                else // in case quantity does not equal checked values.
                {
                    // we do auto fixing
                    
                    IList departmentStocks = stockView.DepartmentStocks;
                    SortListByQuantity(departmentStocks);
                    for( int i =0;i < departmentStocks.Count;i++)
                    {
                        DepartmentStock stock = (DepartmentStock) departmentStocks[i];
                        // if not last item
                        if (i < departmentStocks.Count - 1)
                        {
                            if (checkedGoodQty >= stock.Quantity)
                            {
                                stock.GoodQuantity = stock.Quantity;
                                checkedGoodQty -= stock.Quantity;
                            }
                            else
                            {
                                stock.GoodQuantity = checkedGoodQty;
                                checkedGoodQty = 0;
                            }
                        }
                        else
                        {
                            stock.GoodQuantity = checkedGoodQty;
                            checkedGoodQty = 0;
                        }
                    }
                    // do auto fixing here
                    for( int i =departmentStocks.Count -1;i >= 0;i--)
                    {
                        DepartmentStock stock = (DepartmentStock)departmentStocks[i];
                        if(NeedFixing)
                        {
                            // if not last item
                            if( i > 0)
                            {
                                // fixing
                                AutoFixing(stock, ref checkedErrorQty, ref checkedDamageQty, ref checkedLostQty, ref checkedUnconfirmQty);
                            }
                            else // last fixing
                            {
                                // don't need to fix, just map the remain quantities to stock
                                stock.ErrorQuantity = checkedErrorQty;
                                stock.DamageQuantity = checkedDamageQty;
                                stock.LostQuantity = checkedLostQty;
                                stock.UnconfirmQuantity = checkedUnconfirmQty;
                            }
                        }
                        DepartmentStockTempMapper mapper = new DepartmentStockTempMapper();
                        DepartmentStockTempLogic.Add(mapper.Convert(stock));
                    }
                }
            } 
        }

        private void AdjustGoodQuantity(IList temps, long goodQuantity)
        {
            for (int i = 0; i < temps.Count; i++)
            {
                DepartmentStock stockTemp = (DepartmentStock)temps[i];
                if (i == temps.Count - 1)
                {
                    stockTemp.GoodQuantity = goodQuantity;
                    return;
                }

                stockTemp.GoodQuantity = stockTemp.Quantity;
                goodQuantity -= stockTemp.GoodQuantity;
            }
        }

        private void SortListByQuantity(IList temps)
        {
            DepartmentStock stockTemp = null;
            for (int i = 0; i < temps.Count - 1; i++)
            {
                DepartmentStock stockTemp1 = (DepartmentStock)temps[i];
                for (int j = i + 1; j < temps.Count; j++)
                {
                    DepartmentStock stockTemp2 = (DepartmentStock)temps[j];
                    if (stockTemp1.GoodQuantity > stockTemp2.GoodQuantity)
                    {
                        stockTemp = stockTemp1;
                        stockTemp1 = stockTemp2;
                        stockTemp2 = stockTemp;
                    }
                }

            }
        }

        private void AutoFixing(DepartmentStock stock, ref long errorQuantity,ref long damageQuantity,ref long lostQuantity,ref long unconfirmQuantity)
        {
            if (errorQuantity > 0)
            {
                if (stock.GoodQuantity >= errorQuantity)
                {
                    stock.ErrorQuantity = errorQuantity;
                    stock.GoodQuantity -= errorQuantity;
                    errorQuantity = 0;
                }
                else
                {
                    stock.ErrorQuantity = stock.GoodQuantity;
                    stock.GoodQuantity = 0;
                    errorQuantity -= stock.ErrorQuantity;
                }
            }
            if (lostQuantity > 0)
            {
                if (stock.GoodQuantity >= lostQuantity)
                {
                    stock.LostQuantity = lostQuantity;
                    stock.GoodQuantity -= lostQuantity;
                    lostQuantity = 0;
                }
                else
                {
                    stock.LostQuantity = stock.GoodQuantity;
                    stock.GoodQuantity = 0;
                    lostQuantity -= stock.LostQuantity;
                }
            }
            if (damageQuantity > 0)
            {
                if (stock.GoodQuantity >= damageQuantity)
                {
                    stock.DamageQuantity = damageQuantity;
                    stock.GoodQuantity -= damageQuantity;
                    damageQuantity = 0;
                }
                else
                {
                    stock.DamageQuantity = stock.GoodQuantity;
                    stock.GoodQuantity = 0;
                    damageQuantity -= stock.DamageQuantity;
                }
            }
            if (unconfirmQuantity > 0)
            {
                if (stock.GoodQuantity >= unconfirmQuantity)
                {
                    stock.UnconfirmQuantity = unconfirmQuantity;
                    stock.GoodQuantity -= unconfirmQuantity;
                    unconfirmQuantity = 0;
                }
                else
                {
                    stock.UnconfirmQuantity = stock.GoodQuantity;
                    stock.GoodQuantity = 0;
                    unconfirmQuantity -= stock.UnconfirmQuantity;
                }
            } 
        }
        private void GetCheckingQuantities(IList stocks, out long goods, out long errors, out long losses, out long damages, out long unconfirms)
        {
            goods = errors = losses = damages = unconfirms = 0;
            foreach (DepartmentStock stock in stocks)
            {
                goods += stock.GoodQuantity;
                errors += stock.ErrorQuantity;
                losses += stock.LostQuantity;
                damages += stock.DamageQuantity;
                unconfirms += stock.UnconfirmQuantity;
            }
        }

        void departmentStockCheckingView_LoadGoodsByProductIdEvent(object sender, AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.DepartmentStockCheckingEventArgs e)
        {
            string barCode = e.InputBarcode;
            Product product = ProductLogic.FindById(barCode);
            if(product==null)
            {
                return;
            }

            // search in temp stock
            ObjectCriteria criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DepartmentStockTempPK.ProductId", product.ProductId);
            criteria.AddEqCriteria("DepartmentStockTempPK.DepartmentId", CurrentDepartment.Get().DepartmentId);
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            IList tempList =DepartmentStockTempLogic.FindAll(criteria);
            if(tempList!=null && tempList.Count > 0)
            {
                e.UnconfirmTempBarcode = true;
                throw new BusinessException("Mã vạch này đã kiểm trước đó và chưa được xác nhận. Xin liên hệ người quản lý kho.");
            }
            // search in stock
            ProductMaster searchProductMaster = product.ProductMaster;
            ObjectCriteria searchByProductMasterCriteria = new ObjectCriteria();
            /*searchByProductMasterCriteria.AddEqCriteria("Department", CurrentDepartment.Get());
            searchByProductMasterCriteria.AddEqCriteria("ProductMaster", searchProductMaster);
            searchByProductMasterCriteria.AddOrder("CreateDate", false);
            searchByProductMasterCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            IList productsStockIn = DepartmentStockInDetailLogic.FindAllProductMaster(searchProductMaster);*/
            searchByProductMasterCriteria.AddEqCriteria("ProductMaster", searchProductMaster);
            IList productsStockIn = ProductLogic.FindAll(searchByProductMasterCriteria);
            IList productsInStock = new ArrayList();
            IList productIds = new ArrayList();
            //foreach (DepartmentStockInDetail detail in productsStockIn)
            foreach (Product detail in productsStockIn)
            {
                productIds.Add(detail.ProductId);
            }
            ObjectCriteria stockCrit = new ObjectCriteria();
            stockCrit.AddSearchInCriteria("DepartmentStockPK.ProductId", productIds);
            stockCrit.AddEqCriteria("DepartmentStockPK.DepartmentId", CurrentDepartment.Get().DepartmentId);
            stockCrit.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            stockCrit.AddOrder("DepartmentStockPK.ProductId",true);
            IList departmentStocks = DepartmentStockLogic.FindAll(stockCrit);
            
            // create stock view
            if (departmentStocks != null && departmentStocks.Count > 0)
            {
                DepartmentStockView stockView = new DepartmentStockView();
                stockView.ProductMaster = product.ProductMaster;
                stockView.DepartmentStocks = departmentStocks;
                foreach (DepartmentStock departmentStock in departmentStocks)
                {

                    // empty old stock
                    departmentStock.GoodQuantity = 0;
                    departmentStock.ErrorQuantity = 0;
                    departmentStock.UnconfirmQuantity = 0;
                    departmentStock.LostQuantity = 0;
                    departmentStock.DamageQuantity = 0;

                    // sum new stock
                    stockView.Quantity += departmentStock.Quantity;
                    stockView.GoodQuantity += departmentStock.Quantity;
                    stockView.ErrorQuantity += departmentStock.ErrorQuantity;
                    stockView.UnconfirmQuantity += departmentStock.UnconfirmQuantity;
                    stockView.LostQuantity += departmentStock.LostQuantity;
                    stockView.DamageQuantity += departmentStock.DamageQuantity;
                    stockView.ProductId = product.ProductId;
                    
                    stockView.ProductId = product.ProductId;

                }
                e.ScannedStockView = stockView;
            }
        }
        public IDepartmentStockLogic DepartmentStockLogic { get; set; }
        public IDepartmentStockTempLogic DepartmentStockTempLogic { get; set; }
        public IProductLogic ProductLogic { get; set; }
        public IProductMasterLogic ProductMasterLogic { get; set; }
        public IDepartmentStockInLogic DepartmentStockInLogic { get; set; }
        public IDepartmentStockInDetailLogic DepartmentStockInDetailLogic { get; set; }
        public IDepartmentStockOutLogic DepartmentStockOutLogic { get; set; }
        public IDepartmentStockOutDetailLogic DepartmentStockOutDetailLogic { get; set; }
    }
}
