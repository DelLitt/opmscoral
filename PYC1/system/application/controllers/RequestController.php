<?php

class RequestController extends Controller {

    function _insert() {
        $this->load->helper(array('form', 'url'));
		$this->load->library('form_validation');
        
        //$this->form_validation->set_rules('username', 'Username', 'required');
		//$this->form_validation->set_rules('password', 'Password', 'required');
		//$this->form_validation->set_rules('passconf', 'Password Confirmation', 'required');
		//$this->form_validation->set_rules('email', 'Email', 'required');
        //$this->form_validation->set_rules('txtRequestId', 'RequestId', 'required');    
        //$this->form_validation->set_rules('txtMachineId', 'MachineId', 'required');    
        //$this->form_validation->set_rules('txtFollowUpRequestId', 'FollowUpRequestId', 'required');    
        //$this->form_validation->set_rules('txtCustomerCallDate', 'CustomerCallDate', 'required');    
        //$this->form_validation->set_rules('txtReportDate', 'ReportDate', 'required');    
        //$this->form_validation->set_rules('txtFinishDate', 'FinishDate', 'required');    
        //$this->form_validation->set_rules('txtServiceType', 'ServiceType', 'required');    
        //$this->form_validation->set_rules('txtProblemReport', 'ProblemReport', 'required');    
        //$this->form_validation->set_rules('txtSymptom', 'Symptom', 'required');    
        //$this->form_validation->set_rules('txtCause', 'Cause', 'required');    
        //$this->form_validation->set_rules('txtAction', 'Action', 'required');    
        //$this->form_validation->set_rules('txtCustomerOpinion', 'CustomerOpinion', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
        //$this->form_validation->set_rules('txtRequestCost', 'RequestCost', 'required');    
        //$this->form_validation->set_rules('txtTempCustomerName', 'TempCustomerName', 'required');    
        //$this->form_validation->set_rules('txtTempCompanyName', 'TempCompanyName', 'required');    
        //$this->form_validation->set_rules('txtTempAddress', 'TempAddress', 'required');    
        //$this->form_validation->set_rules('txtTempPhone', 'TempPhone', 'required');    
        //$this->form_validation->set_rules('txtTempFax', 'TempFax', 'required');    
        //$this->form_validation->set_rules('cbbCONTRACT_ID', 'CONTRACT_ID', 'required');
        //$this->form_validation->set_rules('cbbCUSTOMER_ID', 'CUSTOMER_ID', 'required');
        //$this->form_validation->set_rules('cbbCOMPANY_ID', 'COMPANY_ID', 'required');
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $Request = new Request();
                if ($this->input->post('txtRequestId') != FALSE) {
                    $Request->requestId = $this->input->post('txtRequestId');
                }
                if ($this->input->post('txtMachineId') != FALSE) {
                    $Request->machineId = $this->input->post('txtMachineId');
                }
                if ($this->input->post('txtFollowUpRequestId') != FALSE) {
                    $Request->followUpRequestId = $this->input->post('txtFollowUpRequestId');
                }
                if ($this->input->post('txtCustomerCallDate') != FALSE) {
                    $Request->customerCallDate = $this->input->post('txtCustomerCallDate');
                }
                if ($this->input->post('txtReportDate') != FALSE) {
                    $Request->reportDate = $this->input->post('txtReportDate');
                }
                if ($this->input->post('txtFinishDate') != FALSE) {
                    $Request->finishDate = $this->input->post('txtFinishDate');
                }
                if ($this->input->post('txtServiceType') != FALSE) {
                    $Request->serviceType = $this->input->post('txtServiceType');
                }
                if ($this->input->post('txtProblemReport') != FALSE) {
                    $Request->problemReport = $this->input->post('txtProblemReport');
                }
                if ($this->input->post('txtSymptom') != FALSE) {
                    $Request->symptom = $this->input->post('txtSymptom');
                }
                if ($this->input->post('txtCause') != FALSE) {
                    $Request->cause = $this->input->post('txtCause');
                }
                if ($this->input->post('txtAction') != FALSE) {
                    $Request->action = $this->input->post('txtAction');
                }
                if ($this->input->post('txtCustomerOpinion') != FALSE) {
                    $Request->customerOpinion = $this->input->post('txtCustomerOpinion');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Request->createDate = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Request->createUser = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Request->updateDate = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Request->updateUser = $this->input->post('txtUpdateUser');
                }
                if ($this->input->post('txtRequestCost') != FALSE) {
                    $Request->requestCost = $this->input->post('txtRequestCost');
                }
                if ($this->input->post('txtTempCustomerName') != FALSE) {
                    $Request->tempCustomerName = $this->input->post('txtTempCustomerName');
                }
                if ($this->input->post('txtTempCompanyName') != FALSE) {
                    $Request->tempCompanyName = $this->input->post('txtTempCompanyName');
                }
                if ($this->input->post('txtTempAddress') != FALSE) {
                    $Request->tempAddress = $this->input->post('txtTempAddress');
                }
                if ($this->input->post('txtTempPhone') != FALSE) {
                    $Request->tempPhone = $this->input->post('txtTempPhone');
                }
                if ($this->input->post('txtTempFax') != FALSE) {
                    $Request->tempFax = $this->input->post('txtTempFax');
                }
                $Request->contract = new Contract();
                if ($this->input->post('cbbCONTRACT_ID') != FALSE) {
                    $Request->contract->contractId = $this->input->post('cbbCONTRACT_ID');
                }
                $Request->customer = new Customer();
                if ($this->input->post('cbbCUSTOMER_ID') != FALSE) {
                    $Request->customer->customerId = $this->input->post('cbbCUSTOMER_ID');
                }
                $Request->company = new Company();
                if ($this->input->post('cbbCOMPANY_ID') != FALSE) {
                    $Request->company->companyId = $this->input->post('cbbCOMPANY_ID');
                }
            $this->RequestDAO->insert($Request); 
            
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
        //$this->form_validation->set_rules('txtMachineId', 'MachineId', 'required');    
        //$this->form_validation->set_rules('txtFollowUpRequestId', 'FollowUpRequestId', 'required');    
        //$this->form_validation->set_rules('txtCustomerCallDate', 'CustomerCallDate', 'required');    
        //$this->form_validation->set_rules('txtReportDate', 'ReportDate', 'required');    
        //$this->form_validation->set_rules('txtFinishDate', 'FinishDate', 'required');    
        //$this->form_validation->set_rules('txtServiceType', 'ServiceType', 'required');    
        //$this->form_validation->set_rules('txtProblemReport', 'ProblemReport', 'required');    
        //$this->form_validation->set_rules('txtSymptom', 'Symptom', 'required');    
        //$this->form_validation->set_rules('txtCause', 'Cause', 'required');    
        //$this->form_validation->set_rules('txtAction', 'Action', 'required');    
        //$this->form_validation->set_rules('txtCustomerOpinion', 'CustomerOpinion', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
        //$this->form_validation->set_rules('txtRequestCost', 'RequestCost', 'required');    
        //$this->form_validation->set_rules('txtTempCustomerName', 'TempCustomerName', 'required');    
        //$this->form_validation->set_rules('txtTempCompanyName', 'TempCompanyName', 'required');    
        //$this->form_validation->set_rules('txtTempAddress', 'TempAddress', 'required');    
        //$this->form_validation->set_rules('txtTempPhone', 'TempPhone', 'required');    
        //$this->form_validation->set_rules('txtTempFax', 'TempFax', 'required');    
        //$this->form_validation->set_rules('cbbCONTRACT_ID', 'CONTRACT_ID', 'required');
        //$this->form_validation->set_rules('cbbCUSTOMER_ID', 'CUSTOMER_ID', 'required');
        //$this->form_validation->set_rules('cbbCOMPANY_ID', 'COMPANY_ID', 'required');
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $Request = $this->session->userdata('Request');
                
                if ($Request == null) {
                    // TODO move to login page
                }
                
                if ($this->input->post('txtRequestId') != FALSE) {
                    $Request->requestId = $this->input->post('txtRequestId');
                }
                if ($this->input->post('txtMachineId') != FALSE) {
                    $Request->machineId = $this->input->post('txtMachineId');
                }
                if ($this->input->post('txtFollowUpRequestId') != FALSE) {
                    $Request->followUpRequestId = $this->input->post('txtFollowUpRequestId');
                }
                if ($this->input->post('txtCustomerCallDate') != FALSE) {
                    $Request->customerCallDate = $this->input->post('txtCustomerCallDate');
                }
                if ($this->input->post('txtReportDate') != FALSE) {
                    $Request->reportDate = $this->input->post('txtReportDate');
                }
                if ($this->input->post('txtFinishDate') != FALSE) {
                    $Request->finishDate = $this->input->post('txtFinishDate');
                }
                if ($this->input->post('txtServiceType') != FALSE) {
                    $Request->serviceType = $this->input->post('txtServiceType');
                }
                if ($this->input->post('txtProblemReport') != FALSE) {
                    $Request->problemReport = $this->input->post('txtProblemReport');
                }
                if ($this->input->post('txtSymptom') != FALSE) {
                    $Request->symptom = $this->input->post('txtSymptom');
                }
                if ($this->input->post('txtCause') != FALSE) {
                    $Request->cause = $this->input->post('txtCause');
                }
                if ($this->input->post('txtAction') != FALSE) {
                    $Request->action = $this->input->post('txtAction');
                }
                if ($this->input->post('txtCustomerOpinion') != FALSE) {
                    $Request->customerOpinion = $this->input->post('txtCustomerOpinion');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Request->createDate = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Request->createUser = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Request->updateDate = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Request->updateUser = $this->input->post('txtUpdateUser');
                }
                if ($this->input->post('txtRequestCost') != FALSE) {
                    $Request->requestCost = $this->input->post('txtRequestCost');
                }
                if ($this->input->post('txtTempCustomerName') != FALSE) {
                    $Request->tempCustomerName = $this->input->post('txtTempCustomerName');
                }
                if ($this->input->post('txtTempCompanyName') != FALSE) {
                    $Request->tempCompanyName = $this->input->post('txtTempCompanyName');
                }
                if ($this->input->post('txtTempAddress') != FALSE) {
                    $Request->tempAddress = $this->input->post('txtTempAddress');
                }
                if ($this->input->post('txtTempPhone') != FALSE) {
                    $Request->tempPhone = $this->input->post('txtTempPhone');
                }
                if ($this->input->post('txtTempFax') != FALSE) {
                    $Request->tempFax = $this->input->post('txtTempFax');
                }
                $Request->contract = new Contract();
                if ($this->input->post('cbbCONTRACT_ID') != FALSE) {
                    $Request->contract->contractId = $this->input->post('cbbCONTRACT_ID');
                }
                $Request->customer = new Customer();
                if ($this->input->post('cbbCUSTOMER_ID') != FALSE) {
                    $Request->customer->customerId = $this->input->post('cbbCUSTOMER_ID');
                }
                $Request->company = new Company();
                if ($this->input->post('cbbCOMPANY_ID') != FALSE) {
                    $Request->company->companyId = $this->input->post('cbbCOMPANY_ID');
                }
            $this->RequestDAO->update($Request); 
            
			$this->load->view('formsuccess');
		}
    }

    function _findById() {
        $id = $this->input->post('object_id');
        
        $Request = $this->RequestDAO->findById($id);;
        $this->session->set_userdata('Request', $Request);
            
        $this->load->view('formsuccess');
    }
	
    function _search() {
        $id = $this->input->post('object_id');
        
		$criteria = new ObjectCriteria();
		$criteria->addEqCritetia('machineId', $this->input->post('txtMachineId'));
		$criteria->addEqCritetia('followUpRequestId', $this->input->post('txtFollowUpRequestId'));
		$criteria->addEqCritetia('customerCallDate', $this->input->post('txtCustomerCallDate'));
		$criteria->addEqCritetia('reportDate', $this->input->post('txtReportDate'));
		$criteria->addEqCritetia('finishDate', $this->input->post('txtFinishDate'));
		$criteria->addEqCritetia('serviceType', $this->input->post('txtServiceType'));
		$criteria->addEqCritetia('problemReport', $this->input->post('txtProblemReport'));
		$criteria->addEqCritetia('symptom', $this->input->post('txtSymptom'));
		$criteria->addEqCritetia('cause', $this->input->post('txtCause'));
		$criteria->addEqCritetia('action', $this->input->post('txtAction'));
		$criteria->addEqCritetia('customerOpinion', $this->input->post('txtCustomerOpinion'));
		$criteria->addEqCritetia('createDate', $this->input->post('txtCreateDate'));
		$criteria->addEqCritetia('createUser', $this->input->post('txtCreateUser'));
		$criteria->addEqCritetia('updateDate', $this->input->post('txtUpdateDate'));
		$criteria->addEqCritetia('updateUser', $this->input->post('txtUpdateUser'));
		$criteria->addEqCritetia('requestCost', $this->input->post('txtRequestCost'));
		$criteria->addEqCritetia('tempCustomerName', $this->input->post('txtTempCustomerName'));
		$criteria->addEqCritetia('tempCompanyName', $this->input->post('txtTempCompanyName'));
		$criteria->addEqCritetia('tempAddress', $this->input->post('txtTempAddress'));
		$criteria->addEqCritetia('tempPhone', $this->input->post('txtTempPhone'));
		$criteria->addEqCritetia('tempFax', $this->input->post('txtTempFax'));
        $RequestList = $this->RequestDAO->findAll($criteria);;
        $this->session->set_userdata('RequestList', $RequestList);
            
        $this->load->view('formsuccess');
    }
}

?>