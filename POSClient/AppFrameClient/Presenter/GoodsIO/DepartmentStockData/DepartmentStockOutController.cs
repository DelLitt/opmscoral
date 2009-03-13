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

namespace AppFrameClient.Presenter.GoodsIO.DepartmentStockData
{
    public class DepartmentStockOutController : IDepartmentStockOutController
    {

        #region IDepartmentStockInExtraController Members

        private IDepartmentStockOutView mainStockInView;
        public IDepartmentStockOutView DepartmentStockOutView
        {
            get
            {
                return mainStockInView;
            }
            set
            {
                mainStockInView = value;

                mainStockInView.FindBarcodeEvent += new EventHandler<DepartmentStockOutEventArgs>(
                    _departmentStockInView_FindBarcodeEvent);
                mainStockInView.SaveStockOutEvent += new EventHandler<DepartmentStockOutEventArgs>(
                    _departmentStockInView_SaveStockOutEvent);
                mainStockInView.FillProductToComboEvent += new EventHandler<DepartmentStockOutEventArgs>(
                    _departmentStockInView_FillProductToComboEvent);
                mainStockInView.LoadStockStatusEvent += new EventHandler<DepartmentStockOutEventArgs>(
                    _departmentStockInView_LoadStockStatusEvent);
                mainStockInView.LoadGoodsByNameColorSizeEvent += new EventHandler<DepartmentStockOutEventArgs>(
                    _departmentStockInView_LoadGoodsByNameColorSizeEvent);
                mainStockInView.LoadGoodsByNameEvent += new EventHandler<DepartmentStockOutEventArgs>(
                    _departmentStockInView_LoadGoodsByNameEvent);
                mainStockInView.LoadProductColorEvent += new EventHandler<DepartmentStockOutEventArgs>(
                    _departmentStockInView_LoadProductColorEvent);
                mainStockInView.LoadProductSizeEvent += new EventHandler<DepartmentStockOutEventArgs>(
                    _departmentStockInView_LoadProductSizeEvent);

            }
        }

        public void _departmentStockInView_LoadProductSizeEvent(object sender, DepartmentStockOutEventArgs e)
        {
            if (e.SelectedDepartmentStockOutDetail != null && e.SelectedDepartmentStockOutDetail.Product != null && !string.IsNullOrEmpty(e.SelectedDepartmentStockOutDetail.Product.ProductMaster.ProductName))
            {
                var subCriteria = new SubObjectCriteria("ProductMasters");
                subCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                subCriteria.AddEqCriteria("ProductType", e.SelectedDepartmentStockOutDetail.Product.ProductMaster.ProductType);
                subCriteria.AddEqCriteria("ProductName", e.SelectedDepartmentStockOutDetail.Product.ProductMaster.ProductName);
                subCriteria.AddEqCriteria("ProductColor", e.SelectedDepartmentStockOutDetail.Product.ProductMaster.ProductColor);
                subCriteria.AddEqCriteria("Country", e.SelectedDepartmentStockOutDetail.Product.ProductMaster.Country);
                subCriteria.AddEqCriteria("Manufacturer", e.SelectedDepartmentStockOutDetail.Product.ProductMaster.Manufacturer);
                subCriteria.AddEqCriteria("Distributor", e.SelectedDepartmentStockOutDetail.Product.ProductMaster.Distributor);
                subCriteria.AddEqCriteria("Packager", e.SelectedDepartmentStockOutDetail.Product.ProductMaster.Packager);
                var criteria = new ObjectCriteria();
                criteria.AddSubCriteria("ProductMasters", subCriteria);
                IList productSizes = ProductSizeLogic.FindAll(criteria);
                e.ProductSizeList = productSizes;
            }
        }

        public void _departmentStockInView_LoadProductColorEvent(object sender, DepartmentStockOutEventArgs e)
        {
            if (e.SelectedDepartmentStockOutDetail != null && e.SelectedDepartmentStockOutDetail.Product != null
                                    && !string.IsNullOrEmpty(e.SelectedDepartmentStockOutDetail.Product.ProductMaster.ProductName))
            {
                var subCriteria = new SubObjectCriteria("ProductMasters");
                subCriteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
                subCriteria.AddEqCriteria("ProductType", e.SelectedDepartmentStockOutDetail.Product.ProductMaster.ProductType);
                subCriteria.AddEqCriteria("ProductName", e.SelectedDepartmentStockOutDetail.Product.ProductMaster.ProductName);
                subCriteria.AddEqCriteria("ProductSize", e.SelectedDepartmentStockOutDetail.Product.ProductMaster.ProductSize);
                subCriteria.AddEqCriteria("Country", e.SelectedDepartmentStockOutDetail.Product.ProductMaster.Country);
                subCriteria.AddEqCriteria("Manufacturer", e.SelectedDepartmentStockOutDetail.Product.ProductMaster.Manufacturer);
                subCriteria.AddEqCriteria("Distributor", e.SelectedDepartmentStockOutDetail.Product.ProductMaster.Distributor);
                subCriteria.AddEqCriteria("Packager", e.SelectedDepartmentStockOutDetail.Product.ProductMaster.Packager);
                var criteria = new ObjectCriteria();
                criteria.AddSubCriteria("ProductMasters", subCriteria);
                IList productColors = ProductColorLogic.FindAll(criteria);
                e.ProductColorList = productColors;
            }
        }

