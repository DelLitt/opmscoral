using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.SalePoints;
using AppFrame.Utility;
using AppFrame.View.GoodsIO;
using NHibernate.Criterion;

namespace AppFrameClient.Presenter.GoodsIO
{
    public class StockSearchController : IStockSearchController
    {
        #region View use in IGoodsIOSearchController

        private IStockSearchView _stockSearchView;
        public IStockSearchView StockSearchView
        { 
            get
            {
                return _stockSearchView;
            }
            set
            {
                _stockSearchView = value;
                _stockSearchView.InitStockSearchEvent += new System.EventHandler<StockSearchEventArgs>(stockSearchView_InitStockSearchEvent);
                _stockSearchView.SearchStockEvent += new System.EventHandler<StockSearchEventArgs>(stockSearchView_SearchStockEvent);
                _stockSearchView.RemainSearchStockEvent += new System.EventHandler<StockSearchEventArgs>(stockSearchView_RemainSearchStockEvent);
                _stockSearchView.BarcodeSearchStockEvent += new System.EventHandler<StockSearchEventArgs>(stockSearchView_BarcodeSearchStockEvent);
            }
        }

        private void stockSearchView_BarcodeSearchStockEvent(object sender, StockSearchEventArgs e)
        {
            var subCriteria = new SubObjectCriteria("ProductMaster");
            subCriteria.AddLikeCriteria("ProductName", "%" + e.ProductMasterName + "%");
            subCriteria.AddEqCriteria("ProductType", e.ProductType);
            subCriteria.AddEqCriteria("ProductSize", e.ProductSize);
            subCriteria.AddEqCriteria("ProductColor", e.ProductColor);
            subCriteria.AddEqCriteria("Country", e.Country);
            subCriteria.AddEqCriteria("Manufacturer", e.Manufacturer);
            subCriteria.AddEqCriteria("Packager", e.Packager);
            subCriteria.AddEqCriteria("Distributor", e.Distributor);

            var criteria = new ObjectCriteria(true);
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddLikeCriteria("Product.ProductId", e.ProductMasterId + "%");
            criteria.AddSubCriteria("ProductMaster", subCriteria);
            criteria.AddGreaterOrEqualsCriteria("CreateDate", DateUtility.ZeroTime(e.FromDate));
            criteria.AddLesserOrEqualsCriteria("CreateDate", DateUtility.MaxTime(e.ToDate));
            IList list = StockLogic.FindAll(criteria);
            e.StockList = list;
        }

        #endregion

