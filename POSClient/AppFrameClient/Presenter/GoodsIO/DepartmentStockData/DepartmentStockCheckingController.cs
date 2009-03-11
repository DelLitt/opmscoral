using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame;
using AppFrame.Common;
using AppFrame.Exceptions;
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
            if (e.SaveStockDefectList != null && e.SaveStockDefectList.Count > 0)
            {

                long maxId = DepartmentStockDefectLogic.GetMaxDefectId();
                maxId = maxId + 1;
                foreach (DepartmentStockDefect defect in e.SaveStockDefectList)
                {
                    if(    defect.DamageCount == 0 && defect.OldDamageCount == 0 
                        && defect.ErrorCount == 0 && defect.OldErrorCount == 0 
                        && defect.LostCount == 0 && defect.OldLostCount == 0 
                        && defect.UnconfirmCount == 0 && defect.OldUnconfirmCount == 0 )
                    {
                        continue;
                    }

                    defect.CreateDate = DateTime.Now;
                    defect.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    defect.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    defect.UpdateDate = DateTime.Now;
                    defect.DelFlg = 0;

                    // get current stock quantity
                    defect.Quantity = defect.DepartmentStock.Quantity;
                    
                    // calculate business
                    /*int currDamageCount = defect.DamageCount - defect.OldDamageCount;
                    int currErrorCount = defect.ErrorCount - defect.OldErrorCount;
                    int currUnconfirmCount = defect.UnconfirmCount - defect.OldUnconfirmCount;
                    int currLostCount = defect.LostCount - defect.OldLostCount;*/
                    int currDamageCount = defect.DamageCount ;
                    int currErrorCount = defect.ErrorCount ;
                    int currUnconfirmCount = defect.UnconfirmCount ;
                    int currLostCount = defect.LostCount;

                    long totalDefects = currDamageCount + currErrorCount + currLostCount + currUnconfirmCount;

                    /*if (defect.Quantity < totalDefects)
                    {
                        throw new BusinessException("Số lượng hàng lỗi,hư,mất... lớn hơn số tồn thực");
                    }*/

                    defect.GoodCount = defect.Quantity - totalDefects;

                    // update the stock remains equal good count
                    defect.DepartmentStock.Quantity = defect.GoodCount;
                    defect.Quantity = defect.DepartmentStock.Quantity;

                    defect.DepartmentStockDefectPK.DepartmentStockDefectId = maxId++;

                    DepartmentStockDefectLogic.Process(defect);
                    DepartmentStockLogic.Update(defect.DepartmentStock); 
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
            objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("Product.ProductId", e.InputBarcode);
            objectCriteria.AddEqCriteria("DepartmentStockDefectPK.DepartmentId", CurrentDepartment.Get().DepartmentId);
            objectCriteria.AddEqCriteria("DelFlg", (long)0);

            IList stockDefectList = DepartmentStockDefectLogic.FindAll(objectCriteria);
            if (stockDefectList != null && stockDefectList.Count > 0)
            {
                e.ScannedStockDefect = (DepartmentStockDefect)stockDefectList[0];
            }
            else
            {
                e.ScannedStockDefect = null;
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

        #endregion

        #region IInventoryCheckingController Members


        public AppFrame.Logic.IDepartmentStockDefectLogic DepartmentStockDefectLogic
        {
            get;
            set;
        }

        #endregion
    }
}
