using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Presenter.SalePoints;
using AppFrame.Utility;
using AppFrame.View.SalePoints;
using AppFrameClient.Common;
using AppFrameClient.Utility.Mapper;
using AppFrameClient.View.SalePoints;

namespace AppFrameClient.Presenter.SalePoints
{
    public class EmployeeController : IEmployeeController
    {

        private Employee employeeModel;

        #region IEmployeeController<EmployeeEventArgs> Members

        private IEmployeeView employeeView;
        public AppFrame.View.SalePoints.IEmployeeView EmployeeView
        {
            get
            {
                return employeeView;
            }
            set
            {
                employeeView = value;
                employeeView.CloseEmployeeFormEvent += new System.EventHandler<EmployeeEventArgs>(employeeView_CloseEmployeeFormEvent);
                employeeView.HelpEvent += new System.EventHandler<EmployeeEventArgs>(employeeView_HelpEvent);
                employeeView.ResetEmployeeEvent += new System.EventHandler<EmployeeEventArgs>(employeeView_ResetEmployeeEvent);
                employeeView.SaveEmployeeEvent += new System.EventHandler<EmployeeEventArgs>(employeeView_SaveEmployeeEvent);
            }
        }

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
                salePointView.AddEmployeeEvent += new System.EventHandler<EmployeeEventArgs>(salePointView_AddEmployeeEvent);
                salePointView.EditEmployeeEvent += new System.EventHandler<EmployeeEventArgs>(salePointView_EditEmployeeEvent);
            }
        }

        void salePointView_EditEmployeeEvent(object sender, EmployeeEventArgs e)
        {
            EmployeeForm form = GlobalUtility.GetOnlyChildFormObject<EmployeeForm>(GlobalCache.Instance().MainForm,
                                                   FormConstants.EMPLOYEE_FORM);
            EmployeeInfoModel = e.EmployeeInfo;
            form.ModelToForm();
            form.txtHiddenSelectedEmployeeId.Text = e.SelectedEmployee.ToString();

            GlobalUtility.ShowForm(form);
        }

        void salePointView_AddEmployeeEvent(object sender, EmployeeEventArgs e)
        {
            /*EmployeeForm form = GlobalUtility.GetOnlyChildFormObject <EmployeeForm>(GlobalCache.Instance().MainForm,
                                                   FormConstants.EMPLOYEE_FORM);*/
            EmployeeForm form = GlobalUtility.GetFormObject<EmployeeForm>(FormConstants.EMPLOYEE_FORM);
            EmployeeInfoModel = e.EmployeeInfo;
            form.txtDepartmentName.Text = EmployeeInfoModel.Employee.Department.DepartmentName;
            form.ShowDialog(((Form) sender));
            //GlobalUtility.ShowForm(form);
            
        }

        
        
        void employeeView_SaveEmployeeEvent(object sender, EmployeeEventArgs e)
        {
            ResultEventArgs = e;
            ResultEventArgs.EmployeeInfo = EmployeeInfoModel;
            int selectedEmployee = e.SelectedEmployee;
            ResultEventArgs.SelectedEmployee = selectedEmployee;
            if (selectedEmployee == -1)
            {
                EventUtility.fireEvent(CompletedAddEmployeeEvent, this, ResultEventArgs);
            }
            else
            {
                EventUtility.fireEvent(CompletedEditEmployeeEvent, this, ResultEventArgs);    
            }
        }

        void employeeView_ResetEmployeeEvent(object sender, EmployeeEventArgs e)
        {
            EventUtility.fireEvent(CompletedResetEmployeeEvent, this, ResultEventArgs);
        }

        void employeeView_HelpEvent(object sender, EmployeeEventArgs e)
        {
            EventUtility.fireEvent(CompletedHelpEvent, this, ResultEventArgs);
        }

        void employeeView_CloseEmployeeFormEvent(object sender, EmployeeEventArgs e)
        {
            EventUtility.fireEvent(CompletedCloseEmployeeFormEvent,this,ResultEventArgs);
        }
        

        private IEmployeeLogic employeeLogic;
        public AppFrame.Logic.IEmployeeLogic EmployeeLogic
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

        private IEmployeeDetailLogic employeeDetailLogic;
        public AppFrame.Logic.IEmployeeDetailLogic EmployeeDetailLogic
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

        public event System.EventHandler<EmployeeEventArgs> CompletedSaveEmployeeEvent;

        public event System.EventHandler<EmployeeEventArgs> CompletedResetEmployeeEvent;

        public event System.EventHandler<EmployeeEventArgs> CompletedCloseEmployeeFormEvent;

        public event System.EventHandler<EmployeeEventArgs> CompletedHelpEvent;

        #endregion

        #region IBaseController<EmployeeEventArgs> Members

        private EmployeeEventArgs resultEventArgs;
        public EmployeeEventArgs ResultEventArgs
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

        public Employee EmployeeModel
        {
            get { return employeeModel; }
            set { employeeModel = value; }
        }

        #endregion



        #region IEmployeeController Members


        public event System.EventHandler<EmployeeEventArgs> CompletedAddEmployeeEvent;

        #endregion

        #region IEmployeeController Members

        private EmployeeInfo employeeInfo;
        public EmployeeInfo EmployeeInfoModel
        {
            get
            {
                return employeeInfo;
            }
            set
            {
                employeeInfo = value;
            }
        }

        #endregion

        #region IEmployeeController Members


        public event System.EventHandler<EmployeeEventArgs> CompletedEditEmployeeEvent;

        #endregion
    }
}