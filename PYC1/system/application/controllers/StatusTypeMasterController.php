<?php

class StatusTypeMasterController extends Controller {

    function _insert() {
        $this->load->helper(array('form', 'url'));
		$this->load->library('form_validation');
        
        //$this->form_validation->set_rules('username', 'Username', 'required');
		//$this->form_validation->set_rules('password', 'Password', 'required');
		//$this->form_validation->set_rules('passconf', 'Password Confirmation', 'required');
		//$this->form_validation->set_rules('email', 'Email', 'required');
        //$this->form_validation->set_rules('txtStatusType', 'StatusType', 'required');    
        //$this->form_validation->set_rules('txtStatusName', 'StatusName', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $StatusTypeMaster = new StatusTypeMaster();
                if ($this->input->post('txtStatusType') != FALSE) {
                    $StatusTypeMaster->statusType = $this->input->post('txtStatusType');
                }
                if ($this->input->post('txtStatusName') != FALSE) {
                    $StatusTypeMaster->statusName = $this->input->post('txtStatusName');
                }
            $this->StatusTypeMasterDAO->insert($StatusTypeMaster); 
            
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
        //$this->form_validation->set_rules('txtStatusType', 'StatusType', 'required');    
        //$this->form_validation->set_rules('txtStatusName', 'StatusName', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $StatusTypeMaster = $this->session->userdata('StatusTypeMaster');
                
                if ($StatusTypeMaster == null) {
                    // TODO move to login page
                }
                
                if ($this->input->post('txtStatusType') != FALSE) {
                    $StatusTypeMaster->statusType = $this->input->post('txtStatusType');
                }
                if ($this->input->post('txtStatusName') != FALSE) {
                    $StatusTypeMaster->statusName = $this->input->post('txtStatusName');
                }
            $this->StatusTypeMasterDAO->update($StatusTypeMaster); 
            
			$this->load->view('formsuccess');
		}
    }

    function _findById() {
        $id = $this->input->post('object_id');
        
        $StatusTypeMaster = $this->StatusTypeMasterDAO->findById($id);;
        $this->session->set_userdata('StatusTypeMaster', $StatusTypeMaster);
            
        $this->load->view('formsuccess');
    }
	
    function _search() {
        $id = $this->input->post('object_id');
        
		$criteria = new ObjectCriteria();
		$criteria->addEqCritetia('statusName', $this->input->post('txtStatusName'));
        $StatusTypeMasterList = $this->StatusTypeMasterDAO->findAll($criteria);;
        $this->session->set_userdata('StatusTypeMasterList', $StatusTypeMasterList);
            
        $this->load->view('formsuccess');
    }
}

?>