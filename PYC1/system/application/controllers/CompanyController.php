<?php

class CompanyController extends Controller {

    function _insert() {
        $this->load->helper(array('form', 'url'));
		$this->load->library('form_validation');
        
        //$this->form_validation->set_rules('username', 'Username', 'required');
		//$this->form_validation->set_rules('password', 'Password', 'required');
		//$this->form_validation->set_rules('passconf', 'Password Confirmation', 'required');
		//$this->form_validation->set_rules('email', 'Email', 'required');
        //$this->form_validation->set_rules('txtCompanyId', 'CompanyId', 'required');    
        //$this->form_validation->set_rules('txtCompanyName', 'CompanyName', 'required');    
        //$this->form_validation->set_rules('txtAddress', 'Address', 'required');    
        //$this->form_validation->set_rules('txtPhone', 'Phone', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
        //$this->form_validation->set_rules('txtFax', 'Fax', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $Company = new Company();
                if ($this->input->post('txtCompanyId') != FALSE) {
                    $Company->companyId = $this->input->post('txtCompanyId');
                }
                if ($this->input->post('txtCompanyName') != FALSE) {
                    $Company->companyName = $this->input->post('txtCompanyName');
                }
                if ($this->input->post('txtAddress') != FALSE) {
                    $Company->address = $this->input->post('txtAddress');
                }
                if ($this->input->post('txtPhone') != FALSE) {
                    $Company->phone = $this->input->post('txtPhone');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Company->createDate = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Company->createUser = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Company->updateDate = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Company->updateUser = $this->input->post('txtUpdateUser');
                }
                if ($this->input->post('txtFax') != FALSE) {
                    $Company->fax = $this->input->post('txtFax');
                }
            $this->CompanyDAO->insert($Company); 
            
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
        //$this->form_validation->set_rules('txtCompanyId', 'CompanyId', 'required');    
        //$this->form_validation->set_rules('txtCompanyName', 'CompanyName', 'required');    
        //$this->form_validation->set_rules('txtAddress', 'Address', 'required');    
        //$this->form_validation->set_rules('txtPhone', 'Phone', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
        //$this->form_validation->set_rules('txtFax', 'Fax', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $Company = $this->session->userdata('Company');
                
                if ($Company == null) {
                    // TODO move to login page
                }
                
                if ($this->input->post('txtCompanyId') != FALSE) {
                    $Company->companyId = $this->input->post('txtCompanyId');
                }
                if ($this->input->post('txtCompanyName') != FALSE) {
                    $Company->companyName = $this->input->post('txtCompanyName');
                }
                if ($this->input->post('txtAddress') != FALSE) {
                    $Company->address = $this->input->post('txtAddress');
                }
                if ($this->input->post('txtPhone') != FALSE) {
                    $Company->phone = $this->input->post('txtPhone');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Company->createDate = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Company->createUser = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Company->updateDate = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Company->updateUser = $this->input->post('txtUpdateUser');
                }
                if ($this->input->post('txtFax') != FALSE) {
                    $Company->fax = $this->input->post('txtFax');
                }
            $this->CompanyDAO->update($Company); 
            
			$this->load->view('formsuccess');
		}
    }

    function _findById() {
        $id = $this->input->post('object_id');
        
        $Company = $this->CompanyDAO->findById($id);;
        $this->session->set_userdata('Company', $Company);
            
        $this->load->view('formsuccess');
    }
	
    function _search() {
        $id = $this->input->post('object_id');
        
		$criteria = new ObjectCriteria();
		$criteria->addEqCritetia('companyName', $this->input->post('txtCompanyName'));
		$criteria->addEqCritetia('address', $this->input->post('txtAddress'));
		$criteria->addEqCritetia('phone', $this->input->post('txtPhone'));
		$criteria->addEqCritetia('createDate', $this->input->post('txtCreateDate'));
		$criteria->addEqCritetia('createUser', $this->input->post('txtCreateUser'));
		$criteria->addEqCritetia('updateDate', $this->input->post('txtUpdateDate'));
		$criteria->addEqCritetia('updateUser', $this->input->post('txtUpdateUser'));
		$criteria->addEqCritetia('fax', $this->input->post('txtFax'));
        $CompanyList = $this->CompanyDAO->findAll($criteria);;
        $this->session->set_userdata('CompanyList', $CompanyList);
            
        $this->load->view('formsuccess');
    }
}

?>