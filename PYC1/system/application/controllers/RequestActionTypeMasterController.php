<?php

class RequestActionTypeMasterController extends Controller {

    function _insert() {
        $this->load->helper(array('form', 'url'));
		$this->load->library('form_validation');
        
        //$this->form_validation->set_rules('username', 'Username', 'required');
		//$this->form_validation->set_rules('password', 'Password', 'required');
		//$this->form_validation->set_rules('passconf', 'Password Confirmation', 'required');
		//$this->form_validation->set_rules('email', 'Email', 'required');
        //$this->form_validation->set_rules('txtRequestActionTypeId', 'RequestActionTypeId', 'required');    
        //$this->form_validation->set_rules('txtRequestActionTypeName', 'RequestActionTypeName', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $RequestActionTypeMaster = new RequestActionTypeMaster();
                if ($this->input->post('txtRequestActionTypeId') != FALSE) {
                    $RequestActionTypeMaster->requestActionTypeId = $this->input->post('txtRequestActionTypeId');
                }
                if ($this->input->post('txtRequestActionTypeName') != FALSE) {
                    $RequestActionTypeMaster->requestActionTypeName = $this->input->post('txtRequestActionTypeName');
                }
            $this->RequestActionTypeMasterDAO->insert($RequestActionTypeMaster); 
            
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
        //$this->form_validation->set_rules('txtRequestActionTypeId', 'RequestActionTypeId', 'required');    
        //$this->form_validation->set_rules('txtRequestActionTypeName', 'RequestActionTypeName', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $RequestActionTypeMaster = $this->session->userdata('RequestActionTypeMaster');
                
                if ($RequestActionTypeMaster == null) {
                    // TODO move to login page
                }
                
                if ($this->input->post('txtRequestActionTypeId') != FALSE) {
                    $RequestActionTypeMaster->requestActionTypeId = $this->input->post('txtRequestActionTypeId');
                }
                if ($this->input->post('txtRequestActionTypeName') != FALSE) {
                    $RequestActionTypeMaster->requestActionTypeName = $this->input->post('txtRequestActionTypeName');
                }
            $this->RequestActionTypeMasterDAO->update($RequestActionTypeMaster); 
            
			$this->load->view('formsuccess');
		}
    }

    function _findById() {
        $id = $this->input->post('object_id');
        
        $RequestActionTypeMaster = $this->RequestActionTypeMasterDAO->findById($id);;
        $this->session->set_userdata('RequestActionTypeMaster', $RequestActionTypeMaster);
            
        $this->load->view('formsuccess');
    }
	
    function _search() {
        $id = $this->input->post('object_id');
        
		$criteria = new ObjectCriteria();
		$criteria->addEqCritetia('requestActionTypeName', $this->input->post('txtRequestActionTypeName'));
        $RequestActionTypeMasterList = $this->RequestActionTypeMasterDAO->findAll($criteria);;
        $this->session->set_userdata('RequestActionTypeMasterList', $RequestActionTypeMasterList);
            
        $this->load->view('formsuccess');
    }
}

?>