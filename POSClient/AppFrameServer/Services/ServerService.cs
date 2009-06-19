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
        private static List<IDepartmentStockOutCallback> _callbackSubStockList = new List<IDepartmentStockOutCallback>();
        public void JoinDistributingGroup(Department department)
        {
            // Subscribe the guest to the beer inventory
            IDepartmentStockOutCallback guest = OperationContext.Current.GetCallbackChannel<IDepartmentStockOutCallback>();
            if (department.DepartmentId > 999999)
            {
                if (!_callbackSubStockList.Contains(guest))
                {
                    _callbackSubStockList.Add(guest);
                    guest.NotifyConnected();
                }
            }
            else
            {
                if (!_callbackList.Contains(guest))
                {
                    _callbackList.Add(guest);
                    guest.NotifyConnected();
                }    
            }
             
        }


        public void RequestDepartmentStockOut(long departmentId)
        {
            _callbackSubStockList.ForEach(
                 delegate(IDepartmentStockOutCallback callback)
                 {
                     try
                     {
                         callback.NotifyRequestDepartmentStockOut(departmentId);
                     }
                     catch (Exception)
                     {

                     }
                 }); 
        }

        public void InformDepartmentStockOutSuccess(long sourceDeptId, long destDeptId, long deptStockId)
        {
            _callbackSubStockList.ForEach(
                 delegate(IDepartmentStockOutCallback callback)
                 {
                     try
                     {
                         callback.NotifyStockOutSuccess(sourceDeptId, destDeptId, deptStockId);
                     }
                     catch (Exception)
                     {

                     }
                 });
        }

        public void MakeDepartmentStockOut(Department department, DepartmentStockOut stockOut, DepartmentPrice price)
        {
            _callbackList.ForEach(
                delegate(IDepartmentStockOutCallback callback)
                    {
                        try
                        {
                            callback.NotifyNewDepartmentStockOut(department, stockOut, price);
                        }
                        catch (Exception)
                        {   
                            
                        }
                    });
        }

        public void MakeDepartmentStockIn(Department department, DepartmentStockIn stockOut)
        {
            _callbackList.ForEach(
               delegate(IDepartmentStockOutCallback callback)
               {
                   try
                   {
                       callback.NotifyNewDepartmentStockIn(department, stockOut);
                   }
                   catch (Exception)
                   {

                   }
               });
        }

        public void ExitDistributingGroup(Department department)
        {
            // Unsubscribe the guest from the beer inventory
            IDepartmentStockOutCallback guest = OperationContext.Current.GetCallbackChannel<IDepartmentStockOutCallback>();

            if (_callbackList.Contains(guest))
            {
                _callbackList.Remove(guest);
            }
            if (_callbackSubStockList.Contains(guest))
            {
                _callbackSubStockList.Remove(guest);
            }
        }
    }
}
