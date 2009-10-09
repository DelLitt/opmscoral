using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
            e.CountryList = CountryLogic.FindAll(criteria);
            e.CountryList.Insert(0, new Country());
            e.ManufacturerList = ManufacturerLogic.FindAll(criteria);
            e.ManufacturerList.Insert(0, new Manufacturer());
            e.PackagerList = PackagerLogic.FindAll(criteria);
            e.PackagerList.Insert(0, new Packager());
            e.DistributorList = DistributorLogic.FindAll(criteria);
            e.DistributorList.Insert(0, new Distributor());

            // product type
            criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddOrder("TypeName", true);
            e.ProductTypeList = ProductTypeLogic.FindAll(criteria);
            e.ProductTypeList.Insert(0, new ProductType());

            // product size
            criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddOrder("SizeName", true);
            e.ProductSizeList = ProductSizeLogic.FindAll(criteria);
            e.ProductSizeList.Insert(0, new ProductSize());

            // product color
            criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddOrder("ColorName", true);
            e.ProductColorList = ProductColorLogic.FindAll(criteria);
            e.ProductColorList.Insert(0, new ProductColor());
            

            if (e.ProductMasterForInit != null)
            {
                criteria = new ObjectCriteria();
                criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                criteria.AddEqCriteria("ProductName", e.ProductMasterForInit.ProductName);
                criteria.AddEqCriteria("ProductType", e.ProductMasterForInit.ProductType);
                /*criteria.AddEqCriteria("Manufacturer", e.ProductMasterForInit.Manufacturer);
                criteria.AddEqCriteria("Distributor", e.ProductMasterForInit.Distributor);
                criteria.AddEqCriteria("Packager", e.ProductMasterForInit.Packager);
                criteria.AddEqCriteria("Country", e.ProductMasterForInit.Country);*/

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
                    string realPath = "";
                    if (e.ProductMaster.ImagePath.Contains(":"))
                    {
                        realPath = e.ProductMaster.ImagePath;
                        e.ProductMaster.ImagePath = e.ProductMaster.ProductMasterId + ".jpg";
                    }
                    ProductMasterLogic.Update(e.ProductMaster);
                    if (!string.IsNullOrEmpty(realPath))
                    {
                        CopyAndCreateImage(e.ProductMaster, realPath);
                    }
                    ClientUtility.Log(logger, e.ProductMaster.ToString(), CommonConstants.ACTION_SAVE_PRODUCT_MASTER);
                }
                else  // add new ...
                {
                    // update existing product master
                    string imagePath = null;
                    if (e.UpdateProductMasterList != null && e.UpdateProductMasterList.Count > 0)
                    {
                        if (string.IsNullOrEmpty(imagePath))
                        {
                            ProductMaster first = (ProductMaster) e.UpdateProductMasterList[0];
                            if (!string.IsNullOrEmpty(first.ImagePath) && first.ImagePath.Contains(":"))
                            {
                                imagePath = first.ImagePath;
                                CopyAndCreateImage(first, imagePath);
                            }
                            
                        }
                        
                        foreach (ProductMaster productMaster in e.UpdateProductMasterList)
                        {
                            if (!string.IsNullOrEmpty(productMaster.ImagePath))
                            {
                                productMaster.ImagePath =
                                    StringUtility.ConvertUniStringToHexChar(productMaster.ProductName) + ".jpg";
                            }
                            ProductMasterLogic.Update(productMaster);
                        }
                    }

                    if (e.CreatedProductMasterList != null)
                    {
                        string realPath = "";
                        if (string.IsNullOrEmpty(imagePath))
                        {
                            if (e.CreatedProductMasterList.Count > 0 &&
                                e.CreatedProductMasterList[0].ImagePath.Contains(":"))
                            {
                                realPath = e.CreatedProductMasterList[0].ImagePath;
                            }
                        }
                        ProductMasterLogic.AddAll(e.CreatedProductMasterList);
                        if (!string.IsNullOrEmpty(realPath))
                        {
                            CopyAndCreateImage(e.CreatedProductMasterList[0], realPath);
                        }
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
                        string realPath = "";
                        if (!string.IsNullOrEmpty(e.ProductMaster.ImagePath) && e.ProductMaster.ImagePath.Contains(":"))
                        {
                            realPath = e.ProductMaster.ImagePath;
                        }
                        e.ProductMaster = ProductMasterLogic.Add(e.ProductMaster);
                        if (!string.IsNullOrEmpty(realPath))
                        {
                            CopyAndCreateImage(e.ProductMaster, realPath);
                        }

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

        private void CopyAndCreateImage(ProductMaster productMaster, string realImagePath)
        {
            if (!Directory.Exists(Application.StartupPath + "\\ProductImages\\"))
            {
                Directory.CreateDirectory(Application.StartupPath + "\\ProductImages\\");
            }

            // copy image
            if (File.Exists(realImagePath))
            {
                string existPath = Application.StartupPath + "\\ProductImages\\"
                                   + StringUtility.ConvertUniStringToHexChar(productMaster.ProductName)
                                   + ".jpg";
                if(File.Exists(existPath))
                {
                   File.Delete(existPath); 
                }
                File.Copy(realImagePath, Application.StartupPath + "\\ProductImages\\"
                    + StringUtility.ConvertUniStringToHexChar(productMaster.ProductName) 
                    + ".jpg");
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
