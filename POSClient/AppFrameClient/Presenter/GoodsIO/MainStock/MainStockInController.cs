using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Presenter.GoodsIO.MainStock;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;
using AppFrame.View.GoodsIO.MainStock;
using AppFrameClient.Utility;

namespace AppFrameClient.Presenter.GoodsIO.MainStock
{
    public class MainStockInController : IMainStockInController
    {

        #region IDepartmentStockInExtraController Members
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private IMainStockInView mainStockInView;
        public IMainStockInView MainStockInView
        {
            get
            {
                return mainStockInView;
            }
            set
            {
                mainStockInView = value;

                mainStockInView.FillProductToComboEvent +=
                            new EventHandler<MainStockInEventArgs>(_departmentStockInView_FillProductToComboEvent);
                mainStockInView.SaveStockInEvent +=
                            new EventHandler<MainStockInEventArgs>(_departmentStockInView_SaveStockInEvent);
                mainStockInView.LoadGoodsByIdEvent +=
                            new EventHandler<MainStockInEventArgs>(_departmentStockInView_LoadGoodsByIdEvent);
                mainStockInView.LoadGoodsByNameEvent +=
                            new EventHandler<MainStockInEventArgs>(_departmentStockInView_LoadGoodsByNameEvent);
                mainStockInView.GetPriceEvent +=
                            new EventHandler<MainStockInEventArgs>(_departmentStockInView_GetPriceEvent);

                mainStockInView.LoadProductColorEvent += new EventHandler<MainStockInEventArgs>(departmentStockInExtraView_LoadProductColorEvent);
                mainStockInView.LoadProductSizeEvent += new EventHandler<MainStockInEventArgs>(departmentStockInExtraView_LoadProductSizeEvent);
                mainStockInView.LoadGoodsByNameColorEvent +=
                    new EventHandler<MainStockInEventArgs>(_departmentStockInView_LoadGoodsByNameAndColorEvent);
                mainStockInView.LoadGoodsByNameColorSizeEvent +=
            new EventHandler<MainStockInEventArgs>(_departmentStockInView_LoadGoodsByNameColorSizeEvent);
                mainStockInView.LoadAllGoodsByNameEvent += new EventHandler<MainStockInEventArgs>(mainStockInView_LoadAllGoodsByNameEvent);
                mainStockInView.FindByBarcodeEvent += new EventHandler<MainStockInEventArgs>(mainStockInView_FindByBarcodeEvent);
                mainStockInView.SaveReStockInEvent += new EventHandler<MainStockInEventArgs>(mainStockInView_SaveReStockInEvent);
            }
        }

        public void mainStockInView_SaveReStockInEvent(object sender, MainStockInEventArgs e)
        {
            try
            {
                StockInLogic.AddReStock(e.StockIn);
                e.HasErrors = false;
                e.EventResult = "Success";
            }
            catch (Exception)
            {
                
                throw;
            }
            

        }

        public void mainStockInView_FindByBarcodeEvent(object sender, MainStockInEventArgs e)
        {
            var subCriteria = new SubObjectCriteria("StockOut");
            subCriteria.AddEqCriteria("DefectStatus.DefectStatusId", (long)4); // tạm xuất là 4
            var objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("Product.ProductId", e.ProductId);
            objectCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            objectCriteria.AddEqCriteria("DefectStatus.DefectStatusId", (long) 4);
            //objectCriteria.AddSubCriteria("StockOut", subCriteria);
            IList list = StockOutDetailLogic.FindAll(objectCriteria);
            if (list!=null && list.Count > 0)
            {
                var detail = new StockInDetail { Product = ((StockOutDetail)list[0]).Product };
                foreach (StockOutDetail soDetail in list)
                {
                    detail.StockOutQuantity += soDetail.Quantity;
                }
                e.StockInDetail = detail;
            }

            IList reStockInList = StockInLogic.FindReStockIn(e.ProductId);
            if(reStockInList!=null)
            {
                foreach (StockInDetail inDetail in reStockInList)
                {
                    e.StockInDetail.ReStockQuantity += inDetail.Quantity;
                }                
            }

            e.EventResult = "Success";
        }

