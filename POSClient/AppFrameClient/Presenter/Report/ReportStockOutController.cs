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
using AppFrameClient.Utility.Mapper;

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
            StockOutMapper mapper = new StockOutMapper();
            StockOutDetailMapper detailMapper = new StockOutDetailMapper();
            DeptRetProdStockInMapper drpsiMapper = new DeptRetProdStockInMapper();
            DeptRetProdStockInDetailMapper drpsiDetMapper = new DeptRetProdStockInDetailMapper();

            foreach (DepartmentStockOut departmentStockOut in list)
            {
                // ++ Add code for add an empty stock in : 20090906

                StockIn stockIn = drpsiMapper.Convert(departmentStockOut);
                stockIn.StockInDate = DateTime.Now;
                stockIn.StockInType = 0; // stock in for stock out to manufacturers
                stockIn.StockInDetails = new ArrayList();
                stockIn.NotUpdateMainStock = true;
                foreach (DepartmentStockOutDetail detail in departmentStockOut.DepartmentStockOutDetails)
                {
                    ObjectCriteria criteria = new ObjectCriteria();
                    criteria.AddEqCriteria("Product.ProductId", detail.Product.ProductId);
                    IList productList = StockLogic.FindAll(criteria);
                    if (productList != null)
                    {
                        Stock currStock = (Stock)productList[0];
                        currStock.GoodQuantity += detail.GoodQuantity;
                        currStock.Quantity += detail.GoodQuantity;
                        currStock.ErrorQuantity += detail.ErrorQuantity;
                        currStock.Quantity += detail.ErrorQuantity;
                        currStock.LostQuantity += detail.LostQuantity;
                        currStock.LostQuantity += detail.LostQuantity;
                        currStock.DamageQuantity += detail.DamageQuantity;
                        currStock.DamageQuantity += detail.DamageQuantity;
                        StockLogic.Update(currStock);

                        StockInDetail detailStockIn = drpsiDetMapper.Convert(detail);
                        stockIn.StockInDetails.Add(detailStockIn);
                        
                    }
                    else // error
                    {
                        MessageBox.Show(" Không có mã vạch trong kho, đề nghị kiểm tra lại");
                        e.HasErrors = true;
                        return;
                    }

                }

                departmentStockOut.ConfirmFlg = 2;
                DepartmentStockOutLogic.Update(departmentStockOut);

                if(stockIn.StockInDetails.Count > 0 )
                {
                    StockInLogic.AddForStockOutToProducer(stockIn);
                }
                // -- Add code for add an empty stock in : 20090906
            }
            MessageBox.Show(" Lưu thành công !");
            e.HasErrors = false;
        }

        void departmentStockOutReportView_ConfirmStockOutEvent(object sender, ReportStockOutEventArgs e)
        {
            IList list = e.ConfirmDepartmentStockOutList;

            StockOutMapper mapper = new StockOutMapper();
            StockOutDetailMapper detailMapper = new StockOutDetailMapper();
            DeptRetProdStockInMapper drpsiMapper = new DeptRetProdStockInMapper();
            DeptRetProdStockInDetailMapper drpsiDetMapper = new DeptRetProdStockInDetailMapper();
            foreach (DepartmentStockOut departmentStockOut in list)
            {
                
                StockIn stockIn = drpsiMapper.Convert(departmentStockOut);
                stockIn.StockInDate = DateTime.Now;
                stockIn.StockInType = 3; // stock in for stock out to manufacturers
                stockIn.StockInDetails = new ArrayList();
                stockIn.NotUpdateMainStock = true;

                StockOut stockOut = mapper.Convert(departmentStockOut);
                stockOut.NotUpdateMainStock = true;
                stockOut.StockOutDate = DateTime.Now;

                if(departmentStockOut.OtherDepartmentId > 0 )
                {
                    stockOut.DefectStatus = new StockDefectStatus
                                                {
                                                    DefectStatusId = 0,
                                                    DefectStatusName = "Xuất hàng bình thường"
                                                };
                    stockOut.DepartmentId = departmentStockOut.OtherDepartmentId;
                    
                }
                IList detlist = new ArrayList();
                foreach (DepartmentStockOutDetail detail in departmentStockOut.DepartmentStockOutDetails)
                {
                    StockInDetail detailStockIn = drpsiDetMapper.Convert(detail);
                    stockIn.StockInDetails.Add(detailStockIn);
                    StockOutDetail detailStockOut = detailMapper.Convert(detail);
                    if(departmentStockOut.OtherDepartmentId > 0 )
                    {
                        detailStockOut.DefectStatus = new StockDefectStatus
                                                {
                                                    DefectStatusId = 0,
                                                    DefectStatusName = "Xuất hàng bình thường"
                                                };
                        
                    }
                    detlist.Add(detailStockOut);                                           
                }
                stockOut.StockOutDetails = detlist;
                StockInLogic.AddForStockOutToProducer(stockIn);
                StockOutLogic.Add(stockOut);
                departmentStockOut.ConfirmFlg = 0;
                departmentStockOut.StockOutDate = DateTime.Now;
                DepartmentStockOutLogic.Update(departmentStockOut);
            }
            MessageBox.Show(" Lưu thành công !");
            e.HasErrors = false;
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
                    childList.Add(((IList)list[i])[0]); // stock out
                    childList.Add(((IList)list[i])[1]); // quantity
                    childList.Add(((IList)list[i])[2]); // departmentid
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
        public AppFrame.Logic.IStockInLogic StockInLogic
        {
            get;
            set;

        }

        #endregion
    }
}
