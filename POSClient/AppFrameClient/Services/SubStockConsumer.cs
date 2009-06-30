using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Utility;
using AppFrame.View;
using AppFrameClient.Utility;

namespace AppFrameClient.Services
{
    public class SubStockConsumer : ServerServiceCallback
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        const int SleepTime = 200;
        private bool connected = false;
        private Thread m_thread;
        private bool m_running;
        private ServerServiceClient serverService = null;

        public SubStockConsumer()
        {
            IDepartmentStockInLogic deptStockInLogic = (IDepartmentStockInLogic)GlobalUtility.GetObject("AppFrame.Service.IDepartmentStockInLogic");
            DepartmentStockInLogic = deptStockInLogic;

            IDepartmentStockOutLogic deptStockOutLogic = (IDepartmentStockOutLogic)GlobalUtility.GetObject("AppFrame.Service.IDepartmentStockOutLogic");
            DepartmentStockOutLogic = deptStockOutLogic;

            IDepartmentLogic deptLogic = (IDepartmentLogic)GlobalUtility.GetObject("AppFrame.Service.IDepartmentLogic");
            DepartmentLogic = deptLogic;

            IDepartmentPriceLogic deptPriceLogic = (IDepartmentPriceLogic)GlobalUtility.GetObject("AppFrame.Service.IDepartmentPriceLogic");
            DepartmentPriceLogic = deptPriceLogic;
            
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
                            ((MainForm) GlobalCache.Instance().MainForm).ServiceStatus.Text = " Đang kết nối ...";
                            ClientUtility.Log(logger, ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text);
                            serverService = new ServerServiceClient(new InstanceContext(this), "TcpBinding");
                            serverService.JoinDistributingGroup(CurrentDepartment.Get());
                            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = "Kết nối với dịch vụ.";
                            ClientUtility.Log(logger, ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text);
                        }
                        catch (Exception)
                        {
                         
                        }
                        Thread.Sleep(500);
                    }
                    else
                    {
                        // Wait until thread is stopped
                        Thread.Sleep(SleepTime);
                        //((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Chờ lệnh ... ";
                    }
                }
                
        }


        public void NotifyNewDepartmentStockOut(Department department, DepartmentStockOut stockOut, DepartmentPrice price)
        {
            // don't need to implement
        }

        public void NotifyNewDepartmentStockIn(Department department, DepartmentStockIn stockOut)
        {
            // don't need to implement            
        }

        public void NotifyConnected()
        {
            connected = true;
            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Kết nối thành công!";
            ClientUtility.Log(logger, ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text);
        }

        public void NotifyStockOutSuccess(long sourceDeptId, long deptDeptId, long stockOutId)
        {
            ClientUtility.Log(logger, deptDeptId + " notify " + sourceDeptId  + " stock-out success.");
            DepartmentStockOutPK departmentStockOutPk = new DepartmentStockOutPK
            {
                DepartmentId = sourceDeptId,
                StockOutId = stockOutId
            };
            
            DepartmentStockOut deptStockOut = DepartmentStockOutLogic.FindById(departmentStockOutPk);
            if (deptStockOut != null && deptStockOut.OtherDepartmentId == deptDeptId)
            {
                deptStockOut.ConfirmFlg = 0;
                deptStockOut.UpdateDate = DateTime.Now;
                DepartmentStockOutLogic.Update(deptStockOut);
            }
            ClientUtility.Log(logger, " Notify stock-out success.");
        }
        
        public void NotifyRequestDepartmentStockOut(long departmentId)
        {
            ClientUtility.Log(logger, departmentId + " requesting stock-out information.");
            if(serverService == null)
            {
                return;
            }
            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Đang nhận thông tin ...";
            ClientUtility.Log(logger, ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text);
            ObjectCriteria objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("OtherDepartmentId", departmentId);
            objectCriteria.AddEqCriteria("ConfirmFlg", (long)3);
            
            IList list = DepartmentStockOutLogic.FindAll(objectCriteria);
            Department destDept  = new Department
                                       {
                                           DepartmentId = departmentId
                                       } ;
            if(list!= null && list.Count > 0 )
            {
                ClientUtility.Log(logger, " Has " + list.Count + " stock-outs for " + departmentId);
                foreach (DepartmentStockOut departmentStockOut in list)
                {
                    foreach (DepartmentStockOutDetail detail in departmentStockOut.DepartmentStockOutDetails)
                    {
                        string prdMasterId = detail.Product.ProductMaster.ProductMasterId;
                        DepartmentPricePK pricePk = new DepartmentPricePK
                        {
                            DepartmentId = 0,
                            ProductMasterId = prdMasterId
                        };
                        detail.DepartmentPrice = DepartmentPriceLogic.FindById(pricePk);
                    }
                    serverService.MakeDepartmentStockOut(destDept, departmentStockOut, new DepartmentPrice());
                }    
            }
            
            ClientUtility.Log(logger, departmentId + " has been sent stock-out information.");
        }
        /// <summary>
        /// Request the end of the thread method.
        /// </summary>
        public void Stop()
        {
            lock (this)
            {
                m_running = false;
                serverService.Close();
                ClientUtility.Log(logger, " Close service.");
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
        public IDepartmentLogic DepartmentLogic
        {
            get;
            set;
        }
        public IDepartmentPriceLogic DepartmentPriceLogic
        {
            get;
            set;
        }
        #endregion
    }
}