        public void _departmentStockInView_LoadGoodsByNameEvent(object sender, DepartmentStockOutEventArgs e)
        {
            DepartmentStockOutDetail detail = e.SelectedDepartmentStockOutDetail;
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
            e.SelectedDepartmentStockOutDetail = detail;
            IList detailList = new ArrayList();
            detailList.Add(detail);
//            GetRemainStockNumber(detailList);
        }

        public void _departmentStockInView_LoadGoodsByNameColorSizeEvent(object sender, DepartmentStockOutEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void _departmentStockInView_LoadStockStatusEvent(object sender, DepartmentStockOutEventArgs e)
        {
            IList productMasterIds = new ArrayList();
            foreach (ProductMaster master in e.SelectedProductMasterList)
            {
                productMasterIds.Add(master.ProductMasterId);
            }
            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddSearchInCriteria("ProductMaster.ProductMasterId", productMasterIds);
            IList list = DepartmentStockLogic.FindAll(criteria);
            if (list.Count == 0)
            {
                return;
            }

            
            e.DepartmentStockList = new ArrayList();
            e.FoundDepartmentStockOutDetailList = new ArrayList();
            foreach (DepartmentStock stock in list)
            {
                DepartmentStockOutDetail detail = new DepartmentStockOutDetail();
                detail.Product = stock.Product;
                detail.GoodQuantity = stock.GoodQuantity;
                detail.ErrorQuantity = stock.ErrorQuantity;
                detail.LostQuantity = stock.LostQuantity;
                detail.DamageQuantity = stock.DamageQuantity;
                detail.UnconfirmQuantity = stock.UnconfirmQuantity;
                detail.Quantity = stock.Quantity;

                e.DepartmentStockList.Add(stock);
                e.FoundDepartmentStockOutDetailList.Add(detail);
            }
        }

        
        public void _departmentStockInView_FillProductToComboEvent(object sender, DepartmentStockOutEventArgs e)
        {
            ComboBox comboBox = (ComboBox) sender;
            string originalText = comboBox.Text;
            if (e.IsFillToComboBox)
            {
                ProductMaster searchPM = e.SelectedDepartmentStockOutDetail.Product.ProductMaster;
                var criteria = new ObjectCriteria(true);
                criteria.AddEqCriteria("pm.DelFlg", CommonConstants.DEL_FLG_NO);
                criteria.AddEqCriteria("stock.DelFlg", CommonConstants.DEL_FLG_NO);
                criteria.AddLikeCriteria("pm.ProductName", searchPM.ProductName + "%");
                IList list = DepartmentStockLogic.FindByQueryForDeptStock(criteria);

                if(list ==null || list.Count == 0)
                {
                    return;
                }
                IList result = new ArrayList();
                foreach (DepartmentStock stock in list)
                {
                    result.Add(stock.Product.ProductMaster);
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

        public void _departmentStockInView_FindBarcodeEvent(object sender, DepartmentStockOutEventArgs e)
        {
            var criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg", CommonConstants.DEL_FLG_NO);
            criteria.AddEqCriteria("Product.ProductId", e.ProductId);
            IList list = DepartmentStockLogic.FindAll(criteria);
            if (list.Count == 0)
            {
                return;
            }
            Stock stock = list[0] as Stock;
            e.SelectedDepartmentStockOutDetail = new DepartmentStockOutDetail();
            e.SelectedDepartmentStockOutDetail.Product = stock.Product;
            e.SelectedDepartmentStockOutDetail.Quantity = stock.Quantity;
            e.SelectedDepartmentStockOutDetail.GoodQuantity = stock.Quantity;
            e.SelectedDepartmentStockOutDetail.ErrorQuantity = stock.ErrorQuantity;
            e.SelectedDepartmentStockOutDetail.LostQuantity = stock.LostQuantity;
            e.SelectedDepartmentStockOutDetail.DamageQuantity = stock.DamageQuantity;
            e.SelectedDepartmentStockOutDetail.UnconfirmQuantity = stock.UnconfirmQuantity;


            e.EventResult = "Success";
        }

        public void _departmentStockInView_SaveStockOutEvent(object sender, DepartmentStockOutEventArgs e)
        {
            if (e.DepartmentStockOut.DepartmentStockOutPK == null || e.DepartmentStockOut.DepartmentStockOutPK.StockOutId == 0)
            {
                DepartmentStockOutLogic.Add(e.DepartmentStockOut);
                e.EventResult = "Success";
            }
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

        public DepartmentStockOutEventArgs ResultEventArgs
        {
            get ; 
            set ; 
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
