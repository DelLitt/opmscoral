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
using AppFrameClient.Utility.Mapper;

namespace AppFrameClient.Services
{
    public class ServerServiceConsumer : ServerServiceCallback
    {
        private static readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        const int SleepTime = 8*1000;
        private bool connected = false;
        private Thread m_thread;
        private bool m_running;
        private ServerServiceClient serverService = null;
        private bool IsDoingStockOut = false;

        public void NotifyNewDepartmentStockOut(Department department, DepartmentStockOut stockOut,DepartmentPrice price)
        {
            if(CurrentDepartment.Get().DepartmentId != department.DepartmentId)
            {
                return;    
            }
            IsDoingStockOut = true;
            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Đang nhận thông tin ...";
            DepartmentStockIn stockIn;

            try
            {
                ClientUtility.Log(logger, department.DepartmentId + " dang nhan hang.");

                DepartmentStockInHistoryPK departmentStockInHistoryPk = new DepartmentStockInHistoryPK
                                                    {
                                                        SourceDepartmentId = stockOut.DepartmentStockOutPK.DepartmentId,
                                                        DestDepartmentId = CurrentDepartment.Get().DepartmentId,
                                                        StockOutId = stockOut.DepartmentStockOutPK.StockOutId
                                                    };

                ObjectCriteria deptHistCrit = new ObjectCriteria();
                deptHistCrit.AddEqCriteria("DepartmentStockInHistoryPK.SourceDepartmentId", stockOut.DepartmentStockOutPK.DepartmentId);
                deptHistCrit.AddEqCriteria("DepartmentStockInHistoryPK.StockOutId", stockOut.DepartmentStockOutPK.StockOutId);

                IList deptHistList = DepartmentStockInHistoryLogic.FindAll(deptHistCrit);
                // if it has exist in history so don't need to continue
                if(deptHistList!=null && deptHistList.Count > 0 )
                {
                    IsDoingStockOut = false;
                    return;
                }
                // convert from stock out to stock in
                stockIn = new FastDepartmentStockInMapper().Convert(stockOut);
                
                // call method to sync
                LogicResult logicResult = DepartmentStockInLogic.SyncFromSubStock(stockIn);
                if (logicResult.HasError)
                {
                    if(logicResult.Messages != null)
                    {
                        foreach (string message in logicResult.Messages)
                        {
                            ClientUtility.Log(logger, message);
                        }    
                    }
                    serverService.InformDepartmentStockOutFail(stockOut.DepartmentStockOutPK.DepartmentId,
                                                                  stockOut.OtherDepartmentId,
                                                                  stockOut.DepartmentStockOutPK.StockOutId);

                    
                }
                else
                {
                    ClientUtility.Log(logger, " Hoan tat va phan hoi ... " + stockOut.DepartmentStockOutPK.DepartmentId.ToString());
                    // add to stock in history for avoiding duplicate
                    departmentStockInHistoryPk.StockInId = stockIn.DepartmentStockInPK.StockInId;
                    DepartmentStockInHistory departmentStockInHistory = new DepartmentStockInHistory();
                    departmentStockInHistory.DepartmentStockInHistoryPK = departmentStockInHistoryPk;
                    departmentStockInHistory.Description = stockIn.ToString();
                    departmentStockInHistory.CreateDate = DateTime.Now;
                    departmentStockInHistory.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                    departmentStockInHistory.UpdateDate = DateTime.Now;
                    departmentStockInHistory.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                    DepartmentStockInHistoryLogic.Add(departmentStockInHistory);    
                    
                    
                    ((MainForm) GlobalCache.Instance().MainForm).ServiceStatus.Text = " Hoàn tất và phản hồi ...";
                    serverService.InformDepartmentStockOutSuccess(stockOut.DepartmentStockOutPK.DepartmentId,
                                                                  stockOut.OtherDepartmentId,
                                                                  stockOut.DepartmentStockOutPK.StockOutId);
                    ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Hoàn tất ! ";
                    ClientUtility.Log(logger, " Đã nhập hàng " + stockIn.ToString());
                }
            }
            catch (Exception exp)
            {
                ClientUtility.Log(logger, exp.Message);
                serverService.InformDepartmentStockOutFail(stockOut.DepartmentStockOutPK.DepartmentId,
                                                                  stockOut.OtherDepartmentId,
                                                                  stockOut.DepartmentStockOutPK.StockOutId);
            }
            finally
            {
                IsDoingStockOut = false;
            }
        }

