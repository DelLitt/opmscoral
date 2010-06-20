using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.ProductMaster
{
    public class PmSaveAction : PosAction,IPmSaveAction
    {
        public IProductMasterLogic ProductMasterLogic { get; set; }

        public override void DoExecute()
        {
            CoralPOS.Models.ProductMaster master = Flow.Session.Get(FlowConstants.SAVE_PRODUCT_MASTER) as CoralPOS.Models.ProductMaster;

            
            IList productColors = Flow.Session.Get(FlowConstants.SAVE_PRODUCT_COLORS_LIST) as IList;
            IList productSizes = Flow.Session.Get(FlowConstants.SAVE_PRODUCT_SIZES_LIST) as IList;
            bool IsOK = ProductMasterLogic.Save(master, productColors, productSizes);
            if (IsOK) MessageBox.Show(master.ProductName + " đã được lưu thành công !");
            GoToNextNode();
        }
    }
}
