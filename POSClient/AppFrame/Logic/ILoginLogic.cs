using AppFrame.Common;
using AppFrame.DataLayer;
using AppFrame.Model;

namespace AppFrame.Logic
{
    public interface ILoginLogic
    {
        
        //ILoginDao LoginDao { get; set; }
        #region function in logic

        bool validate(LoginModel loginModel);
        BaseUser doAuthentication(LoginModel model);

        BaseUser getUser(string username);
        #endregion

        EmployeeInfo GetEmployeeInfo(string username);
    }
}