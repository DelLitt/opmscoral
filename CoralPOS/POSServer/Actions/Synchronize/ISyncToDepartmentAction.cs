using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POSServer.BusinessLogic.Implement;

namespace POSServer.Actions.Synchronize
{
    public interface ISyncToDepartmentAction
    {

        ISyncLogic SyncLogic { get; set; }
        object SyncToDepartment(SyncToDepartmentObject syncToDepartmentObject);
    }
}
