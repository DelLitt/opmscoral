using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AppFrame;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter.Report;
using AppFrame.Presenter.SalePoints;

namespace AppFrameClient.Presenter.Report
{
    public class ReportStockOutController : IReportStockOutController
    {
        #region IReportStockOutController Members


        public AppFrame.Logic.IDepartmentStockInLogic DepartmentStockInLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IDepartmentStockInDetailLogic DepartmentStockInDetailLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IDepartmentLogic DepartmentLogic
        {
            get;set;
            
        }

        #endregion

        #region IReportStockOutController Members

        private AppFrame.View.Reports.IStockOutReportView mainStockOutReportView;
        public AppFrame.View.Reports.IStockOutReportView MainStockOutReportView
        {
            get
            {
                return mainStockOutReportView;
            }
            set
            {
                mainStockOutReportView = value;
                mainStockOutReportView.LoadStockOutsEvent += new EventHandler<ReportStockOutEventArgs>(mainStockOutReportView_LoadStockOutsEvent);
            }
        }

        void mainStockOutReportView_LoadStockOutsEvent(object sender, ReportStockOutEventArgs e)
        {
            IList list = StockOutLogic.FindStockOut(e.ReportDateStockOutParam.FromDate, e.ReportDateStockOutParam.ToDate);
            if (list != null)
            {
                IList parentList = new ArrayList();
                for (int i = 0; i < list.Count; i++)
                {
                    IList childList = new ArrayList();
                    childList.Add(((IList)list[i])[0]);
                    childList.Add(((IList)list[i])[1]);
                    childList.Add(((IList)list[i])[2]);
                    long departmentId = (long) ((IList) list[i])[2];
                    Department dep = DepartmentLogic.FindById(departmentId);
                    childList.Add(dep);
                    parentList.Add(childList);
                }
                e.ResultStockOutList = parentList;
            }
        }

        public AppFrame.Logic.IDepartmentStockOutLogic DepartmentStockOutLogic
        {
            get;set;
        }

        public AppFrame.Logic.IDepartmentStockOutDetailLogic DepartmentStockOutDetailLogic
        {
            get;set;
        }

        public AppFrame.Logic.IStockOutLogic StockOutLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IStockOutDetailLogic StockOutDetailLogic
        {
            get;set;
        }

        #endregion

        #region IReportStockOutController Members

        AppFrame.View.GoodsIO.IDepartmentStockOutReportView departmentStockOutReportView;
        public AppFrame.View.GoodsIO.IDepartmentStockOutReportView DepartmentStockOutReportView
        {
            get
            {
                return departmentStockOutReportView;
            }
            set
            {
                departmentStockOutReportView = value;
                departmentStockOutReportView.LoadDepartmentStockOutsEvent += new EventHandler<ReportStockOutEventArgs>(departmentStockOutReportView_LoadDepartmentStockOutsEvent);
                departmentStockOutReportView.ConfirmStockOutEvent += new EventHandler<ReportStockOutEventArgs>(departmentStockOutReportView_ConfirmStockOutEvent);
                departmentStockOutReportView.DenyStockOutEvent += new EventHandler<ReportStockOutEventArgs>(departmentStockOutReportView_DenyStockOutEvent);    
            }
        }

