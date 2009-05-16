using System.Collections;
using AppFrame.DataLayer;
using AppFrame.Model;
using AppFrame.Presenter;

namespace AppFrame.Logic
{
    public interface ITestCustomerLogic : IAuthoriseLogic
    {
        ITestCustomerDao CustomerDao { get; set;}
        CustomerModel GetCustomer(string customerName);
        bool SaveCustomer(CustomerModel customer);
        bool UpdateCustomer(CustomerModel customer);
        bool DeleteCustomer(CustomerModel customer);
        IList LoadAllCustomers();
        CustomerModel LoadCustomer(int id);
        IList Find(string name);

        
    }
}