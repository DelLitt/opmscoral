using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame.View;

namespace AppFrame.Logic
{
    public interface IClosedPeriodLogic
    {
        // view 
        IClosedPeriodView ClosedPeriodView { get; set; }

        // logic
        IPurchaseOrderLogic PurchaseOrderLogic
        {
            get;
            set;
        }

        IPurchaseOrderDetailLogic PurchaseOrderDetailLogic
        {
            get;
            set;
        }

        IProductMasterLogic ProductMasterLogic
        {
            get;
            set;
        }
        
        IReturnPoLogic ReturnPoLogic { get; set; }
        IDepartmentPriceLogic DepartmentPriceLogic { get; set; }
        IEmployeeMoneyLogic EmployeeMoneyLogic { get; set; }
    }
}
