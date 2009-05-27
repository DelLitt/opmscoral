<?php

class ContractTypeMasterController extends Controller {

    function _insert() {
        $this->load->helper(array('form', 'url'));
		$this->load->library('form_validation');
        
        //$this->form_validation->set_rules('username', 'Username', 'required');
		//$this->form_validation->set_rules('password', 'Password', 'required');
		//$this->form_validation->set_rules('passconf', 'Password Confirmation', 'required');
		//$this->form_validation->set_rules('email', 'Email', 'required');
        //$this->form_validation->set_rules('txtContractTypeId', 'ContractTypeId', 'required');    
        //$this->form_validation->set_rules('txtContractTypeName', 'ContractTypeName', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $ContractTypeMaster = new ContractTypeMaster();
                if ($this->input->post('txtContractTypeId') != FALSE) {
                    $ContractTypeMaster->contractTypeId = $this->input->post('txtContractTypeId');
                }
                if ($this->input->post('txtContractTypeName') != FALSE) {
                    $ContractTypeMaster->contractTypeName = $this->input->post('txtContractTypeName');
                }
            $this->ContractTypeMasterDAO->insert($ContractTypeMaster); 
            
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
        //$this->form_validation->set_rules('txtContractTypeId', 'ContractTypeId', 'required');    
        //$this->form_validation->set_rules('txtContractTypeName', 'ContractTypeName', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $ContractTypeMaster = $this->session->userdata('ContractTypeMaster');
                
                if ($ContractTypeMaster == null) {
                    // TODO move to login page
                }
                
                if ($this->input->post('txtContractTypeId') != FALSE) {
                    $ContractTypeMaster->contractTypeId = $this->input->post('txtContractTypeId');
                }
                if ($this->input->post('txtContractTypeName') != FALSE) {
                    $ContractTypeMaster->contractTypeName = $this->input->post('txtContractTypeName');
                }
            $this->ContractTypeMasterDAO->update($ContractTypeMaster); 
            
			$this->load->view('formsuccess');
		}
    }

    function _findById() {
        $id = $this->input->post('object_id');
        
        $ContractTypeMaster = $this->ContractTypeMasterDAO->findById($id);;
        $this->session->set_userdata('ContractTypeMaster', $ContractTypeMaster);
            
        $this->load->view('formsuccess');
    }
	
    function _search() {
        $id = $this->input->post('object_id');
        
		$criteria = new ObjectCriteria();
		$criteria->addEqCritetia('contractTypeName', $this->input->post('txtContractTypeName'));
        $ContractTypeMasterList = $this->ContractTypeMasterDAO->findAll($criteria);;
        $this->session->set_userdata('ContractTypeMasterList', $ContractTypeMasterList);
            
        $this->load->view('formsuccess');
    }
}

?>