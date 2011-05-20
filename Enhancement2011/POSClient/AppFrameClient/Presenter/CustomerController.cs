using System;
using System.Collections;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Logic;
using AppFrame.Model;
using AppFrame.Utility;
using AppFrame.View;

namespace AppFrame.Presenter
{
    public class CustomerController : ICustomerController<CustomerEventArgs>
    {
        private ITestCustomerLogic mCustomerLogic;
        private INewCustomerView<CustomerEventArgs> newCustomerView;
        private IEditCustomerView<CustomerEventArgs> editCustomerView;

        private CustomerEventArgs customerEventArgs;


        #region ICustomerController<CustomerEventArgs> Members
        

        
        IEditCustomerView<CustomerEventArgs> ICustomerController<CustomerEventArgs>.EditCustomerView
        {
            get
            {
                return editCustomerView;
            }
            set
            {
                editCustomerView = value;
                editCustomerView.LoadAllCustomerEventEvent +=new EventHandler<CustomerEventArgs>(editCustomerView_LoadAllCustomerEventEvent);
                editCustomerView.LoadCustomerEvent +=new EventHandler<CustomerEventArgs>(editCustomerView_LoadCustomerEvent);
                editCustomerView.UpdateCustomerEvent +=new EventHandler<CustomerEventArgs>(editCustomerView_UpdateCustomerEvent);
                editCustomerView.DeleteCustomerEvent+=new EventHandler<CustomerEventArgs>(editCustomerView_DeleteCustomerEvent);
            }
        }

        private void editCustomerView_DeleteCustomerEvent(object sender, CustomerEventArgs e)
        {
            bool result = CustomerLogic.DeleteCustomer(e.Customer);
            ResultEventArgs.EventResult = result;
            EventUtility.fireEvent(CompleteDeleteCustomerEvent, this, ResultEventArgs);
        }

        private void editCustomerView_UpdateCustomerEvent(object sender, CustomerEventArgs e)
        {
            bool result = CustomerLogic.UpdateCustomer(e.Customer);
            ResultEventArgs.EventResult = result;
            EventUtility.fireEvent(CompleteUpdateCustomerEvent,this,ResultEventArgs);
        }

        private void editCustomerView_LoadCustomerEvent(object sender, CustomerEventArgs e)
        {
            CustomerModel customer = CustomerLogic.LoadCustomer(e.Customer.Id);
            ResultEventArgs.EventResult = customer;
            EventUtility.fireEvent(CompleteLoadCustomerEvent,this,ResultEventArgs);
        }

        private void editCustomerView_LoadAllCustomerEventEvent(object sender, CustomerEventArgs e)
        {
            IList customerList = CustomerLogic.LoadAllCustomers();
            ResultEventArgs.EventResult = customerList;
            EventUtility.fireEvent<CustomerEventArgs>(CompleteLoadAllCustomerEvent,this,ResultEventArgs);
        }


        public ITestCustomerLogic CustomerLogic
        {
            get
            {
                return mCustomerLogic;
            }
            set
            {
                mCustomerLogic = value;
            }
        }

        
        #endregion

        #region IBaseController<CustomerEventArgs> Members

        public CustomerEventArgs ResultEventArgs
        {
            get
            {
                return customerEventArgs;
            }
            set
            {
                customerEventArgs = value;
            }
        }

        #endregion




        #region ICustomerController<CustomerEventArgs> Members

        INewCustomerView<CustomerEventArgs> ICustomerController<CustomerEventArgs>.NewCustomerView
        {
            get
            {
                return newCustomerView;
            }
            set
            {
                newCustomerView = value;

                newCustomerView.NewCustomerEvent +=new EventHandler<CustomerEventArgs>(newCustomerView_NewCustomerEvent);
            }
        }

        private void newCustomerView_NewCustomerEvent(object sender, CustomerEventArgs e)
        {
            bool result = CustomerLogic.SaveCustomer(e.Customer);
            ResultEventArgs.EventResult = result;
            EventUtility.fireEvent<CustomerEventArgs>(CompleteSaveCustomerEvent, this, ResultEventArgs);
        }

        public event EventHandler<CustomerEventArgs> CompleteSaveCustomerEvent;

        public event EventHandler<CustomerEventArgs> CompleteEditCustomerEvent;

        public event EventHandler<CustomerEventArgs> CompleteDeleteCustomerEvent;

        public event EventHandler<CustomerEventArgs> CompleteLoadAllCustomerEvent;

        public event EventHandler<CustomerEventArgs> CompleteLoadCustomerEvent;

        public event EventHandler<CustomerEventArgs> CompleteUpdateCustomerEvent;

        #endregion
    }
}