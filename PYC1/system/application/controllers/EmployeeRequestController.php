<?php

class EmployeeRequestController extends Controller {

    function _insert() {
        $this->load->helper(array('form', 'url'));
		$this->load->library('form_validation');
        
        //$this->form_validation->set_rules('username', 'Username', 'required');
		//$this->form_validation->set_rules('password', 'Password', 'required');
		//$this->form_validation->set_rules('passconf', 'Password Confirmation', 'required');
		//$this->form_validation->set_rules('email', 'Email', 'required');
        //$this->form_validation->set_rules('txtRequestId', 'RequestId', 'required');    
        //$this->form_validation->set_rules('txtEmployeeId', 'EmployeeId', 'required');    
        //$this->form_validation->set_rules('txtRequestActionTypeId', 'RequestActionTypeId', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $EmployeeRequest = new EmployeeRequest();
                if ($this->input->post('txtRequestId') != FALSE) {
                    $EmployeeRequest->requestId = $this->input->post('txtRequestId');
                }
                if ($this->input->post('txtEmployeeId') != FALSE) {
                    $EmployeeRequest->employeeId = $this->input->post('txtEmployeeId');
                }
                if ($this->input->post('txtRequestActionTypeId') != FALSE) {
                    $EmployeeRequest->requestActionTypeId = $this->input->post('txtRequestActionTypeId');
                }
            $this->EmployeeRequestDAO->insert($EmployeeRequest); 
            
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
        //$this->form_validation->set_rules('txtRequestId', 'RequestId', 'required');    
        //$this->form_validation->set_rules('txtEmployeeId', 'EmployeeId', 'required');    
        //$this->form_validation->set_rules('txtRequestActionTypeId', 'RequestActionTypeId', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $EmployeeRequest = $this->session->userdata('EmployeeRequest');
                
                if ($EmployeeRequest == null) {
                    // TODO move to login page
                }
                
                if ($this->input->post('txtRequestId') != FALSE) {
                    $EmployeeRequest->requestId = $this->input->post('txtRequestId');
                }
                if ($this->input->post('txtEmployeeId') != FALSE) {
                    $EmployeeRequest->employeeId = $this->input->post('txtEmployeeId');
                }
                if ($this->input->post('txtRequestActionTypeId') != FALSE) {
                    $EmployeeRequest->requestActionTypeId = $this->input->post('txtRequestActionTypeId');
                }
            $this->EmployeeRequestDAO->update($EmployeeRequest); 
            
			$this->load->view('formsuccess');
		}
    }

    function _findById() {
        $id = $this->input->post('object_id');
        
        $EmployeeRequest = $this->EmployeeRequestDAO->findById($id);;
        $this->session->set_userdata('EmployeeRequest', $EmployeeRequest);
            
        $this->load->view('formsuccess');
    }
	
    function _search() {
        $id = $this->input->post('object_id');
        
		$criteria = new ObjectCriteria();
        $EmployeeRequestList = $this->EmployeeRequestDAO->findAll($criteria);;
        $this->session->set_userdata('EmployeeRequestList', $EmployeeRequestList);
            
        $this->load->view('formsuccess');
    }
}

?>