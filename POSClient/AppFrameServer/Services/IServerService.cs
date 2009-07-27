using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrameServer.Services
{
    [ServiceContract(
        Name = "ServerService",Namespace = "http://localhost:8001/",
        SessionMode = SessionMode.Required,
        CallbackContract = typeof(IDepartmentStockOutCallback))]
    public interface IServerService
    {
        [OperationContract()]
        void JoinDistributingGroup(Department department);
        
        [OperationContract(IsOneWay = true)]
        void MakeDepartmentStockOut(Department department, DepartmentStockOut stockOut,DepartmentPrice price);

        /// <summary>
        /// This method access database directly and update information about stock out
        /// </summary>
        /// <param name="department"></param>
        /// <param name="stockOut"></param>
        /// <param name="price"></param>
        void MakeRawDepartmentStockOut(Department department, DepartmentStockOut stockOut, DepartmentPrice price);
        
        [OperationContract(IsOneWay = true)]
        void MakeMultiDepartmentStockOut(Department department, DepartmentStockOut[] stockOutList, DepartmentPrice price);

        [OperationContract(IsOneWay = true)]
        void MakeDepartmentStockIn(Department department, DepartmentStockIn stockOut);

        /// <summary>
        /// This method access database directly and update information about stock in
        /// </summary>
        /// <param name="department"></param>
        /// <param name="stockOut"></param>
        void MakeRawDepartmentStockIn(Department department, DepartmentStockIn stockOut);

        [OperationContract(IsOneWay = true)]
        void ExitDistributingGroup(Department department);

        [OperationContract(IsOneWay = true)]
        void RequestDepartmentStockOut(long departmentId);

        /// <summary>
        /// This method access database directly and update information about stock out
        /// </summary>
        /// <param name="departmentId"></param>
        [OperationContract(IsOneWay = true)]
        void RequestRawDepartmentStockOut(long departmentId);

        /// <summary>
        /// This method access database directly and update information about stock in
        /// </summary>
        /// <param name="departmentId"></param>
        /// 
        [OperationContract(IsOneWay = true)]
        void RequestRawDepartmentStockIn(long departmentId);

        [OperationContract(IsOneWay = true)]
        void RequestDepartmentStockIn(long departmentId);
        
        DepartmentStockIn MakeAllShoesDepartmentStockInBack(long salePointId,long subStockId);

        [OperationContract(IsOneWay = true)]
        void InformMessage(long destDeptId, bool isError, string message);

        [OperationContract(IsOneWay = true)]
        void InformDepartmentStockOutSuccess(long sourceDeptId, long destDeptId, long deptStockId);

        [OperationContract(IsOneWay = true)]
        void InformDepartmentStockOutFail(long sourceDeptId, long destDeptId, long deptStockId);

        [OperationContract(IsOneWay = true)]
        void InformDepartmentStockInSuccess(Department department, DepartmentStockIn stockIn,long stockOutId);

        [OperationContract(IsOneWay = true)]
        void InformMultiDepartmentStockInSuccess(Department department, DepartmentStockIn[] stockIn, long stockOutId);

        [OperationContract(IsOneWay = true)]
        void InformDepartmentStockInFail(Department department, DepartmentStockIn stockIn, long stockOutId);

        [OperationContract(IsOneWay = true)]
        void UpdateStockInBackFlag(Department department, DepartmentStockIn stockIn, long stockOutId);
        
    }
}
