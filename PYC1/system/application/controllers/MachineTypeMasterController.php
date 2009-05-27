<?php

class MachineTypeMasterController extends Controller {

    function _insert() {
        $this->load->helper(array('form', 'url'));
		$this->load->library('form_validation');
        
        //$this->form_validation->set_rules('username', 'Username', 'required');
		//$this->form_validation->set_rules('password', 'Password', 'required');
		//$this->form_validation->set_rules('passconf', 'Password Confirmation', 'required');
		//$this->form_validation->set_rules('email', 'Email', 'required');
        //$this->form_validation->set_rules('txtTypeId', 'TypeId', 'required');    
        //$this->form_validation->set_rules('txtTypeName', 'TypeName', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $MachineTypeMaster = new MachineTypeMaster();
                if ($this->input->post('txtTypeId') != FALSE) {
                    $MachineTypeMaster->typeId = $this->input->post('txtTypeId');
                }
                if ($this->input->post('txtTypeName') != FALSE) {
                    $MachineTypeMaster->typeName = $this->input->post('txtTypeName');
                }
            $this->MachineTypeMasterDAO->insert($MachineTypeMaster); 
            
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
        //$this->form_validation->set_rules('txtTypeId', 'TypeId', 'required');    
        //$this->form_validation->set_rules('txtTypeName', 'TypeName', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $MachineTypeMaster = $this->session->userdata('MachineTypeMaster');
                
                if ($MachineTypeMaster == null) {
                    // TODO move to login page
                }
                
                if ($this->input->post('txtTypeId') != FALSE) {
                    $MachineTypeMaster->typeId = $this->input->post('txtTypeId');
                }
                if ($this->input->post('txtTypeName') != FALSE) {
                    $MachineTypeMaster->typeName = $this->input->post('txtTypeName');
                }
            $this->MachineTypeMasterDAO->update($MachineTypeMaster); 
            
			$this->load->view('formsuccess');
		}
    }

    function _findById() {
        $id = $this->input->post('object_id');
        
        $MachineTypeMaster = $this->MachineTypeMasterDAO->findById($id);;
        $this->session->set_userdata('MachineTypeMaster', $MachineTypeMaster);
            
        $this->load->view('formsuccess');
    }
	
    function _search() {
        $id = $this->input->post('object_id');
        
		$criteria = new ObjectCriteria();
		$criteria->addEqCritetia('typeName', $this->input->post('txtTypeName'));
        $MachineTypeMasterList = $this->MachineTypeMasterDAO->findAll($criteria);;
        $this->session->set_userdata('MachineTypeMasterList', $MachineTypeMasterList);
            
        $this->load->view('formsuccess');
    }
}

?>