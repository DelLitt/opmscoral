<?php

class RoleMasterController extends Controller {

    function _insert() {
        $this->load->helper(array('form', 'url'));
		$this->load->library('form_validation');
        
        //$this->form_validation->set_rules('username', 'Username', 'required');
		//$this->form_validation->set_rules('password', 'Password', 'required');
		//$this->form_validation->set_rules('passconf', 'Password Confirmation', 'required');
		//$this->form_validation->set_rules('email', 'Email', 'required');
        //$this->form_validation->set_rules('txtRoleId', 'RoleId', 'required');    
        //$this->form_validation->set_rules('txtRoleName', 'RoleName', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $RoleMaster = new RoleMaster();
                if ($this->input->post('txtRoleId') != FALSE) {
                    $RoleMaster->roleId = $this->input->post('txtRoleId');
                }
                if ($this->input->post('txtRoleName') != FALSE) {
                    $RoleMaster->roleName = $this->input->post('txtRoleName');
                }
            $this->RoleMasterDAO->insert($RoleMaster); 
            
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
        //$this->form_validation->set_rules('txtRoleId', 'RoleId', 'required');    
        //$this->form_validation->set_rules('txtRoleName', 'RoleName', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $RoleMaster = $this->session->userdata('RoleMaster');
                
                if ($RoleMaster == null) {
                    // TODO move to login page
                }
                
                if ($this->input->post('txtRoleId') != FALSE) {
                    $RoleMaster->roleId = $this->input->post('txtRoleId');
                }
                if ($this->input->post('txtRoleName') != FALSE) {
                    $RoleMaster->roleName = $this->input->post('txtRoleName');
                }
            $this->RoleMasterDAO->update($RoleMaster); 
            
			$this->load->view('formsuccess');
		}
    }

    function _findById() {
        $id = $this->input->post('object_id');
        
        $RoleMaster = $this->RoleMasterDAO->findById($id);;
        $this->session->set_userdata('RoleMaster', $RoleMaster);
            
        $this->load->view('formsuccess');
    }
	
    function _search() {
        $id = $this->input->post('object_id');
        
		$criteria = new ObjectCriteria();
		$criteria->addEqCritetia('roleName', $this->input->post('txtRoleName'));
        $RoleMasterList = $this->RoleMasterDAO->findAll($criteria);;
        $this->session->set_userdata('RoleMasterList', $RoleMasterList);
            
        $this->load->view('formsuccess');
    }
}

?>