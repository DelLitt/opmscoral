using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Utility;
using AppFrameClient.Utility.Mapper;

namespace AppFrameClient.Services
{
    public class ServerServiceConsumer : ServerServiceCallback
    {
        const int SleepTime = 1000;
        private bool connected = false;
        private Thread m_thread;
        private bool m_running;
        private ServerServiceClient serverService = null;

        public void NotifyNewDepartmentStockOut(Department department, DepartmentStockOut stockOut,DepartmentPrice price)
        {
            if(CurrentDepartment.Get().DepartmentId != department.DepartmentId)
            {
                return;    
            }
            DepartmentStockIn stockIn;
            // convert from stock out to stock in
            stockIn = new FastDepartmentStockInMapper().Convert(stockOut);
            // call method to sync
            DepartmentStockInLogic.SyncFromSubStock(stockIn);
            serverService.InformDepartmentStockOutSuccess(stockOut.DepartmentStockOutPK.DepartmentId,stockOut.OtherDepartmentId,stockOut.DepartmentStockOutPK.StockOutId);
        }

        
        public void NotifyConnected()
        {
            connected = true;
        }

        public void NotifyStockOutSuccess(long sourceDeptId, long deptDeptId, long stockOutId)
        {
            // don't need to implement
        }

        

        public void NotifyRequestDepartmentStockOut(long departmentId)
        {
            // don't need to implement
        }

        public ServerServiceConsumer()
        {
            IDepartmentStockInLogic deptStockInLogic = (IDepartmentStockInLogic)GlobalUtility.GetObject("AppFrame.Service.IDepartmentStockInLogic");
            DepartmentStockInLogic = deptStockInLogic;
            
            m_thread = new Thread(new ThreadStart(ThreadMethod));
            m_thread.Start();
        }

        private void ThreadMethod()
        {
            
                m_running = true;
                while (m_running)
                {
                    if(!connected)
                    {
                        serverService = new ServerServiceClient(new InstanceContext(this), "TcpBinding");
                        serverService.JoinDistributingGroup(CurrentDepartment.Get());
                        Thread.Sleep(500);
                    }
                    else
                    {
                        // Wait until thread is stopped
                        serverService.RequestDepartmentStockOut(CurrentDepartment.Get().DepartmentId);
                        Thread.Sleep(SleepTime);    
                    }
                }
                
        }

        #region Logic use in IDepartmentStockInController

        public IDepartmentStockInLogic DepartmentStockInLogic
        {
            get;
            set;
        }
        public IDepartmentStockOutLogic DepartmentStockOutLogic
        {
            get;
            set;
        }
        #endregion 
    }
}
