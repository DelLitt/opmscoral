using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using AppFrame;
using AppFrame.Common;
using AppFrame.Exceptions;
using AppFrame.Model;
using AppFrame.Presenter.GoodsSale;
using AppFrame.Utility;
using AppFrame.View.GoodsSale;

namespace AppFrameClient.Presenter.GoodsSale
{
    public class GoodsSaleController : IGoodsSaleController
    {

        #region IGoodsSaleController Members
        private IGoodsSaleView goodsSaleView;
        public AppFrame.View.GoodsSale.IGoodsSaleView GoodsSaleView
        {
            get
            {
                return goodsSaleView; 
            }
            set
            {
                goodsSaleView = value;
                goodsSaleView.AddGoodsEvent += new EventHandler<GoodsSaleEventArgs>(goodsSaleView_AddGoodsEvent);
                goodsSaleView.CloseFormEvent += new EventHandler<GoodsSaleEventArgs>(goodsSaleView_CloseFormEvent);
                goodsSaleView.DeleteGoodsEvent += new EventHandler<GoodsSaleEventArgs>(goodsSaleView_DeleteGoodsEvent);
                goodsSaleView.FirstRecordEvent += new EventHandler<GoodsSaleEventArgs>(goodsSaleView_FirstRecordEvent);
                goodsSaleView.HelpEvent += new EventHandler<GoodsSaleEventArgs>(goodsSaleView_HelpEvent);
                goodsSaleView.LastRecordEvent += new EventHandler<GoodsSaleEventArgs>(goodsSaleView_LastRecordEvent);
                goodsSaleView.NextRecordEvent += new EventHandler<GoodsSaleEventArgs>(goodsSaleView_NextRecordEvent);
                goodsSaleView.FillProductToComboEvent += new EventHandler<GoodsSaleEventArgs>(goodsSaleView_FillProductToComboEvent);
                goodsSaleView.LoadGoodsEvent += new EventHandler<GoodsSaleEventArgs>(goodsSaleView_LoadGoodsEvent);
                goodsSaleView.SavePurchaseOrderEvent += new EventHandler<GoodsSaleEventArgs>(goodsSaleView_SavePurchaseOrderEvent);
                goodsSaleView.FindRefPurchaseOrder += new EventHandler<GoodsSaleEventArgs>(goodsSaleView_FindRefPurchaseOrder);
            }
        }

        void goodsSaleView_FindRefPurchaseOrder(object sender, GoodsSaleEventArgs e)
        {
            PurchaseOrderPK pk = new PurchaseOrderPK { DepartmentId = CurrentDepartment.Get().DepartmentId, PurchaseOrderId = e.RefPurchaseOrder.PurchaseOrderPK.PurchaseOrderId };
            PurchaseOrder purchaseOrder = PurchaseOrderLogic.FindById(pk);
                e.RefPurchaseOrder = purchaseOrder;
            
        }

        void goodsSaleView_SavePurchaseOrderEvent(object sender, GoodsSaleEventArgs e)
        {
            try
            {
                PurchaseOrderLogic.Add(this.PurchaseOrder);
                e.HasErrors = false;
            }
            catch (Exception exception)
            {
                e.HasErrors = true;
                throw exception;  
            }
            
            
        }

