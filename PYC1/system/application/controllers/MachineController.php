<?php

class MachineController extends Controller {

    function _insert() {
        $this->load->helper(array('form', 'url'));
		$this->load->library('form_validation');
        
        //$this->form_validation->set_rules('username', 'Username', 'required');
		//$this->form_validation->set_rules('password', 'Password', 'required');
		//$this->form_validation->set_rules('passconf', 'Password Confirmation', 'required');
		//$this->form_validation->set_rules('email', 'Email', 'required');
        //$this->form_validation->set_rules('txtMachineId', 'MachineId', 'required');    
        //$this->form_validation->set_rules('txtMachineName', 'MachineName', 'required');    
        //$this->form_validation->set_rules('txtSerialNumber', 'SerialNumber', 'required');    
        //$this->form_validation->set_rules('txtModel', 'Model', 'required');    
        //$this->form_validation->set_rules('txtCounterNo', 'CounterNo', 'required');    
        //$this->form_validation->set_rules('txtColor', 'Color', 'required');    
        //$this->form_validation->set_rules('txtFaxTx', 'FaxTx', 'required');    
        //$this->form_validation->set_rules('txtReceiveRx', 'ReceiveRx', 'required');    
        //$this->form_validation->set_rules('txtPreportMaster', 'PreportMaster', 'required');    
        //$this->form_validation->set_rules('txtCopy', 'Copy', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
        //$this->form_validation->set_rules('cbbMACHINE_TYPE', 'MACHINE_TYPE', 'required');
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $Machine = new Machine();
                if ($this->input->post('txtMachineId') != FALSE) {
                    $Machine->machineId = $this->input->post('txtMachineId');
                }
                if ($this->input->post('txtMachineName') != FALSE) {
                    $Machine->machineName = $this->input->post('txtMachineName');
                }
                if ($this->input->post('txtSerialNumber') != FALSE) {
                    $Machine->serialNumber = $this->input->post('txtSerialNumber');
                }
                if ($this->input->post('txtModel') != FALSE) {
                    $Machine->model = $this->input->post('txtModel');
                }
                if ($this->input->post('txtCounterNo') != FALSE) {
                    $Machine->counterNo = $this->input->post('txtCounterNo');
                }
                if ($this->input->post('txtColor') != FALSE) {
                    $Machine->color = $this->input->post('txtColor');
                }
                if ($this->input->post('txtFaxTx') != FALSE) {
                    $Machine->faxTx = $this->input->post('txtFaxTx');
                }
                if ($this->input->post('txtReceiveRx') != FALSE) {
                    $Machine->receiveRx = $this->input->post('txtReceiveRx');
                }
                if ($this->input->post('txtPreportMaster') != FALSE) {
                    $Machine->preportMaster = $this->input->post('txtPreportMaster');
                }
                if ($this->input->post('txtCopy') != FALSE) {
                    $Machine->copy = $this->input->post('txtCopy');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Machine->createDate = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Machine->createUser = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Machine->updateDate = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Machine->updateUser = $this->input->post('txtUpdateUser');
                }
                $Machine->machineTypeMaster = new MachineTypeMaster();
                if ($this->input->post('cbbMACHINE_TYPE') != FALSE) {
                    $Machine->machineTypeMaster->typeId = $this->input->post('cbbMACHINE_TYPE');
                }
            $this->MachineDAO->insert($Machine); 
            
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
        //$this->form_validation->set_rules('txtMachineId', 'MachineId', 'required');    
        //$this->form_validation->set_rules('txtMachineName', 'MachineName', 'required');    
        //$this->form_validation->set_rules('txtSerialNumber', 'SerialNumber', 'required');    
        //$this->form_validation->set_rules('txtModel', 'Model', 'required');    
        //$this->form_validation->set_rules('txtCounterNo', 'CounterNo', 'required');    
        //$this->form_validation->set_rules('txtColor', 'Color', 'required');    
        //$this->form_validation->set_rules('txtFaxTx', 'FaxTx', 'required');    
        //$this->form_validation->set_rules('txtReceiveRx', 'ReceiveRx', 'required');    
        //$this->form_validation->set_rules('txtPreportMaster', 'PreportMaster', 'required');    
        //$this->form_validation->set_rules('txtCopy', 'Copy', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
        //$this->form_validation->set_rules('cbbMACHINE_TYPE', 'MACHINE_TYPE', 'required');
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $Machine = $this->session->userdata('Machine');
                
                if ($Machine == null) {
                    // TODO move to login page
                }
                
                if ($this->input->post('txtMachineId') != FALSE) {
                    $Machine->machineId = $this->input->post('txtMachineId');
                }
                if ($this->input->post('txtMachineName') != FALSE) {
                    $Machine->machineName = $this->input->post('txtMachineName');
                }
                if ($this->input->post('txtSerialNumber') != FALSE) {
                    $Machine->serialNumber = $this->input->post('txtSerialNumber');
                }
                if ($this->input->post('txtModel') != FALSE) {
                    $Machine->model = $this->input->post('txtModel');
                }
                if ($this->input->post('txtCounterNo') != FALSE) {
                    $Machine->counterNo = $this->input->post('txtCounterNo');
                }
                if ($this->input->post('txtColor') != FALSE) {
                    $Machine->color = $this->input->post('txtColor');
                }
                if ($this->input->post('txtFaxTx') != FALSE) {
                    $Machine->faxTx = $this->input->post('txtFaxTx');
                }
                if ($this->input->post('txtReceiveRx') != FALSE) {
                    $Machine->receiveRx = $this->input->post('txtReceiveRx');
                }
                if ($this->input->post('txtPreportMaster') != FALSE) {
                    $Machine->preportMaster = $this->input->post('txtPreportMaster');
                }
                if ($this->input->post('txtCopy') != FALSE) {
                    $Machine->copy = $this->input->post('txtCopy');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Machine->createDate = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Machine->createUser = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Machine->updateDate = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Machine->updateUser = $this->input->post('txtUpdateUser');
                }
                $Machine->machineTypeMaster = new MachineTypeMaster();
                if ($this->input->post('cbbMACHINE_TYPE') != FALSE) {
                    $Machine->machineTypeMaster->typeId = $this->input->post('cbbMACHINE_TYPE');
                }
            $this->MachineDAO->update($Machine); 
            
			$this->load->view('formsuccess');
		}
    }

    function _findById() {
        $id = $this->input->post('object_id');
        
        $Machine = $this->MachineDAO->findById($id);;
        $this->session->set_userdata('Machine', $Machine);
            
        $this->load->view('formsuccess');
    }
	
    function _search() {
        $id = $this->input->post('object_id');
        
		$criteria = new ObjectCriteria();
		$criteria->addEqCritetia('machineName', $this->input->post('txtMachineName'));
		$criteria->addEqCritetia('serialNumber', $this->input->post('txtSerialNumber'));
		$criteria->addEqCritetia('model', $this->input->post('txtModel'));
		$criteria->addEqCritetia('counterNo', $this->input->post('txtCounterNo'));
		$criteria->addEqCritetia('color', $this->input->post('txtColor'));
		$criteria->addEqCritetia('faxTx', $this->input->post('txtFaxTx'));
		$criteria->addEqCritetia('receiveRx', $this->input->post('txtReceiveRx'));
		$criteria->addEqCritetia('preportMaster', $this->input->post('txtPreportMaster'));
		$criteria->addEqCritetia('copy', $this->input->post('txtCopy'));
		$criteria->addEqCritetia('createDate', $this->input->post('txtCreateDate'));
		$criteria->addEqCritetia('createUser', $this->input->post('txtCreateUser'));
		$criteria->addEqCritetia('updateDate', $this->input->post('txtUpdateDate'));
		$criteria->addEqCritetia('updateUser', $this->input->post('txtUpdateUser'));
        $MachineList = $this->MachineDAO->findAll($criteria);;
        $this->session->set_userdata('MachineList', $MachineList);
            
        $this->load->view('formsuccess');
    }
}

?>