        void mainStockInView_LoadAllGoodsByNameEvent(object sender, MainStockInEventArgs e)
        {
            if(e.SelectedProductMaster!=null)
            {
                var criteria = new ObjectCriteria();
                criteria.AddEqCriteria("ProductName", e.SelectedProductMaster.ProductName);
                // sort by color and size
                
                IList productMastersList = ProductMasterLogic.FindAll(criteria);
                
                e.ProductMasterList = productMastersList;
            }
        }

        void departmentStockInExtraView_LoadProductSizeEvent(object sender, MainStockInEventArgs e)
        {
            if (e.SelectedStockInDetail != null && e.SelectedStockInDetail.Product != null && !string.IsNullOrEmpty(e.SelectedStockInDetail.Product.ProductMaster.ProductName))
            {
                var subCriteria = new SubObjectCriteria("ProductMasters");
                subCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                subCriteria.AddEqCriteria("ProductType", e.SelectedStockInDetail.Product.ProductMaster.ProductType);
                subCriteria.AddEqCriteria("ProductName", e.SelectedStockInDetail.Product.ProductMaster.ProductName);
                subCriteria.AddEqCriteria("ProductColor", e.SelectedStockInDetail.Product.ProductMaster.ProductColor);
                subCriteria.AddEqCriteria("Country", e.SelectedStockInDetail.Product.ProductMaster.Country);
                subCriteria.AddEqCriteria("Manufacturer", e.SelectedStockInDetail.Product.ProductMaster.Manufacturer);
                subCriteria.AddEqCriteria("Distributor", e.SelectedStockInDetail.Product.ProductMaster.Distributor);
                subCriteria.AddEqCriteria("Packager", e.SelectedStockInDetail.Product.ProductMaster.Packager);
                var criteria = new ObjectCriteria();
                criteria.AddSubCriteria("ProductMasters", subCriteria);
                IList productSizes = ProductSizeLogic.FindAll(criteria);
                e.ProductSizeList = productSizes;
            }
        }

        void departmentStockInExtraView_LoadProductColorEvent(object sender, MainStockInEventArgs e)
        {
            if (e.SelectedStockInDetail != null && e.SelectedStockInDetail.Product != null
                && !string.IsNullOrEmpty(e.SelectedStockInDetail.Product.ProductMaster.ProductName))
            {
                var subCriteria = new SubObjectCriteria("ProductMasters");
                subCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                subCriteria.AddEqCriteria("ProductType", e.SelectedStockInDetail.Product.ProductMaster.ProductType);
                subCriteria.AddEqCriteria("ProductName", e.SelectedStockInDetail.Product.ProductMaster.ProductName);
                subCriteria.AddEqCriteria("ProductSize", e.SelectedStockInDetail.Product.ProductMaster.ProductSize);
                subCriteria.AddEqCriteria("Country", e.SelectedStockInDetail.Product.ProductMaster.Country);
                subCriteria.AddEqCriteria("Manufacturer", e.SelectedStockInDetail.Product.ProductMaster.Manufacturer);
                subCriteria.AddEqCriteria("Distributor", e.SelectedStockInDetail.Product.ProductMaster.Distributor);
                subCriteria.AddEqCriteria("Packager", e.SelectedStockInDetail.Product.ProductMaster.Packager);
                var criteria = new ObjectCriteria();
                criteria.AddSubCriteria("ProductMasters",subCriteria);
                IList productColors = ProductColorLogic.FindAll(criteria);
                e.ProductColorList = productColors;
            }
        }