        void goodsSaleView_LoadGoodsEvent(object sender, GoodsSaleEventArgs e)
        {
            PurchaseOrderDetail detail = e.SelectedPurchaseOrderDetail;
            bool NotAvailableInStock = e.NotAvailableInStock;
            /*ProductMaster prodMaster = ProductMasterLogic.FindById(e.SelectedPurchaseOrderDetail.ProductMaster.ProductMasterId);
            if (prodMaster == null)
            {
                return;
            }*/
            //Product product = ProductLogic.FindProduct(e.SelectedPurchaseOrderDetail.Product.ProductId,CurrentDepartment.Get().DepartmentId);
            // TEMP FIXING
            //NotAvailableInStock = false;

            ObjectCriteria objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("DepartmentStockPK.ProductId", e.SelectedPurchaseOrderDetail.Product.ProductId);
            objectCriteria.AddEqCriteria("DepartmentStockPK.DepartmentId", CurrentDepartment.Get().DepartmentId);
            if(!NotAvailableInStock)
            {
                objectCriteria.AddGreaterCriteria("GoodQuantity", (long) 0);
            }
            IList result = DepartmentStockLogic.FindAll(objectCriteria) ;
            
            if(!NotAvailableInStock)
            {
                if ((result == null || result.Count == 0))
                {
                    throw new BusinessException("Mặt hàng này không tồn tại hoặc đã hết !");
                }
            }

            if ((result == null || result.Count == 0))
            {
                throw new BusinessException("Mặt hàng này không tồn tại !");
            }

            Product product = null;
            bool NeedSwitchPrdId = false;
            if (result.Count == 1)
            {
                DepartmentStock stock = (DepartmentStock) result[0];
                product = stock.Product;
                if(stock.GoodQuantity <= 0)
                {
                    NeedSwitchPrdId = true;
                }
            }
            // START ---- don ma

            /*if (product != null && NeedSwitchPrdId)
            {
                ObjectCriteria prdCrit = new ObjectCriteria();
                prdCrit.AddEqCriteria("ProductMaster.ProductName", product.ProductMaster.ProductName);
                IList productIdsList = ProductLogic.FindAll(prdCrit);
                if (productIdsList != null && productIdsList.Count > 0)
                {
                    IList productIds = new ArrayList();
                    foreach (Product prd in productIdsList)
                    {
                        productIds.Add(prd.ProductId);
                    }
                    prdCrit = new ObjectCriteria();
                    prdCrit.AddSearchInCriteria("DepartmentStockPK.ProductId", productIds);
                    prdCrit.AddEqCriteria("DepartmentStockPK.DepartmentId", CurrentDepartment.Get().DepartmentId);
                    IList allStocks = DepartmentStockLogic.FindAll(prdCrit);
                    if(allStocks != null && allStocks.Count > 0)
                    {
                        SortByGoodQuantity(allStocks);
                        
                    }
                }
            }*/
            // END ---- don ma
            /*else
            {
                if(CommonConstants.UNDEFINED_BARCODE.Equals(e.SelectedPurchaseOrderDetail.Product.ProductId))
                {
                    Product undefProduct = ProductLogic.FindById(e.SelectedPurchaseOrderDetail.Product.ProductId);
                    product = undefProduct;
                }
            }*/
            
            detail.Product = product;
            detail.ProductMaster = product.ProductMaster;
            DepartmentPrice price = DepartmentPriceLogic.FindById(new DepartmentPricePK { DepartmentId = 0,ProductMasterId = detail.ProductMaster.ProductMasterId} );
            if (price == null || price.Price == 0 )
            {
                throw new BusinessException("Giá của mặt hàng " + product.ProductMaster.ProductName + " không có hoặc là 0. Xin kiểm tra lại.");
            }
            detail.Price = price.Price;
            e.SelectedPurchaseOrderDetail = detail;
        }

        private void SortByGoodQuantity(IList temps)
        {
            DepartmentStock stockTemp = null;
            for (int i = 0; i < temps.Count - 1; i++)
            {
                DepartmentStock stockTemp1 = (DepartmentStock)temps[i];
                long qty1 = stockTemp1.GoodQuantity;
                for (int j = i + 1; j < temps.Count; j++)
                {
                    DepartmentStock stockTemp2 = (DepartmentStock)temps[j];
                    long qty2 = stockTemp2.GoodQuantity;
                    if (qty1 > qty2)
                    {
                        stockTemp = stockTemp1;
                        stockTemp1 = stockTemp2;
                        stockTemp2 = stockTemp;
                    }
                }

            }
        }

        private void SortByProductId(IList temps)
        {
            DepartmentStock stockTemp =null;
            for(int i=0;i < temps.Count-1; i++)
            {
                DepartmentStock stockTemp1 = (DepartmentStock) temps[i];
                long prdId1 = Int64.Parse(stockTemp1.Product.ProductId);
                for (int j = i + 1; j < temps.Count;j++ )
                {
                    DepartmentStock stockTemp2 = (DepartmentStock)temps[j];
                    long prdId2 = Int64.Parse(stockTemp2.Product.ProductId);
                    if(prdId1>prdId2)
                    {
                        stockTemp = stockTemp1;
                        stockTemp1 = stockTemp2;
                        stockTemp2 = stockTemp;
                    }
                }

            }
        }

