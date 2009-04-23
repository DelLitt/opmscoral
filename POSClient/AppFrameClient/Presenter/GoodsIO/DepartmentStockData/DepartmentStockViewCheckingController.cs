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
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
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
            }
        }
        [Transaction(ReadOnly = false)]
        void departmentStockCheckingView_SaveInventoryCheckingEvent(object sender, AppFrame.Presenter.GoodsIO.DepartmentGoodsIO.DepartmentStockCheckingEventArgs e)
        {
            foreach (DepartmentStockView stockView in e.SaveStockViewList)
            {
                long goodQuantity, errorQuantity, lostQuantity, damageQuantity, unconfirmQuantity;
                GetCheckingQuantities(stockView.DepartmentStocks,out goodQuantity,out errorQuantity,out lostQuantity,out damageQuantity,out unconfirmQuantity);
                // if normal quantity
                if(stockView.Quantity == 
                    (stockView.GoodQuantity+stockView.ErrorQuantity+
                     stockView.DamageQuantity+stockView.LostQuantity+stockView.UnconfirmQuantity))
                {
                    long checkedGoodQty = stockView.GoodQuantity;
                    long checkedErrorQty = stockView.ErrorQuantity;
                    long checkedLostQty = stockView.LostQuantity;
                    long checkedDamageQty = stockView.DamageQuantity;
                    long checkedUnconfirmQty = stockView.UnconfirmQuantity;

                    foreach (DepartmentStock stock in stockView.DepartmentStocks)
                    {
                        if(stockView.UnconfirmQuantity!=unconfirmQuantity)
                        {
                            
                        }
                    }                    
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
            // search in stock
            ProductMaster searchProductMaster = product.ProductMaster;
            ObjectCriteria searchByProductMasterCriteria = new ObjectCriteria();
            searchByProductMasterCriteria.AddEqCriteria("Department", CurrentDepartment.Get());
            searchByProductMasterCriteria.AddEqCriteria("ProductMaster", searchProductMaster);
            searchByProductMasterCriteria.AddOrder("CreateDate", false);
            searchByProductMasterCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            IList productsStockIn = DepartmentStockInDetailLogic.FindAllProductMaster(searchProductMaster);
            IList productsInStock = new ArrayList();
            IList productIds = new ArrayList();
            foreach (DepartmentStockInDetail detail in productsStockIn)
            {
                productIds.Add(detail.Product.ProductId);
            }
            ObjectCriteria stockCrit = new ObjectCriteria();
            stockCrit.AddSearchInCriteria("DepartmentStockPK.ProductId", productIds);
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
        public IProductLogic ProductLogic { get; set; }
        public IProductMasterLogic ProductMasterLogic { get; set; }
        public IDepartmentStockInLogic DepartmentStockInLogic { get; set; }
        public IDepartmentStockInDetailLogic DepartmentStockInDetailLogic { get; set; }
        public IDepartmentStockOutLogic DepartmentStockOutLogic { get; set; }
        public IDepartmentStockOutDetailLogic DepartmentStockOutDetailLogic { get; set; }
    }
}
