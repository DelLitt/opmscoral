using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.Presenter.SalePoints;
using AppFrame.Utility;
using AppFrame.View.GoodsIO;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using NHibernate.Criterion;

namespace AppFrameClient.Presenter.GoodsIO.DepartmentStockData
{
    public class DepartmentStockInController : IDepartmentStockInController
    {
        #region View use in IDepartmentStockInController

        private IDepartmentStockInView _departmentStockInView;
        public IDepartmentStockInView DepartmentStockInView
        { 
            get
            {
                return _departmentStockInView;
            }
            set
            {
                _departmentStockInView = value;
                _departmentStockInView.InitDepartmentStockInEvent += new System.EventHandler<DepartmentStockInEventArgs>(departmentStockInView_InitStockSearchEvent);
                _departmentStockInView.FindProductMasterEvent += new System.EventHandler<DepartmentStockInEventArgs>(departmentStockInView_SearchStockEvent);
                _departmentStockInView.SaveDepartmentStockInEvent += new System.EventHandler<DepartmentStockInEventArgs>(departmentStockInView_SaveDepartmentStockInEvent);
                _departmentStockInView.SyncDepartmentStockInEvent += new System.EventHandler<DepartmentStockInEventArgs>(departmentStockInView_SyncDepartmentStockInEvent);
                _departmentStockInView.FindByBarcodeEvent += new EventHandler<DepartmentStockInEventArgs>(_departmentStockInView_FindByBarcodeEvent);
                _departmentStockInView.SaveReDepartmentStockInEvent += new EventHandler<DepartmentStockInEventArgs>(_departmentStockInView_SaveReDepartmentStockInEvent);
            }
        }

        void _departmentStockInView_SaveReDepartmentStockInEvent(object sender, DepartmentStockInEventArgs e)
        {
            try
            {
                DepartmentStockInLogic.AddReStock(e.DepartmentStockIn);
                e.HasErrors = false;
                e.EventResult = "Success";
            }
            catch (Exception)
            {

                throw;
            }
        }

        void _departmentStockInView_FindByBarcodeEvent(object sender, DepartmentStockInEventArgs e)
        {
            var subCriteria = new SubObjectCriteria("StockOut");
            subCriteria.AddEqCriteria("DefectStatus.DefectStatusId", (long)4); // tạm xuất là 8
            var objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("Product.ProductId", e.ProductId);
            objectCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            objectCriteria.AddSubCriteria("StockOut", subCriteria);
            IList list = DepartmentStockOutDetailLogic.FindAll(objectCriteria);
            if (list.Count > 0)
            {
                var detail = new DepartmentStockInDetail { Product = ((StockOutDetail)list[0]).Product };
                foreach (DepartmentStockInDetail soDetail in list)
                {
                    detail.DepartmentStockOutQuantity += soDetail.Quantity;
                }
                e.DepartmentStockInDetail = detail;
            }
            e.EventResult = "Success";
        }
        #endregion

        public void departmentStockInView_SaveDepartmentStockInEvent(object sender, DepartmentStockInEventArgs e)
        {
            var stockIn = e.DepartmentStockIn;
            if (stockIn.StockInId == 0)
            {
                DepartmentStockInLogic.Add(stockIn);
            }
            else
            {
                DepartmentStockInLogic.Update(stockIn);
            }
            if (stockIn.DepartmentStockInPK != null && e.IsForSync)
            {
                e.DepartmentStockIn = DepartmentStockInLogic.FindById(stockIn.DepartmentStockInPK);
                IList productMasterIds = new ArrayList();
                foreach (DepartmentStockInDetail detail in e.DepartmentStockIn.DepartmentStockInDetails)
                {
                    if (!productMasterIds.Contains(detail.Product.ProductMaster.ProductMasterId))
                    {
                        productMasterIds.Add(detail.Product.ProductMaster.ProductMasterId);
                    }
                }
                var criteria = new ObjectCriteria();
                criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                criteria.AddEqCriteria("DepartmentPricePK.DepartmentId", (long)0);
                criteria.AddSearchInCriteria("DepartmentPricePK.ProductMasterId", productMasterIds);
                IList priceList = DepartmentPriceLogic.FindAll(criteria);
                foreach (DepartmentStockInDetail detail in e.DepartmentStockIn.DepartmentStockInDetails)
                {
                    foreach (DepartmentPrice price in priceList)
                    {
                        if (price.DepartmentPricePK.ProductMasterId.Equals(detail.Product.ProductMaster.ProductMasterId))
                        {
                            detail.Price = price.Price;
                        }
                    }
                }
            }
            e.EventResult = "Success";
        }

