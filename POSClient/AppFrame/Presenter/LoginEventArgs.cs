using System.Web.UI.WebControls;
using AppFrame.Common;
using AppFrame.Model;

namespace AppFrame.Presenter
{
    public class LoginEventArgs : BaseEventArgs
    {
        private string status;
        private LoginModel loginModel;
        public string ConfirmAction { get; set; }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }

        public bool IsValid
        {
            get { return isValid; }
            set { isValid = value; }
        }

        public LoginModel LoginModel
        {
            get { return loginModel; }
            set { loginModel = value; }
        }
        public string EmployeeId { get; set; }
        public string OldPassword
        {
            get; set;
        }
        public string NewPassword
        {
            get; set;
        }
        private bool isValid;
        public string ConfirmType { get; set;}
    }
    
}