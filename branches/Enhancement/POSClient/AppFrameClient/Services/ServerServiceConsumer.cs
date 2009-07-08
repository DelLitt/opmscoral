﻿using System;
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
using AppFrameClient.Common;
using AppFrameClient.Utility;
using AppFrameClient.Utility.Mapper;

namespace AppFrameClient.Services
{
    public class ServerServiceConsumer : ServerServiceCallback
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        const int SleepTime = 10*1000;
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
            ClientUtility.Log(logger, " Have stock-out to ..." + department.DepartmentId);
            DepartmentStockIn stockIn;
            // convert from stock out to stock in
            stockIn = new FastDepartmentStockInMapper().Convert(stockOut);
            // call method to sync
            ClientUtility.Log(logger, " Do stock in");
            DepartmentStockInLogic.SyncFromSubStock(stockIn);
            ClientUtility.Log(logger, " Completed and feed back ... ");
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
            ClientUtility.Log(logger, " Have stock-in back request to ..." + department.DepartmentId);
            DepartmentStockOut stockOut;
            // convert from stock out to stock in
            ClientUtility.Log(logger, " Do stock out from ..." + department.DepartmentId);
            stockOut = new FastDepartmentStockOutMapper().Convert(stockIn);
            
            // call method to sync
            DepartmentStockOutLogic.Add(stockOut);
            ClientUtility.Log(logger, " Completed and feeding back ..." );
            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Hoàn tất và phản hồi ...";
            ClientUtility.Log(logger, ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text);
            
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
                            ClientUtility.Log(logger, ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text);
                            serverService = new ServerServiceClient(new InstanceContext(this), ClientSetting.ServiceBinding);
                            serverService.JoinDistributingGroup(CurrentDepartment.Get());
                            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Kết nối với dịch vụ.";
                            ClientUtility.Log(logger, ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text);
                            Thread.Sleep(500);
                            
                        }
                        catch (Exception ex)
                        {
                            string s = ex.Message; 
                        }
                        
                    }
                    else
                    {
                        try
                        {
                            // Wait until thread is stopped
                            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Yêu cầu thông tin ... ";
                            ClientUtility.Log(logger, ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text);
                            serverService.RequestDepartmentStockOut(CurrentDepartment.Get().DepartmentId);
                            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Chờ lệnh ... ";
                            ClientUtility.Log(logger, ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text);
                            Thread.Sleep(SleepTime);
                        }
                        catch (Exception)
                        {
                            if(serverService.State == CommunicationState.Faulted
                               || serverService.State == CommunicationState.Closed)
                            {
                                connected = false;
                                serverService.Close();
                            }
                            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Thất bại ... ";
                            ClientUtility.Log(logger, ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text);
                            Thread.Sleep(1000 * 5);
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