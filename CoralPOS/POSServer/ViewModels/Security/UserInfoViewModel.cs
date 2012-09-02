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
using POSServer.ViewModels.Management;
using POSServer.ViewModels.Menu.Management;


namespace POSServer.ViewModels.Security
{
    /// <summary>
    /// 
    /// </summary>
    [AttachMenuAndMainScreen(typeof(DeptEmpMenuViewModel), typeof(ManagementMainViewModel))]
    public class UserInfoViewModel : PosViewModel
    {

        private IShellViewModel _startViewModel;
        public UserInfoViewModel()
        {
            _startViewModel = ShellViewModel.Current;
        }

        #region Fields

        private string _username;
        public string Username
        {
            get
            {
                return _username;
            }
            set
            {
                _username = value;
                NotifyOfPropertyChange(() => Username);
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }

        private EmployeeInfo _selectedEmployeeInfo;
        public EmployeeInfo SelectedEmployeeInfo
        {
            get { return _selectedEmployeeInfo; }
            set
            {
                _selectedEmployeeInfo = value;
                NotifyOfPropertyChange(() => SelectedEmployeeInfo);
            }
        }

        private UserInfo _selectedUserInfo;
        public UserInfo SelectedUserInfo
        {
            get { return _selectedUserInfo; }
            set
            {
                _selectedUserInfo = value;
                NotifyOfPropertyChange(() => SelectedUserInfo);
            }
        }

        private Role _selectedRole;
        public Role SelectedRole
        {
            get { return _selectedRole; }
            set
            {
                _selectedRole = value;
                NotifyOfPropertyChange(() => SelectedRole);
            }
        }

        public IUserInfoLogic UserInfoLogic { get; set; }
        public IEmployeeInfoLogic EmployeeInfoLogic { get; set; }
        public IUserRoleLogic UserRoleLogic { get; set; }
        public IRoleLogic RoleLogic { get; set; }
        #endregion

        #region List use to fetch object for view

        private IList _rightList;
        public IList RightList
        {
            get
            {
                return _rightList;
            }
            set
            {
                _rightList = value;
                NotifyOfPropertyChange(() => RightList);
            }
        }
        #endregion

        #region List of boolean object

        private bool _showDeletedAccount;
        public bool ShowDeletedAccount
        {
            get
            {
                return _showDeletedAccount;
            }
            set
            {
                _showDeletedAccount = value;
                NotifyOfPropertyChange(() => ShowDeletedAccount);
            }
        }

        private bool _isShowPassword;
        public bool IsShowPassword
        {
            get
            {
                return _isShowPassword;
            }
            set
            {
                _isShowPassword = value;
                NotifyOfPropertyChange(() => IsShowPassword);
            }
        }
        #endregion

        #region List of date object
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

        private IList _userAccountList;
        private bool _isCreate;
        private bool _isEdit;
        private bool _enableEditUsername;

        public IList UserAccountList
        {
            get
            {
                return _userAccountList;
            }
            set
            {
                _userAccountList = value;
                NotifyOfPropertyChange(() => UserAccountList);
            }
        }



        #endregion

        #region Methods

        /// <summary>
        /// Helps this instance.
        /// </summary>
        public void Help()
        {

        }


        public bool CanSave
        {
            get
            {
                if (IsEdit) return true;
                else return false;
            }
        }

        public bool IsEdit
        {
            get
            {
                return _isEdit;
            }
            set
            {
                _isEdit = value;
                if (_isEdit)
                {
                    if (Flow.Session.Get(FlowConstants.EDIT_USER_INFO) != null)
                        EnableEditUsername = false;
                    else
                        EnableEditUsername = true;
                }

                NotifyOfPropertyChange(() => IsEdit);
            }
        }

        public bool EnableEditUsername
        {
            get
            {
                return _enableEditUsername;
            }
            set
            {
                _enableEditUsername = value;
                NotifyOfPropertyChange(() => EnableEditUsername);
            }
        }

        public bool IsCreate
        {
            get
            {
                return _isCreate;
            }
            set
            {
                _isCreate = value;
                NotifyOfPropertyChange(() => IsCreate);
            }
        }



        /// <summary>
        /// Saves this instance.
        /// </summary>
        //[Dependencies("IsEdit")]
        public void Save()
        {
            var editUserInfo = Flow.Session.Get(FlowConstants.EDIT_USER_INFO);
            if (editUserInfo == null) // create new
            {
                UserInfo info = new UserInfo
                {
                    Username = Username,
                    Password = Password,
                    Deleted = 0,
                    DepartmentId = 0,
                    Suspended = 0,
                };

                var attachedEmployeeInfo = Flow.Session.Get(FlowConstants.ATTACHED_EMPLOYEE_INFO);
                if (attachedEmployeeInfo != null) // create user from employee info
                {
                    info.EmployeeId = (attachedEmployeeInfo as EmployeeInfo).EmployeeId;
                }


                // add user role
                UserRole userRole = new UserRole
                                        {
                                            Role = SelectedRole,
                                            UserInfo = info,
                                            Userid = Username
                                        };
                

                // database processing
                UserInfoLogic.Add(info);
                UserRoleLogic.Add(userRole);

            }
            else // edit user info
            {
                UserInfo info = editUserInfo as UserInfo;
                UserRole role = Flow.Session.Get(FlowConstants.EDIT_USER_ROLE) as UserRole;

                // check role

                // set value
                UserRole userRole = new UserRole
                {
                    Role = SelectedRole,
                    UserInfo = info,
                    Userid = Username
                };
                
                info.Password = Password;

                // do save
                UserInfoLogic.Update(info);
                UserRoleLogic.Update(userRole);
            }

            // cleanning
            IsEdit = false;
            //EnableEditUsername = false;
            MessageBox.Show("OK!");
            InitContent();
        }

        /// <summary>
        /// Stops this instance.
        /// </summary>
        public void Stop()
        {
            Flow.End();
        }

        /// <summary>
        /// Cancels this instance.
        /// </summary>
        public void Cancel()
        {
            // clear sesssion
            Flow.Session.Clear();
            Flow.IsRepeated = true;
            Flow.End();
        }

        /// <summary>
        /// Creates the employee account.
        /// </summary>
        public void CreateEmployeeAccount()
        {
            Flow.Session.Clear();
            if (SelectedEmployeeInfo != null)
            {
                Flow.Session.Put(FlowConstants.ATTACHED_EMPLOYEE_INFO, SelectedEmployeeInfo);
                Username = SelectedEmployeeInfo.EmployeeId.ToLower();
                Password = "1234";
                //EnableEditUsername = true;
                IsEdit = true;
            }
        }

        /// <summary>
        /// Creates the normal account.
        /// </summary>
        public void CreateNormalAccount()
        {
            Flow.Session.Clear();
            Username = "username";
            Password = "1234";
            //EnableEditUsername = true;
            IsEdit = true;
        }

        /// <summary>
        /// Edits the user info.
        /// </summary>
        public void EditUserInfo()
        {

            if (SelectedUserInfo != null)
            {
                Flow.Session.Put(FlowConstants.EDIT_USER_INFO, SelectedUserInfo);
                Username = SelectedUserInfo.Username;
                Password = SelectedUserInfo.Password;
                // select approriately userrole

                UserRole role = UserRoleLogic.FindRole(SelectedUserInfo.Username);
                Flow.Session.Put(FlowConstants.EDIT_USER_ROLE, role);
                SelectedRole = (RightList as IList<Role>).Where(m => m.Id == role.Role.Id).FirstOrDefault();
                //EnableEditUsername = false;
                IsEdit = true;
                
            }
        }

        /// <summary>
        /// Called when [initialize].
        /// </summary>
        protected override void OnInitialize()
        {
            InitContent();

        }

        private void InitContent()
        {
            Flow.Session.Clear();
            Username = "";
            Password = "";
            /*SelectedUserInfo = new UserInfo();
            SelectedEmployeeInfo = new EmployeeInfo();
            SelectedRole = new Role();*/
            var employeeList = EmployeeInfoLogic.FindAll(new ObjectCriteria<EmployeeInfo>()) as IList;
            EmployeeList = employeeList;
            var userAccountList = UserInfoLogic.FindAll(new ObjectCriteria<UserInfo>()) as IList;
            UserAccountList = userAccountList;
            var rightList = RoleLogic.FindAll(new ObjectCriteria<Role>()) as IList;
            RightList = rightList;
            if (employeeList.Count > 0) SelectedEmployeeInfo = employeeList[0] as EmployeeInfo;
            if (userAccountList.Count > 0) SelectedUserInfo = userAccountList[0] as UserInfo;
            if (rightList.Count > 0) SelectedRole = rightList[0] as Role;

            //EnableEditUsername = false;
            IsEdit = false;
        }

        #endregion



    }
}