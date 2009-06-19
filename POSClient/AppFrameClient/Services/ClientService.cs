﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3521
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using AppFrame.Model;

namespace AppFrameClient.Services
{

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace = "http://localhost:8001/", ConfigurationName = "ServerService", CallbackContract = typeof(ServerServiceCallback), SessionMode = System.ServiceModel.SessionMode.Required)]
    public interface ServerService
    {

        [System.ServiceModel.OperationContractAttribute(Action = "http://localhost:8001/ServerService/JoinDistributingGroup", ReplyAction = "http://localhost:8001/ServerService/JoinDistributingGroupResponse")]
        void JoinDistributingGroup(Department department);

        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://localhost:8001/ServerService/MakeDepartmentStockOut")]
        void MakeDepartmentStockOut(Department department, DepartmentStockOut stockOut, AppFrame.Model.DepartmentPrice price);

        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://localhost:8001/ServerService/MakeDepartmentStockIn")]
        void MakeDepartmentStockIn(Department department, DepartmentStockIn stockOut);

        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://localhost:8001/ServerService/ExitDistributingGroup")]
        void ExitDistributingGroup(Department department);

        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://localhost:8001/ServerService/RequestDepartmentStockOut")]
        void RequestDepartmentStockOut(long departmentId);

        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://localhost:8001/ServerService/InformDepartmentStockOutSuccess")]
        void InformDepartmentStockOutSuccess(long sourceDeptId, long destDeptId, long deptStockId);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ServerServiceCallback
    {

        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://localhost:8001/ServerService/NotifyNewDepartmentStockOut")]
        void NotifyNewDepartmentStockOut(Department department, DepartmentStockOut stockOut, AppFrame.Model.DepartmentPrice price);

        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://localhost:8001/ServerService/NotifyNewDepartmentStockIn")]
        void NotifyNewDepartmentStockIn(Department department, DepartmentStockIn stockOut);

        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://localhost:8001/ServerService/NotifyConnected")]
        void NotifyConnected();

        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://localhost:8001/ServerService/NotifyStockOutSuccess")]
        void NotifyStockOutSuccess(long sourceDeptId, long deptDeptId, long stockOutId);

        [System.ServiceModel.OperationContractAttribute(IsOneWay = true, Action = "http://localhost:8001/ServerService/NotifyRequestDepartmentStockOut")]
        void NotifyRequestDepartmentStockOut(long departmentId);
    }

    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public interface ServerServiceChannel : ServerService, System.ServiceModel.IClientChannel
    {
    }

    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
    public partial class ServerServiceClient : System.ServiceModel.DuplexClientBase<ServerService>, ServerService
    {

        public ServerServiceClient(System.ServiceModel.InstanceContext callbackInstance) :
            base(callbackInstance)
        {
        }

        public ServerServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName) :
            base(callbackInstance, endpointConfigurationName)
        {
        }

        public ServerServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, string remoteAddress) :
            base(callbackInstance, endpointConfigurationName, remoteAddress)
        {
        }

        public ServerServiceClient(System.ServiceModel.InstanceContext callbackInstance, string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) :
            base(callbackInstance, endpointConfigurationName, remoteAddress)
        {
        }

        public ServerServiceClient(System.ServiceModel.InstanceContext callbackInstance, System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) :
            base(callbackInstance, binding, remoteAddress)
        {
        }

        public void JoinDistributingGroup(Department department)
        {
            base.Channel.JoinDistributingGroup(department);
        }

        public void MakeDepartmentStockOut(Department department, DepartmentStockOut stockOut, AppFrame.Model.DepartmentPrice price)
        {
            base.Channel.MakeDepartmentStockOut(department, stockOut, price);
        }

        public void MakeDepartmentStockIn(Department department, DepartmentStockIn stockOut)
        {
            base.Channel.MakeDepartmentStockIn(department, stockOut);
        }

        public void ExitDistributingGroup(Department department)
        {
            base.Channel.ExitDistributingGroup(department);
        }

        public void RequestDepartmentStockOut(long departmentId)
        {
            base.Channel.RequestDepartmentStockOut(departmentId);
        }

        public void InformDepartmentStockOutSuccess(long sourceDeptId, long destDeptId, long deptStockId)
        {
            base.Channel.InformDepartmentStockOutSuccess(sourceDeptId, destDeptId, deptStockId);
        }

}
}