        void goodsSaleView_FillProductToComboEvent(object sender, GoodsSaleEventArgs e)
        {
            ComboBox comboBox = (ComboBox) sender;
            string originalText = comboBox.Text;
            Console.WriteLine(this.PurchaseOrder);
            if (e.IsFillComboBox)
            {
                IList result =
                    ProductLogic.FindProductById(
                        e.SelectedPurchaseOrderDetail.Product.ProductId, 20,false);
                BindingList<Product> products = new BindingList<Product>();
                if (result != null)
                {
                    foreach (Product product in result)
                    {
                        products.Add(product);
                    }
                }
                BindingSource bindingSource = new BindingSource();
                bindingSource.DataSource = products;
                comboBox.DataSource = bindingSource;
                comboBox.DisplayMember = "ProductFullName";
                comboBox.ValueMember = e.ComboBoxDisplayMember;
                comboBox.DropDownWidth = 600;
                comboBox.DropDownHeight = 200;
                // keep the original text
                comboBox.Text = originalText;
                //comboBox.SelectedIndex = -1;
                //comboBox.SelectionStart = comboBox.Text.Length;
                comboBox.DroppedDown = true;
                comboBox.MaxDropDownItems = 8;
                comboBox.DropDownWidth = 600;
            }
        }

        void goodsSaleView_NextRecordEvent(object sender, GoodsSaleEventArgs e)
        {
            throw new NotImplementedException();
        }

        void goodsSaleView_LastRecordEvent(object sender, GoodsSaleEventArgs e)
        {
            throw new NotImplementedException();
        }

        void goodsSaleView_HelpEvent(object sender, GoodsSaleEventArgs e)
        {
            throw new NotImplementedException();
        }

        void goodsSaleView_FirstRecordEvent(object sender, GoodsSaleEventArgs e)
        {
            throw new NotImplementedException();
        }

        void goodsSaleView_DeleteGoodsEvent(object sender, GoodsSaleEventArgs e)
        {
            throw new NotImplementedException();
        }

        void goodsSaleView_CloseFormEvent(object sender, GoodsSaleEventArgs e)
        {
            
        }

        void goodsSaleView_AddGoodsEvent(object sender, GoodsSaleEventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region IGoodsSaleController Members


        public AppFrame.Logic.IPurchaseOrderLogic PurchaseOrderLogic
        {
            get;
            set;
        }

        public AppFrame.Logic.IPurchaseOrderDetailLogic PurchaseOrderDetailLogic
        {
            get;
            set;
        }

        public AppFrame.Logic.IProductMasterLogic ProductMasterLogic
        {
            get; set;

        }
        public AppFrame.Logic.IDepartmentPriceLogic DepartmentPriceLogic
        {
            get; set;
        }

        #endregion

        #region IGoodsSaleController Members


        public AppFrame.Model.PurchaseOrder PurchaseOrder
        {
            get;set;
        }

        #endregion

        #region IGoodsSaleController Members


        public event EventHandler<GoodsSaleEventArgs> CompletedLoadGoodsEvent;

        public event EventHandler<GoodsSaleEventArgs> CompletedFillProductToComboEvent;
        public event EventHandler<GoodsSaleEventArgs> CompletedSavePurchaseOrderEvent;

        #endregion

        #region IGoodsSaleController Members


        public AppFrame.Logic.IProductLogic ProductLogic
        {
            get;set;
        }

        #endregion

        #region IGoodsSaleController Members

        private IGoodsSaleView goodsSaleReturnView;    
        public IGoodsSaleView GoodsSaleReturnView
        {
            get
            {
                return goodsSaleReturnView;
            }
            set
            {
                goodsSaleReturnView = value;
                goodsSaleReturnView.LoadGoodsEvent += new EventHandler<GoodsSaleEventArgs>(goodsSaleView_LoadGoodsEvent);
            }
        }

        #endregion

        #region IGoodsSaleController Members


        public AppFrame.Logic.IDepartmentStockLogic DepartmentStockLogic
        {
            get;set;
        }

        #endregion
    }
}
