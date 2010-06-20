using System;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using System.Text;
using System.Xml.Serialization;
using AppFrame.Common;

namespace AppFrame.Model
{
    [Serializable]
    public class LoginModel 
    {
        private string username;
        private string password;
        private EmployeeInfo employeeInfo;
        private IList roles = new ArrayList();

        public virtual string RoleType { get; set; }
        public virtual string Username
        {
            get { return username; }
            set { username = value; }
        }

        public virtual string Password
        {
            get { return password; }
            set { password = value; }
        }

        [XmlArrayItem(typeof(Role))]
        public virtual IList Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        public virtual EmployeeInfo EmployeeInfo
        {
            get { return employeeInfo; }
            set { employeeInfo = value; }
        }
        public virtual Int32 Suspended { get; set; }
        public virtual Int32 Deleted { get; set; }

        public virtual DateTime CreateDate { get; set; }
        public virtual DateTime UpdateDate { get; set; }
    }
}
