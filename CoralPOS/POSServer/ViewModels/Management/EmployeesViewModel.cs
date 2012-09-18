



using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.DataLayer;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using POSServer.ViewModels.Menu.Management;


namespace POSServer.ViewModels.Management
{
    /// <summary>
    /// 
    /// </summary>
    //[AttachMenuAndMainScreen(typeof(DeptEmpMenuViewModel), typeof(ManagementMainViewModel))]
    [PerRequest]
    public class EmployeesViewModel : PosViewModel
    {

        private IShellViewModel _startViewModel;
        /// <summary>
        /// Initializes a new instance of the <see cref="EmployeesViewModel"/> class.
        /// </summary>
        /// <param name="startViewModel">The start view model.</param>
        public EmployeesViewModel()
        {
            _startViewModel = ShellViewModel.Current;
        }

        #region Fields

        private string _address;
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>The address.</value>
        public string Address
        {
            get
            {
                return _address;
            }
            set
            {
                _address = value;
                NotifyOfPropertyChange(() => Address);
            }
        }

        private string _employeeName;
        /// <summary>
        /// Gets or sets the name of the employee.
        /// </summary>
        /// <value>The name of the employee.</value>
        public string EmployeeName
        {
            get
            {
                return _employeeName;
            }
            set
            {
                _employeeName = value;
                NotifyOfPropertyChange(() => EmployeeName);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string _employeeId;
        /// <summary>
        /// Gets or sets the employee id.
        /// </summary>
        /// <value>The employee id.</value>
        public string EmployeeId
        {
            get
            {
                return _employeeId;
            }
            set
            {
                _employeeId = value;
                NotifyOfPropertyChange(() => EmployeeId);
            }
        }

        private string _cardId;
        /// <summary>
        /// Gets or sets the card id.
        /// </summary>
        /// <value>The card id.</value>
        public string CardId
        {
            get
            {
                return _cardId;
            }
            set
            {
                _cardId = value;
                NotifyOfPropertyChange(() => CardId);
            }
        }

        /// <summary>
        /// Gets or sets the employee info logic.
        /// </summary>
        /// <value>The employee info logic.</value>
        [Autowired]
        public IEmployeeInfoLogic EmployeeInfoLogic { get; set; }
        #endregion

        #region List use to fetch object for view
        #endregion

        #region List of boolean object
        #endregion

        #region List of date object

        private DateTime _startDay;
        /// <summary>
        /// Gets or sets the start day.
        /// </summary>
        /// <value>The start day.</value>
        public DateTime StartDay
        {
            get
            {
                return _startDay;
            }
            set
            {
                _startDay = value;
                NotifyOfPropertyChange(() => StartDay);
            }
        }
        #endregion

        #region List which just using in Data Grid

        private IList _employeeList;
        /// <summary>
        /// Gets or sets the employee list.
        /// </summary>
        /// <value>The employee list.</value>
        public IList EmployeeList
        {
            get
            {
                return _employeeList;
            }
            set
            {
                _employeeList = value;
                NotifyOfPropertyChange(() => EmployeeList);
            }
        }



        /// <summary>
        /// Gets or sets the selected employee.
        /// </summary>
        /// <value>The selected employee.</value>
        public EmployeeInfo SelectedEmployee
        {
            get
            {
                return _selectedEmployee;
            }
            set
            {
                _selectedEmployee = value;
                NotifyOfPropertyChange(() => SelectedEmployee);
            }
        }

        private EmployeeInfo _selectedEmployee;
        #endregion

        #region Methods

        /// <summary>
        /// Helps this instance.
        /// </summary>
        public void Help()
        {

        }

        /// <summary>
        /// Deletes this instance.
        /// </summary>
        public void Delete()
        {

        }


        /// <summary>
        /// Gets a value indicating whether this instance can edit.
        /// </summary>
        /// <value><c>true</c> if this instance can edit; otherwise, <c>false</c>.</value>
        public bool CanEdit
        {
            get
            {
                if(SelectedEmployee!=null && !string.IsNullOrEmpty(SelectedEmployee.EmployeeId))
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Edits this instance.
        /// </summary>
        public void Edit()
        {
            if(SelectedEmployee!=null && !string.IsNullOrEmpty(SelectedEmployee.EmployeeId))
            {
                IsEditMode = true;
                EditEmployee = SelectedEmployee;
                EmployeeName = EditEmployee.EmployeeName;
                Address = EditEmployee.Address;
                StartDay = EditEmployee.Birthday;
                CardId = EditEmployee.ExFld4;
            }
        }

        /// <summary>
        /// Gets or sets the edit employee.
        /// </summary>
        /// <value>The edit employee.</value>
        protected EmployeeInfo EditEmployee { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is edit mode.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if this instance is edit mode; otherwise, <c>false</c>.
        /// </value>
        protected bool IsEditMode { get; set; }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            Flow.End();
        }

        /// <summary>
        /// Creates this instance.
        /// </summary>
        public void Create()
        {
            if (!IsEditMode) // create mode
            {
                EmployeeInfo info = new EmployeeInfo
                                        {
                                            EmployeeName = EmployeeName,
                                            CreateDate = DateTime.Now,
                                            ExFld4 = CardId,
                                            CreateId = "admin",
                                            UpdateDate = DateTime.Now,
                                            UpdateId = "admin",
                                            Birthday = StartDay,
                                            Address = Address
                                        };

                string empId = EmployeeInfoLogic.GenerateEmpId(info.EmployeeName);
                info.EmployeeId = empId;
                info.Barcode = EmployeeInfoLogic.GetNextBarcode();
                EmployeeInfoLogic.Add(info);
            }
            else // edit mode
            {
                EditEmployee.EmployeeName = EmployeeName;
                EditEmployee.UpdateDate = DateTime.Now;
                EditEmployee.UpdateId = "admin";
                EditEmployee.Birthday = StartDay;
                EditEmployee.Address = Address;
                EmployeeInfoLogic.Update(EditEmployee);
            }
            IsEditMode = false;
            MessageBox.Show("Save OK");
            InitContent();
        }

        /// <summary>
        /// Inits the content.
        /// </summary>
        private void InitContent()
        {
            EmployeeName = "";
            CardId = "";
            StartDay = DateTime.Now;
            EmployeeList = new ArrayList();
            IList<EmployeeInfo> list = EmployeeInfoLogic.FindAll(new ObjectCriteria<EmployeeInfo>());
            EmployeeList = list.OrderBy(m => m.EmployeeName).ToList();
            Flow.Session.Put(FlowConstants.SAVE_EMPLOYEE_LIST, EmployeeList);
            SelectedEmployee = new EmployeeInfo();
            if(EmployeeList.Count > 0)
            {
                SelectedEmployee = (EmployeeInfo)EmployeeList[0];
            }
        }

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        protected override void OnInitialize()
        {
            InitContent();
        }

        #endregion



    }
}