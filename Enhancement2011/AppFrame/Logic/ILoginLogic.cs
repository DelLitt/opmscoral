using System.Collections;
using AppFrame.Common;
using AppFrame.DataLayer;
using AppFrame.Model;
using Spring.Transaction.Interceptor;

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
        
        [Transaction(ReadOnly = false)]
        EmployeeInfo GetEmployeeInfo(string username);

        [Transaction(ReadOnly = false)]
        LoginModel FindById(object id);

        [Transaction(ReadOnly = false)]
        LoginModel Add(LoginModel data);

        [Transaction(ReadOnly = false)]
        void Update(LoginModel data);
        
        [Transaction(ReadOnly = false)]
        void Delete(LoginModel data);

        
        [Transaction(ReadOnly = false)]
        void DeleteById(object id);
        
        [Transaction(ReadOnly = false)]
        IList FindAll(ObjectCriteria criteria);

        void ProcessUser(LoginModel model);
        void ChangePassword(string username, string password, string newPassword);
        
    }
}