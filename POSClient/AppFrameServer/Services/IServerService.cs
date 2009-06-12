using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrameServer.Services
{
    [ServiceContract(
        Name = "ServerService",
        Namespace = "http://localhost:8001/ServerService/",
        SessionMode = SessionMode.Required,
        CallbackContract = typeof(IDepartmentStockOutCallback))]
    public interface IServerService
    {
        [OperationContract()]
        void JoinDistributingGroup(Department department, BaseUser user);
        
        [OperationContract(IsOneWay = true)]
        void MakeDepartmentStockOut(Department department, BaseUser user,DepartmentStockOut stockOut);

        [OperationContract(IsOneWay = true)]
        void ExitDistributingGroup(Department department, BaseUser user);
    }
}
