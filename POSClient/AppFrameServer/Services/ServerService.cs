using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;
using AppFrameServer.Utility;

namespace AppFrameServer.Services
{
    [ServiceBehavior(
        ConcurrencyMode = ConcurrencyMode.Single,
        InstanceContextMode = InstanceContextMode.PerCall)]
    public class ServerService : IServerService
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static List<IDepartmentStockOutCallback> _callbackList = new List<IDepartmentStockOutCallback>();
        private static List<IDepartmentStockOutCallback> _callbackSubStockList = new List<IDepartmentStockOutCallback>();
        public void JoinDistributingGroup(Department department)
        {
            ServerUtility.Log(logger, department.DepartmentId + " joining the distributing group.");
            // Subscribe the guest to the beer inventory
            IDepartmentStockOutCallback guest = OperationContext.Current.GetCallbackChannel<IDepartmentStockOutCallback>();
            if (department.DepartmentId > 9999)
            {
                if (!_callbackSubStockList.Contains(guest))
                {

                    _callbackSubStockList.Add(guest);
                    guest.NotifyConnected();
                    ServerUtility.Log(logger, department.DepartmentId + " joined the substock group.");
                }
            }
            else
            {
                if (!_callbackList.Contains(guest))
                {
                    _callbackList.Add(guest);
                    ServerUtility.Log(logger, department.DepartmentId + " joined the normal group.");
                    guest.NotifyConnected();
                }    
            }
             
        }


        public void RequestDepartmentStockOut(long departmentId)
        {
            ServerUtility.Log(logger, departmentId + " request stock out.");
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
            ServerUtility.Log(logger, sourceDeptId + " inform stock out success to " + destDeptId);
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
            ServerUtility.Log(logger, " Stock-out dispatching to " + department.DepartmentId );
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
            ServerUtility.Log(logger, " Stock-in dispatching from " + department.DepartmentId);
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
            ServerUtility.Log(logger, department.DepartmentId + " quitting distributing group. ");
            // Unsubscribe the guest from the beer inventory
            IDepartmentStockOutCallback guest = OperationContext.Current.GetCallbackChannel<IDepartmentStockOutCallback>();

            if (_callbackList.Contains(guest))
            {
                ServerUtility.Log(logger, department.DepartmentId + " quit normal group. ");
                _callbackList.Remove(guest);
            }
            if (_callbackSubStockList.Contains(guest))
            {
                ServerUtility.Log(logger, department.DepartmentId + " quit substock group. ");
                _callbackSubStockList.Remove(guest);
            }
        }
    }
}
