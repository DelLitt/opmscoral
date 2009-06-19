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
using AppFrame.View;
using AppFrameClient.Utility.Mapper;

namespace AppFrameClient.Services
{
    public class ServerServiceConsumer : ServerServiceCallback
    {
        const int SleepTime = 5*60*1000;
        private bool connected = false;
        private Thread m_thread;
        private bool m_running;
        private ServerServiceClient serverService = null;

        public void NotifyNewDepartmentStockOut(Department department, DepartmentStockOut stockOut,DepartmentPrice price)
        {
            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Đang nhận thông tin ...";
            if(CurrentDepartment.Get().DepartmentId != department.DepartmentId)
            {
                return;    
            }
            DepartmentStockIn stockIn;
            // convert from stock out to stock in
            stockIn = new FastDepartmentStockInMapper().Convert(stockOut);
            // call method to sync
            DepartmentStockInLogic.SyncFromSubStock(stockIn);
            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Hoàn tất và phản hồi ...";
            serverService.InformDepartmentStockOutSuccess(stockOut.DepartmentStockOutPK.DepartmentId,stockOut.OtherDepartmentId,stockOut.DepartmentStockOutPK.StockOutId);
            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Hoàn tất ! ";
        }

        public void NotifyNewDepartmentStockIn(Department department, DepartmentStockIn stockIn)
        {
            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Đang nhận thông tin ...";
            if (CurrentDepartment.Get().DepartmentId != department.DepartmentId)
            {
                return;
            }
            DepartmentStockOut stockOut;
            // convert from stock out to stock in
            stockOut = new FastDepartmentStockOutMapper().Convert(stockIn);
            
            // call method to sync
            DepartmentStockOutLogic.Add(stockOut);
            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Hoàn tất và phản hồi ...";
        }
    

        public void NotifyConnected()
        {
            connected = true;
            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Kết nối thành công!";
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
            IDepartmentStockOutLogic deptStockOutLogic = (IDepartmentStockOutLogic)GlobalUtility.GetObject("AppFrame.Service.IDepartmentStockOutLogic");
            DepartmentStockOutLogic = deptStockOutLogic;
            
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
                        try
                        {
                            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Đang kết nối ...";
                            serverService = new ServerServiceClient(new InstanceContext(this), "TcpBinding");
                            serverService.JoinDistributingGroup(CurrentDepartment.Get());
                            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Kết nối với dịch vụ.";
                            Thread.Sleep(500);
                            
                        }
                        catch (Exception) { }
                        
                    }
                    else
                    {
                        try
                        {
                            // Wait until thread is stopped
                            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Yêu cầu thông tin ... ";
                            serverService.RequestDepartmentStockOut(CurrentDepartment.Get().DepartmentId);
                            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Chờ lệnh ... ";
                            Thread.Sleep(SleepTime);     
                        }
                        catch (Exception)
                        {
                            if(serverService.State == CommunicationState.Faulted
                               || serverService.State == CommunicationState.Closed)
                            {
                                connected = false;
                            }
                        }
                        
                        
                    }
                }
                
        }
        /// <summary>
        /// Request the end of the thread method.
        /// </summary>
        public void Stop()
        {
            lock (this)
            {
                m_running = false;
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
