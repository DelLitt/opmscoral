using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter.SalePoints;
using AppFrame.Utility;
using AppFrame.View.SalePoints;
using AppFrameClient.Common;
using AppFrameClient.View.SalePoints;

namespace AppFrameClient.Presenter.SalePoints
{
    public class SalePointController  : ISalePointController
    {

        private Department departmentModel;

        #region ISalePointController Members

        private ISalePointView salePointView;
        public ISalePointView SalePointView
        {
            get
            {
                return salePointView;
            }
            set
            {
                salePointView = value;
                salePointView.SaveDepartmentEvent += new EventHandler<SalePointEventArgs>(salePointView_SaveDepartmentEvent);
            }
        }

        void salePointView_SaveDepartmentEvent(object sender, SalePointEventArgs e)
        {
            try
            {
                //DepartmentModel = e.Department;
                if (departmentModel.DepartmentId == 0)
                {
                    DepartmentLogic.Add(DepartmentModel);
                    DepartmentModel = CreateNewDepartment();
                }
                else
                {
                    DepartmentLogic.Update(DepartmentModel);
                }
                e.HasErrors = false;
            }
            catch(Exception ex)
            {
                e.HasErrors = true;
            }

        }

        private Department CreateNewDepartment()
        {
            Department department = new Department();
            department.StartDate = DateTime.Now;
            department.Active = 0;
            department.CreateId = ClientInfo.getInstance().LoggedUser.Name;
            department.UpdateId = ClientInfo.getInstance().LoggedUser.Name;
            return department;
        }

        
        private IEmployeeLogic employeeLogic;
        public IEmployeeLogic EmployeeLogic
        {
            get
            {
                return employeeLogic;
            }
            set
            {
                employeeLogic = value;
            }
        }

        private IDepartmentLogic departmentLogic;
        public IDepartmentLogic DepartmentLogic
        {
            get
            {
                return departmentLogic;
            }
            set
            {
                departmentLogic = value;
            }
        }

        private IEmployeeDetailLogic employeeDetailLogic;
        public IEmployeeDetailLogic EmployeeDetailLogic
        {
            get
            {
                return employeeDetailLogic;
            }
            set
            {
                employeeDetailLogic = value;
            }
        }

        public event EventHandler<SalePointEventArgs> CompletedCheckAllGridEvent;

        public event EventHandler<SalePointEventArgs> CompletedUncheckAllGridEvent;

        public event EventHandler<SalePointEventArgs> CompletedAddEmployeeEvent;

        public event EventHandler<SalePointEventArgs> CompletedEditEmployeeEvent;

        public event EventHandler<SalePointEventArgs> CompletedDeleteEmployeeEvent;

        public event EventHandler<SalePointEventArgs> CompletedHelpEvent;

        #endregion

        #region IBaseController<SalePointEventArgs> Members

        private SalePointEventArgs resultEventArgs;
        public SalePointEventArgs ResultEventArgs
        {
            get
            {
                return resultEventArgs;
            }
            set
            {
                resultEventArgs = value;
            }
        }

        public Department DepartmentModel
        {
            get { return departmentModel; }
            set { departmentModel = value; }
        }

        private ISalePointSubStockView salePointSubStockView;
        public ISalePointSubStockView SalePointSubStockView
        {
            get
            {
                return salePointSubStockView;
            }
            set
            {
                salePointSubStockView = value;
                salePointSubStockView.LoadDepartmentsEvent += new EventHandler<SalePointEventArgs>(salePointSubStockView_LoadDepartmentsEvent);
                salePointSubStockView.SaveDepartmentSubStockEvent += new EventHandler<SalePointEventArgs>(salePointSubStockView_SaveDepartmentSubStockEvent);
            }
        }

        void salePointSubStockView_SaveDepartmentSubStockEvent(object sender, SalePointEventArgs e)
        {
            if(e.SavingSubStock!= null)
            {
                DepartmentLogic.AddSubStock(e.SavingSubStock);
            }
        }

        void salePointSubStockView_LoadDepartmentsEvent(object sender, SalePointEventArgs e)
        {
            ObjectCriteria criteria = new ObjectCriteria();
            criteria.AddLesserCriteria("DepartmentId", (long)10000);
            IList departmentList = DepartmentLogic.FindAll(criteria);
            e.DepartmentList = departmentList;
        }

        #endregion


        #region ISalePointController Members


        public event EventHandler<SalePointEventArgs> CompletedAddDepartmentEvent;

        #endregion
        

        #region ISalePointController Members


        public event EventHandler<SalePointEventArgs> CompletedEditDepartmentEvent;

        #endregion

        #region ISalePointController Members


        public void EndEditDepartment()
        {
            EventUtility.fireEvent(CompletedEditDepartmentEvent, this, new SalePointEventArgs());
        }

        #endregion
    }
}