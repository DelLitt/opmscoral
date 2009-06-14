<?php
require "./system/application/helpers/ObjectCriteria.php";
require "./system/application/helpers/ColumnHelper.php";

class RequestController extends Controller {

	function index() {
	    $this->load->model('RequestModel');
		$action = $this->input->get_post('action');

		if ($action == FALSE) {
			$data = array('searchResult' => null, 'criteria' => null);
			$this->load->view('TimHopDong', $data);
		} else if ($action == 'search') {
			$this->_search();
		} else if ($action == 'next') {
			$this->_next();
		} else if ($action == 'sort') {
			$this->_sort();
        } else if ($action == 'edit') {
            $this->_viewEdit();
        } else if ($action == 'save') {
            $this->_update();
		} else if ($action == 'add_new_screen') {
			$data = array('Contract' => null, 'ContractTypeMasterList' => array());
			$this->load->view('TaoHopDong', $data);
		} else {
			show_error($action);
		}
	}


    function _insert() {
        $this->load->helper(array('form', 'url'));
		$this->load->library('form_validation');
        
        //$this->form_validation->set_rules('username', 'Username', 'required');
		//$this->form_validation->set_rules('password', 'Password', 'required');
		//$this->form_validation->set_rules('passconf', 'Password Confirmation', 'required');
		//$this->form_validation->set_rules('email', 'Email', 'required');
        //$this->form_validation->set_rules('txtRequestId', 'RequestId', 'required');    
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
        //$this->form_validation->set_rules('cbbMACHINE_ID', 'MACHINE_ID', 'required');
        //$this->form_validation->set_rules('cbbCOMPANY_ID', 'COMPANY_ID', 'required');
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $Request = array();
                if ($this->input->post('txtRequestId') != FALSE) {
                    $Request['requestId'] = $this->input->post('txtRequestId');
                }
                if ($this->input->post('txtFollowUpRequestId') != FALSE) {
                    $Request['followUpRequestId'] = $this->input->post('txtFollowUpRequestId');
                }
                if ($this->input->post('txtCustomerCallDate') != FALSE) {
                    $Request['customerCallDate'] = $this->input->post('txtCustomerCallDate');
                }
                if ($this->input->post('txtReportDate') != FALSE) {
                    $Request['reportDate'] = $this->input->post('txtReportDate');
                }
                if ($this->input->post('txtFinishDate') != FALSE) {
                    $Request['finishDate'] = $this->input->post('txtFinishDate');
                }
                if ($this->input->post('txtServiceType') != FALSE) {
                    $Request['serviceType'] = $this->input->post('txtServiceType');
                }
                if ($this->input->post('txtProblemReport') != FALSE) {
                    $Request['problemReport'] = $this->input->post('txtProblemReport');
                }
                if ($this->input->post('txtSymptom') != FALSE) {
                    $Request['symptom'] = $this->input->post('txtSymptom');
                }
                if ($this->input->post('txtCause') != FALSE) {
                    $Request['cause'] = $this->input->post('txtCause');
                }
                if ($this->input->post('txtAction') != FALSE) {
                    $Request['action'] = $this->input->post('txtAction');
                }
                if ($this->input->post('txtCustomerOpinion') != FALSE) {
                    $Request['customerOpinion'] = $this->input->post('txtCustomerOpinion');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Request['createDate'] = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Request['createUser'] = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Request['updateDate'] = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Request['updateUser'] = $this->input->post('txtUpdateUser');
                }
                if ($this->input->post('txtRequestCost') != FALSE) {
                    $Request['requestCost'] = $this->input->post('txtRequestCost');
                }
                if ($this->input->post('txtTempCustomerName') != FALSE) {
                    $Request['tempCustomerName'] = $this->input->post('txtTempCustomerName');
                }
                if ($this->input->post('txtTempCompanyName') != FALSE) {
                    $Request['tempCompanyName'] = $this->input->post('txtTempCompanyName');
                }
                if ($this->input->post('txtTempAddress') != FALSE) {
                    $Request['tempAddress'] = $this->input->post('txtTempAddress');
                }
                if ($this->input->post('txtTempPhone') != FALSE) {
                    $Request['tempPhone'] = $this->input->post('txtTempPhone');
                }
                if ($this->input->post('txtTempFax') != FALSE) {
                    $Request['tempFax'] = $this->input->post('txtTempFax');
                }
                if ($this->input->post('cbbCONTRACT_ID') != FALSE) {
                    $Request['contract.contractId'] = $this->input->post('cbbCONTRACT_ID');
                }
                if ($this->input->post('cbbCUSTOMER_ID') != FALSE) {
                    $Request['customer.customerId'] = $this->input->post('cbbCUSTOMER_ID');
                }
                if ($this->input->post('cbbMACHINE_ID') != FALSE) {
                    $Request['machine.machineId'] = $this->input->post('cbbMACHINE_ID');
                }
                if ($this->input->post('cbbCOMPANY_ID') != FALSE) {
                    $Request['company.companyId'] = $this->input->post('cbbCOMPANY_ID');
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
        //$this->form_validation->set_rules('cbbMACHINE_ID', 'MACHINE_ID', 'required');
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
                    $Request['requestId'] = $this->input->post('txtRequestId');
                }
                if ($this->input->post('txtFollowUpRequestId') != FALSE) {
                    $Request['followUpRequestId'] = $this->input->post('txtFollowUpRequestId');
                }
                if ($this->input->post('txtCustomerCallDate') != FALSE) {
                    $Request['customerCallDate'] = $this->input->post('txtCustomerCallDate');
                }
                if ($this->input->post('txtReportDate') != FALSE) {
                    $Request['reportDate'] = $this->input->post('txtReportDate');
                }
                if ($this->input->post('txtFinishDate') != FALSE) {
                    $Request['finishDate'] = $this->input->post('txtFinishDate');
                }
                if ($this->input->post('txtServiceType') != FALSE) {
                    $Request['serviceType'] = $this->input->post('txtServiceType');
                }
                if ($this->input->post('txtProblemReport') != FALSE) {
                    $Request['problemReport'] = $this->input->post('txtProblemReport');
                }
                if ($this->input->post('txtSymptom') != FALSE) {
                    $Request['symptom'] = $this->input->post('txtSymptom');
                }
                if ($this->input->post('txtCause') != FALSE) {
                    $Request['cause'] = $this->input->post('txtCause');
                }
                if ($this->input->post('txtAction') != FALSE) {
                    $Request['action'] = $this->input->post('txtAction');
                }
                if ($this->input->post('txtCustomerOpinion') != FALSE) {
                    $Request['customerOpinion'] = $this->input->post('txtCustomerOpinion');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Request['createDate'] = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Request['createUser'] = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Request['updateDate'] = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Request['updateUser'] = $this->input->post('txtUpdateUser');
                }
                if ($this->input->post('txtRequestCost') != FALSE) {
                    $Request['requestCost'] = $this->input->post('txtRequestCost');
                }
                if ($this->input->post('txtTempCustomerName') != FALSE) {
                    $Request['tempCustomerName'] = $this->input->post('txtTempCustomerName');
                }
                if ($this->input->post('txtTempCompanyName') != FALSE) {
                    $Request['tempCompanyName'] = $this->input->post('txtTempCompanyName');
                }
                if ($this->input->post('txtTempAddress') != FALSE) {
                    $Request['tempAddress'] = $this->input->post('txtTempAddress');
                }
                if ($this->input->post('txtTempPhone') != FALSE) {
                    $Request['tempPhone'] = $this->input->post('txtTempPhone');
                }
                if ($this->input->post('txtTempFax') != FALSE) {
                    $Request['tempFax'] = $this->input->post('txtTempFax');
                }
                if ($this->input->post('cbbCONTRACT_ID') != FALSE) {
                    $Request['contract.contractId'] = $this->input->post('cbbCONTRACT_ID');
                }
                if ($this->input->post('cbbCUSTOMER_ID') != FALSE) {
                    $Request['customer.customerId'] = $this->input->post('cbbCUSTOMER_ID');
                }
                if ($this->input->post('cbbMACHINE_ID') != FALSE) {
                    $Request['machine.machineId'] = $this->input->post('cbbMACHINE_ID');
                }
                if ($this->input->post('cbbCOMPANY_ID') != FALSE) {
                    $Request['company.companyId'] = $this->input->post('cbbCOMPANY_ID');
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
	
    function _buildTable($InList, $pageNum, $criteria) {
        $str = '<table border="0" cellpadding="0" cellspacing="0" class="data">';
        $str .= '<tr class="sort">';
        $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="requestId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.requestId').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'requestId' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="followUpRequestId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.followUpRequestId').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'followUpRequestId' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="customerCallDate";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.customerCallDate').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'customerCallDate' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="reportDate";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.reportDate').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'reportDate' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="finishDate";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.finishDate').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'finishDate' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="serviceType";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.serviceType').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'serviceType' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="problemReport";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.problemReport').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'problemReport' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="symptom";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.symptom').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'symptom' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="cause";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.cause').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'cause' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="action";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.action').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'action' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="customerOpinion";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.customerOpinion').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'customerOpinion' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="createDate";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.createDate').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'createDate' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="createUser";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.createUser').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'createUser' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="updateDate";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.updateDate').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'updateDate' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="updateUser";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.updateUser').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'updateUser' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="requestCost";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.requestCost').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'requestCost' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="tempCustomerName";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.tempCustomerName').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'tempCustomerName' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="tempCompanyName";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.tempCompanyName').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'tempCompanyName' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="tempAddress";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.tempAddress').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'tempAddress' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="tempPhone";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.tempPhone').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'tempPhone' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="tempFax";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.tempFax').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'tempFax' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="contract.contractId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Contract.contractId').'</a>';				
        if ($criteria != null && count($criteria) > 0 && 'contractId' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="customer.customerId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Customer.customerId').'</a>';				
        if ($criteria != null && count($criteria) > 0 && 'customerId' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="machine.machineId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Machine.machineId').'</a>';				
        if ($criteria != null && count($criteria) > 0 && 'machineId' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="company.companyId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Company.companyId').'</a>';				
        if ($criteria != null && count($criteria) > 0 && 'companyId' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
		
        $str .= '</tr>';
        $i = 1;
        foreach ($InList as $data) {
            $str .= '<tr '.($i % 2 != 0 ? 'class="odd"' : '').">";
            $str .= '<td>'.$data['requestId'].'</td>';
            $str .= '<td>'.$data['followUpRequestId'].'</td>';
            $str .= '<td>'.$data['customerCallDate'].'</td>';
            $str .= '<td>'.$data['reportDate'].'</td>';
            $str .= '<td>'.$data['finishDate'].'</td>';
            $str .= '<td>'.$data['serviceType'].'</td>';
            $str .= '<td>'.$data['problemReport'].'</td>';
            $str .= '<td>'.$data['symptom'].'</td>';
            $str .= '<td>'.$data['cause'].'</td>';
            $str .= '<td>'.$data['action'].'</td>';
            $str .= '<td>'.$data['customerOpinion'].'</td>';
            $str .= '<td>'.$data['createDate'].'</td>';
            $str .= '<td>'.$data['createUser'].'</td>';
            $str .= '<td>'.$data['updateDate'].'</td>';
            $str .= '<td>'.$data['updateUser'].'</td>';
            $str .= '<td>'.$data['requestCost'].'</td>';
            $str .= '<td>'.$data['tempCustomerName'].'</td>';
            $str .= '<td>'.$data['tempCompanyName'].'</td>';
            $str .= '<td>'.$data['tempAddress'].'</td>';
            $str .= '<td>'.$data['tempPhone'].'</td>';
            $str .= '<td>'.$data['tempFax'].'</td>';
            $str .= '<td>'.$data['contract.contractId'].'</td>';				
            $str .= '<td>'.$data['customer.customerId'].'</td>';				
            $str .= '<td>'.$data['machine.machineId'].'</td>';				
            $str .= '<td>'.$data['company.companyId'].'</td>';				
            //$str .= '<td>'.($contract->contractDate != null ? date("d/m/Y H:i:s", strtotime($contract->contractDate)) : '') .'</td>';
            $str .= '</tr>';
            $i++;
        }
        $str .= '</table>';
        
        return $str;
    }
	
    function _sort() {
	    $order_by = 'requestId';
		if ($this->input->post('hidOrderBy') != FALSE) {
			$order_by = $this->input->post('hidOrderBy');
		}

		$criteria = null;
		if (isset($_SESSION['criteria'])) {
			$criteria = $_SESSION['criteria'];
		} else {
			$criteria = array();
		}
		
		$sort_order = FALSE;
		if (isset($criteria['orderField']) && $order_by == $criteria['orderField']) {
			if ($this->input->post('hidSortOrder') == '') {
				$sort_order = TRUE;
			} else {
				$sort_order = FALSE;
			}
		}

        //echo $criteria;
        ObjectCriteria::clearOrder($criteria);
        ObjectCriteria::addOrder($criteria, ColumnHelper::mapContractColumn($order_by), $sort_order);
        $criteria['orderField'] = $order_by;
        $criteria['orderDirection'] = $sort_order;
        $_SESSION['criteria'] = $criteria;
        
        $this->_doSearch($criteria);
    }
	
    function _next() {
        $criteria = null;
        if (isset($_SESSION['criteria'])) {
            $criteria = $_SESSION['criteria'];
        } else {
            $criteria = array();
        }
        
        $pageNumber = $this->uri->segment(5, 0);
        
        $criteria['pageNumber'] = $pageNumber;
        
        $this->_doSearch($criteria, 5);
    }
	
    function _doSearch($criteria, $pageSegment = 0) {
		$DataList = $this->RequestModel->findPaging($criteria);
		$countSearch = $this->RequestModel->count($criteria);
		
        $searchResult = '';
        if (count($DataList) == 0) {
            $searchResult = "Không tìm thấy dữ liệu";
        } else {
            $searchResult = $this->_buildTable($DataList, $criteria['pageNumber'], $criteria);
            
            $config['base_url'] = base_url().'index.php?c=requestcontroller&action=next';
            $config['total_rows'] = $countSearch;
            $config['per_page'] = $criteria['recordPerPage'];
            $config['uri_segment'] = $pageSegment;
            $config['page_query_string'] = TRUE;
            $config['query_string_segment'] = 'current_page';
            $this->pagination->initialize($config); 
            
            $searchResult .= '<br/>'.($this->pagination->create_links()); 
        }
        
        $data = array('searchResult' => $searchResult, 
                      'criteria' => $criteria);
  	    
        $this->load->view('TimHopDong', $data);
    }
	
    function _search() {
		$criteria = array();
		$criteria['where'] = array();
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('requestId'), $this->input->post('txtRequestId'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('followUpRequestId'), $this->input->post('txtFollowUpRequestId'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('customerCallDate'), $this->input->post('txtCustomerCallDate'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('reportDate'), $this->input->post('txtReportDate'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('finishDate'), $this->input->post('txtFinishDate'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('serviceType'), $this->input->post('txtServiceType'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('problemReport'), $this->input->post('txtProblemReport'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('symptom'), $this->input->post('txtSymptom'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('cause'), $this->input->post('txtCause'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('action'), $this->input->post('txtAction'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('customerOpinion'), $this->input->post('txtCustomerOpinion'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('createDate'), $this->input->post('txtCreateDate'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('createUser'), $this->input->post('txtCreateUser'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('updateDate'), $this->input->post('txtUpdateDate'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('updateUser'), $this->input->post('txtUpdateUser'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('requestCost'), $this->input->post('txtRequestCost'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('tempCustomerName'), $this->input->post('txtTempCustomerName'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('tempCompanyName'), $this->input->post('txtTempCompanyName'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('tempAddress'), $this->input->post('txtTempAddress'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('tempPhone'), $this->input->post('txtTempPhone'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('tempFax'), $this->input->post('txtTempFax'));
		ObjectCriteria::addOrder($criteria, ColumnHelper::mapContractColumn('requestId'), FALSE);
        $criteria['orderField'] = 'contractId';
        $criteria['orderDirection'] = FALSE;
        $criteria['order'] = array();
        $criteria['pageNumber'] = 0;
        $criteria['recordPerPage'] = 2;
		
        $_SESSION['criteria'] = $criteria;
        
        $this->_doSearch($criteria);
	}
	
    function _viewEdit() {
        $id = $this->input->get_post('hidId');

        if ($id != FALSE) {
            $DataList = $this->ContractModel->findById($id);
            
            $searchResult = '';
    		if (count($DataList) == 0) {
    			$searchResult = "Không tìm thấy dữ liệu";
    		} else {
    		}
            
            $_SESSION['Contract'] = $DataList;
            
    		$data = array('searchResult' => $searchResult,
                          'Contract' => $DataList,
                          'ContractTypeMasterList' => array());
    		 
    		$this->load->view('TaoHopDong', $data);
        }
    }
	
	function _back() {
		$criteria = $_SESSION['criteria'];
   		$this->_doSearch($criteria);
	}
}

?>