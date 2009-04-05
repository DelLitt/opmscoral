using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.Collection;
using AppFrame.Common;
using AppFrame.Exceptions;
using AppFrame.Model;
using AppFrame.Presenter;
using AppFrame.Utility;
using AppFrame.View;

namespace AppFrameClient.View
{
    public partial class SecuritySettingsForm : BaseForm, ISecurityView
    {
        private LoginModelCollection loginList;
        private LoginModel SaveModel;
        public SecuritySettingsForm()
        {
            InitializeComponent();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #region ISecurityView Members

        AppFrame.Presenter.ISecurityController securityController;
        public AppFrame.Presenter.ISecurityController SecurityController
        {
            get
            {
                return securityController;
            }
            set
            {
                securityController = value;
                securityController.SecurityView = this;
            }
        }

        public event EventHandler<AppFrame.Presenter.SecurityEventArgs> InitSecuritySettingsEvent;

        public event EventHandler<AppFrame.Presenter.SecurityEventArgs> SaveUserEvent;

        public event EventHandler<AppFrame.Presenter.SecurityEventArgs> EditUserEvent;

        #endregion

        private void SecuritySettings_Load(object sender, EventArgs e)
        {
            lstEmployee.Items.Clear();
            SecurityEventArgs eventArgs = new SecurityEventArgs();
            EventUtility.fireEvent(InitSecuritySettingsEvent, this, eventArgs);
            IList departmentList = eventArgs.departmentList;
            bdsDepartment.DataSource = departmentList;
            bdsDepartment.ResetBindings(true);
            cboDepartment.DisplayMember = "DepartmentName";
            cboDepartment.Refresh();
            cboDepartment.Invalidate();

            lstEmployee.Items.Clear();
            if (eventArgs.employees != null && eventArgs.employees.Count > 0)
            {
                foreach (EmployeeInfo employeeInfo in eventArgs.employees)
                {
                    ListViewItem item =
                        new ListViewItem(new string[] {employeeInfo.EmployeePK.EmployeeId, employeeInfo.EmployeeName});
                    lstEmployee.Items.Add(item);
                }
            }


            loginList = new LoginModelCollection(bdsUserInfo);
            bdsUserInfo.ResetBindings(true);
            loginList.Clear();

            LoadInfo();
            ClearGroupUserInfo();
        }

        private void ClearGroupUserInfo()
        {
            txtUsername.Enabled = true;
            txtUsername.Text = "";
            txtPassword.Text = "";
            foreach (ListViewItem item in lstRight.Items)
            {
                item.Selected = false;
            }
            grpUserInfo.Enabled = false;
            SaveModel = null;
        }

        private void LoadInfo()
        {
            loginList.Clear();
            SecurityEventArgs eventArgs = new SecurityEventArgs();
            EventUtility.fireEvent(InitSecuritySettingsEvent, this, eventArgs);            
            if (eventArgs.userInfoList != null && eventArgs.userInfoList.Count > 0)
            {
                foreach (LoginModel loginModel in eventArgs.userInfoList)
                {
                    loginModel.RoleType = ((RoleModel)loginModel.Roles[0]).Name;
                    loginList.Add(loginModel);
                    /*if (loginModel.EmployeeInfo != null)
                    {
                        loginModel.EmployeeInfo.Department = GetDepartmentFromEmployee(loginModel.EmployeeInfo);
                    }*/
                }
            }
            bdsUserInfo.EndEdit();
            dgvUserInfo.Refresh();
            dgvUserInfo.Invalidate();
        }

        private Department GetDepartmentFromEmployee(EmployeeInfo info)
        {
            foreach (Department department in bdsDepartment)
            {
                if(department.DepartmentId== info.EmployeePK.DepartmentId)
                {
                    return department;
                }
            }
            return null;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cboDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void btnCreateFromEmployee_Click(object sender, EventArgs e)
        {
            CreateSaveModel(true);
            LockControlInEditMode();
            grpUserInfo.Enabled = true;
            txtUsername.Text = SaveModel.Username;
            txtPassword.Text = SaveModel.Password;    
        }

        private void CreateSaveModel(bool fromEmployee)
        {
            if(SaveModel== null)
            {
                SaveModel = new LoginModel();
            }
            SaveModel.Password = "";
            if(fromEmployee)
            {
                if (lstEmployee.SelectedItems != null && lstEmployee.SelectedItems.Count > 0)
                {
                    ListView.SelectedListViewItemCollection selectedItems = lstEmployee.SelectedItems;
                    ListViewItem selectedItem = selectedItems[0];
                    SaveModel.Username = selectedItem.Text.ToLower();
                    SaveModel.EmployeeInfo = GetEmployeeInfoFromListEmployee(selectedItem);
                    

                }
                
            }
            else
            {
                SaveModel.Username = "";    
            }
        }

        private void btnCreateNew_Click(object sender, EventArgs e)
        {
            CreateSaveModel(false);
            grpUserInfo.Enabled = true;
            txtUsername.Text = SaveModel.Username;
            txtPassword.Text = SaveModel.Password;
        }

        private void LockControlInEditMode()
        {
            dgvUserInfo.Enabled = false;
            lstEmployee.Enabled = false;
            cboDepartment.Enabled = false;
            cboWatchBy.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            
            
            if(dgvUserInfo.SelectedRows!= null && dgvUserInfo.SelectedRows.Count > 0 )
            {
                DataGridViewSelectedRowCollection selectedRowCollection = dgvUserInfo.SelectedRows;
                LoginModel selectedModel = loginList[selectedRowCollection[0].Index];
                if(selectedModel.RoleType.Equals("Administrator"))
                {
                    // if role is lower then exit
                    if(ClientInfo.getInstance().LoggedUser.IsInRole(new Role {Name = "Supervisor"}))
                    {
                        MessageBox.Show("Không đủ quyền để thay đổi thông tin tài khoản này");
                        return;
                    }
                }
                if (selectedModel.RoleType.Equals("Supervisor"))
                {
                    // if role is not equal then exit
                    IList list = ClientInfo.getInstance().LoggedUser.Roles;
                    Role currentRole = list[0] as Role;
                    if (!ClientInfo.getInstance().LoggedUser.Name.Equals(selectedModel.Username))
                    {
                        MessageBox.Show("Không đủ quyền để thay đổi thông tin tài khoản này");
                        return;
                    }
                }
                LockControlInEditMode();
                grpUserInfo.Enabled = true;
                CreateSaveModel(false);
                PopulateSaveModel(selectedModel);
                txtUsername.Text = SaveModel.Username;
                txtUsername.Enabled = false;
                txtPassword.Text = SaveModel.Password;
                lstRight.Items[GetRightListIndex(((RoleModel)SaveModel.Roles[0]).Id)].Selected = true;
                
            }
        }

        private void PopulateSaveModel(LoginModel selectedModel)
        {
            SaveModel.Username = selectedModel.Username;
            SaveModel.Password = selectedModel.Password;
            SaveModel.Roles = selectedModel.Roles;
            SaveModel.EmployeeInfo = selectedModel.EmployeeInfo;
            SaveModel.Suspended = selectedModel.Suspended;
            SaveModel.Deleted = selectedModel.Deleted;
        }

        private int GetRightListIndex(int id)
        {

            int retId = 0;
            switch (id)
            {
                case 5:   // Supervisor
                    retId = 0;
                    break;
                case 2: // Manager
                    retId = 1;
                    break;
                case 3: // Accountant
                    retId = 2;
                    break;
                default:
                    break;
            }
            return retId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(CheckIntegrity() )
            {
                if(SaveModel == null)
                {
                    MessageBox.Show("Không có thông tin để lưu");
                }
                SaveModel.Username = txtUsername.Text.Trim().ToLower();
                SaveModel.Password = txtPassword.Text;
                
                RoleModel roleModel = new RoleModel{Id =CreateRoleIdFromRightList()};
                if(SaveModel.Roles == null)
                {
                    SaveModel.Roles = new ArrayList();
                }
                SaveModel.Roles.Clear();
                SaveModel.Roles.Add(roleModel);
                SecurityEventArgs eventArgs = new SecurityEventArgs();
                eventArgs.SaveModel = SaveModel;
                EventUtility.fireEvent(SaveUserEvent,this,eventArgs);
                if(!eventArgs.HasErrors)
                {
                    MessageBox.Show("Lưu thông tin tài khoản thành công");
                    ClearGroupUserInfo();
                    UnlockControl();
                    LoadInfo();
                }
            }
        }

        private void UnlockControl()
        {
            dgvUserInfo.Enabled = true;
            lstEmployee.Enabled = true;
            cboDepartment.Enabled = true;
            cboWatchBy.Enabled = true;
        }

        private EmployeeInfo GetEmployeeInfoFromListEmployee(ListViewItem item)
        {
            Department department = (Department)cboDepartment.SelectedItem;
            foreach (EmployeeInfo employeeInfo in department.Employees)
            {
                if(employeeInfo.EmployeePK.EmployeeId.Equals(item.Text.Trim().ToUpper()))
                {
                    return employeeInfo;
                }
            }
            return null;
        }

        private int CreateRoleIdFromRightList()
        {
            int retId = 3;
            switch (lstRight.SelectedIndices[0])
            {
                case 0: // Supervisor
                    retId = 5;
                    break;
                case 1: // Manager
                    retId = 2;
                    break;
                case 2: // Accountant
                    retId = 3;
                    break;
                default:
                    break;
            }
            return retId;
        }

        private bool CheckIntegrity()
        {
            if(CheckUtility.IsNullOrEmpty(txtUsername.Text) 
                || CheckUtility.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Tên hoặc mật khẩu không được để trống");
                return false;
            }
            if(lstRight.SelectedIndices == null || lstRight.SelectedIndices.Count ==0)
            {
                MessageBox.Show("Phải xác định quyền cho tài khoản");
                return false;
            }
            return true;            
        }

        private void btnSuspend_Click(object sender, EventArgs e)
        {
            
            UpdateUserAccount(true, false);
        }

        private void UpdateUserAccount(bool isSuspend, bool isDelete)
        {
            if (dgvUserInfo.SelectedRows != null && dgvUserInfo.SelectedRows.Count > 0)
            {
                
                DataGridViewSelectedRowCollection selectedRowCollection = dgvUserInfo.SelectedRows;
                LoginModel selectedModel = loginList[selectedRowCollection[0].Index];
                if (selectedModel.RoleType.Equals("Administrator") || selectedModel.RoleType.Equals("Supervisor"))
                {
                    // if role is lower then exit
                    if (ClientInfo.getInstance().LoggedUser.IsInRole(new Role { Name = "Supervisor" }))
                    {
                        MessageBox.Show("Không đủ quyền để thay đổi thông tin tài khoản này");
                        return;
                    }
                }
                if (selectedModel.RoleType.Equals("Administrator") && ClientInfo.getInstance().LoggedUser.Name.Equals(selectedModel.Username))
                {
                    MessageBox.Show("Không thể thay đổi thông tin tài khoản quyền cao nhất");
                        return;
                }
                CreateSaveModel(false);
                PopulateSaveModel(selectedModel);
                if(isSuspend)
                SaveModel.Suspended = 1;
                else
                {
                    SaveModel.Suspended = 0;                    
                }

                if(isDelete)
                {
                    SaveModel.Deleted = 1;
                }
                else
                {
                    SaveModel.Deleted = 0;                    
                }
                SecurityEventArgs eventArgs = new SecurityEventArgs();
                eventArgs.SaveModel = SaveModel;
                EventUtility.fireEvent(SaveUserEvent, this, eventArgs);
                if (!eventArgs.HasErrors)
                {
                    MessageBox.Show("Lưu thông tin tài khoản thành công");
                    LoadInfo();
                }
                SaveModel = null;
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            UpdateUserAccount(false, true);
        }

        private void btnUnsuspend_Click(object sender, EventArgs e)
        {
            UpdateUserAccount(false, false);
        }

        private void btnUnremove_Click(object sender, EventArgs e)
        {
            UpdateUserAccount(false, false);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SaveModel = null;
            ClearGroupUserInfo();
            UnlockControl();
        }
    }
}