        public void stockSearchView_SearchStockEvent(object sender, StockSearchEventArgs e)
        {
            /*            var subCriteria1 = new SubObjectCriteria("Product");
                        var subCriteria2 = new SubObjectCriteria("ProductMaster");
                        subCriteria2.AddLikeCriteria("ProductMasterId", e.ProductMasterId);
                        subCriteria2.AddLikeCriteria("ProductName", e.ProductMasterName);*/

            var criteria = new ObjectCriteria(true);
            criteria.AddEqCriteria("stock.DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddLikeCriteria("pm.ProductMasterId", e.ProductMasterId + "%");
            criteria.AddLikeCriteria("pm.ProductName", "%" + e.ProductMasterName + "%");
            criteria.AddEqCriteria("pm.ProductType", e.ProductType);
            criteria.AddEqCriteria("pm.ProductSize", e.ProductSize);
            criteria.AddEqCriteria("pm.ProductColor", e.ProductColor);
            criteria.AddEqCriteria("pm.Country", e.Country);
            criteria.AddEqCriteria("pm.Manufacturer", e.Manufacturer);
            criteria.AddEqCriteria("pm.Packager", e.Packager);
            criteria.AddEqCriteria("pm.Distributor", e.Distributor);
            criteria.AddLikeCriteria("pm.Description", "%" + e.Description + "%");
            IList list = StockLogic.FindByQuery(criteria);
            if(!CheckUtility.IsNullOrEmpty(GlobalCache.Instance().WarningText))
            {
                MessageBox.Show(GlobalCache.Instance().WarningText);
                GlobalCache.Instance().WarningText = null;
            }
            e.StockList = list;
        }

        public void stockSearchView_InitStockSearchEvent(object sender, StockSearchEventArgs e)
        {
            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", (long)0);
            e.ProductTypeList = ProductTypeLogic.FindAll(criteria);
            e.ProductTypeList.Insert(0, new ProductType());
            e.ProductSizeList = ProductSizeLogic.FindAll(criteria);
            e.ProductSizeList.Insert(0, new ProductSize());
            e.ProductColorList = ProductColorLogic.FindAll(criteria);
            e.ProductColorList.Insert(0, new ProductColor());
            e.CountryList = CountryLogic.FindAll(criteria);
            e.CountryList.Insert(0, new Country());
            e.ManufacturerList = ManufacturerLogic.FindAll(criteria);
            e.ManufacturerList.Insert(0, new Manufacturer());
            e.PackagerList = PackagerLogic.FindAll(criteria);
            e.PackagerList.Insert(0, new Packager());
            e.DistributorList = DistributorLogic.FindAll(criteria);
            e.DistributorList.Insert(0, new Distributor());
        }

        #region Logic use in IStockCreateController
        public ICountryLogic CountryLogic { get; set; }
        public IProductColorLogic ProductColorLogic { get; set; }
        public IProductTypeLogic ProductTypeLogic { get; set; }
        public IProductSizeLogic ProductSizeLogic { get; set; }
        public IManufacturerLogic ManufacturerLogic { get; set; }
        public IDistributorLogic DistributorLogic { get; set; }
        public IPackagerLogic PackagerLogic { get; set; }
        public IStockLogic StockLogic { get; set; }
        public IStockInDetailLogic StockInDetailLogic { get; set; }
        public IStockHistoryLogic StockHistoryLogic { get; set; }
        public IDepartmentStockInDetailLogic DepartmentStockInDetailLogic { get; set; }
        #endregion

        #region Implementation of IBaseController<StockCreateEventArgs>

        public StockSearchEventArgs ResultEventArgs
        {
            get; set;
        }

        #endregion

        public void stockSearchView_RemainSearchStockEvent(object sender, StockSearchEventArgs e)
        {
            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", (long)0);
            criteria.AddLesserOrEqualsCriteria("CreateDate", e.FromDate);
            IList deptStockInDetailFromList = DepartmentStockInDetailLogic.FindAll(criteria);
            
            criteria.AddNotEqualsCriteria("StockInType", (long)1);
            IList stockInDetailFromList = StockInDetailLogic.FindAll(criteria);

            criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", (long)0);
            criteria.AddLesserOrEqualsCriteria("CreateDate", e.ToDate);

            IList deptStockInDetailToList = DepartmentStockInDetailLogic.FindAll(criteria);
            criteria.AddNotEqualsCriteria("StockInType", (long)1);
            IList stockInDetailToList = StockInDetailLogic.FindAll(criteria);

//            IList stockHistoryList = StockHistoryLogic.FindByMaxDate(criteria);
            var reportList = new List<UniversalStockReportObject>();

            // calculate dau` ton`
            foreach (StockInDetail stockInDetail in stockInDetailFromList)
            {
                UniversalStockReportObject report = null;
                foreach (var reportObject in reportList)
                {
                    if (stockInDetail.Product.ProductMaster.ProductMasterId.Equals(reportObject.ProductMaster.ProductMasterId))
                    {
                        report = reportObject;
                        break;
                    }
                }

                if (report != null)
                {
                    report.StockStartQuantity += stockInDetail.Quantity;
                    report.StockInStartQuantity += stockInDetail.Quantity;

                }
                else
                {
                    report = new UniversalStockReportObject();
                    reportList.Add(report);
                    report.StockStartQuantity = stockInDetail.Quantity;
                    report.StockInStartQuantity = stockInDetail.Quantity;
                }

                report.ProductMaster = stockInDetail.Product.ProductMaster;
                foreach (DepartmentStockInDetail deptStockInDetail in deptStockInDetailFromList)
                {
                    if (report.ProductMaster.ProductMasterId.Equals(deptStockInDetail.Product.ProductMaster.ProductMasterId))
                    {
                        report.StockStartQuantity -= deptStockInDetail.Quantity;
                        report.DepartmentStockInStartQuantity += deptStockInDetail.Quantity;
                    }
                }
                reportList.Add(report);
            }

            // calculate cuoi ton
            foreach (StockInDetail stockInDetail in stockInDetailToList)
            {
                UniversalStockReportObject report = null;
                foreach (var reportObject in reportList)
                {
                    if (stockInDetail.Product.ProductMaster.ProductMasterId.Equals(reportObject.ProductMaster.ProductMasterId))
                    {
                        report = reportObject;
                        break;
                    }
                }
                if (report != null)
                {
                    report.StockEndQuantity += stockInDetail.Quantity;
                    report.StockInEndQuantity += stockInDetail.Quantity;
                    
                }
                else
                {
                    report = new UniversalStockReportObject();
                    report.ProductMaster = stockInDetail.Product.ProductMaster;
                    reportList.Add(report);
                    report.StockEndQuantity = stockInDetail.Quantity;
                    report.StockInEndQuantity = stockInDetail.Quantity;
                }

                foreach (DepartmentStockInDetail deptStockInDetail in deptStockInDetailToList)
                {
                    if (report.ProductMaster.ProductMasterId.Equals(deptStockInDetail.Product.ProductMaster.ProductMasterId))
                    {
                        report.StockEndQuantity -= deptStockInDetail.Quantity;
                        report.DepartmentStockInEndQuantity += deptStockInDetail.Quantity;
                    }
                }
//                foreach (StockHistory stockHistory in stockHistoryList)
//                {
//                    if (report.ProductMaster.ProductMasterId.Equals(stockHistory.Product.ProductMaster.ProductMasterId))
//                    {
//                        report.LostCount += stockHistory.LostCount;
//                        report.GoodCount += stockHistory.GoodCount;
//                        report.ErrorCount += stockHistory.ErrorCount;
//                        report.DamageCount += stockHistory.DamageCount;
//                    }
//                }
            }
            e.ReportList = reportList;
        }
    }
}