        public void NotifyNewDepartmentStockIn(Department department, DepartmentStockIn stockIn)
        {
            if (CurrentDepartment.Get().DepartmentId != department.DepartmentId)
            {
                return;
            }
            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Đang nhận thông tin ...";
            
            DepartmentStockOut stockOut;
            // convert from stock out to stock in
            
            // call method to sync
            try
            {
                ClientUtility.Log(logger, department.DepartmentId + " tra hang ve " + stockIn.DepartmentStockInPK.DepartmentId);
                stockOut = new FastDepartmentStockOutMapper().Convert(stockIn);
                ClientUtility.Log(logger, department.DepartmentId + " xuat hang ...");
                stockOut.ConfirmFlg = 0;
                DepartmentStockOutLogic.Add(stockOut);
                ClientUtility.Log(logger, " Hoan tat và phản hồi ... ");
                ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Hoàn tất và phản hồi ...";
                serverService.InformDepartmentStockInSuccess(department, stockIn,stockOut.DepartmentStockOutPK.StockOutId);
                ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Hoàn tất ! ";
                ClientUtility.Log(logger, " Hoan tat tra " + stockOut.ToString());
            }
            catch (Exception ex)
            {
                ClientUtility.Log(logger, ex.Message);
                try
                {
                    serverService.InformDepartmentStockInSuccess(department, null,0);
                }
                catch (Exception exception)
                {
                    ClientUtility.Log(logger,exception.Message);
                }
                
            }
            
            
            
        }

        public void NotifyConnected()

        {
            connected = true;
            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Kết nối thành công!";
            ClientUtility.Log(logger, ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text);
        }

        public void NotifyStockOutSuccess(long sourceDeptId, long deptDeptId, long stockOutId)
        {
            // don't need to implement
        }

        public void NotifyStockInSuccess(Department department, DepartmentStockIn stockIn,long stockOutId)
        {
            //serverService.InformDepartmentStockInSucess(department,stockIn);
        }

        public void NotifyUpdateStockOutFlag(Department department, DepartmentStockIn stockIn, long stockOutId)
        {
            //ClientUtility.Log(logger, departmentId + " requesting stock-out information.");
            
            if(department.DepartmentId!= CurrentDepartment.Get().DepartmentId)
            {
                return;
            }
            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Đang nhận thông tin ...";
            DepartmentStockOutPK pk = new DepartmentStockOutPK
                                          {
                                             DepartmentId  = CurrentDepartment.Get().DepartmentId,
                                             StockOutId = stockOutId
                                          };

            DepartmentStockOut stockOut = DepartmentStockOutLogic.FindById(pk);
            if(stockOut == null)
            {
                ClientUtility.Log(logger, "Khong co phieu xuat hang: " + stockOutId.ToString() + " . Kiem tra lai ... ");
                return;
            }
            stockOut.ConfirmFlg = 0;
            DepartmentStockOutLogic.Update(stockOut);
            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Chờ lệnh ...";
            ClientUtility.Log(logger, "Cap nhat tra hang cho " + stockOutId.ToString());

        }


        public void NotifyRequestDepartmentStockOut(long departmentId)
        {
            // don't need to implement
        }

