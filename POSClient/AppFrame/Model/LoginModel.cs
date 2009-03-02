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

        
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        [XmlArrayItem(typeof(Role))]
        public IList Roles
        {
            get { return roles; }
            set { roles = value; }
        }

        public EmployeeInfo EmployeeInfo
        {
            get { return employeeInfo; }
            set { employeeInfo = value; }
        }
    }
}
