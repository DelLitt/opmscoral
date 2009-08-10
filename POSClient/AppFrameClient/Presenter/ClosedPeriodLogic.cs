using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame;
using AppFrame.Logic;
using AppFrame.Presenter;
using AppFrame.Utility;
using AppFrame.View;

namespace AppFrameClient.Presenter
{
    public class ClosedPeriodLogic : IClosedPeriodLogic
    {
        private IClosedPeriodView closedPeriodView;
        public IClosedPeriodView ClosedPeriodView
        {
            get
            {
                return closedPeriodView;
            }
            set
            {
                closedPeriodView = value;
                closedPeriodView.LoadClosedPeriodEvent += new EventHandler<ClosedPeriodEventArgs>(closedPeriodView_LoadClosedPeriodEvent);
            }
        }

        void closedPeriodView_LoadClosedPeriodEvent(object sender, ClosedPeriodEventArgs e)
        {
            DateTime fromDay = DateUtility.DateOnly(e.FromDate);
            DateTime toDay = DateUtility.DateOnly(e.ToDate);
            ObjectCriteria objectCriteria = new ObjectCriteria();
            objectCriteria.AddBetweenCriteria("EmployeeMoneyPK.WorkingDay", fromDay,toDay);
            IList list = EmployeeMoneyLogic.FindAll(objectCriteria);
            e.EmployeeMoneyList = list;    
        }

        public IPurchaseOrderLogic PurchaseOrderLogic { get; set; }
        public IPurchaseOrderDetailLogic PurchaseOrderDetailLogic { get; set; }
        public IProductMasterLogic ProductMasterLogic { get; set; }
        public IReturnPoLogic ReturnPoLogic { get; set; }
        public IDepartmentPriceLogic DepartmentPriceLogic { get; set; }
        public IEmployeeMoneyLogic EmployeeMoneyLogic { get; set; }
    }
}
