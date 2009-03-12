using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Exceptions;
using AppFrame.Model;
using AppFrame.Presenter.GoodsSale;
using AppFrame.Utility;

namespace AppFrameClient.Presenter.GoodsSale
{
    public class GoodsSaleReturnController : IGoodsSaleReturnController
    {
        #region IGoodsSaleReturnController Members

        private AppFrame.View.GoodsSale.IGoodsSaleReturnView goodsSaleReturnView; 
        public AppFrame.View.GoodsSale.IGoodsSaleReturnView GoodsSaleReturnView
        {
            get
            {
                return goodsSaleReturnView;
            }
            set
            {
                goodsSaleReturnView = value;
                goodsSaleReturnView.LoadPurchaseOrderEvent += new EventHandler<GoodsSaleReturnEventArgs>(goodsSaleReturnView_LoadPurchaseOrderEvent);
                goodsSaleReturnView.SavePurchaseOrderEvent += new EventHandler<GoodsSaleReturnEventArgs>(goodsSaleReturnView_SavePurchaseOrderEvent);
                goodsSaleReturnView.LoadGoodsEvent += new EventHandler<GoodsSaleEventArgs>(goodsSaleReturnView_LoadGoodsEvent);

            }
        }

        void goodsSaleReturnView_LoadGoodsEvent(object sender, GoodsSaleEventArgs e)
        {
            PurchaseOrderDetail detail = e.SelectedPurchaseOrderDetail;
            /*ProductMaster prodMaster = ProductMasterLogic.FindById(e.SelectedPurchaseOrderDetail.ProductMaster.ProductMasterId);
            if (prodMaster == null)
            {
                return;
            }*/
            Product product = ProductLogic.FindById(e.SelectedPurchaseOrderDetail.Product.ProductId);
            detail.Product = product;
            detail.ProductMaster = product.ProductMaster;
            DepartmentPrice price = DepartmentPriceLogic.FindById(new DepartmentPricePK { DepartmentId = 0, ProductMasterId = detail.ProductMaster.ProductMasterId });
            if (price == null)
            {
                return;
            }
            detail.Price = price.Price;
            e.SelectedPurchaseOrderDetail = detail; 
        }

        void goodsSaleReturnView_SavePurchaseOrderEvent(object sender, GoodsSaleReturnEventArgs e)
        {
            try
                {
            // save return order to ReturnPo
            foreach (PurchaseOrderDetail purchaseOrderDetail in e.ReturnPurchaseOrderDetails)
            {
                
                    ReturnPo po = new ReturnPo();
                    po.CreateDate = DateTime.Now;
                    po.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    po.UpdateDate = DateTime.Now;
                    po.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    ReturnPoPK poPK = new ReturnPoPK
                                          {
                                              DepartmentId = purchaseOrderDetail.PurchaseOrderDetailPK.DepartmentId,
                                              PurchaseOrderId =
                                                  purchaseOrderDetail.PurchaseOrderDetailPK.PurchaseOrderId,
                                              PurchaseOrderDetailId =
                                                  purchaseOrderDetail.PurchaseOrderDetailPK.PurchaseOrderDetailId,
                                              CreateDate = DateTime.Now

                                          };
                    long originAmount = FindOriginAmount(e.RefPurchaseOrder.PurchaseOrderDetails, purchaseOrderDetail);
                    if (originAmount == 0)
                    {
                        throw new BusinessException("Có lỗi ở hoá đơn gốc, đề nghị kiểm tra");
                    }

                    if (originAmount < (long) ReturnPoLogic.FindQuantityById(poPK))
                    {
                        throw new BusinessException(
                            "Đã trả hàng trước đó và số lượng trả tổng cộng vượt quá số lượng mua từ mặt hàng " +
                            purchaseOrderDetail.Product.ProductMaster.ProductName + " của hoá đơn này");
                    }
                    po.ReturnPoPK = poPK;
                    po.Quantity = purchaseOrderDetail.Quantity;
                    po.ReturnDate = DateTime.Now;
                    ReturnPoLogic.Add(po);
               
                    }
                    PurchaseOrderLogic.Add(e.NextPurchaseOrder);
                e.HasErrors = false;
                }
            catch (Exception ex )
            {
                e.HasErrors = true;
                throw ex;
            }
            

        }

        private long FindOriginAmount(IList details, PurchaseOrderDetail detail)
        {
            foreach (PurchaseOrderDetail orderDetail in details)
            {
                if(orderDetail.PurchaseOrderDetailPK.DepartmentId == detail.PurchaseOrderDetailPK.DepartmentId
                  && orderDetail.PurchaseOrderDetailPK.PurchaseOrderId == detail.PurchaseOrderDetailPK.PurchaseOrderId
                  && orderDetail.PurchaseOrderDetailPK.PurchaseOrderDetailId == detail.PurchaseOrderDetailPK.PurchaseOrderDetailId)
                {
                    return orderDetail.Quantity;
                }
            }
            return 0;
        }

        void goodsSaleReturnView_LoadPurchaseOrderEvent(object sender, GoodsSaleReturnEventArgs e)
        {
            PurchaseOrderPK pk = new PurchaseOrderPK {DepartmentId = CurrentDepartment.Get().DepartmentId,PurchaseOrderId = e.SearchPurchaseOrderId};
            PurchaseOrder purchaseOrder = PurchaseOrderLogic.FindById(pk);
            e.RefPurchaseOrder = purchaseOrder;
        }

        public AppFrame.Logic.IPurchaseOrderLogic PurchaseOrderLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IPurchaseOrderDetailLogic PurchaseOrderDetailLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IProductMasterLogic ProductMasterLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IProductLogic ProductLogic
        {
            get;set;
            
        }

        public AppFrame.Model.PurchaseOrder ReturnPurchaseOrder
        {
            get;set;
            
        }

        public System.Collections.IList ReturnPOs
        {
            get;set;
        }

        public event EventHandler<GoodsSaleReturnEventArgs> CompletedSavePurchaseOrderEvent;

        #endregion

        #region IGoodsSaleReturnController Members


        public AppFrame.Logic.IDepartmentPriceLogic DepartmentPriceLogic
        {
            get ;set;
            
        }

        #endregion

        #region IGoodsSaleReturnController Members


        public AppFrame.Logic.IReturnPoLogic ReturnPoLogic
        {
            get;set;
        }

        #endregion

        #region IGoodsSaleReturnController Members


        public PurchaseOrder NextPurchaseOrder
        {
            get;set;
        }

        #endregion
    }
}
