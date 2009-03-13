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
            }
        }

        void goodsSaleView_SavePurchaseOrderEvent(object sender, GoodsSaleEventArgs e)
        {
            PurchaseOrderLogic.Add(this.PurchaseOrder);
            EventUtility.fireEvent(CompletedSavePurchaseOrderEvent,this,new GoodsSaleEventArgs());
        }

        void goodsSaleView_LoadGoodsEvent(object sender, GoodsSaleEventArgs e)
        {
            PurchaseOrderDetail detail = e.SelectedPurchaseOrderDetail;
            /*ProductMaster prodMaster = ProductMasterLogic.FindById(e.SelectedPurchaseOrderDetail.ProductMaster.ProductMasterId);
            if (prodMaster == null)
            {
                return;
            }*/
            //Product product = ProductLogic.FindProduct(e.SelectedPurchaseOrderDetail.Product.ProductId,CurrentDepartment.Get().DepartmentId);
            ObjectCriteria objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("DepartmentStockPK.ProductId", e.SelectedPurchaseOrderDetail.Product.ProductId);
            objectCriteria.AddEqCriteria("DepartmentStockPK.DepartmentId", CurrentDepartment.Get().DepartmentId);
            IList result = DepartmentStockLogic.FindAll(objectCriteria) ;
            if(result == null)
            {
                throw new BusinessException("Mặt hàng này không tồn tại trong kho !");
            }
            DepartmentStock stock = (DepartmentStock)result[0];            
            Product product = stock.Product;
            detail.Product = product;
            detail.ProductMaster = product.ProductMaster;
            DepartmentPrice price = DepartmentPriceLogic.FindById(new DepartmentPricePK { DepartmentId = 0,ProductMasterId = detail.ProductMaster.ProductMasterId} );
            if (price == null)
            {
                return;    
            }
            detail.Price = price.Price;
            e.SelectedPurchaseOrderDetail = detail;
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
