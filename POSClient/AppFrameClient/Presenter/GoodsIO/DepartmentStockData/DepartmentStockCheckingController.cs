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
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using NHibernate.Criterion;
using ArrayList = System.Collections.ArrayList;

namespace AppFrameClient.Presenter.GoodsIO.DepartmentStockData
{
    public class DepartmentStockCheckingController : IDepartmentStockCheckingController
    {
        #region IInventoryCheckingController Members

        IDepartmentStockCheckingView departmentStockCheckingView;
        public IDepartmentStockCheckingView DepartmentStockCheckingView
        {
            get
            {
                return departmentStockCheckingView;
            }
            set
            {
                departmentStockCheckingView = value;

                departmentStockCheckingView.LoadGoodsByProductIdEvent += new EventHandler<DepartmentStockCheckingEventArgs>(inventoryCheckingView_LoadGoodsByProductIdEvent);
                departmentStockCheckingView.SaveInventoryCheckingEvent += new EventHandler<DepartmentStockCheckingEventArgs>(inventoryCheckingView_SaveInventoryCheckingEvent);
            }
        }

        void inventoryCheckingView_SaveInventoryCheckingEvent(object sender, DepartmentStockCheckingEventArgs e)
        {
            if (e.SaveStockList != null && e.SaveStockList.Count > 0)
            {

                
                foreach (DepartmentStock stock in e.SaveStockList)
                {
                    if(    stock.DamageQuantity == 0 && stock.OldDamageQuantity == 0 
                        && stock.ErrorQuantity == 0 && stock.OldErrorQuantity == 0 
                        && stock.LostQuantity == 0 && stock.OldLostQuantity == 0 
                        && stock.UnconfirmQuantity == 0 && stock.OldUnconfirmQuantity == 0 )
                    {
                        continue;
                    }

                    stock.CreateDate = DateTime.Now;
                    stock.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    stock.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    stock.UpdateDate = DateTime.Now;
                    stock.DelFlg = 0;

                    DepartmentStockLogic.Update(stock); 
                }
                
                

                    
            }
        }

        void inventoryCheckingView_LoadGoodsByProductIdEvent(object sender, DepartmentStockCheckingEventArgs e)
        {
            ObjectCriteria objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("DepartmentStockPK.ProductId", e.InputBarcode);
            objectCriteria.AddEqCriteria("DepartmentStockPK.DepartmentId", CurrentDepartment.Get().DepartmentId);
            objectCriteria.AddEqCriteria("DelFlg", (long)0);
            System.Collections.IList stockList = DepartmentStockLogic.FindAll(objectCriteria);
            if (stockList != null && stockList.Count > 0)
            {
                e.ScannedStock = (DepartmentStock)stockList[0];
            }
            else
            {
                e.ScannedStock = null;
            }
        }


        public AppFrame.Logic.IDepartmentStockLogic DepartmentStockLogic
        {
            get;
            set;
        }

        public AppFrame.Logic.IProductLogic ProductLogic
        {
            get;
            set;
        }

        public AppFrame.Logic.IProductMasterLogic ProductMasterLogic
        {
            get;
            set;

        }

        public AppFrame.Logic.IDepartmentStockInLogic DepartmentStockInLogic
        {
            get;
            set;

        }

        public AppFrame.Logic.IDepartmentStockInDetailLogic DepartmentStockInDetailLogic
        {
            get;
            set;

        }

        #endregion

        #region IInventoryCheckingController Members


        public AppFrame.Logic.IDepartmentStockOutLogic DepartmentStockOutLogic
        {
            get;
            set;

        }

        public AppFrame.Logic.IDepartmentStockOutDetailLogic DepartmentStockOutDetailLogic
        {
            get;
            set;
        }

        public IDepartmentStockTempLogic DepartmentStockTempLogic
        {
            get; set;
        }

        #endregion

        
    }
}