        void _departmentStockInView_LoadGoodsByNameEvent(object sender, MainStockInEventArgs e)
        {
            StockInDetail detail = e.SelectedStockInDetail;
            ObjectCriteria objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            objectCriteria.AddEqCriteria("ProductName", detail.Product.ProductMaster.ProductName);            
            IList list  = ProductMasterLogic.FindAll(objectCriteria);
            e.FoundProductMasterList = list;
            if (list == null || list.Count == 0)
            {
                return;
            }
            ProductMaster prodMaster = list[0] as ProductMaster;
            detail.Product.ProductMaster = prodMaster;
            e.SelectedStockInDetail = detail;
        }

        void _departmentStockInView_LoadGoodsByNameAndColorEvent(object sender, MainStockInEventArgs e)
        {
            StockInDetail detail = e.SelectedStockInDetail;
            ObjectCriteria objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("ProductName", detail.Product.ProductMaster.ProductName);
            objectCriteria.AddEqCriteria("ProductType", e.SelectedStockInDetail.Product.ProductMaster.ProductType);
            objectCriteria.AddEqCriteria("Country", e.SelectedStockInDetail.Product.ProductMaster.Country);
            objectCriteria.AddEqCriteria("Manufacturer", e.SelectedStockInDetail.Product.ProductMaster.Manufacturer);
            objectCriteria.AddEqCriteria("Distributor", e.SelectedStockInDetail.Product.ProductMaster.Distributor);
            objectCriteria.AddEqCriteria("Packager", e.SelectedStockInDetail.Product.ProductMaster.Packager);
            objectCriteria.AddEqCriteria("ProductColor", e.SelectedStockInDetail.Product.ProductMaster.ProductColor);
            IList list = ProductMasterLogic.FindAll(objectCriteria);
            if (list == null || list.Count == 0)
            {
                return;
            }
            ProductMaster prodMaster = list[0] as ProductMaster;
            detail.Product.ProductMaster = prodMaster;
            e.SelectedStockInDetail = detail;
            departmentStockInExtraView_LoadProductSizeEvent(sender, e);
        }

        void _departmentStockInView_LoadGoodsByNameColorSizeEvent(object sender, MainStockInEventArgs e)
        {
            StockInDetail detail = e.SelectedStockInDetail;
            ObjectCriteria objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("ProductName", detail.Product.ProductMaster.ProductName);
            objectCriteria.AddEqCriteria("ProductType", e.SelectedStockInDetail.Product.ProductMaster.ProductType);
            objectCriteria.AddEqCriteria("Country", e.SelectedStockInDetail.Product.ProductMaster.Country);
            objectCriteria.AddEqCriteria("Manufacturer", e.SelectedStockInDetail.Product.ProductMaster.Manufacturer);
            objectCriteria.AddEqCriteria("Distributor", e.SelectedStockInDetail.Product.ProductMaster.Distributor);
            objectCriteria.AddEqCriteria("Packager", e.SelectedStockInDetail.Product.ProductMaster.Packager);
            objectCriteria.AddEqCriteria("ProductColor", e.SelectedStockInDetail.Product.ProductMaster.ProductColor);
            objectCriteria.AddEqCriteria("ProductSize", e.SelectedStockInDetail.Product.ProductMaster.ProductSize);
            IList list = ProductMasterLogic.FindAll(objectCriteria);
            if (list == null || list.Count == 0)
            {
                return;
            }
            ProductMaster prodMaster = list[0] as ProductMaster;
            detail.Product.ProductMaster = prodMaster;
            e.SelectedStockInDetail = detail;
        }


        void _departmentStockInView_LoadGoodsByIdEvent(object sender, MainStockInEventArgs e)
        {
            StockInDetail detail = e.SelectedStockInDetail;
            ProductMaster prodMaster = ProductMasterLogic.FindById(detail.Product.ProductMaster.ProductMasterId);
            if (prodMaster == null)
            {
                return;
            }
            detail.Product.ProductMaster = prodMaster;

            e.SelectedStockInDetail = detail;
        }

