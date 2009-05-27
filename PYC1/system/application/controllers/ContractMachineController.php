<?php

class ContractMachineController extends Controller {

    function _insert() {
        $this->load->helper(array('form', 'url'));
		$this->load->library('form_validation');
        
        //$this->form_validation->set_rules('username', 'Username', 'required');
		//$this->form_validation->set_rules('password', 'Password', 'required');
		//$this->form_validation->set_rules('passconf', 'Password Confirmation', 'required');
		//$this->form_validation->set_rules('email', 'Email', 'required');
        //$this->form_validation->set_rules('txtContractId', 'ContractId', 'required');    
        //$this->form_validation->set_rules('txtMachineId', 'MachineId', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $ContractMachine = new ContractMachine();
                if ($this->input->post('txtContractId') != FALSE) {
                    $ContractMachine->contractId = $this->input->post('txtContractId');
                }
                if ($this->input->post('txtMachineId') != FALSE) {
                    $ContractMachine->machineId = $this->input->post('txtMachineId');
                }
            $this->ContractMachineDAO->insert($ContractMachine); 
            
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
        //$this->form_validation->set_rules('txtMachineId', 'MachineId', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $ContractMachine = $this->session->userdata('ContractMachine');
                
                if ($ContractMachine == null) {
                    // TODO move to login page
                }
                
                if ($this->input->post('txtContractId') != FALSE) {
                    $ContractMachine->contractId = $this->input->post('txtContractId');
                }
                if ($this->input->post('txtMachineId') != FALSE) {
                    $ContractMachine->machineId = $this->input->post('txtMachineId');
                }
            $this->ContractMachineDAO->update($ContractMachine); 
            
			$this->load->view('formsuccess');
		}
    }

    function _findById() {
        $id = $this->input->post('object_id');
        
        $ContractMachine = $this->ContractMachineDAO->findById($id);;
        $this->session->set_userdata('ContractMachine', $ContractMachine);
            
        $this->load->view('formsuccess');
    }
	
    function _search() {
        $id = $this->input->post('object_id');
        
		$criteria = new ObjectCriteria();
        $ContractMachineList = $this->ContractMachineDAO->findAll($criteria);;
        $this->session->set_userdata('ContractMachineList', $ContractMachineList);
            
        $this->load->view('formsuccess');
    }
}

?>