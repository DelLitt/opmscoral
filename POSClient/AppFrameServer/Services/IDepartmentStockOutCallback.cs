using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using AppFrame.Model;

namespace AppFrameServer.Services
{
    public interface IDepartmentStockOutCallback
    {
        [OperationContract(IsOneWay = true)]
        void NotifyNewDepartmentStockOut(Department department,DepartmentStockOut stockOut,DepartmentPrice price);
        
        [OperationContract(IsOneWay = true)]
        void NotifyConnected();

        [OperationContract(IsOneWay = true)]
        void NotifyStockOutSuccess(long sourceDeptId, long deptDeptId, long stockOutId);

        [OperationContract(IsOneWay = true)]
        void NotifyRequestDepartmentStockOut(long departmentId);
    }
}
