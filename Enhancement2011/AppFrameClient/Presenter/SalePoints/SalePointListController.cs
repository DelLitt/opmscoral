using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using AppFrame;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter.SalePoints;
using AppFrame.Utility;
using AppFrame.View.SalePoints;
using AppFrameClient.Common;
using AppFrameClient.View.SalePoints;
using NHibernate;

namespace AppFrameClient.Presenter.SalePoints
{
    public class SalePointListController : ISalePointListController
    {

        #region ISalePointListController Members

        private ISalePointListView salePointListView;
        public AppFrame.View.SalePoints.ISalePointListView SalePointListView
        {
            get
            {
                return salePointListView;
            }
            set
            {
                salePointListView = value;
                salePointListView.AddSalePointEvent += new EventHandler<SalePointListEventArgs>(salePointListView_AddSalePointEvent);
                salePointListView.CheckAllEvent += new EventHandler<SalePointListEventArgs>(salePointListView_CheckAllEvent);
                salePointListView.CloseSalePointListFormEvent += new EventHandler<SalePointListEventArgs>(salePointListView_CloseSalePointListFormEvent);
                salePointListView.DeleteSalePointEvent += new EventHandler<SalePointListEventArgs>(salePointListView_DeleteSalePointEvent);
                salePointListView.EditSalePointEvent += new EventHandler<SalePointListEventArgs>(salePointListView_EditSalePointEvent);
                salePointListView.HelpEvent += new EventHandler<SalePointListEventArgs>(salePointListView_HelpEvent);
                salePointListView.LoadDepartmentsEvent += new EventHandler<SalePointListEventArgs>(salePointListView_LoadDepartmentsEvent);
            }
        }

        void salePointListView_LoadDepartmentsEvent(object sender, SalePointListEventArgs e)
        {
            ObjectCriteria criteria = new ObjectCriteria();
            criteria.AddEqCriteria("DelFlg",(long)0);
            IList list = DepartmentLogic.FindAll(criteria);
            SalePointListEventArgs eventArgs = new SalePointListEventArgs();
            eventArgs.DepartmentList = ObjectConverter.ConvertGenericList<Department>(list);
            EventUtility.fireEvent(CompletedLoadDepartmentsEvent,this,eventArgs);
        }

        void salePointListView_HelpEvent(object sender, SalePointListEventArgs e)
        {
            throw new NotImplementedException();
        }

        void salePointListView_EditSalePointEvent(object sender, SalePointListEventArgs e)
        {
            SalePointForm form = GlobalUtility.GetFormObject<SalePointForm>(FormConstants.SALEPOINT_FORM);
            
            //e.SelectedDepartment = this.LoadDepartment(e.SelectedDepartment);
            form.SalePointController.DepartmentModel = e.SelectedDepartment; 
            e.SelectedDepartment = null;
            form.Status = ViewStatus.EDIT;
            
            form.ModelToForm();
            
            form.ShowDialog((Form) sender);
            //GlobalUtility.ShowForm(form);
            //e.EditedDepartment = selectedDepartment;
        }

        private Department LoadDepartment(Department department)
        {
            return DepartmentLogic.LoadDepartment(department);            
        }

        void salePointListView_DeleteSalePointEvent(object sender, SalePointListEventArgs e)
        {
            foreach (Department department in DepartmentList)
            {
                if(department.DelFlg == 1)
                {
                    DepartmentLogic.Update(department);
                }
            }
            EventUtility.fireEvent(CompletedDeleteSalePointEvent,this,new SalePointListEventArgs());
        }

        void salePointListView_CloseSalePointListFormEvent(object sender, SalePointListEventArgs e)
        {
            throw new NotImplementedException();
        }

        void salePointListView_CheckAllEvent(object sender, SalePointListEventArgs e)
        {
            throw new NotImplementedException();
        }

        void salePointListView_AddSalePointEvent(object sender, SalePointListEventArgs e)
        {
            SalePointForm form = GlobalUtility.GetOnlyChildFormObject<SalePointForm>(GlobalCache.Instance().MainForm,
                                                   FormConstants.SALEPOINT_FORM);
            //SalePointForm form = GlobalUtility.GetFormObject<SalePointForm>(FormConstants.SALEPOINT_FORM);
            Department department = new Department();

            form.SalePointController.DepartmentModel = department;
            form.Status = ViewStatus.ADD;

            //form.ShowDialog((Form) sender);
            //form.ModelToForm();
            GlobalUtility.ShowForm(form);
            //form.ShowDialog();
        }

        public event EventHandler<SalePointListEventArgs> CompletedHelpEvent;

        public event EventHandler<SalePointListEventArgs> CompletedCheckAllEvent;

        public event EventHandler<SalePointListEventArgs> CompletedUncheckAllEvent;

        public event EventHandler<SalePointListEventArgs> CompletedAddSalePointEvent;

        public event EventHandler<SalePointListEventArgs> CompletedEditSalePointEvent;

        public event EventHandler<SalePointListEventArgs> CompletedDeleteSalePointEvent;

        public event EventHandler<SalePointListEventArgs> CompletedCloseSalePointListFormEvent;
        
        public event EventHandler<SalePointListEventArgs> CompletedLoadDepartmentsEvent;

        #endregion

        #region IBaseController<SalePointListEventArgs> Members

        private SalePointListEventArgs salePointListEventArgs;
        public SalePointListEventArgs ResultEventArgs
        {
            get
            {
                return salePointListEventArgs;
            }
            set
            {
                salePointListEventArgs = value;
            }
        }

        #endregion

        #region ISalePointListController Members

        private IList<Department> departmentList;
        public IList<AppFrame.Model.Department> DepartmentList
        {
            get
            {
                return departmentList;
            }
            set
            {
                departmentList = value;
            }
        }

        #endregion

        #region ISalePointListController Members

        private IDepartmentLogic departmentLogic;
        public AppFrame.Logic.IDepartmentLogic DepartmentLogic
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

        #endregion
        
    }
}
