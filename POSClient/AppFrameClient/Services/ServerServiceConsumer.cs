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
        const int SleepTime = 200;
        private bool connected = false;
        private Thread m_thread;
        private bool m_running;

        public void NotifyNewDepartmentStockOut(Department department, DepartmentStockOut stockOut,DepartmentPrice price)
        {
            DepartmentStockIn stockIn;
            // convert from stock out to stock in
            stockIn = new FastDepartmentStockInMapper().Convert(stockOut);
            // call method to sync
            DepartmentStockInLogic.SyncFromSubStock(stockIn);
        }

        
        public void NotifyConnected()
        {
            connected = true;
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
                        ServerServiceClient serverService = new ServerServiceClient(new InstanceContext(this), "TcpBinding");
                        serverService.JoinDistributingGroup(CurrentDepartment.Get());
                        Thread.Sleep(500);
                    }
                    else
                    {
                        // Wait until thread is stopped
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
        #endregion 
    }
}
