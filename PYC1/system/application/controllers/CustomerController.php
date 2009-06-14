<?php
require "./system/application/helpers/ObjectCriteria.php";
require "./system/application/helpers/ColumnHelper.php";

class CustomerController extends Controller {

	function index() {
	    $this->load->model('CustomerModel');
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
        //$this->form_validation->set_rules('txtCustomerId', 'CustomerId', 'required');    
        //$this->form_validation->set_rules('txtCustomerName', 'CustomerName', 'required');    
        //$this->form_validation->set_rules('txtAddress', 'Address', 'required');    
        //$this->form_validation->set_rules('txtCompanyId', 'CompanyId', 'required');    
        //$this->form_validation->set_rules('txtPhone', 'Phone', 'required');    
        //$this->form_validation->set_rules('txtFax', 'Fax', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
        //$this->form_validation->set_rules('txtDescription', 'Description', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $Customer = array();
                if ($this->input->post('txtCustomerId') != FALSE) {
                    $Customer['customerId'] = $this->input->post('txtCustomerId');
                }
                if ($this->input->post('txtCustomerName') != FALSE) {
                    $Customer['customerName'] = $this->input->post('txtCustomerName');
                }
                if ($this->input->post('txtAddress') != FALSE) {
                    $Customer['address'] = $this->input->post('txtAddress');
                }
                if ($this->input->post('txtCompanyId') != FALSE) {
                    $Customer['companyId'] = $this->input->post('txtCompanyId');
                }
                if ($this->input->post('txtPhone') != FALSE) {
                    $Customer['phone'] = $this->input->post('txtPhone');
                }
                if ($this->input->post('txtFax') != FALSE) {
                    $Customer['fax'] = $this->input->post('txtFax');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Customer['createDate'] = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Customer['createUser'] = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Customer['updateDate'] = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Customer['updateUser'] = $this->input->post('txtUpdateUser');
                }
                if ($this->input->post('txtDescription') != FALSE) {
                    $Customer['description'] = $this->input->post('txtDescription');
                }
            $this->CustomerDAO->insert($Customer); 
            
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
        //$this->form_validation->set_rules('txtCustomerId', 'CustomerId', 'required');    
        //$this->form_validation->set_rules('txtCustomerName', 'CustomerName', 'required');    
        //$this->form_validation->set_rules('txtAddress', 'Address', 'required');    
        //$this->form_validation->set_rules('txtCompanyId', 'CompanyId', 'required');    
        //$this->form_validation->set_rules('txtPhone', 'Phone', 'required');    
        //$this->form_validation->set_rules('txtFax', 'Fax', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
        //$this->form_validation->set_rules('txtDescription', 'Description', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $Customer = $this->session->userdata('Customer');
                
                if ($Customer == null) {
                    // TODO move to login page
                }
                
                if ($this->input->post('txtCustomerId') != FALSE) {
                    $Customer['customerId'] = $this->input->post('txtCustomerId');
                }
                if ($this->input->post('txtCustomerName') != FALSE) {
                    $Customer['customerName'] = $this->input->post('txtCustomerName');
                }
                if ($this->input->post('txtAddress') != FALSE) {
                    $Customer['address'] = $this->input->post('txtAddress');
                }
                if ($this->input->post('txtCompanyId') != FALSE) {
                    $Customer['companyId'] = $this->input->post('txtCompanyId');
                }
                if ($this->input->post('txtPhone') != FALSE) {
                    $Customer['phone'] = $this->input->post('txtPhone');
                }
                if ($this->input->post('txtFax') != FALSE) {
                    $Customer['fax'] = $this->input->post('txtFax');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Customer['createDate'] = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Customer['createUser'] = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Customer['updateDate'] = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Customer['updateUser'] = $this->input->post('txtUpdateUser');
                }
                if ($this->input->post('txtDescription') != FALSE) {
                    $Customer['description'] = $this->input->post('txtDescription');
                }
            $this->CustomerDAO->update($Customer); 
            
			$this->load->view('formsuccess');
		}
    }

    function _findById() {
        $id = $this->input->post('object_id');
        
        $Customer = $this->CustomerDAO->findById($id);;
        $this->session->set_userdata('Customer', $Customer);
            
        $this->load->view('formsuccess');
    }
	
    function _buildTable($InList, $pageNum, $criteria) {
        $str = '<table border="0" cellpadding="0" cellspacing="0" class="data">';
        $str .= '<tr class="sort">';
        $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="customerId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Customer.customerId').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'customerId' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="customerName";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Customer.customerName').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'customerName' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="address";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Customer.address').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'address' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="companyId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Customer.companyId').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'companyId' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="phone";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Customer.phone').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'phone' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="fax";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Customer.fax').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'fax' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="createDate";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Customer.createDate').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'createDate' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="createUser";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Customer.createUser').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'createUser' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="updateDate";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Customer.updateDate').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'updateDate' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="updateUser";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Customer.updateUser').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'updateUser' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="description";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Customer.description').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'description' == $criteria['orderField']) {
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
            $str .= '<td>'.$data['customerId'].'</td>';
            $str .= '<td>'.$data['customerName'].'</td>';
            $str .= '<td>'.$data['address'].'</td>';
            $str .= '<td>'.$data['companyId'].'</td>';
            $str .= '<td>'.$data['phone'].'</td>';
            $str .= '<td>'.$data['fax'].'</td>';
            $str .= '<td>'.$data['createDate'].'</td>';
            $str .= '<td>'.$data['createUser'].'</td>';
            $str .= '<td>'.$data['updateDate'].'</td>';
            $str .= '<td>'.$data['updateUser'].'</td>';
            $str .= '<td>'.$data['description'].'</td>';
            //$str .= '<td>'.($contract->contractDate != null ? date("d/m/Y H:i:s", strtotime($contract->contractDate)) : '') .'</td>';
            $str .= '</tr>';
            $i++;
        }
        $str .= '</table>';
        
        return $str;
    }
	
    function _sort() {
	    $order_by = 'customerId';
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
		$DataList = $this->CustomerModel->findPaging($criteria);
		$countSearch = $this->CustomerModel->count($criteria);
		
        $searchResult = '';
        if (count($DataList) == 0) {
            $searchResult = "Không tìm thấy dữ liệu";
        } else {
            $searchResult = $this->_buildTable($DataList, $criteria['pageNumber'], $criteria);
            
            $config['base_url'] = base_url().'index.php?c=customercontroller&action=next';
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
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('customerId'), $this->input->post('txtCustomerId'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('customerName'), $this->input->post('txtCustomerName'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('address'), $this->input->post('txtAddress'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('companyId'), $this->input->post('txtCompanyId'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('phone'), $this->input->post('txtPhone'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('fax'), $this->input->post('txtFax'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('createDate'), $this->input->post('txtCreateDate'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('createUser'), $this->input->post('txtCreateUser'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('updateDate'), $this->input->post('txtUpdateDate'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('updateUser'), $this->input->post('txtUpdateUser'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('description'), $this->input->post('txtDescription'));
		ObjectCriteria::addOrder($criteria, ColumnHelper::mapContractColumn('customerId'), FALSE);
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