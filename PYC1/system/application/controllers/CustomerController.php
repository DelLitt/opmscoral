<?php

class CustomerController extends Controller {

    function _insert() {
        $this->load->helper(array('form', 'url'));
		$this->load->library('form_validation');
        
        //$this->form_validation->set_rules('username', 'Username', 'required');
		//$this->form_validation->set_rules('password', 'Password', 'required');
		//$this->form_validation->set_rules('passconf', 'Password Confirmation', 'required');
		//$this->form_validation->set_rules('email', 'Email', 'required');
        //$this->form_validation->set_rules('txtCustomerId', 'CustomerId', 'required');    
        //$this->form_validation->set_rules('txtCustomerName', 'CustomerName', 'required');    
        //$this->form_validation->set_rules('txtAddress', 'Address', 'required');    
        //$this->form_validation->set_rules('txtCompanyId', 'CompanyId', 'required');    
        //$this->form_validation->set_rules('txtPhone', 'Phone', 'required');    
        //$this->form_validation->set_rules('txtFax', 'Fax', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $Customer = new Customer();
                if ($this->input->post('txtCustomerId') != FALSE) {
                    $Customer->customerId = $this->input->post('txtCustomerId');
                }
                if ($this->input->post('txtCustomerName') != FALSE) {
                    $Customer->customerName = $this->input->post('txtCustomerName');
                }
                if ($this->input->post('txtAddress') != FALSE) {
                    $Customer->address = $this->input->post('txtAddress');
                }
                if ($this->input->post('txtCompanyId') != FALSE) {
                    $Customer->companyId = $this->input->post('txtCompanyId');
                }
                if ($this->input->post('txtPhone') != FALSE) {
                    $Customer->phone = $this->input->post('txtPhone');
                }
                if ($this->input->post('txtFax') != FALSE) {
                    $Customer->fax = $this->input->post('txtFax');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Customer->createDate = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Customer->createUser = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Customer->updateDate = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Customer->updateUser = $this->input->post('txtUpdateUser');
                }
            $this->CustomerDAO->insert($Customer); 
            
			$this->load->view('formsuccess');
		}
    }

    function _update() {
        $this->load->helper(array('form', 'url'));
		$this->load->library('form_validation');
        
        //$this->form_validation->set_rules('username', 'Username', 'required');
		//$this->form_validation->set_rules('password', 'Password', 'required');
		//$this->form_validation->set_rules('passconf', 'Password Confirmation', 'required');
		//$this->form_validation->set_rules('email', 'Email', 'required');
        //$this->form_validation->set_rules('txtCustomerId', 'CustomerId', 'required');    
        //$this->form_validation->set_rules('txtCustomerName', 'CustomerName', 'required');    
        //$this->form_validation->set_rules('txtAddress', 'Address', 'required');    
        //$this->form_validation->set_rules('txtCompanyId', 'CompanyId', 'required');    
        //$this->form_validation->set_rules('txtPhone', 'Phone', 'required');    
        //$this->form_validation->set_rules('txtFax', 'Fax', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $Customer = $this->session->userdata('Customer');
                
                if ($Customer == null) {
                    // TODO move to login page
                }
                
                if ($this->input->post('txtCustomerId') != FALSE) {
                    $Customer->customerId = $this->input->post('txtCustomerId');
                }
                if ($this->input->post('txtCustomerName') != FALSE) {
                    $Customer->customerName = $this->input->post('txtCustomerName');
                }
                if ($this->input->post('txtAddress') != FALSE) {
                    $Customer->address = $this->input->post('txtAddress');
                }
                if ($this->input->post('txtCompanyId') != FALSE) {
                    $Customer->companyId = $this->input->post('txtCompanyId');
                }
                if ($this->input->post('txtPhone') != FALSE) {
                    $Customer->phone = $this->input->post('txtPhone');
                }
                if ($this->input->post('txtFax') != FALSE) {
                    $Customer->fax = $this->input->post('txtFax');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Customer->createDate = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Customer->createUser = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Customer->updateDate = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Customer->updateUser = $this->input->post('txtUpdateUser');
                }
            $this->CustomerDAO->update($Customer); 
            
			$this->load->view('formsuccess');
		}
    }

    function _findById() {
        $id = $this->input->post('object_id');
        
        $Customer = $this->CustomerDAO->findById($id);;
        $this->session->set_userdata('Customer', $Customer);
            
        $this->load->view('formsuccess');
    }
	
    function _search() {
        $id = $this->input->post('object_id');
        
		$criteria = new ObjectCriteria();
		$criteria->addEqCritetia('customerName', $this->input->post('txtCustomerName'));
		$criteria->addEqCritetia('address', $this->input->post('txtAddress'));
		$criteria->addEqCritetia('companyId', $this->input->post('txtCompanyId'));
		$criteria->addEqCritetia('phone', $this->input->post('txtPhone'));
		$criteria->addEqCritetia('fax', $this->input->post('txtFax'));
		$criteria->addEqCritetia('createDate', $this->input->post('txtCreateDate'));
		$criteria->addEqCritetia('createUser', $this->input->post('txtCreateUser'));
		$criteria->addEqCritetia('updateDate', $this->input->post('txtUpdateDate'));
		$criteria->addEqCritetia('updateUser', $this->input->post('txtUpdateUser'));
        $CustomerList = $this->CustomerDAO->findAll($criteria);;
        $this->session->set_userdata('CustomerList', $CustomerList);
            
        $this->load->view('formsuccess');
    }
}

?>