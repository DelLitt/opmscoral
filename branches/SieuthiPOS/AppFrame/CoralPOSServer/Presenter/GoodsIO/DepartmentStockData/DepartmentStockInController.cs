﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using AppFrame;
using AppFrame.Common;
using AppFrame.Exceptions;
using CoralPOS.Interfaces.Common;
using CoralPOS.Interfaces.Logic;
using CoralPOS.Interfaces.Model;
using CoralPOS.Interfaces.Presenter.GoodsIO;
using CoralPOS.Interfaces.Presenter.GoodsIO.DepartmentGoodsIO;
using CoralPOS.Interfaces.Presenter.GoodsIO.MainStock;
using CoralPOS.Interfaces.Presenter.SalePoints;
using AppFrame.Utility;
using CoralPOS.Interfaces.View.GoodsIO;
using CoralPOS.Interfaces.View.GoodsIO.DepartmentGoodsIO;
using CoralPOS.Utility;
using Microsoft.ReportingServices.Diagnostics.Utilities;
using NHibernate.Criterion;

namespace CoralPOSServer.Presenter.GoodsIO.DepartmentStockData
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
            /*var subCriteria = new SubObjectCriteria("StockOut");
            subCriteria.AddEqCriteria("DefectStatus.DefectStatusId", (long)4); // tạm xuất là 8*/
            var objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("Product.ProductId", e.ProductId);
            objectCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            objectCriteria.AddEqCriteria("DefectStatus.DefectStatusId", (long)4); // tạm xuất là 4
            
            IList list = DepartmentStockOutDetailLogic.FindAll(objectCriteria);
            if (list!=null && list.Count > 0)
            {
                var detail = new DepartmentStockInDetail { Product = ((DepartmentStockOutDetail)list[0]).Product };
                foreach (DepartmentStockOutDetail soDetail in list)
                {
                    detail.StockOutQuantity += soDetail.Quantity;
                }
                e.DepartmentStockInDetail = detail;

                IList reStockInList = DepartmentStockInLogic.FindReStockIn(e.ProductId);
                if (reStockInList != null)
                {
                    foreach (DepartmentStockInDetail inDetail in reStockInList)
                    {
                        e.DepartmentStockInDetail.ReStockQuantity += inDetail.Quantity;
                    }
                }
            }
            e.EventResult = "Success";
        }
        #endregion
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public virtual void departmentStockInView_SaveDepartmentStockInEvent(object sender, DepartmentStockInEventArgs e)
        {

            var stockIn = e.DepartmentStockIn;
            IList masterIds = new ArrayList();
            foreach (DepartmentStockInDetail detail in stockIn.DepartmentStockInDetails)
            {
                if (!masterIds.Contains(detail.Product.ProductMaster.ProductMasterId))
                {
                    masterIds.Add(detail.Product.ProductMaster.ProductMasterId);
                }
            }
            var cri2 = new ObjectCriteria();
            cri2.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            cri2.AddEqCriteria("DepartmentPricePK.DepartmentId", (long)0);
            cri2.AddSearchInCriteria("DepartmentPricePK.ProductMasterId", masterIds);
            IList prices = DepartmentPriceLogic.FindAll(cri2);
            foreach (DepartmentStockInDetail detail in stockIn.DepartmentStockInDetails)
            {
                foreach (DepartmentPrice price in prices)
                {
                    if (price.DepartmentPricePK.ProductMasterId.Equals(detail.Product.ProductMaster.ProductMasterId))
                    {
                        detail.Price = price.Price;
                    }
                    if(price.Price <= 0)
                    {
                        throw new BusinessException(" Giá hàng của " + detail.Product.ProductMaster.ProductName + " bằng 0 hoặc âm. Đề nghị điều chỉnh trước khi xuất ra cửa hàng.");
                    }
                }
            }

            if (stockIn.StockInId == 0)
            {
                //StockOutLogic.Add(stockIn);   
                DepartmentStockInLogic.Add(stockIn);
                if (!e.IsForSync)
                {
                    ClientUtility.Log(logger, stockIn.ToString(), "Nhập kho cửa hàng");
                }
                else
                {
                    ClientUtility.Log(logger, "Đồng bộ về cửa hàng.\r\n" + stockIn.ToString(), "Đồng bộ về cửa hàng");
                }
            }
            else
            {
                //StockOutLogic.Update(stockIn);   
                DepartmentStockInLogic.Update(stockIn);
                if (!e.IsForSync)
                {
                    ClientUtility.Log(logger, "Chỉnh sửa " + stockIn.ToString(), "Chỉnh sửa Nhập kho cửa hàng");
                }
                else
                {
                    ClientUtility.Log(logger, "Đồng bộ về cửa hàng.\r\n" + stockIn.ToString(), "Đồng bộ về cửa hàng");
                }
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

                // Department information
                if (DepartmentLogic != null)
                {
                    e.DepartmentStockIn.Department = DepartmentLogic.FindById(stockIn.DepartmentStockInPK.DepartmentId);
                    criteria = new ObjectCriteria();
                    criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                    criteria.AddEqCriteria("EmployeePK.DepartmentId", stockIn.DepartmentStockInPK.DepartmentId);
                    e.DepartmentStockIn.Department.Employees = EmployeeLogic.FindAll(criteria);
                }
            }
            
            
            e.EventResult = "Success";
        }

        public void departmentStockInView_SyncDepartmentStockInEvent(object sender, DepartmentStockInEventArgs e)
        {
            try
            {
                /*var stockIn = e.DepartmentStockIn;
                DepartmentStockInLogic.Sync(stockIn);*/
                var syncFromMainToDepartment = e.SyncFromMainToDepartment;
                DepartmentStockInLogic.Sync(syncFromMainToDepartment);
                ClientUtility.Log(logger, syncFromMainToDepartment.ToString(), "Đồng bộ từ cửa hàng về kho");
                e.EventResult = "Success";
            }
            catch (Exception)
            {
                
                throw;
            }
            
            e.EventResult = "Success";
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
        public IDepartmentStockInDetailLogic DepartmentStockInDetailLogic
        {
            get;
            set;
        }
        public IStockLogic StockLogic
        {
            get;
            set;
        }
        public IDepartmentStockLogic DepartmentStockLogic
        {
            get;
            set;
        }

        public IDepartmentStockOutLogic DepartmentStockOutLogic
        {
            get;
            set;
        }
        public IDepartmentStockOutDetailLogic DepartmentStockOutDetailLogic
        {
            get;
            set;
        }
        public IDepartmentPriceLogic DepartmentPriceLogic
        {
            get;
            set;
        }
        public IDepartmentLogic DepartmentLogic
        {
            get;
            set;
        }
        public IEmployeeLogic EmployeeLogic
        {
            get;
            set;
        }

        public IStockOutLogic StockOutLogic
        {
            get; set;
        }
        #endregion

        #region Implementation of IBaseController<StockCreateEventArgs>

        public DepartmentStockInEventArgs ResultEventArgs
        {
            get; set;
        }

        #endregion


        #region IDepartmentStockInController Members




        #endregion
    }
}