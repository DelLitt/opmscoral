using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.Base;
using AppFrame.DataLayer;
using AppFrame.WPF.Screens;
using Caliburn.PresentationFramework.Actions;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.Stock.StockIn
{
    public class StockInPreLoadAction : PosAction,IStockInPreLoadAction
    {
        public IProductMasterLogic ProductMasterLogic { get; set; }
        private ILoadViewModel _loadViewModel;
        [AsyncAction(BlockInteraction = false)]
        public override void DoExecute()
        {
            _loadViewModel = Flow.Navigator.ServiceLocator.GetInstance<ILoadViewModel>("ILoadViewModel");
            _loadViewModel.StartLoading();
            IList  productMasters = ProductMasterLogic.LoadAllProductMasterWIthType();
            Flow.Session.Put(FlowConstants.PRODUCT_NAMES_LIST, productMasters);
            if (_loadViewModel != null) _loadViewModel.StopLoading();
            GoToNextNode();
        }
    }
}