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

namespace AppFrameClient.Presenter.GoodsIO.MainStock
{
    public class MainStockOutController : IMainStockOutController
    {

        #region IDepartmentStockInExtraController Members

        private IMainStockOutView mainStockOutView;
        public IMainStockOutView MainStockOutView
        {
            get
            {
                return mainStockOutView;
            }
            set
            {
                mainStockOutView = value;

                mainStockOutView.FindBarcodeEvent += new EventHandler<MainStockOutEventArgs>(
                    _departmentStockInView_FindBarcodeEvent);
                mainStockOutView.SaveStockOutEvent += new EventHandler<MainStockOutEventArgs>(
                    mainStockOutView_SaveStockOutEvent);
                mainStockOutView.FillProductToComboEvent += new EventHandler<MainStockOutEventArgs>(
                    mainStockOutView_FillProductToComboEvent);
                mainStockOutView.LoadStockStatusEvent += new EventHandler<MainStockOutEventArgs>(
                    mainStockOutView_LoadStockStatusEvent);
                mainStockOutView.LoadGoodsByNameColorSizeEvent += new EventHandler<MainStockOutEventArgs>(
                    mainStockOutView_LoadGoodsByNameColorSizeEvent);
                mainStockOutView.LoadGoodsByNameEvent += new EventHandler<MainStockOutEventArgs>(
                    mainStockOutView_LoadGoodsByNameEvent);
                mainStockOutView.LoadProductColorEvent += new EventHandler<MainStockOutEventArgs>(
                    mainStockOutView_LoadProductColorEvent);
                mainStockOutView.LoadProductSizeEvent += new EventHandler<MainStockOutEventArgs>(
                    mainStockOutView_LoadProductSizeEvent);

            }
        }

        public void mainStockOutView_LoadProductSizeEvent(object sender, MainStockOutEventArgs e)
        {
            if (e.SelectedStockOutDetail != null && e.SelectedStockOutDetail.Product != null && !string.IsNullOrEmpty(e.SelectedStockOutDetail.Product.ProductMaster.ProductName))
            {
                var subCriteria = new SubObjectCriteria("ProductMasters");
                subCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                subCriteria.AddEqCriteria("ProductType", e.SelectedStockOutDetail.Product.ProductMaster.ProductType);
                subCriteria.AddEqCriteria("ProductName", e.SelectedStockOutDetail.Product.ProductMaster.ProductName);
                subCriteria.AddEqCriteria("ProductColor", e.SelectedStockOutDetail.Product.ProductMaster.ProductColor);
                subCriteria.AddEqCriteria("Country", e.SelectedStockOutDetail.Product.ProductMaster.Country);
                subCriteria.AddEqCriteria("Manufacturer", e.SelectedStockOutDetail.Product.ProductMaster.Manufacturer);
                subCriteria.AddEqCriteria("Distributor", e.SelectedStockOutDetail.Product.ProductMaster.Distributor);
                subCriteria.AddEqCriteria("Packager", e.SelectedStockOutDetail.Product.ProductMaster.Packager);
                var criteria = new ObjectCriteria();
                criteria.AddSubCriteria("ProductMasters", subCriteria);
                IList productSizes = ProductSizeLogic.FindAll(criteria);
                e.ProductSizeList = productSizes;
            }
        }

        public void mainStockOutView_LoadProductColorEvent(object sender, MainStockOutEventArgs e)
        {
            if (e.SelectedStockOutDetail != null && e.SelectedStockOutDetail.Product != null
                                    && !string.IsNullOrEmpty(e.SelectedStockOutDetail.Product.ProductMaster.ProductName))
            {
                var subCriteria = new SubObjectCriteria("ProductMasters");
                subCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                subCriteria.AddEqCriteria("ProductType", e.SelectedStockOutDetail.Product.ProductMaster.ProductType);
                subCriteria.AddEqCriteria("ProductName", e.SelectedStockOutDetail.Product.ProductMaster.ProductName);
                subCriteria.AddEqCriteria("ProductSize", e.SelectedStockOutDetail.Product.ProductMaster.ProductSize);
                subCriteria.AddEqCriteria("Country", e.SelectedStockOutDetail.Product.ProductMaster.Country);
                subCriteria.AddEqCriteria("Manufacturer", e.SelectedStockOutDetail.Product.ProductMaster.Manufacturer);
                subCriteria.AddEqCriteria("Distributor", e.SelectedStockOutDetail.Product.ProductMaster.Distributor);
                subCriteria.AddEqCriteria("Packager", e.SelectedStockOutDetail.Product.ProductMaster.Packager);
                var criteria = new ObjectCriteria();
                criteria.AddSubCriteria("ProductMasters", subCriteria);
                IList productColors = ProductColorLogic.FindAll(criteria);
                e.ProductColorList = productColors;
            }
        }

        public void mainStockOutView_LoadGoodsByNameEvent(object sender, MainStockOutEventArgs e)
        {
            StockOutDetail detail = e.SelectedStockOutDetail;
            ObjectCriteria objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            objectCriteria.AddEqCriteria("ProductName", detail.Product.ProductMaster.ProductName);
            IList list = ProductMasterLogic.FindAll(objectCriteria);
            e.FoundProductMasterList = list;
            if (list == null || list.Count == 0)
            {
                return;
            }
            ProductMaster prodMaster = list[0] as ProductMaster;
            detail.Product.ProductMaster = prodMaster;
            e.SelectedStockOutDetail = detail;
            IList detailList = new ArrayList();
            detailList.Add(detail);
            //            GetRemainStockNumber(detailList);
        }

