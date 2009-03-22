using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;

namespace AppFrameClient.Presenter.GoodsIO
{
    public class ProductMasterSearchDepartmentController : IProductMasterSearchDepartmentController
    {
        #region IProductMasterSearchDepartmentController Members

        private AppFrame.View.GoodsIO.IProductMasterSearchDepartmentView productMasterSearchDepartmentView;
        
        public AppFrame.View.GoodsIO.IProductMasterSearchDepartmentView ProductMasterSearchDepartmentView
        {
            get
            {
                return productMasterSearchDepartmentView;
            }
            set
            {
                productMasterSearchDepartmentView = value;
                productMasterSearchDepartmentView.InitProductMasterSearchDepartmentEvent += new EventHandler<ProductMasterSearchDepartmentEventArgs>(productMasterSearchDepartmentView_InitProductMasterSearchDepartmentEvent);
                productMasterSearchDepartmentView.SearchProductMasterEvent += new EventHandler<ProductMasterSearchDepartmentEventArgs>(productMasterSearchDepartmentView_SearchProductMasterEvent);
                productMasterSearchDepartmentView.SelectProductEvent += new EventHandler<ProductMasterSearchDepartmentEventArgs>(productMasterSearchDepartmentView_SelectProductEvent);
                productMasterSearchDepartmentView.SearchProductsEvent+= new EventHandler<ProductMasterSearchDepartmentEventArgs>(productMasterSearchDepartmentView_SearchProductEvent);    
            }
        }

        private void productMasterSearchDepartmentView_SearchProductEvent(object sender, ProductMasterSearchDepartmentEventArgs e)
        {
            ProductMaster searchProductMaster = e.SelectedProductMaster;
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
            IList stockList = DepartmentStockLogic.FindAll(stockCrit);
            if (stockList != null && stockList.Count > 0)
            {
                foreach (DepartmentStock departmentStock in stockList)
                {
                    departmentStock.Product = ProductLogic.FindById(departmentStock.DepartmentStockPK.ProductId);
                    productsInStock.Add(departmentStock);    
                }
                
            }
            e.ProductsInDepartment = productsInStock;
        }

        void productMasterSearchDepartmentView_SelectProductEvent(object sender, ProductMasterSearchDepartmentEventArgs e)
        {
            
        }

        void productMasterSearchDepartmentView_SearchProductMasterEvent(object sender, ProductMasterSearchDepartmentEventArgs e)
        {
            ProductMaster searchProductMaster = new ProductMaster();
            
            if (!string.IsNullOrEmpty(e.ProductMasterId))
            {
                /*long value = 0;
                Int64.TryParse(e.ProductMasterId, out value);*/
                searchProductMaster.ProductMasterId= e.ProductMasterId;
            }
            searchProductMaster.DelFlg = CommonConstants.DEL_FLG_NO;
            searchProductMaster.ProductName= e.ProductMasterName;

            searchProductMaster.ProductType = new ProductType();
            if (e.ProductType != null && e.ProductType.TypeId > 0)
            {
                
                searchProductMaster.ProductType.TypeId= e.ProductType.TypeId;
            }

            searchProductMaster.ProductSize = new ProductSize();
            if (e.ProductSize != null && e.ProductSize.SizeId > 0)
            {
                
                searchProductMaster.ProductSize.SizeId= e.ProductSize.SizeId;
            }

            searchProductMaster.ProductColor = new ProductColor();
            if (e.ProductColor != null && e.ProductColor.ColorId > 0)
            {
                
                searchProductMaster.ProductColor.ColorId= e.ProductColor.ColorId;
            }

            searchProductMaster.Country = new Country();
            if (e.Country != null && e.Country.CountryId > 0)
            {
                
                searchProductMaster.Country.CountryId= e.Country.CountryId;
            }

            bool allDepartment = false;
            e.ProductMasterList = ProductMasterLogic.FindAllInDepartment(searchProductMaster,allDepartment);
        }

        void productMasterSearchDepartmentView_InitProductMasterSearchDepartmentEvent(object sender, ProductMasterSearchDepartmentEventArgs e)
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

        public AppFrame.Logic.IProductMasterLogic ProductMasterLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IProductLogic ProductLogic
        {
            get;
            set;

        }

        public AppFrame.Logic.ICountryLogic CountryLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IProductColorLogic ProductColorLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IProductTypeLogic ProductTypeLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IProductSizeLogic ProductSizeLogic
        {
            get;set;
        }

        public AppFrame.Logic.IManufacturerLogic ManufacturerLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IDistributorLogic DistributorLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IPackagerLogic PackagerLogic
        {
            get;set;
            
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
        #endregion
    }
}
