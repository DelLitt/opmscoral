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
            }
        }

        void _departmentStockAdhocProcessingView_LoadAdhocStocksEvent(object sender, DepartmentStockAdhocProcessingEventArgs e)
        {
            ObjectCriteria criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddOrder("ProductMaster.ProductMasterId", true);
            IList list = DepartmentStockTempLogic.FindAll(criteria);

            if (list != null & list.Count > 0)
            {
                IList deptStockTempList = new ArrayList();
                
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
                        view.RealQuantity = stockTemp.GoodQuantity + stockTemp.ErrorQuantity + stockTemp.DamageQuantity +
                                        stockTemp.LostQuantity + stockTemp.UnconfirmQuantity;
                    }
                }

            }

            e.DeptStockAdhocList = list;



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

        #endregion
    }
}
