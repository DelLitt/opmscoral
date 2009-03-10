using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Utility.Mapper;
using AppFrameClient.ViewModel;

namespace AppFrameClient.Utility.Mapper
{
    public class StockOutDetailMapper : BaseMapper<StockOutDetail, StockOutDetailView>
    {
        #region BaseMapper<StockOutDetail,StockOutDetailView> Members

        public StockOutDetail Convert(StockOutDetailView source)
        {
            StockOutDetail dest = new StockOutDetail();
            dest.Product = source.StockOutDetail.Product;
            dest.ProductId = source.StockOutDetail.Product.ProductId;
            dest.ProductMaster = source.StockOutDetail.Product.ProductMaster;
            dest.Description = source.StockOutDetail.Description;

            dest.CreateDate = DateTime.Now;
            dest.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            dest.UpdateDate = DateTime.Now;
            dest.UpdateId = ClientInfo.getInstance().LoggedUser.Name;

            dest.Quantity = source.StockOutDetail.Quantity;
            dest.GoodQuantity = source.StockOutDetail.GoodQuantity;
            dest.ErrorQuantity = source.StockOutDetail.ErrorQuantity;
            dest.LostQuantity = source.StockOutDetail.LostQuantity;
            dest.DamageQuantity = source.StockOutDetail.DamageQuantity;
            dest.UnconfirmQuantity = source.StockOutDetail.UnconfirmQuantity;

            return dest;
        }

        #endregion
    }
}