        void departmentStockOutReportView_DenyStockOutEvent(object sender, ReportStockOutEventArgs e)
        {
            IList list = e.DenyDepartmentStockOutList;
            foreach (DepartmentStockOut departmentStockOut in list)
            {
                foreach (DepartmentStockOutDetail detail in departmentStockOut.DepartmentStockOutDetails)
                {
                    ObjectCriteria criteria = new ObjectCriteria();
                    criteria.AddEqCriteria("Product.ProductId", detail.Product.ProductId);
                    IList productList = StockLogic.FindAll(criteria);
                    if (productList != null)
                    {
                        Stock currStock = (Stock)productList[0];
                        currStock.Quantity += detail.GoodQuantity;

                        ObjectCriteria defectCriteria = new ObjectCriteria();
                        defectCriteria.AddEqCriteria("Product.ProductId", detail.Product.ProductId);
                        defectCriteria.AddEqCriteria("Stock.StockId", currStock.StockId);
                        IList defectList = StockDefectLogic.FindAll(defectCriteria);
                        if(defectList!=null)
                        {
                            if (defectList.Count > 0)
                            {
                                StockDefect currDefect = (StockDefect) defectList[0];
                                currDefect.GoodCount = currStock.Quantity;
                                currDefect.ErrorCount = currDefect.ErrorCount+ (int) detail.ErrorQuantity;
                                currDefect.DamageCount = currDefect.DamageCount + (int) detail.DamageQuantity;

                                currDefect.Quantity = currDefect.GoodCount + currDefect.ErrorCount +
                                                      currDefect.DamageCount +
                                                      currDefect.UnconfirmCount;
                                StockDefectLogic.Update(currDefect);
                            }
                            else
                            {
                                long maxId = StockDefectLogic.FindMaxStockDefectId();
                                maxId = maxId + 1;

                                StockDefect stockDefect = new StockDefect();
                                stockDefect.Product = detail.Product;
                                stockDefect.ProductMaster = currStock.ProductMaster;

                                stockDefect.Description = departmentStockOut.DefectStatus.DefectStatusName;
                                stockDefect.Stock = currStock;

                                stockDefect.GoodCount = currStock.Quantity;
                                stockDefect.ErrorCount = (int)detail.ErrorQuantity;
                                stockDefect.DamageCount = (int)detail.DamageQuantity;
                                stockDefect.Quantity = stockDefect.GoodCount + stockDefect.ErrorCount +
                                                      stockDefect.DamageCount +
                                                      stockDefect.UnconfirmCount;

                                stockDefect.CreateDate = DateTime.Now;
                                stockDefect.CreateId = ClientInfo.getInstance().LoggedUser.Name;
                                stockDefect.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
                                stockDefect.UpdateDate = DateTime.Now;
                                stockDefect.DelFlg = 0;
                                

                                stockDefect.StockDefectId = maxId;

                                StockDefectLogic.Add(stockDefect);
                            }
                        }
                        StockLogic.Update(currStock);
                        MessageBox.Show(" Lưu thành công !");
                        e.HasErrors = false;
                        
                    }
                    else // error
                    {
                        MessageBox.Show(" Không có mã vạch trong kho, đề nghị kiểm tra lại");
                        e.HasErrors = true;
                        return;
                    }

                }
            }
        }

        void departmentStockOutReportView_ConfirmStockOutEvent(object sender, ReportStockOutEventArgs e)
        {
            
        }

        void departmentStockOutReportView_LoadDepartmentStockOutsEvent(object sender, ReportStockOutEventArgs e)
        {
            IList list = DepartmentStockOutLogic.FindStockOut(e.ReportDateStockOutParam.FromDate, e.ReportDateStockOutParam.ToDate);
            if (list != null)
            {
                IList parentList = new ArrayList();
                for (int i = 0; i < list.Count; i++)
                {
                    IList childList = new ArrayList();
                    childList.Add(((IList)list[i])[0]);
                    childList.Add(((IList)list[i])[1]);
                    childList.Add(((IList)list[i])[2]);
                    long departmentId = (long)((IList)list[i])[2];
                    Department dep = DepartmentLogic.FindById(departmentId);
                    childList.Add(dep);
                    parentList.Add(childList);
                }
                e.ResultStockOutList = parentList;
            }            
        }

        #endregion

        #region IReportStockOutController Members


        public AppFrame.Logic.IStockLogic StockLogic
        {
            get;set;
            
        }

        public AppFrame.Logic.IStockDefectLogic StockDefectLogic
        {
            get;set;
        }

        #endregion
    }
}
