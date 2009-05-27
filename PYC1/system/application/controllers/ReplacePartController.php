<?php

class ReplacePartController extends Controller {

    function _insert() {
        $this->load->helper(array('form', 'url'));
		$this->load->library('form_validation');
        
        //$this->form_validation->set_rules('username', 'Username', 'required');
		//$this->form_validation->set_rules('password', 'Password', 'required');
		//$this->form_validation->set_rules('passconf', 'Password Confirmation', 'required');
		//$this->form_validation->set_rules('email', 'Email', 'required');
        //$this->form_validation->set_rules('txtReplacePartId', 'ReplacePartId', 'required');    
        //$this->form_validation->set_rules('txtPartNo', 'PartNo', 'required');    
        //$this->form_validation->set_rules('txtDescription', 'Description', 'required');    
        //$this->form_validation->set_rules('txtQuantity', 'Quantity', 'required');    
        //$this->form_validation->set_rules('txtPriceUsd', 'PriceUsd', 'required');    
        //$this->form_validation->set_rules('txtPriceVnd', 'PriceVnd', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
        //$this->form_validation->set_rules('cbbREQUEST_ID', 'REQUEST_ID', 'required');
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $ReplacePart = new ReplacePart();
                if ($this->input->post('txtReplacePartId') != FALSE) {
                    $ReplacePart->replacePartId = $this->input->post('txtReplacePartId');
                }
                if ($this->input->post('txtPartNo') != FALSE) {
                    $ReplacePart->partNo = $this->input->post('txtPartNo');
                }
                if ($this->input->post('txtDescription') != FALSE) {
                    $ReplacePart->description = $this->input->post('txtDescription');
                }
                if ($this->input->post('txtQuantity') != FALSE) {
                    $ReplacePart->quantity = $this->input->post('txtQuantity');
                }
                if ($this->input->post('txtPriceUsd') != FALSE) {
                    $ReplacePart->priceUsd = $this->input->post('txtPriceUsd');
                }
                if ($this->input->post('txtPriceVnd') != FALSE) {
                    $ReplacePart->priceVnd = $this->input->post('txtPriceVnd');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $ReplacePart->createDate = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $ReplacePart->createUser = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $ReplacePart->updateDate = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $ReplacePart->updateUser = $this->input->post('txtUpdateUser');
                }
                $ReplacePart->request = new Request();
                if ($this->input->post('cbbREQUEST_ID') != FALSE) {
                    $ReplacePart->request->requestId = $this->input->post('cbbREQUEST_ID');
                }
            $this->ReplacePartDAO->insert($ReplacePart); 
            
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
        //$this->form_validation->set_rules('txtReplacePartId', 'ReplacePartId', 'required');    
        //$this->form_validation->set_rules('txtPartNo', 'PartNo', 'required');    
        //$this->form_validation->set_rules('txtDescription', 'Description', 'required');    
        //$this->form_validation->set_rules('txtQuantity', 'Quantity', 'required');    
        //$this->form_validation->set_rules('txtPriceUsd', 'PriceUsd', 'required');    
        //$this->form_validation->set_rules('txtPriceVnd', 'PriceVnd', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
        //$this->form_validation->set_rules('cbbREQUEST_ID', 'REQUEST_ID', 'required');
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $ReplacePart = $this->session->userdata('ReplacePart');
                
                if ($ReplacePart == null) {
                    // TODO move to login page
                }
                
                if ($this->input->post('txtReplacePartId') != FALSE) {
                    $ReplacePart->replacePartId = $this->input->post('txtReplacePartId');
                }
                if ($this->input->post('txtPartNo') != FALSE) {
                    $ReplacePart->partNo = $this->input->post('txtPartNo');
                }
                if ($this->input->post('txtDescription') != FALSE) {
                    $ReplacePart->description = $this->input->post('txtDescription');
                }
                if ($this->input->post('txtQuantity') != FALSE) {
                    $ReplacePart->quantity = $this->input->post('txtQuantity');
                }
                if ($this->input->post('txtPriceUsd') != FALSE) {
                    $ReplacePart->priceUsd = $this->input->post('txtPriceUsd');
                }
                if ($this->input->post('txtPriceVnd') != FALSE) {
                    $ReplacePart->priceVnd = $this->input->post('txtPriceVnd');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $ReplacePart->createDate = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $ReplacePart->createUser = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $ReplacePart->updateDate = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $ReplacePart->updateUser = $this->input->post('txtUpdateUser');
                }
                $ReplacePart->request = new Request();
                if ($this->input->post('cbbREQUEST_ID') != FALSE) {
                    $ReplacePart->request->requestId = $this->input->post('cbbREQUEST_ID');
                }
            $this->ReplacePartDAO->update($ReplacePart); 
            
			$this->load->view('formsuccess');
		}
    }

    function _findById() {
        $id = $this->input->post('object_id');
        
        $ReplacePart = $this->ReplacePartDAO->findById($id);;
        $this->session->set_userdata('ReplacePart', $ReplacePart);
            
        $this->load->view('formsuccess');
    }
	
    function _search() {
        $id = $this->input->post('object_id');
        
		$criteria = new ObjectCriteria();
		$criteria->addEqCritetia('partNo', $this->input->post('txtPartNo'));
		$criteria->addEqCritetia('description', $this->input->post('txtDescription'));
		$criteria->addEqCritetia('quantity', $this->input->post('txtQuantity'));
		$criteria->addEqCritetia('priceUsd', $this->input->post('txtPriceUsd'));
		$criteria->addEqCritetia('priceVnd', $this->input->post('txtPriceVnd'));
		$criteria->addEqCritetia('createDate', $this->input->post('txtCreateDate'));
		$criteria->addEqCritetia('createUser', $this->input->post('txtCreateUser'));
		$criteria->addEqCritetia('updateDate', $this->input->post('txtUpdateDate'));
		$criteria->addEqCritetia('updateUser', $this->input->post('txtUpdateUser'));
        $ReplacePartList = $this->ReplacePartDAO->findAll($criteria);;
        $this->session->set_userdata('ReplacePartList', $ReplacePartList);
            
        $this->load->view('formsuccess');
    }
}

?>