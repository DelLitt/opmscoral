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
    public class StockOutMapper : BaseMapper<StockOut, StockOutView>
    {
        #region BaseMapper<StockOut,StockOutView> Members

        public StockOut Convert(StockOutView source)
        {
            StockOut dest = new StockOut();
            dest.StockOutDate = source.StockOut.StockOutDate;
            dest.DefectStatus = source.StockOut.DefectStatus;

            dest.CreateDate = DateTime.Now;
            dest.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            dest.UpdateDate = DateTime.Now;
            dest.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            return dest;
        }

        #endregion
    }
}
