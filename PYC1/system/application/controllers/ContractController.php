<?php
require "./system/application/helpers/ObjectCriteria.php";
require "./system/application/helpers/ColumnHelper.php";

class ContractController extends Controller {

	function index() {
		$this->load->model('ContractModel');
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
		} else if ($action == 'back') {
            $this->_back();
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
		//$this->form_validation->set_rules('txtContractId', 'ContractId', 'required');
		//$this->form_validation->set_rules('txtContractNumber', 'ContractNumber', 'required');
		//$this->form_validation->set_rules('txtContractDate', 'ContractDate', 'required');
		//$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');
		//$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');
		//$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');
		//$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');
		//$this->form_validation->set_rules('cbbCUSTOMER_ID', 'CUSTOMER_ID', 'required');
		//$this->form_validation->set_rules('cbbCOMPANY_ID', 'COMPANY_ID', 'required');
		//$this->form_validation->set_rules('cbbCONTRACT_TYPE_ID', 'CONTRACT_TYPE_ID', 'required');
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
			$Contract = array();
			if ($this->input->post('txtContractId') != FALSE) {
				$Contract['contractId'] = $this->input->post('txtContractId');
			}
			if ($this->input->post('txtContractNumber') != FALSE) {
				$Contract['contractNumber'] = $this->input->post('txtContractNumber');
			}
			if ($this->input->post('txtContractDate') != FALSE) {
				$Contract['contractDate'] = $this->input->post('txtContractDate');
			}
			if ($this->input->post('txtCreateDate') != FALSE) {
				$Contract['createDate'] = $this->input->post('txtCreateDate');
			}
			if ($this->input->post('txtCreateUser') != FALSE) {
				$Contract['createUser'] = $this->input->post('txtCreateUser');
			}
			if ($this->input->post('txtUpdateDate') != FALSE) {
				$Contract['updateDate'] = $this->input->post('txtUpdateDate');
			}
			if ($this->input->post('txtUpdateUser') != FALSE) {
				$Contract['updateUser'] = $this->input->post('txtUpdateUser');
			}
			if ($this->input->post('cbbCUSTOMER_ID') != FALSE) {
				$Contract['customer.customerId'] = $this->input->post('cbbCUSTOMER_ID');
			}
			if ($this->input->post('cbbCOMPANY_ID') != FALSE) {
				$Contract['company.companyId'] = $this->input->post('cbbCOMPANY_ID');
			}
			if ($this->input->post('cbbCONTRACT_TYPE_ID') != FALSE) {
				$Contract['contractTypeMaster.contractTypeId'] = $this->input->post('cbbCONTRACT_TYPE_ID');
			}
			$this->ContractDAO->insert($Contract);

			$this->load->view('formsuccess');
		}
	}

	function _update() {
		//$this->form_validation->set_rules('username', 'Username', 'required');
		//$this->form_validation->set_rules('password', 'Password', 'required');
		//$this->form_validation->set_rules('passconf', 'Password Confirmation', 'required');
		//$this->form_validation->set_rules('email', 'Email', 'required');
		//$this->form_validation->set_rules('txtContractId', 'ContractId', 'required');
		//$this->form_validation->set_rules('txtContractNumber', 'ContractNumber', 'required');
		//$this->form_validation->set_rules('txtContractDate', 'ContractDate', 'required');
		//$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');
		//$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');
		//$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');
		//$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');
		//$this->form_validation->set_rules('cbbCUSTOMER_ID', 'CUSTOMER_ID', 'required');
		//$this->form_validation->set_rules('cbbCOMPANY_ID', 'COMPANY_ID', 'required');
		//$this->form_validation->set_rules('cbbCONTRACT_TYPE_ID', 'CONTRACT_TYPE_ID', 'required');
		//if ($this->form_validation->run() == FALSE)
		//{
		//	$this->load->view('myform');
		//}
		//else
		{
			$Contract = $_SESSION['Contract'];

			if ($Contract == null) {
				// TODO move to login page
			}

			if ($this->input->post('txtContractNumber') != FALSE) {
				$Contract['contractNumber'] = $this->input->post('txtContractNumber');
			}
			if ($this->input->post('txtContractDate') != FALSE) {
				$Contract['contractDate'] = $this->input->post('txtContractDate');
			}
			if ($this->input->post('txtCreateDate') != FALSE) {
				$Contract['createDate'] = $this->input->post('txtCreateDate');
			}
			if ($this->input->post('txtCreateUser') != FALSE) {
				$Contract['createUser'] = $this->input->post('txtCreateUser');
			}
			if ($this->input->post('txtUpdateDate') != FALSE) {
				$Contract['updateDate'] = $this->input->post('txtUpdateDate');
			}
			if ($this->input->post('txtUpdateUser') != FALSE) {
				$Contract['updateUser'] = $this->input->post('txtUpdateUser');
			}
			if ($this->input->post('cbbCUSTOMER_ID') != FALSE) {
				$Contract['customer.customerId'] = $this->input->post('cbbCUSTOMER_ID');
			}
			if ($this->input->post('cbbCOMPANY_ID') != FALSE) {
				$Contract['company.companyId'] = $this->input->post('cbbCOMPANY_ID');
			}
			if ($this->input->post('cbbCONTRACT_TYPE_ID') != FALSE) {
				$Contract['contractTypeMaster.contractTypeId'] = $this->input->post('cbbCONTRACT_TYPE_ID');
			}
			$this->ContractModel->update($Contract);

			$data = array('searchResult' => '',
                          'Contract' => $Contract,
                          'ContractTypeMasterList' => array());
    		 
    		$this->load->view('TaoHopDong', $data);
		}
	}

	function _findById() {
		$id = $this->input->post('object_id');

		$Contract = $this->ContractDAO->findById($id);;
		$this->session->set_userdata('Contract', $Contract);

		$this->load->view('formsuccess');
	}

	function _buildTable($InList, $pageNum, $criteria) {
		$str = '<table border="0" cellpadding="0" cellspacing="0" class="data">';
		$str .= '<tr class="sort">';
		$str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="contractId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Contract.contractId').'</a>';
		if ($criteria != null && count($criteria) > 0 && 'contractId' == $criteria['orderField']) {
			if ($criteria['orderDirection'] == TRUE) {
				$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';
			} else {
				$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
			}
		}
		$str .= '</th>';
		$str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="contractNumber";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Contract.contractNumber').'</a>';
		if ($criteria != null && count($criteria) > 0 && 'contractNumber' == $criteria['orderField']) {
			if ($criteria['orderDirection'] == TRUE) {
				$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';
			} else {
				$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
			}
		}
		$str .= '</th>';
		$str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="contractDate";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Contract.contractDate').'</a>';
		if ($criteria != null && count($criteria) > 0 && 'contractDate' == $criteria['orderField']) {
			if ($criteria['orderDirection'] == TRUE) {
				$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';
			} else {
				$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
			}
		}
		$str .= '</th>';
		$str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="createDate";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Contract.createDate').'</a>';
		if ($criteria != null && count($criteria) > 0 && 'createDate' == $criteria['orderField']) {
			if ($criteria['orderDirection'] == TRUE) {
				$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';
			} else {
				$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
			}
		}
		$str .= '</th>';
		$str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="createUser";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Contract.createUser').'</a>';
		if ($criteria != null && count($criteria) > 0 && 'createUser' == $criteria['orderField']) {
			if ($criteria['orderDirection'] == TRUE) {
				$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';
			} else {
				$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
			}
		}
		$str .= '</th>';
		$str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="updateDate";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Contract.updateDate').'</a>';
		if ($criteria != null && count($criteria) > 0 && 'updateDate' == $criteria['orderField']) {
			if ($criteria['orderDirection'] == TRUE) {
				$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';
			} else {
				$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
			}
		}
		$str .= '</th>';
		$str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="updateUser";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Contract.updateUser').'</a>';
		if ($criteria != null && count($criteria) > 0 && 'updateUser' == $criteria['orderField']) {
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
		$str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="company.companyId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Company.companyId').'</a>';
		if ($criteria != null && count($criteria) > 0 && 'companyId' == $criteria['orderField']) {
			if ($criteria['orderDirection'] == TRUE) {
				$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';
			} else {
				$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
			}
		}
		$str .= '</th>';
		$str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="contractTypeMaster.contractTypeId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('ContractTypeMaster.contractTypeId').'</a>';
		if ($criteria != null && count($criteria) > 0 && 'contractTypeId' == $criteria['orderField']) {
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
			$str .= '<td><a href="'.base_url().'index.php?c=contractcontroller&action=edit&hidId='.htmlentities($data['contractId']).'">'.$data['contractId'].'</a></td>';
			$str .= '<td>'.$data['contractNumber'].'</td>';
			$str .= '<td>'.$data['contractDate'].'</td>';
			$str .= '<td>'.$data['createDate'].'</td>';
			$str .= '<td>'.$data['createUser'].'</td>';
			$str .= '<td>'.$data['updateDate'].'</td>';
			$str .= '<td>'.$data['updateUser'].'</td>';
			$str .= '<td>'.$data['customer.customerId'].'</td>';
			$str .= '<td>'.$data['company.companyId'].'</td>';
			$str .= '<td>'.$data['contractTypeMaster.contractTypeId'].'</td>';
			//$str .= '<td>'.($contract->contractDate != null ? date("d/m/Y H:i:s", strtotime($contract->contractDate)) : '') .'</td>';
			$str .= '</tr>';
			$i++;
		}
		$str .= '</table>';

		return $str;
	}

	function _sort() {
		$order_by = 'contractId';
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

		ObjectCriteria::clearOrder($criteria);
		ObjectCriteria::addOrder($criteria, ColumnHelper::mapContractColumn($order_by), $sort_order);
		$criteria['orderField'] = $order_by;
		$criteria['orderDirection'] = $sort_order;
		$_SESSION['criteria'] = $criteria;

		$this->_doSearch($criteria, 5);
	}

	function _next() {
		$criteria = null;
		if (isset($_SESSION['criteria'])) {
			$criteria = $_SESSION['criteria'];
		} else {
			$criteria = array();
		}

        $pageNumber = 0;
        if ($this->input->get_post('current_page') != FALSE) {
			$pageNumber = $this->input->get_post('current_page');
		}

		$criteria['pageNumber'] = $pageNumber;
		$_SESSION['criteria'] = $criteria;
		$this->_doSearch($criteria);
	}

	function _doSearch($criteria, $pageSegment = 0) {
		$DataList = $this->ContractModel->findPaging($criteria);
		$countSearch = $this->ContractModel->count($criteria);

		$searchResult = '';
		if (count($DataList) == 0) {
			$searchResult = "Không tìm thấy dữ liệu";
		} else {
			$searchResult = $this->_buildTable($DataList, $criteria['pageNumber'], $criteria);

			$config['base_url'] = 'http://localhost:9999/pyc1/index.php?c=contractcontroller&action=next';
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
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('contractId'), $this->input->post('txtContractId'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('contractNumber'), $this->input->post('txtContractNumber'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('contractDate'), $this->input->post('txtContractDate'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('createDate'), $this->input->post('txtCreateDate'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('createUser'), $this->input->post('txtCreateUser'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('updateDate'), $this->input->post('txtUpdateDate'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('updateUser'), $this->input->post('txtUpdateUser'));
		ObjectCriteria::addOrder($criteria, ColumnHelper::mapContractColumn('contractId'), FALSE);
		$criteria['orderField'] = 'contractId';
		$criteria['orderDirection'] = FALSE;
		$criteria['order'] = array();
		$criteria['pageNumber'] = 0;
		$criteria['recordPerPage'] = 2;

        $criteria['input_value'] = array();
        $criteria['input_value']['txtContractId'] = $this->input->post('txtContractId');
        $criteria['input_value']['txtContractNumber'] = $this->input->post('txtContractNumber');
        
		$this->form_validation->set_rules('txtContractNumber', 'contract Number', 'is_natural');
		if ($this->form_validation->run() == FALSE)
		{
			$data = array('searchResult' => '',
                          'criteria' => $criteria);
		 
            $this->load->view('TimHopDong', $data);
		}
		else
		{
    		$_SESSION['criteria'] = $criteria;

    		$this->_doSearch($criteria);
		}
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