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

namespace AppFrameClient.Services
{
    public class SubStockConsumer : ServerServiceCallback
    {
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
                            serverService = new ServerServiceClient(new InstanceContext(this), "TcpBinding");
                            serverService.JoinDistributingGroup(CurrentDepartment.Get());
                            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = "Kết nối với dịch vụ.";
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

        public void NotifyConnected()
        {
            connected = true;
            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Kết nối thành công!";
        }

        public void NotifyStockOutSuccess(long sourceDeptId, long deptDeptId, long stockOutId)
        {
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
        }
        
        public void NotifyRequestDepartmentStockOut(long departmentId)
        {
            if(serverService == null)
            {
                return;
            }
            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Đang nhận thông tin ...";
            ObjectCriteria objectCriteria = new ObjectCriteria();
            objectCriteria.AddEqCriteria("OtherDepartmentId", departmentId);
            objectCriteria.AddEqCriteria("ConfirmFlg", (long)3);

            IList list = DepartmentStockOutLogic.FindAll(objectCriteria);
            Department destDept  = new Department
                                       {
                                           DepartmentId = departmentId
                                       } ;
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
               serverService.MakeDepartmentStockOut(destDept,departmentStockOut,new DepartmentPrice()); 
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
