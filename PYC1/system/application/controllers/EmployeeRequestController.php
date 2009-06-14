<?php
require "./system/application/helpers/ObjectCriteria.php";
require "./system/application/helpers/ColumnHelper.php";

class EmployeeRequestController extends Controller {

	function index() {
	    $this->load->model('EmployeeRequestModel');
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
        //$this->form_validation->set_rules('txtEmployeeId', 'EmployeeId', 'required');    
        //$this->form_validation->set_rules('txtRequestActionTypeId', 'RequestActionTypeId', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $EmployeeRequest = array();
                if ($this->input->post('txtRequestId') != FALSE) {
                    $EmployeeRequest['requestId'] = $this->input->post('txtRequestId');
                }
                if ($this->input->post('txtEmployeeId') != FALSE) {
                    $EmployeeRequest['employeeId'] = $this->input->post('txtEmployeeId');
                }
                if ($this->input->post('txtRequestActionTypeId') != FALSE) {
                    $EmployeeRequest['requestActionTypeId'] = $this->input->post('txtRequestActionTypeId');
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
                    $EmployeeRequest['requestId'] = $this->input->post('txtRequestId');
                }
                if ($this->input->post('txtEmployeeId') != FALSE) {
                    $EmployeeRequest['employeeId'] = $this->input->post('txtEmployeeId');
                }
                if ($this->input->post('txtRequestActionTypeId') != FALSE) {
                    $EmployeeRequest['requestActionTypeId'] = $this->input->post('txtRequestActionTypeId');
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
	
    function _buildTable($InList, $pageNum, $criteria) {
        $str = '<table border="0" cellpadding="0" cellspacing="0" class="data">';
        $str .= '<tr class="sort">';
        $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="requestId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('EmployeeRequest.requestId').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'requestId' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
        $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="employeeId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('EmployeeRequest.employeeId').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'employeeId' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
        $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="requestActionTypeId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('EmployeeRequest.requestActionTypeId').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'requestActionTypeId' == $criteria['orderField']) {
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
            $str .= '<td>'.$data['employeeId'].'</td>';
            $str .= '<td>'.$data['requestActionTypeId'].'</td>';
            //$str .= '<td>'.($contract->contractDate != null ? date("d/m/Y H:i:s", strtotime($contract->contractDate)) : '') .'</td>';
            $str .= '</tr>';
            $i++;
        }
        $str .= '</table>';
        
        return $str;
    }
	
    function _sort() {
	    $order_by = 'requestId';
	    $order_by = 'employeeId';
	    $order_by = 'requestActionTypeId';
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
		$DataList = $this->EmployeeRequestModel->findPaging($criteria);
		$countSearch = $this->EmployeeRequestModel->count($criteria);
		
        $searchResult = '';
        if (count($DataList) == 0) {
            $searchResult = "Không tìm thấy dữ liệu";
        } else {
            $searchResult = $this->_buildTable($DataList, $criteria['pageNumber'], $criteria);
            
            $config['base_url'] = base_url().'index.php?c=employeerequestcontroller&action=next';
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
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('employeeId'), $this->input->post('txtEmployeeId'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('requestActionTypeId'), $this->input->post('txtRequestActionTypeId'));
		ObjectCriteria::addOrder($criteria, ColumnHelper::mapContractColumn('requestId'), FALSE);
		ObjectCriteria::addOrder($criteria, ColumnHelper::mapContractColumn('employeeId'), FALSE);
		ObjectCriteria::addOrder($criteria, ColumnHelper::mapContractColumn('requestActionTypeId'), FALSE);
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