        public void mainStockOutView_LoadGoodsByNameColorSizeEvent(object sender, MainStockOutEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void mainStockOutView_LoadStockStatusEvent(object sender, MainStockOutEventArgs e)
        {
            IList productMasterIds = new ArrayList();
            foreach (ProductMaster master in e.SelectedProductMasterList)
            {
                productMasterIds.Add(master.ProductMasterId);
            }
            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddSearchInCriteria("ProductMaster.ProductMasterId", productMasterIds);
            IList list = StockLogic.FindAll(criteria);
            if (list.Count == 0)
            {
                return;
            }
            e.StockList = new ArrayList();
            e.FoundStockOutDetailList = new ArrayList();
            foreach (Stock stock in list)
            {
                StockOutDetail detail = new StockOutDetail();
                detail.Product = stock.Product;
                detail.GoodQuantity = stock.GoodQuantity;
                detail.ErrorQuantity = stock.ErrorQuantity;
                detail.LostQuantity = stock.LostQuantity;
                detail.DamageQuantity = stock.DamageQuantity;
                detail.UnconfirmQuantity = stock.UnconfirmQuantity;
                detail.Quantity = stock.Quantity;
                e.StockList.Add(stock);

                e.FoundStockOutDetailList.Add(detail);
            }
        }

        public void mainStockOutView_FillProductToComboEvent(object sender, MainStockOutEventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string originalText = comboBox.Text;
            if (e.IsFillToComboBox)
            {
                ProductMaster searchPM = e.SelectedStockOutDetail.Product.ProductMaster;
                var criteria = new ObjectCriteria(true);
                criteria.AddEqCriteria("pm.DelFlg", CommonConstants.DEL_FLG_NO);
                criteria.AddEqCriteria("stock.DelFlg", CommonConstants.DEL_FLG_NO);
                criteria.AddLikeCriteria("pm.ProductName", searchPM.ProductName + "%");
                IList list = StockLogic.FindByQueryForStockIn(criteria);

                if (list == null || list.Count == 0)
                {
                    return;
                }
                IList result = new ArrayList();
                foreach (Stock stock in list)
                {
                    result.Add(stock.ProductMaster);
                }
                IList retlist = RemoveDuplicateName(result);

                result = new ArrayList();
                int count = 0;
                foreach (var p in retlist)
                {
                    if (count == 50)
                    {
                        break;
                    }
                    result.Add(p);
                    count++;
                }

                var productMasters = new BindingList<ProductMaster>();
                foreach (ProductMaster master in result)
                {
                    productMasters.Add(master);
                }

                var bindingSource = new BindingSource();
                bindingSource.DataSource = productMasters;
                comboBox.DataSource = bindingSource;
                comboBox.DisplayMember = "TypeAndName";
                comboBox.ValueMember = e.ComboBoxDisplayMember;
                comboBox.DropDownWidth = 300;
                comboBox.DropDownHeight = 200;
                // keep the original text
                comboBox.Text = originalText;
                //comboBox.SelectedIndex = -1;
                //comboBox.SelectionStart = comboBox.Text.Length;
                comboBox.DroppedDown = true;
                comboBox.MaxDropDownItems = 10;
            }
        }

        public void _departmentStockInView_FindBarcodeEvent(object sender, MainStockOutEventArgs e)
        {
            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddEqCriteria("Product.ProductId", e.ProductId);
            IList list = StockLogic.FindAll(criteria);
            if (list.Count == 0)
            {
                return;
            }
            Stock stock = list[0] as Stock;
            e.SelectedStockOutDetail = new StockOutDetail();
            e.SelectedStockOutDetail.Product = stock.Product;
            e.SelectedStockOutDetail.Quantity = stock.Quantity;
            e.SelectedStockOutDetail.ErrorQuantity = stock.ErrorQuantity;
            e.SelectedStockOutDetail.LostQuantity = stock.LostQuantity;
            e.SelectedStockOutDetail.DamageQuantity = stock.DamageQuantity;
            e.SelectedStockOutDetail.UnconfirmQuantity = stock.UnconfirmQuantity;
            e.SelectedStockOutDetail.Quantity = stock.Quantity;
            e.EventResult = "Success";

            e.Stock = stock;
        }

        public void mainStockOutView_SaveStockOutEvent(object sender, MainStockOutEventArgs e)
        {
            if (e.StockOut.StockoutId == 0)
            {
                StockOutLogic.Add(e.StockOut);
                e.EventResult = "Success";
            }
        }
        public IStockLogic StockLogic
        {
            get;
            set;
        }
        public IStockOutLogic StockOutLogic
        {
            get;
            set;
        }


        public IProductColorLogic ProductColorLogic
        {
            get;
            set;

        }
        public IProductSizeLogic ProductSizeLogic
        {
            get;
            set;
        }
        public IProductMasterLogic ProductMasterLogic
        {
            get;
            set;
        }
        #endregion

        public MainStockOutEventArgs ResultEventArgs
        {
            get;
            set;
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
    }
}
