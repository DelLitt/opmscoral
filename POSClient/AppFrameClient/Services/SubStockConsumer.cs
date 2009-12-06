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
using AppFrameClient.Common;
using AppFrameClient.Utility;

namespace AppFrameClient.Services
{
    public class SubStockConsumer : ServerServiceCallback
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        const int SleepTime = 10*1000;
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
                            //ClientUtility.Log(logger, ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text);
                            serverService = new ServerServiceClient(new InstanceContext(this), ClientSetting.ServiceBinding);
                            serverService.JoinDistributingGroup(CurrentDepartment.Get());
                            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = "Kết nối với dịch vụ.";
                            //ClientUtility.Log(logger, ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text);
                        }
                        catch (Exception)
                        {
                            
                        }
                        Thread.Sleep(100);
                    }
                    else
                    {
                        Thread.Sleep(100);
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
            GlobalMessage message = (GlobalMessage)GlobalUtility.GetObject("GlobalMessage");
            if(sourceDeptId!= CurrentDepartment.Get().DepartmentId)
            {
                return;
            }
            ClientUtility.Log(logger, deptDeptId + " phan hoi den " + sourceDeptId + " da nhap hang thanh cong.");
            try
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

                message.PublishMessage(ChannelConstants.SUBSTOCK2DEPT_STOCKOUT, sourceDeptId + "đã xuất " + stockOutId+ " xuống " + deptDeptId + " thành công !");
                ClientUtility.Log(logger, " Xuat hang hoan tat.");
            }
            catch (Exception exp)
            {
                message.PublishError(ChannelConstants.SUBSTOCK2DEPT_STOCKOUT, sourceDeptId + "đã xuất " + stockOutId + " xuống " + deptDeptId + " thất bại !");
                ClientUtility.Log(logger, exp.Message);
            }
        }

        public void NotifyStockInSuccess(Department department, DepartmentStockIn stockIn,long stockOutId)
        {
            GlobalMessage message = (GlobalMessage)GlobalUtility.GetObject("GlobalMessage");
            message.PublishMessage(ChannelConstants.DEPT2SUBSTOCK_STOCKOUT, "Đã lấy hàng thành công!");
            ClientUtility.Log(logger, department.DepartmentId + " Nhap lai hang THANH CONG." + stockIn.ToString());    
        }

        public void NotifyUpdateStockOutFlag(Department department, DepartmentStockIn stockIn,long stockOutId)
        {
            // dont need to implment
        }

        public void NotifyRequestDepartmentStockOut(long departmentId)
        {
            //ClientUtility.Log(logger, departmentId + " requesting stock-out information.");
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
            if(list!= null && list.Count > 0 )
            {
                ClientUtility.Log(logger, " Co " + list.Count + " phieu xuat hang ve " + departmentId);
                ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Gửi thông tin ...";
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
                }
                DepartmentStockOut[] array = new DepartmentStockOut[list.Count];
                int i = 0;
                foreach (DepartmentStockOut @out in list)
                {
                    array[i] = @out;
                    i++;
                }
                serverService.MakeMultiDepartmentStockOut(destDept,array, new DepartmentPrice());
                ClientUtility.Log(logger, departmentId + " da duoc gui thong tin xuat hang.");
            }
            
        }

        public void NotifyRequestDepartmentStockIn(long departmentId)
        {
            // do not implement
        }

        public void NotifyNewMultiDepartmentStockOut(Department department, DepartmentStockOut[] list, DepartmentPrice price)
        {
            // do not implement
        }

        public void NotifyMultiStockInSuccess(Department department, DepartmentStockIn[] stockInList, long id)
        {
            GlobalMessage message = (GlobalMessage)GlobalUtility.GetObject("GlobalMessage");

            try
            {
                foreach (DepartmentStockIn stockIn in stockInList)
                {
                    if (stockIn != null)
                    {
                        if (stockIn.DepartmentStockInPK.DepartmentId != CurrentDepartment.Get().DepartmentId)
                        {
                            return;
                        }
                        ClientUtility.Log(logger, department.DepartmentId + " dang nhan thong tin nhap hang");
                        DepartmentStockInLogic.AddStockInBack(stockIn);
                        ClientUtility.Log(logger, " Nhap lai hang thanh cong.");

                        message.PublishMessage(ChannelConstants.DEPT2SUBSTOCK_STOCKOUT, "Đã lấy hàng thành công!");
                        serverService.UpdateStockInBackFlag(department, stockIn, id);

                    }
                    else
                    {
                        ClientUtility.Log(logger, department.DepartmentId + " nhap lai hang that bai.");
                        message.PublishError(ChannelConstants.DEPT2SUBSTOCK_STOCKOUT, "Đã lấy hàng thất bại!");
                    }
                }
            }
            catch (Exception exception)
            {
                ClientUtility.Log(logger, exception.Message); 
            }
        }

        public void NotifyStockInFail(Department department, DepartmentStockIn stockIn, long id)
        {
            GlobalMessage message = (GlobalMessage)GlobalUtility.GetObject("GlobalMessage");
                ClientUtility.Log(logger, department.DepartmentId + " Nhap lai hang THAT BAI." + stockIn.ToString());    
                message.PublishError(ChannelConstants.DEPT2SUBSTOCK_STOCKOUT, "Đã lấy hàng thất bại!");
            
        }

        public void NotifyStockOutFail(long sourceId, long destId, long stockId)
        {
            GlobalMessage message = (GlobalMessage)GlobalUtility.GetObject("GlobalMessage");
            string msg = sourceId + " xuat " + stockId + " den " + destId + " that bai";
            ClientUtility.Log(logger, msg);
            message.PublishError(ChannelConstants.SUBSTOCK2DEPT_STOCKOUT, " Đơn hàng " + stockId + " truyền thất bại!");
        }

        public static readonly int SUBTODEPT = 1;
        public static readonly int DEPTTOSUB = 2;

        public void NotifyInformMessage(long destDeptId,int channel, bool isError, string message)
        {
           GlobalMessage globalChannel = (GlobalMessage)GlobalUtility.GetObject("GlobalMessage");
           if(isError)
           {
               if(channel == SUBTODEPT)
               {
                   globalChannel.PublishError(ChannelConstants.SUBSTOCK2DEPT_STOCKOUT, message);    
               }
               if (channel == DEPTTOSUB)
               {
                   globalChannel.PublishError(ChannelConstants.DEPT2SUBSTOCK_STOCKOUT, message);
               }
           }
           else
           {
               if (channel == SUBTODEPT)
               {
                   globalChannel.PublishMessage(ChannelConstants.SUBSTOCK2DEPT_STOCKOUT, message);
               }
               if (channel == DEPTTOSUB)
               {
                   globalChannel.PublishMessage(ChannelConstants.DEPT2SUBSTOCK_STOCKOUT, message);
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
                serverService = null;
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