        void _departmentStockInView_GetPriceEvent(object sender, MainStockInEventArgs e)
        {
            var pk = new DepartmentPricePK { DepartmentId = 0, ProductMasterId = e.ProductMasterIdForPrice };
            e.DepartmentPrice = DepartmentPriceLogic.FindById(pk);
        }

        void _departmentStockInView_SaveStockInEvent(object sender, MainStockInEventArgs e)
        {

            if (string.IsNullOrEmpty(e.StockIn.StockInId))
            {
                StockInLogic.Add(e.StockIn);
                ClientUtility.Log(logger, e.StockIn.ToString(), CommonConstants.ACTION_ADD_STOCK_IN);
            }
            else
            {
                StockInLogic.Update(e.StockIn);
                ClientUtility.Log(logger, e.StockIn.ToString(), CommonConstants.ACTION_UPDATE_STOCK_IN);
            }
            e.EventResult = "Success";
        }

        void _departmentStockInView_FillProductToComboEvent(object sender, MainStockInEventArgs e)
        {
            ComboBox comboBox = (ComboBox) sender;
            string originalText = comboBox.Text;
            if (e.IsFillToComboBox)
            {
                ProductMaster searchPM = e.SelectedStockInDetail.Product.ProductMaster;
                System.Collections.IList result = null;
                if (e.ComboBoxDisplayMember.Equals("ProductMasterId"))
                {
                    result = ProductMasterLogic.FindProductMasterById(searchPM.ProductMasterId, 50,true);
                }
                else
                {
                    //result = ProductMasterLogic.FindProductMasterByName(searchPM.ProductName, 50,true);
                    ObjectCriteria criteria = new ObjectCriteria();
                    criteria.AddLikeCriteria("ProductName", "%" + searchPM.ProductName + "%");
                    criteria.AddOrder("ProductName", true);
                    criteria.MaxResult = 200;
                    result = ProductMasterLogic.FindAll(criteria);

                }
                if(result==null)
                {
                    return;
                }

                BindingList<ProductMaster> productMasters = new BindingList<ProductMaster>();
                if (result != null)
                {
                    result = RemoveDuplicateName(result);
                    foreach (ProductMaster master in result)
                    {

                        productMasters.Add(master);
                    }
                }
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = productMasters;
                comboBox.DataSource = bindingSource;
                comboBox.DisplayMember = "ProductName";
                comboBox.ValueMember = e.ComboBoxDisplayMember;
                comboBox.DropDownWidth = 300;
                comboBox.DropDownHeight = 200;
                // keep the original text
                comboBox.Text = originalText;
                if (result.Count > 0)
                {
                    comboBox.SelectedIndex = 0;
                }
                
                comboBox.SelectionStart = comboBox.Text.Length;
                //comboBox.DroppedDown = false;
                comboBox.MaxDropDownItems = 15;
            }
        }
        private IList RemoveDuplicateName(IList prdlist)
        {
            IList list = new ArrayList();
            foreach (ProductMaster productMaster in prdlist)
            {
                if (NotInList(productMaster, list))
                {
                    list.Add(productMaster);
                }
            }
            return list;
        }
        private bool NotInList(ProductMaster master, IList list)
        {
            foreach (ProductMaster productMaster in list)
            {
                if (productMaster.ProductName.Equals(master.ProductName))
                {
                    return false;
                }
            }
            return true;
        }
        #endregion

        #region IDepartmentStockInExtraController Members


        public AppFrame.Logic.IProductColorLogic ProductColorLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IProductSizeLogic ProductSizeLogic
        {
            get;set;
        }

        public IProductMasterLogic ProductMasterLogic
        {
            get;
            set;
        }
        public IDepartmentPriceLogic DepartmentPriceLogic
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
        public IStockOutDetailLogic StockOutDetailLogic
        {
            get;
            set;
        }
        #endregion

        public MainStockInEventArgs ResultEventArgs
        {
            get ; 
            set ; 
        }
    }
}