        public void departmentStockInView_SyncDepartmentStockInEvent(object sender, DepartmentStockInEventArgs e)
        {
            var stockIn = e.DepartmentStockIn;
            DepartmentStockInLogic.Sync(stockIn);
        }

        public void departmentStockInView_SearchStockEvent(object sender, DepartmentStockInEventArgs e)
        {
            e.SelectedProductMaster = ProductMasterLogic.FindById(e.ProductMasterId);
        }

        public void departmentStockInView_InitStockSearchEvent(object sender, DepartmentStockInEventArgs e)
        {
            var stockIn = e.DepartmentStockIn;
            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", (long)0);
            criteria.AddEqCriteria("DepartmentStockInDetailPK.StockInId", stockIn.StockInId);
            criteria.AddEqCriteria("DepartmentStockInDetailPK.DepartmentId", CurrentDepartment.Get().DepartmentId);
            IList stockInDetailList = DepartmentStockInDetailLogic.FindAll(criteria);

            stockIn.DepartmentStockInDetails = stockInDetailList;
            if (stockInDetailList.Count > 0)
            {
                IList productIdList = new ArrayList();
                IList productMasterIdList = new ArrayList();
                foreach (DepartmentStockInDetail detail in stockInDetailList)
                {
                    productIdList.Add(detail.Product.ProductId);
                    productMasterIdList.Add(detail.Product.ProductMaster.ProductMasterId);
                }
                criteria = new ObjectCriteria();
                criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO)
                    .AddEqCriteria("DepartmentStockPK.DepartmentId", CurrentDepartment.Get().DepartmentId)
                    .AddSearchInCriteria("DepartmentStockPK.ProductId", productIdList);
                IList departmentStockList = DepartmentStockLogic.FindAll(criteria);
                e.DepartmentStockList = departmentStockList;

                criteria = new ObjectCriteria(true);
                criteria.AddEqCriteria("s.DelFlg", CommonConstants.DEL_FLG_NO)
                    .AddEqCriteria("sdetail.DelFlg", CommonConstants.DEL_FLG_NO)
                    .AddEqCriteria("s.DepartmentStockPK.DepartmentId", CurrentDepartment.Get().DepartmentId)
                    .AddSearchInCriteria("pm.ProductMasterId", productMasterIdList);
                //e.DepartmentRemainStockList = DepartmentStockLogic.FindByQuery(criteria);
            }
        }

        #region Logic use in IDepartmentStockInController
        public IProductMasterLogic ProductMasterLogic
        {
            get;
            set;
        }

        public IDepartmentStockInLogic DepartmentStockInLogic
        {
            get;
            set;
        }
        public IStockInLogic StockInLogic
        {
            get;
            set;
        }
        public IDepartmentStockInDetailLogic DepartmentStockInDetailLogic
        {
            get;
            set;
        }
        public IDepartmentStockLogic DepartmentStockLogic
        {
            get;
            set;
        }

        public IDepartmentPriceLogic DepartmentPriceLogic
        {
            get;
            set;
        }
        #endregion

        #region Implementation of IBaseController<StockCreateEventArgs>

        public DepartmentStockInEventArgs ResultEventArgs
        {
            get; set;
        }

        #endregion


        #region IDepartmentStockInController Members


        public IDepartmentStockOutLogic DepartmentStockOutLogic
        {
            get;set;
        }

        public IDepartmentStockOutDetailLogic DepartmentStockOutDetailLogic
        {
            get;set;
        }

        #endregion
    }
}