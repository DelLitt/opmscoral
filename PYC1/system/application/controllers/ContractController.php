<?php

class ContractController extends Controller {

    function _insert() {
        $this->load->helper(array('form', 'url'));
		$this->load->library('form_validation');
        
        //$this->form_validation->set_rules('username', 'Username', 'required');
		//$this->form_validation->set_rules('password', 'Password', 'required');
		//$this->form_validation->set_rules('passconf', 'Password Confirmation', 'required');
		//$this->form_validation->set_rules('email', 'Email', 'required');
        //$this->form_validation->set_rules('txtContractId', 'ContractId', 'required');    
        //$this->form_validation->set_rules('txtContractNumber', 'ContractNumber', 'required');    
        //$this->form_validation->set_rules('txtCustomerId', 'CustomerId', 'required');    
        //$this->form_validation->set_rules('txtCompanyId', 'CompanyId', 'required');    
        //$this->form_validation->set_rules('txtContractDate', 'ContractDate', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
        //$this->form_validation->set_rules('cbbCONTRACT_TYPE_ID', 'CONTRACT_TYPE_ID', 'required');
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $Contract = new Contract();
                if ($this->input->post('txtContractId') != FALSE) {
                    $Contract->contractId = $this->input->post('txtContractId');
                }
                if ($this->input->post('txtContractNumber') != FALSE) {
                    $Contract->contractNumber = $this->input->post('txtContractNumber');
                }
                if ($this->input->post('txtCustomerId') != FALSE) {
                    $Contract->customerId = $this->input->post('txtCustomerId');
                }
                if ($this->input->post('txtCompanyId') != FALSE) {
                    $Contract->companyId = $this->input->post('txtCompanyId');
                }
                if ($this->input->post('txtContractDate') != FALSE) {
                    $Contract->contractDate = $this->input->post('txtContractDate');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Contract->createDate = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Contract->createUser = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Contract->updateDate = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Contract->updateUser = $this->input->post('txtUpdateUser');
                }
                $Contract->contractTypeMaster = new ContractTypeMaster();
                if ($this->input->post('cbbCONTRACT_TYPE_ID') != FALSE) {
                    $Contract->contractTypeMaster->contractTypeId = $this->input->post('cbbCONTRACT_TYPE_ID');
                }
            $this->ContractDAO->insert($Contract); 
            
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
        //$this->form_validation->set_rules('txtContractId', 'ContractId', 'required');    
        //$this->form_validation->set_rules('txtContractNumber', 'ContractNumber', 'required');    
        //$this->form_validation->set_rules('txtCustomerId', 'CustomerId', 'required');    
        //$this->form_validation->set_rules('txtCompanyId', 'CompanyId', 'required');    
        //$this->form_validation->set_rules('txtContractDate', 'ContractDate', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
        //$this->form_validation->set_rules('cbbCONTRACT_TYPE_ID', 'CONTRACT_TYPE_ID', 'required');
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $Contract = $this->session->userdata('Contract');
                
                if ($Contract == null) {
                    // TODO move to login page
                }
                
                if ($this->input->post('txtContractId') != FALSE) {
                    $Contract->contractId = $this->input->post('txtContractId');
                }
                if ($this->input->post('txtContractNumber') != FALSE) {
                    $Contract->contractNumber = $this->input->post('txtContractNumber');
                }
                if ($this->input->post('txtCustomerId') != FALSE) {
                    $Contract->customerId = $this->input->post('txtCustomerId');
                }
                if ($this->input->post('txtCompanyId') != FALSE) {
                    $Contract->companyId = $this->input->post('txtCompanyId');
                }
                if ($this->input->post('txtContractDate') != FALSE) {
                    $Contract->contractDate = $this->input->post('txtContractDate');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Contract->createDate = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Contract->createUser = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Contract->updateDate = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Contract->updateUser = $this->input->post('txtUpdateUser');
                }
                $Contract->contractTypeMaster = new ContractTypeMaster();
                if ($this->input->post('cbbCONTRACT_TYPE_ID') != FALSE) {
                    $Contract->contractTypeMaster->contractTypeId = $this->input->post('cbbCONTRACT_TYPE_ID');
                }
            $this->ContractDAO->update($Contract); 
            
			$this->load->view('formsuccess');
		}
    }

    function _findById() {
        $id = $this->input->post('object_id');
        
        $Contract = $this->ContractDAO->findById($id);;
        $this->session->set_userdata('Contract', $Contract);
            
        $this->load->view('formsuccess');
    }
	
    function _search() {
        $id = $this->input->post('object_id');
        
		$criteria = new ObjectCriteria();
		$criteria->addEqCritetia('contractNumber', $this->input->post('txtContractNumber'));
		$criteria->addEqCritetia('customerId', $this->input->post('txtCustomerId'));
		$criteria->addEqCritetia('companyId', $this->input->post('txtCompanyId'));
		$criteria->addEqCritetia('contractDate', $this->input->post('txtContractDate'));
		$criteria->addEqCritetia('createDate', $this->input->post('txtCreateDate'));
		$criteria->addEqCritetia('createUser', $this->input->post('txtCreateUser'));
		$criteria->addEqCritetia('updateDate', $this->input->post('txtUpdateDate'));
		$criteria->addEqCritetia('updateUser', $this->input->post('txtUpdateUser'));
        $ContractList = $this->ContractDAO->findAll($criteria);;
        $this->session->set_userdata('ContractList', $ContractList);
            
        $this->load->view('formsuccess');
    }
}

?>