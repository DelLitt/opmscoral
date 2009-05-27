<?php

class EmployeeController extends Controller {

    function _insert() {
        $this->load->helper(array('form', 'url'));
		$this->load->library('form_validation');
        
        //$this->form_validation->set_rules('username', 'Username', 'required');
		//$this->form_validation->set_rules('password', 'Password', 'required');
		//$this->form_validation->set_rules('passconf', 'Password Confirmation', 'required');
		//$this->form_validation->set_rules('email', 'Email', 'required');
        //$this->form_validation->set_rules('txtEmployeeId', 'EmployeeId', 'required');    
        //$this->form_validation->set_rules('txtEmployeeName', 'EmployeeName', 'required');    
        //$this->form_validation->set_rules('txtRoleId', 'RoleId', 'required');    
        //$this->form_validation->set_rules('txtAddress', 'Address', 'required');    
        //$this->form_validation->set_rules('txtPhone', 'Phone', 'required');    
        //$this->form_validation->set_rules('txtLoginName', 'LoginName', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
        //$this->form_validation->set_rules('cbbROLE_MASTER_ROLE_ID', 'ROLE_MASTER_ROLE_ID', 'required');
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $Employee = new Employee();
                if ($this->input->post('txtEmployeeId') != FALSE) {
                    $Employee->employeeId = $this->input->post('txtEmployeeId');
                }
                if ($this->input->post('txtEmployeeName') != FALSE) {
                    $Employee->employeeName = $this->input->post('txtEmployeeName');
                }
                if ($this->input->post('txtRoleId') != FALSE) {
                    $Employee->roleId = $this->input->post('txtRoleId');
                }
                if ($this->input->post('txtAddress') != FALSE) {
                    $Employee->address = $this->input->post('txtAddress');
                }
                if ($this->input->post('txtPhone') != FALSE) {
                    $Employee->phone = $this->input->post('txtPhone');
                }
                if ($this->input->post('txtLoginName') != FALSE) {
                    $Employee->loginName = $this->input->post('txtLoginName');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Employee->createDate = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Employee->createUser = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Employee->updateDate = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Employee->updateUser = $this->input->post('txtUpdateUser');
                }
                $Employee->roleMaster = new RoleMaster();
                if ($this->input->post('cbbROLE_MASTER_ROLE_ID') != FALSE) {
                    $Employee->roleMaster->roleId = $this->input->post('cbbROLE_MASTER_ROLE_ID');
                }
            $this->EmployeeDAO->insert($Employee); 
            
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
        //$this->form_validation->set_rules('txtEmployeeId', 'EmployeeId', 'required');    
        //$this->form_validation->set_rules('txtEmployeeName', 'EmployeeName', 'required');    
        //$this->form_validation->set_rules('txtRoleId', 'RoleId', 'required');    
        //$this->form_validation->set_rules('txtAddress', 'Address', 'required');    
        //$this->form_validation->set_rules('txtPhone', 'Phone', 'required');    
        //$this->form_validation->set_rules('txtLoginName', 'LoginName', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
        //$this->form_validation->set_rules('cbbROLE_MASTER_ROLE_ID', 'ROLE_MASTER_ROLE_ID', 'required');
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $Employee = $this->session->userdata('Employee');
                
                if ($Employee == null) {
                    // TODO move to login page
                }
                
                if ($this->input->post('txtEmployeeId') != FALSE) {
                    $Employee->employeeId = $this->input->post('txtEmployeeId');
                }
                if ($this->input->post('txtEmployeeName') != FALSE) {
                    $Employee->employeeName = $this->input->post('txtEmployeeName');
                }
                if ($this->input->post('txtRoleId') != FALSE) {
                    $Employee->roleId = $this->input->post('txtRoleId');
                }
                if ($this->input->post('txtAddress') != FALSE) {
                    $Employee->address = $this->input->post('txtAddress');
                }
                if ($this->input->post('txtPhone') != FALSE) {
                    $Employee->phone = $this->input->post('txtPhone');
                }
                if ($this->input->post('txtLoginName') != FALSE) {
                    $Employee->loginName = $this->input->post('txtLoginName');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Employee->createDate = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Employee->createUser = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Employee->updateDate = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Employee->updateUser = $this->input->post('txtUpdateUser');
                }
                $Employee->roleMaster = new RoleMaster();
                if ($this->input->post('cbbROLE_MASTER_ROLE_ID') != FALSE) {
                    $Employee->roleMaster->roleId = $this->input->post('cbbROLE_MASTER_ROLE_ID');
                }
            $this->EmployeeDAO->update($Employee); 
            
			$this->load->view('formsuccess');
		}
    }

    function _findById() {
        $id = $this->input->post('object_id');
        
        $Employee = $this->EmployeeDAO->findById($id);;
        $this->session->set_userdata('Employee', $Employee);
            
        $this->load->view('formsuccess');
    }
	
    function _search() {
        $id = $this->input->post('object_id');
        
		$criteria = new ObjectCriteria();
		$criteria->addEqCritetia('employeeName', $this->input->post('txtEmployeeName'));
		$criteria->addEqCritetia('roleId', $this->input->post('txtRoleId'));
		$criteria->addEqCritetia('address', $this->input->post('txtAddress'));
		$criteria->addEqCritetia('phone', $this->input->post('txtPhone'));
		$criteria->addEqCritetia('loginName', $this->input->post('txtLoginName'));
		$criteria->addEqCritetia('createDate', $this->input->post('txtCreateDate'));
		$criteria->addEqCritetia('createUser', $this->input->post('txtCreateUser'));
		$criteria->addEqCritetia('updateDate', $this->input->post('txtUpdateDate'));
		$criteria->addEqCritetia('updateUser', $this->input->post('txtUpdateUser'));
        $EmployeeList = $this->EmployeeDAO->findAll($criteria);;
        $this->session->set_userdata('EmployeeList', $EmployeeList);
            
        $this->load->view('formsuccess');
    }
}

?>