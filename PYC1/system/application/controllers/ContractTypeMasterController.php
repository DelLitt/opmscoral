<?php
require "./system/application/helpers/ObjectCriteria.php";
require "./system/application/helpers/ColumnHelper.php";

class ContractTypeMasterController extends Controller {

	function index() {
	    $this->load->model('ContractTypeMasterModel');
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
        //$this->form_validation->set_rules('txtContractTypeId', 'ContractTypeId', 'required');    
        //$this->form_validation->set_rules('txtContractTypeName', 'ContractTypeName', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $ContractTypeMaster = array();
                if ($this->input->post('txtContractTypeId') != FALSE) {
                    $ContractTypeMaster['contractTypeId'] = $this->input->post('txtContractTypeId');
                }
                if ($this->input->post('txtContractTypeName') != FALSE) {
                    $ContractTypeMaster['contractTypeName'] = $this->input->post('txtContractTypeName');
                }
            $this->ContractTypeMasterDAO->insert($ContractTypeMaster); 
            
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
        //$this->form_validation->set_rules('txtContractTypeId', 'ContractTypeId', 'required');    
        //$this->form_validation->set_rules('txtContractTypeName', 'ContractTypeName', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $ContractTypeMaster = $this->session->userdata('ContractTypeMaster');
                
                if ($ContractTypeMaster == null) {
                    // TODO move to login page
                }
                
                if ($this->input->post('txtContractTypeId') != FALSE) {
                    $ContractTypeMaster['contractTypeId'] = $this->input->post('txtContractTypeId');
                }
                if ($this->input->post('txtContractTypeName') != FALSE) {
                    $ContractTypeMaster['contractTypeName'] = $this->input->post('txtContractTypeName');
                }
            $this->ContractTypeMasterDAO->update($ContractTypeMaster); 
            
			$this->load->view('formsuccess');
		}
    }

    function _findById() {
        $id = $this->input->post('object_id');
        
        $ContractTypeMaster = $this->ContractTypeMasterDAO->findById($id);;
        $this->session->set_userdata('ContractTypeMaster', $ContractTypeMaster);
            
        $this->load->view('formsuccess');
    }
	
    function _buildTable($InList, $pageNum, $criteria) {
        $str = '<table border="0" cellpadding="0" cellspacing="0" class="data">';
        $str .= '<tr class="sort">';
        $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="contractTypeId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('ContractTypeMaster.contractTypeId').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'contractTypeId' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="contractTypeName";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('ContractTypeMaster.contractTypeName').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'contractTypeName' == $criteria['orderField']) {
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
            $str .= '<td>'.$data['contractTypeId'].'</td>';
            $str .= '<td>'.$data['contractTypeName'].'</td>';
            //$str .= '<td>'.($contract->contractDate != null ? date("d/m/Y H:i:s", strtotime($contract->contractDate)) : '') .'</td>';
            $str .= '</tr>';
            $i++;
        }
        $str .= '</table>';
        
        return $str;
    }
	
    function _sort() {
	    $order_by = 'contractTypeId';
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
		$DataList = $this->ContractTypeMasterModel->findPaging($criteria);
		$countSearch = $this->ContractTypeMasterModel->count($criteria);
		
        $searchResult = '';
        if (count($DataList) == 0) {
            $searchResult = "Không tìm thấy dữ liệu";
        } else {
            $searchResult = $this->_buildTable($DataList, $criteria['pageNumber'], $criteria);
            
            $config['base_url'] = base_url().'index.php?c=contracttypemastercontroller&action=next';
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
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('contractTypeId'), $this->input->post('txtContractTypeId'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('contractTypeName'), $this->input->post('txtContractTypeName'));
		ObjectCriteria::addOrder($criteria, ColumnHelper::mapContractColumn('contractTypeId'), FALSE);
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