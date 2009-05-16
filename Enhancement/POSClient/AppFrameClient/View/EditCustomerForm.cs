using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AppFrame.Common;
using AppFrame.Model;
using AppFrame.Presenter;
using AppFrame.Utility;
using AppFrame.View;
using Spring.Context;
using Spring.Context.Support;

namespace AppFrameClient.View
{
    public partial class EditCustomerForm : BaseForm,IEditCustomerView<CustomerEventArgs>
    {
        public EditCustomerForm()
        {
            InitializeComponent();
            pnlCustomer.Enabled = false;
            btnSave.Enabled = false;
        }

        private void EditCustomerForm_Load(object sender, EventArgs e)
        {
            CallDatabaseToLoadCustomers();
        }

        private void CallDatabaseToLoadCustomers()
        {
            EventUtility.fireAsyncEvent(LoadAllCustomerEventEvent, this, null, new AsyncCallback(EndEvent)); 
        }

        #region ICustomerView<CustomerEventArgs> Members

        private ICustomerController<CustomerEventArgs> customerController;    
        public ICustomerController<CustomerEventArgs> CustomerController
        {
            set
            {
                customerController = value;
                customerController.EditCustomerView = this;
                customerController.CompleteLoadAllCustomerEvent+=new EventHandler<CustomerEventArgs>(customerController_CompleteLoadAllCustomerEvent);
                customerController.CompleteLoadCustomerEvent+=new EventHandler<CustomerEventArgs>(customerController_CompleteLoadCustomerEvent);
                customerController.CompleteUpdateCustomerEvent+=new EventHandler<CustomerEventArgs>(customerController_CompleteUpdateCustomerEvent);
                customerController.CompleteDeleteCustomerEvent+=new EventHandler<CustomerEventArgs>(customerController_CompleteDeleteCustomerEvent);
            }
        }

        private void customerController_CompleteDeleteCustomerEvent(object sender, CustomerEventArgs e)
        {
            if (((bool)e.EventResult) == true)
            {
                MessageBox.Show(ResourceUtility.GetMessageString("deleteOK"));
            }
            else
            {
                MessageBox.Show(ResourceUtility.GetErrorString("deleteFail"));
            }
            CallDatabaseToLoadCustomers();
        }

        private void customerController_CompleteUpdateCustomerEvent(object sender, CustomerEventArgs e)
        {
            if(((bool)e.EventResult) == true)
            {
                MessageBox.Show(ResourceUtility.GetMessageString("updateOK"));
            }
            else
            {
                MessageBox.Show(ResourceUtility.GetErrorString("updateFail"));                     
            }
            CallDatabaseToLoadCustomers();
        }

        private void customerController_CompleteLoadCustomerEvent(object sender, CustomerEventArgs e)
        {
            CustomerModel resultModel = e.EventResult as CustomerModel;
            txtId.Text = resultModel.Id.ToString();
            txtCustomerName.Text = resultModel.CustomerName;
            txtAddress.Text = resultModel.Address;
            txtTelephone.Text = resultModel.Telephone.ToString();
            txtContactPerson.Text = resultModel.ContactPerson;
           
        }

        private void customerController_CompleteLoadAllCustomerEvent(object sender, CustomerEventArgs e)
        {
            IList customerList = e.EventResult as IList;
            dgvCustomer.DataSource = customerList;
        }


        public event EventHandler<CustomerEventArgs> LoadAllCustomerEventEvent;

        public event EventHandler<CustomerEventArgs> LoadCustomerEvent;

        public event EventHandler<CustomerEventArgs> UpdateCustomerEvent;

        public event EventHandler<CustomerEventArgs> DeleteCustomerEvent;

        #endregion

        private void dgvCustomer_SelectionChanged(object sender, EventArgs e)
        {
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CustomerModel saveModel = new CustomerModel();
            saveModel.Id = Int32.Parse(txtId.Text);
            saveModel.CustomerName = txtCustomerName.Text;
            saveModel.Address = txtAddress.Text;
            saveModel.Telephone = Int32.Parse(txtTelephone.Text);
            saveModel.ContactPerson = txtContactPerson.Text;
            CustomerEventArgs customerEventArgs = new CustomerEventArgs();
            customerEventArgs.Customer = saveModel;
            EventUtility.fireAsyncEvent(UpdateCustomerEvent, this, customerEventArgs, new AsyncCallback(EndEvent));

        }

        private void dgvCustomer_Click(object sender, EventArgs e)
        {
            LoadCustomerToPanel();
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //LoadCustomerToPanel();
        }
        private void LoadCustomerToPanel()
        {
            int id = -1;
            try
            {
                id = Int32.Parse(dgvCustomer.SelectedRows[0].Cells[0].Value.ToString());
            }
            catch (Exception)
            {


            }
            if (id != -1)
            {
                pnlCustomer.Enabled = true;
                btnSave.Enabled = true;
            }
            CustomerModel queryModel = new CustomerModel();
            queryModel.Id = id;
            CustomerEventArgs customerEventArgs = new CustomerEventArgs();
            customerEventArgs.Customer = queryModel;
            EventUtility.fireAsyncEvent(LoadCustomerEvent, this, customerEventArgs, new AsyncCallback(EndEvent));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Dispose();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            CustomerModel saveModel = new CustomerModel();
            saveModel.Id = Int32.Parse(txtId.Text);
            saveModel.CustomerName = txtCustomerName.Text;
            saveModel.Address = txtAddress.Text;
            saveModel.Telephone = Int32.Parse(txtTelephone.Text);
            saveModel.ContactPerson = txtContactPerson.Text;
            CustomerEventArgs customerEventArgs = new CustomerEventArgs();
            customerEventArgs.Customer = saveModel;
            EventUtility.fireAsyncEvent(DeleteCustomerEvent, this, customerEventArgs, new AsyncCallback(EndEvent));
        }
    }
}