        public void NotifyRequestDepartmentStockIn(long departmentId)
        {
            //ClientUtility.Log(logger, departmentId + " requesting stock-out information.");

            try
            {
                ObjectCriteria objectCriteria = new ObjectCriteria();
                objectCriteria.AddEqCriteria("OtherDepartmentId", departmentId);
                objectCriteria.AddEqCriteria("ConfirmFlg", (long)3);

                IList list = DepartmentStockOutLogic.FindAll(objectCriteria);
                Department destDept = new Department
                                          {
                                              DepartmentId = CurrentDepartment.Get().DepartmentId
                                          };
                if (list != null && list.Count > 0)
                {
                    
                    ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Gửi thông tin ...";
                    ClientUtility.Log(logger, " Co " + list.Count + " phieu tra hang ve " + departmentId);
                    IList stockInList = new ArrayList();
                    foreach (DepartmentStockOut departmentStockOut in list)
                    {
                        foreach (DepartmentStockOutDetail detail in departmentStockOut.DepartmentStockOutDetails)
                        {
                            string prdMasterId = detail.Product.ProductMaster.ProductMasterId;
                        }
                        FastDepartmentStockInMapper mapper = new FastDepartmentStockInMapper();
                        DepartmentStockIn stockIn = mapper.Convert(departmentStockOut);
                        /*stockInList.Add(stockIn);*/
                        serverService.InformDepartmentStockInSuccess(destDept,stockIn,departmentStockOut.DepartmentStockOutPK.DepartmentId);
                    }
                    /*object[] array = new object[stockInList.Count];
                    int i = 0;
                    foreach (DepartmentStockIn @out in stockInList)
                    {
                        array[i] = @out;
                        i++;
                    }
                    ClientUtility.Log(logger, departmentId + " da duoc gui thong tin tra hang.");
                    serverService.InformMultiDepartmentStockInSuccess(destDept, array, array.Length);*/
                }
            }
            catch (Exception exception)
            {
                ClientUtility.Log(logger, exception.Message);
            }
            
        }
        
        public void NotifyNewMultiDepartmentStockOut(Department department, DepartmentStockOut[] list, DepartmentPrice price)
        {
            if (CurrentDepartment.Get().DepartmentId != department.DepartmentId)
            {
                return;
            }

            IsDoingStockOut = true;
            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Đang nhận thông tin ...";
            
                ClientUtility.Log(logger, department.DepartmentId + " dang nhan hang.");
                foreach (DepartmentStockOut stockOut in list)
                {
                    try
                    {
                    DepartmentStockInHistoryPK departmentStockInHistoryPk = new DepartmentStockInHistoryPK
                    {
                        SourceDepartmentId = stockOut.DepartmentStockOutPK.DepartmentId,
                        DestDepartmentId = CurrentDepartment.Get().DepartmentId,
                        StockOutId = stockOut.DepartmentStockOutPK.StockOutId
                    };

                    ObjectCriteria deptHistCrit = new ObjectCriteria();
                    deptHistCrit.AddEqCriteria("DepartmentStockInHistoryPK.SourceDepartmentId", stockOut.DepartmentStockOutPK.DepartmentId);
                    deptHistCrit.AddEqCriteria("DepartmentStockInHistoryPK.StockOutId", stockOut.DepartmentStockOutPK.StockOutId);
                    deptHistCrit.AddEqCriteria("DepartmentStockInHistoryPK.DestDepartmentId", department.DepartmentId);

                    IList deptHistList = DepartmentStockInHistoryLogic.FindAll(deptHistCrit);
                    // if it has exist in history so don't need to continue
                    if (deptHistList != null && deptHistList.Count > 0)
                    {
                        continue;
                    }

                    DepartmentStockIn stockIn;
                    // convert from stock out to stock in
                    stockIn = new FastDepartmentStockInMapper().Convert(stockOut);
                    // call method to sync
                    LogicResult logicResult = DepartmentStockInLogic.SyncFromSubStock(stockIn);
                    if (logicResult.HasError)
                    {
                        if (logicResult.Messages != null)
                        {
                            foreach (string message in logicResult.Messages)
                            {
                                ClientUtility.Log(logger, message);
                            }
                        }
                        serverService.InformDepartmentStockOutFail(stockOut.DepartmentStockOutPK.DepartmentId,
                                                                      stockOut.OtherDepartmentId,
                                                                      stockOut.DepartmentStockOutPK.StockOutId);
                    }
                    else
                    {
                        ClientUtility.Log(logger,
                                          " Hoan tat va phan hoi ... " +
                                          stockOut.DepartmentStockOutPK.DepartmentId.ToString());

                        // add to stock in history for avoiding duplicate
                        departmentStockInHistoryPk.StockInId = stockIn.DepartmentStockInPK.StockInId;
                        DepartmentStockInHistory departmentStockInHistory = new DepartmentStockInHistory();
                        departmentStockInHistory.DepartmentStockInHistoryPK = departmentStockInHistoryPk;
                        departmentStockInHistory.Description = stockIn.ToString();
                        departmentStockInHistory.CreateDate = DateTime.Now;
                        departmentStockInHistory.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                        departmentStockInHistory.UpdateDate = DateTime.Now;
                        departmentStockInHistory.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                        DepartmentStockInHistoryLogic.Add(departmentStockInHistory);

                        serverService.InformDepartmentStockOutSuccess(stockOut.DepartmentStockOutPK.DepartmentId,
                                                                      stockOut.OtherDepartmentId,
                                                                      stockOut.DepartmentStockOutPK.StockOutId);
                        ((MainForm) GlobalCache.Instance().MainForm).ServiceStatus.Text = " Hoàn tất ! ";
                        ClientUtility.Log(logger, " Hoan tat!");
                    }
                    }
                    catch (Exception exp)
                    {
                        ClientUtility.Log(logger, exp.Message);
                    }
                }
            IsDoingStockOut = false;
            
        }

