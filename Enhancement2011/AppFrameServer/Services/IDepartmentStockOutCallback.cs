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

        int DepartmentId { get; set; }

        [OperationContract(IsOneWay = true)]
        void NotifyNewDepartmentStockOut(Department department,DepartmentStockOut stockOut,DepartmentPrice price);

        [OperationContract(IsOneWay = true)]
        void NotifyNewDepartmentStockIn(Department department, DepartmentStockIn stockOut);
        
        [OperationContract(IsOneWay = true)]
        void NotifyConnected();

        [OperationContract(IsOneWay = true)]
        void NotifyStockOutSuccess(long sourceDeptId, long deptDeptId, long stockOutId);

        [OperationContract(IsOneWay = true)]
        void NotifyStockInSuccess(Department department, DepartmentStockIn stockIn,long stockOutId);

        [OperationContract(IsOneWay = true)]
        void NotifyUpdateStockOutFlag(Department department, DepartmentStockIn stockIn, long stockOutId);

        [OperationContract(IsOneWay = true)]
        void NotifyRequestDepartmentStockOut(long departmentId);

        [OperationContract(IsOneWay = true)]
        void NotifyRequestDepartmentStockIn(long departmentId);

        [OperationContract(IsOneWay = true)]
        void NotifyNewMultiDepartmentStockOut(Department department, DepartmentStockOut[] list, DepartmentPrice price);

        [OperationContract(IsOneWay = true)]
        void NotifyMultiStockInSuccess(Department department, DepartmentStockIn[] stockInList, long id);

        [OperationContract(IsOneWay = true)]
        void NotifyStockInFail(Department department, DepartmentStockIn stockIn, long id);

        [OperationContract(IsOneWay = true)]
        void NotifyStockOutFail(long sourceId, long destId, long stockId);

        [OperationContract(IsOneWay = true)]
        void NotifyInformMessage(long destDeptId, int channel, bool isError, string message);
    }
}
