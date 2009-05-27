<?php

class RequestStatusController extends Controller {

    function _insert() {
        $this->load->helper(array('form', 'url'));
		$this->load->library('form_validation');
        
        //$this->form_validation->set_rules('username', 'Username', 'required');
		//$this->form_validation->set_rules('password', 'Password', 'required');
		//$this->form_validation->set_rules('passconf', 'Password Confirmation', 'required');
		//$this->form_validation->set_rules('email', 'Email', 'required');
        //$this->form_validation->set_rules('txtRequestStatusId', 'RequestStatusId', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
        //$this->form_validation->set_rules('txtDescription', 'Description', 'required');    
        //$this->form_validation->set_rules('cbbSTATUS_TYPE', 'STATUS_TYPE', 'required');
        //$this->form_validation->set_rules('cbbREQUEST_ID', 'REQUEST_ID', 'required');
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $RequestStatus = new RequestStatus();
                if ($this->input->post('txtRequestStatusId') != FALSE) {
                    $RequestStatus->requestStatusId = $this->input->post('txtRequestStatusId');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $RequestStatus->createDate = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $RequestStatus->createUser = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $RequestStatus->updateDate = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $RequestStatus->updateUser = $this->input->post('txtUpdateUser');
                }
                if ($this->input->post('txtDescription') != FALSE) {
                    $RequestStatus->description = $this->input->post('txtDescription');
                }
                $RequestStatus->statusTypeMaster = new StatusTypeMaster();
                if ($this->input->post('cbbSTATUS_TYPE') != FALSE) {
                    $RequestStatus->statusTypeMaster->statusType = $this->input->post('cbbSTATUS_TYPE');
                }
                $RequestStatus->request = new Request();
                if ($this->input->post('cbbREQUEST_ID') != FALSE) {
                    $RequestStatus->request->requestId = $this->input->post('cbbREQUEST_ID');
                }
            $this->RequestStatusDAO->insert($RequestStatus); 
            
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
        //$this->form_validation->set_rules('txtRequestStatusId', 'RequestStatusId', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
        //$this->form_validation->set_rules('txtDescription', 'Description', 'required');    
        //$this->form_validation->set_rules('cbbSTATUS_TYPE', 'STATUS_TYPE', 'required');
        //$this->form_validation->set_rules('cbbREQUEST_ID', 'REQUEST_ID', 'required');
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $RequestStatus = $this->session->userdata('RequestStatus');
                
                if ($RequestStatus == null) {
                    // TODO move to login page
                }
                
                if ($this->input->post('txtRequestStatusId') != FALSE) {
                    $RequestStatus->requestStatusId = $this->input->post('txtRequestStatusId');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $RequestStatus->createDate = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $RequestStatus->createUser = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $RequestStatus->updateDate = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $RequestStatus->updateUser = $this->input->post('txtUpdateUser');
                }
                if ($this->input->post('txtDescription') != FALSE) {
                    $RequestStatus->description = $this->input->post('txtDescription');
                }
                $RequestStatus->statusTypeMaster = new StatusTypeMaster();
                if ($this->input->post('cbbSTATUS_TYPE') != FALSE) {
                    $RequestStatus->statusTypeMaster->statusType = $this->input->post('cbbSTATUS_TYPE');
                }
                $RequestStatus->request = new Request();
                if ($this->input->post('cbbREQUEST_ID') != FALSE) {
                    $RequestStatus->request->requestId = $this->input->post('cbbREQUEST_ID');
                }
            $this->RequestStatusDAO->update($RequestStatus); 
            
			$this->load->view('formsuccess');
		}
    }

    function _findById() {
        $id = $this->input->post('object_id');
        
        $RequestStatus = $this->RequestStatusDAO->findById($id);;
        $this->session->set_userdata('RequestStatus', $RequestStatus);
            
        $this->load->view('formsuccess');
    }
	
    function _search() {
        $id = $this->input->post('object_id');
        
		$criteria = new ObjectCriteria();
		$criteria->addEqCritetia('createDate', $this->input->post('txtCreateDate'));
		$criteria->addEqCritetia('createUser', $this->input->post('txtCreateUser'));
		$criteria->addEqCritetia('updateDate', $this->input->post('txtUpdateDate'));
		$criteria->addEqCritetia('updateUser', $this->input->post('txtUpdateUser'));
		$criteria->addEqCritetia('description', $this->input->post('txtDescription'));
        $RequestStatusList = $this->RequestStatusDAO->findAll($criteria);;
        $this->session->set_userdata('RequestStatusList', $RequestStatusList);
            
        $this->load->view('formsuccess');
    }
}

?>