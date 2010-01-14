using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Presenter.GoodsIO.DepartmentGoodsIO;
using AppFrame.Utility;
using AppFrame.View.GoodsIO.DepartmentGoodsIO;

namespace AppFrameClient.Presenter.GoodsIO.DepartmentStockData
{
    public class DepartmentCostController : IDepartmentCostController
    {
        private IDepartmentCostCreateView departmentCostCreateView;
        public IDepartmentCostCreateView DepartmentCostCreateView
        {
            get
            {
                return departmentCostCreateView;
            }
            set
            {
                departmentCostCreateView = value;
                departmentCostCreateView.CreateDepartmentCostEvent += new EventHandler<DepartmentCostEventArgs>(departmentCostCreateView_CreateDepartmentCostEvent);
            }
        }

        void departmentCostCreateView_CreateDepartmentCostEvent(object sender, DepartmentCostEventArgs e)
        {
            try
            {
                if (e.CreateCost != null)
                    DepartmentCostLogic.Add(e.CreateCost);
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                e.HasErrors = true;               
                
            }
            

        }

        private IDepartmentCostEditView departmentCostEditView;
        public IDepartmentCostEditView DepartmentCostEditView
        {
            get
            {
                return departmentCostEditView;    
            }
            set
            {
                departmentCostEditView = value;
                departmentCostEditView.EditDepartmentCostEvent += new EventHandler<DepartmentCostEventArgs>(departmentCostEditView_EditDepartmentCostEvent);
            }
        }

        void departmentCostEditView_EditDepartmentCostEvent(object sender, DepartmentCostEventArgs e)
        {
            try
            {
                if (e.CreateCost != null)
                    DepartmentCostLogic.Update(e.UpdateCost);
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                e.HasErrors = true;

            }
        }

        private IDepartmentCostListView departmentCostListView;        
        public IDepartmentCostListView DepartmentCostListView
        {
            get
            {
                return departmentCostListView;                
            }
            set
            {
                departmentCostListView = value;
                departmentCostListView.SearchDepartmentCostEvent += new EventHandler<DepartmentCostEventArgs>(departmentCostListView_SearchDepartmentCostEvent);
            }
        }

        private IDepartmentCostSummaryView departmentCostSummaryView;
        public IDepartmentCostSummaryView DepartmentCostSummaryView
        {
            get
            {
                return departmentCostSummaryView; 
            }
            set
            {
                departmentCostSummaryView.CommitDepartmentCostEvent += new EventHandler<DepartmentCostEventArgs>(departmentCostSummaryView_CommitDepartmentCostEvent);
            }
        }

        void departmentCostSummaryView_CommitDepartmentCostEvent(object sender, DepartmentCostEventArgs e)
        {
            
        }

        void departmentCostListView_SearchDepartmentCostEvent(object sender, DepartmentCostEventArgs e)
        {
           if(e.FromDate == DateTime.MinValue && e.ToDate == DateTime.MinValue)
           {
                ObjectCriteria objectCriteria = new ObjectCriteria();
                objectCriteria.AddBetweenCriteria("DepartmentCostPK.CostDate", DateUtility.ZeroTime(DateTime.Now),
                                                 DateUtility.MaxTime(DateTime.Now));
                objectCriteria.AddEqCriteria("DepartmentCostPK.DepartmentId", CurrentDepartment.Get().DepartmentId);
               IList list = DepartmentCostLogic.FindAll(objectCriteria);
               e.CostList = list;
           }
        }
        public IDepartmentCostLogic DepartmentCostLogic { get; set; }
        public IEmployeeMoneyLogic EmployeeMoneyLogic
        {
            get; set;
        }
    }
}
