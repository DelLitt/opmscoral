



using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using AppFrame.Base;
using AppFrame.CustomAttributes;
using AppFrame.DataLayer;
using AppFrame.Utility;
using Caliburn.Core;
using Caliburn.Core.IoC;
using Caliburn.PresentationFramework.ApplicationModel;
using Caliburn.PresentationFramework.Filters;
using Caliburn.PresentationFramework.Screens;
using CoralPOS.Models;
using POSServer.BusinessLogic.Common;
using POSServer.BusinessLogic.Implement;
using System.Linq;
using System.Linq.Expressions;
using POSServer.ViewModels.Menu.Management;


namespace POSServer.ViewModels.Management
{
    [AttachMenuAndMainScreen(typeof(IDeptEmpMenuViewModel), typeof(IManagementMainViewModel))]
    public class EmployeesViewModel : PosViewModel, IEmployeesViewModel
    {

        private IShellViewModel _startViewModel;
        public EmployeesViewModel(IShellViewModel startViewModel)
        {
            _startViewModel = startViewModel;
        }

        #region Fields

        private string _address;
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

        private string _employeeId;
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

        public IEmployeeInfoLogic EmployeeInfoLogic { get; set; }
        #endregion

        #region List use to fetch object for view
        #endregion

        #region List of boolean object
        #endregion

        #region List of date object

        private DateTime _startDay;
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

        public void Help()
        {

        }

        public void Delete()
        {

        }


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

        protected EmployeeInfo EditEmployee { get; set; }

        protected bool IsEditMode { get; set; }

        public void Stop()
        {
            Flow.End();
        }

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

        public override void Initialize()
        {
            InitContent();
        }

        #endregion



    }
}