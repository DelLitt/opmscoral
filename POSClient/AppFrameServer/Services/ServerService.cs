using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrameServer.Services
{
    [ServiceBehavior(
        ConcurrencyMode = ConcurrencyMode.Single,
        InstanceContextMode = InstanceContextMode.PerCall)]
    public class ServerService : IServerService
    {
        private static List<IDepartmentStockOutCallback> _callbackList = new List<IDepartmentStockOutCallback>();
        public void JoinDistributingGroup(Department department, BaseUser user)
        {
            // Subscribe the guest to the beer inventory
            IDepartmentStockOutCallback guest = OperationContext.Current.GetCallbackChannel<IDepartmentStockOutCallback>();

            if (!_callbackList.Contains(guest))
            {
                _callbackList.Add(guest);
            } 
        }

        public void MakeDepartmentStockOut(Department department, BaseUser user,DepartmentStockOut stockOut)
        {
            _callbackList.ForEach(
                delegate(IDepartmentStockOutCallback callback)
                { callback.NotifyNewDepartmentStockOut(department, stockOut); });
        }

        public void ExitDistributingGroup(Department department, BaseUser user)
        {
            // Unsubscribe the guest from the beer inventory
            IDepartmentStockOutCallback guest = OperationContext.Current.GetCallbackChannel<IDepartmentStockOutCallback>();

            if (_callbackList.Contains(guest))
            {
                _callbackList.Remove(guest);
            }
        }
    }
}