        public void NotifyMultiStockInSuccess(Department department, DepartmentStockIn[] stockInList, long id)
        {
            
        }

        public void NotifyStockInFail(Department department, DepartmentStockIn stockIn, long id)
        {
            
        }

        public void NotifyStockOutFail(long sourceId, long destId, long stockId)
        {
            
        }

        public void NotifyInformMessage(long destDeptId, int channel, bool isError, string message)
        {
            
        }
        
        public ServerServiceConsumer()
        {
            IDepartmentStockInLogic deptStockInLogic = (IDepartmentStockInLogic)GlobalUtility.GetObject("AppFrame.Service.IDepartmentStockInLogic");
            DepartmentStockInLogic = deptStockInLogic;
            IDepartmentStockOutLogic deptStockOutLogic = (IDepartmentStockOutLogic)GlobalUtility.GetObject("AppFrame.Service.IDepartmentStockOutLogic");
            DepartmentStockOutLogic = deptStockOutLogic;

            IDepartmentStockInHistoryLogic deptStockInHistoryLogic = (IDepartmentStockInHistoryLogic)GlobalUtility.GetObject("AppFrame.Service.IDepartmentStockInHistoryLogic");
            DepartmentStockInHistoryLogic = deptStockInHistoryLogic;
            
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
                            serverService = new ServerServiceClient(new InstanceContext(this), ClientSetting.ServiceBinding);
                            serverService.JoinDistributingGroup(CurrentDepartment.Get());
                            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Kết nối với dịch vụ.";
                            Thread.Sleep(100);
                            
                        }
                        catch (Exception ex)
                        {
                            //ClientUtility.Log(logger,ex.Message);
                        }
                        
                    }
                    else
                    {
                        try
                        {
                            // Wait until thread is stopped
                            if (!IsDoingStockOut)
                            {
                                ((MainForm) GlobalCache.Instance().MainForm).ServiceStatus.Text =
                                    " Yêu cầu thông tin ... ";
                                //serverService.RequestDepartmentStockOut(CurrentDepartment.Get().DepartmentId);
                                ((MainForm) GlobalCache.Instance().MainForm).ServiceStatus.Text = " Chờ lệnh ... ";
                            }
                            Thread.Sleep(SleepTime);
                        }
                        catch (Exception)
                        {
                            if(serverService.State == CommunicationState.Faulted
                               || serverService.State == CommunicationState.Closed)
                            {
                                connected = false;
                                serverService = null;
                            }
                            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Thất bại ... ";
                            //ClientUtility.Log(logger, ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text);
                            Thread.Sleep(1000 * 3);
                            ((MainForm)GlobalCache.Instance().MainForm).ServiceStatus.Text = " Xử lý lại ... ";
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

        public IDepartmentStockInHistoryLogic DepartmentStockInHistoryLogic
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
