using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO;
using AppFrame.Presenter.SalePoints;
using AppFrame.View.GoodsIO;
using AppFrameClient.Utility;

namespace AppFrameClient.Presenter.GoodsIO
{
    public class ProductMasterController : IProductMasterController
    {
        #region View use in IProductMasterController
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IProductMasterView _productMasterView;
        public IProductMasterView ProductMasterView
        {
            get
            {
                return _productMasterView;
            }
            set
            {
                _productMasterView = value;
                _productMasterView.SaveProductMasterEvent += new System.EventHandler<ProductMasterEventArgs>(productMasterView_SaveProductMasterEvent);
                _productMasterView.LoadProductMasterEvent += new System.EventHandler<ProductMasterEventArgs>(productMasterView_LoadProductMasterEvent);
                _productMasterView.InitProductMasterEvent += new System.EventHandler<ProductMasterEventArgs>(productMasterView_InitProductMasterEvent);
                _productMasterView.DeleteProductMasterEvent += new System.EventHandler<ProductMasterEventArgs>(productMasterView_DeleteProductMasterEvent);
            }
        }

        private IProductMasterEditView productMasterEditView;
        public IProductMasterEditView ProductMasterEditView
        {
            get
            {
                return productMasterEditView;
            }
            set
            {
                productMasterEditView = value;
                productMasterEditView.LoadProductMasters += new EventHandler<ProductMasterEventArgs>(productMasterEditView_LoadProductMasters);
                productMasterEditView.SaveProductMasters += new EventHandler<ProductMasterEventArgs>(productMasterEditView_SaveProductMasters);
            }
        }

        void productMasterEditView_SaveProductMasters(object sender, ProductMasterEventArgs e)
        {
            
            //ProductMasterLogic.FindAll();
        }

        void productMasterEditView_LoadProductMasters(object sender, ProductMasterEventArgs e)
        {
            
        }

        #endregion

        private void productMasterView_InitProductMasterEvent(object sender, ProductMasterEventArgs e)
        {
            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
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

            if (e.ProductMasterForInit != null)
            {
                criteria = new ObjectCriteria();
                criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                criteria.AddEqCriteria("ProductName", e.ProductMasterForInit.ProductName);
                criteria.AddEqCriteria("ProductType", e.ProductMasterForInit.ProductType);
                criteria.AddEqCriteria("Manufacturer", e.ProductMasterForInit.Manufacturer);
                criteria.AddEqCriteria("Distributor", e.ProductMasterForInit.Distributor);
                criteria.AddEqCriteria("Packager", e.ProductMasterForInit.Packager);
                criteria.AddEqCriteria("Country", e.ProductMasterForInit.Country);

                e.SameProductMasterList = ProductMasterLogic.FindAll(criteria);
            }
        }

        public void productMasterView_LoadProductMasterEvent(object sender, ProductMasterEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.ProductMasterId))
            {
                e.ProductMaster = ProductMasterLogic.FindById(e.ProductMasterId);
                if (e.ProductMaster != null)
                {
                    // all the dept has same price
                    var criteria = new ObjectCriteria();
                    criteria.AddEqCriteria("DepartmentPricePK.ProductMasterId", e.ProductMasterId);
                    criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                    IList list = DepartmentPriceLogic.FindAll(criteria);
                    if (list.Count > 0)
                    {
                        e.DepartmentPrice = (DepartmentPrice)list[0];
                    }
                }

            }
        }

        public void productMasterView_SaveProductMasterEvent(object sender, ProductMasterEventArgs e)
        {
            try
            {
                if (e.ProductMaster != null && !string.IsNullOrEmpty(e.ProductMaster.ProductMasterId))
                {
                    ProductMasterLogic.Update(e.ProductMaster);
                    ClientUtility.Log(logger, e.ProductMaster.ToString(), CommonConstants.ACTION_SAVE_PRODUCT_MASTER);
                }
                else
                {
                    if (e.CreatedProductMasterList != null)
                    {
                        ProductMasterLogic.AddAll(e.CreatedProductMasterList);

                        StringBuilder sb = new StringBuilder("Tổng số lượng sản phẩm: ")
                            .Append(e.CreatedProductMasterList.Count).Append("\r\n");
                        
                        foreach (ProductMaster pm in e.CreatedProductMasterList)
                        {
                            sb.Append(pm.ToString()).Append("\r\n");
                        }
                        ClientUtility.Log(logger, sb.ToString(), CommonConstants.ACTION_SAVE_PRODUCT_MASTER);
                    }
                    else if (e.ProductMaster != null)
                    {
                        e.ProductMaster = ProductMasterLogic.Add(e.ProductMaster);
                        ClientUtility.Log(logger, e.ProductMaster.ToString(), CommonConstants.ACTION_SAVE_PRODUCT_MASTER);
                    }
                }
                e.EventResult = "Success";
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void productMasterView_DeleteProductMasterEvent(object sender, ProductMasterEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.ProductMasterId))
            {
                ProductMasterLogic.Delete(new ProductMaster { ProductMasterId = e.ProductMasterId });
            }
        }

        #region Logic use in IProductMasterController
        public ICountryLogic CountryLogic { get; set; }
        public IProductColorLogic ProductColorLogic { get; set; }
        public IProductTypeLogic ProductTypeLogic { get; set; }
        public IProductSizeLogic ProductSizeLogic { get; set; }
        public IManufacturerLogic ManufacturerLogic { get; set; }
        public IDistributorLogic DistributorLogic { get; set; }
        public IPackagerLogic PackagerLogic { get; set; }
        public IProductMasterLogic ProductMasterLogic { get; set; }
        public IDepartmentPriceLogic DepartmentPriceLogic { get; set; }
        #endregion

        #region Implementation of IBaseController<ProductMasterEventArgs>

        public ProductMasterEventArgs ResultEventArgs
        {
            get;
            set;
        }

        #endregion
    }
}
