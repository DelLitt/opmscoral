<?php
require "./system/application/helpers/ObjectCriteria.php";
require "./system/application/helpers/ColumnHelper.php";

class CompanyController extends Controller {

	function index() {
	    $this->load->model('CompanyModel');
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
        //$this->form_validation->set_rules('txtCompanyId', 'CompanyId', 'required');    
        //$this->form_validation->set_rules('txtCompanyName', 'CompanyName', 'required');    
        //$this->form_validation->set_rules('txtAddress', 'Address', 'required');    
        //$this->form_validation->set_rules('txtPhone', 'Phone', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
        //$this->form_validation->set_rules('txtFax', 'Fax', 'required');    
        //$this->form_validation->set_rules('txtRepresentName', 'RepresentName', 'required');    
        //$this->form_validation->set_rules('txtRepresentPhone', 'RepresentPhone', 'required');    
        //$this->form_validation->set_rules('txtRepresentFax', 'RepresentFax', 'required');    
        //$this->form_validation->set_rules('txtDescription', 'Description', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $Company = array();
                if ($this->input->post('txtCompanyId') != FALSE) {
                    $Company['companyId'] = $this->input->post('txtCompanyId');
                }
                if ($this->input->post('txtCompanyName') != FALSE) {
                    $Company['companyName'] = $this->input->post('txtCompanyName');
                }
                if ($this->input->post('txtAddress') != FALSE) {
                    $Company['address'] = $this->input->post('txtAddress');
                }
                if ($this->input->post('txtPhone') != FALSE) {
                    $Company['phone'] = $this->input->post('txtPhone');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Company['createDate'] = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Company['createUser'] = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Company['updateDate'] = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Company['updateUser'] = $this->input->post('txtUpdateUser');
                }
                if ($this->input->post('txtFax') != FALSE) {
                    $Company['fax'] = $this->input->post('txtFax');
                }
                if ($this->input->post('txtRepresentName') != FALSE) {
                    $Company['representName'] = $this->input->post('txtRepresentName');
                }
                if ($this->input->post('txtRepresentPhone') != FALSE) {
                    $Company['representPhone'] = $this->input->post('txtRepresentPhone');
                }
                if ($this->input->post('txtRepresentFax') != FALSE) {
                    $Company['representFax'] = $this->input->post('txtRepresentFax');
                }
                if ($this->input->post('txtDescription') != FALSE) {
                    $Company['description'] = $this->input->post('txtDescription');
                }
            $this->CompanyDAO->insert($Company); 
            
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
        //$this->form_validation->set_rules('txtCompanyId', 'CompanyId', 'required');    
        //$this->form_validation->set_rules('txtCompanyName', 'CompanyName', 'required');    
        //$this->form_validation->set_rules('txtAddress', 'Address', 'required');    
        //$this->form_validation->set_rules('txtPhone', 'Phone', 'required');    
        //$this->form_validation->set_rules('txtCreateDate', 'CreateDate', 'required');    
        //$this->form_validation->set_rules('txtCreateUser', 'CreateUser', 'required');    
        //$this->form_validation->set_rules('txtUpdateDate', 'UpdateDate', 'required');    
        //$this->form_validation->set_rules('txtUpdateUser', 'UpdateUser', 'required');    
        //$this->form_validation->set_rules('txtFax', 'Fax', 'required');    
        //$this->form_validation->set_rules('txtRepresentName', 'RepresentName', 'required');    
        //$this->form_validation->set_rules('txtRepresentPhone', 'RepresentPhone', 'required');    
        //$this->form_validation->set_rules('txtRepresentFax', 'RepresentFax', 'required');    
        //$this->form_validation->set_rules('txtDescription', 'Description', 'required');    
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $Company = $this->session->userdata('Company');
                
                if ($Company == null) {
                    // TODO move to login page
                }
                
                if ($this->input->post('txtCompanyId') != FALSE) {
                    $Company['companyId'] = $this->input->post('txtCompanyId');
                }
                if ($this->input->post('txtCompanyName') != FALSE) {
                    $Company['companyName'] = $this->input->post('txtCompanyName');
                }
                if ($this->input->post('txtAddress') != FALSE) {
                    $Company['address'] = $this->input->post('txtAddress');
                }
                if ($this->input->post('txtPhone') != FALSE) {
                    $Company['phone'] = $this->input->post('txtPhone');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Company['createDate'] = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Company['createUser'] = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Company['updateDate'] = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Company['updateUser'] = $this->input->post('txtUpdateUser');
                }
                if ($this->input->post('txtFax') != FALSE) {
                    $Company['fax'] = $this->input->post('txtFax');
                }
                if ($this->input->post('txtRepresentName') != FALSE) {
                    $Company['representName'] = $this->input->post('txtRepresentName');
                }
                if ($this->input->post('txtRepresentPhone') != FALSE) {
                    $Company['representPhone'] = $this->input->post('txtRepresentPhone');
                }
                if ($this->input->post('txtRepresentFax') != FALSE) {
                    $Company['representFax'] = $this->input->post('txtRepresentFax');
                }
                if ($this->input->post('txtDescription') != FALSE) {
                    $Company['description'] = $this->input->post('txtDescription');
                }
            $this->CompanyDAO->update($Company); 
            
			$this->load->view('formsuccess');
		}
    }

    function _findById() {
        $id = $this->input->post('object_id');
        
        $Company = $this->CompanyDAO->findById($id);;
        $this->session->set_userdata('Company', $Company);
            
        $this->load->view('formsuccess');
    }
	
    function _buildTable($InList, $pageNum, $criteria) {
        $str = '<table border="0" cellpadding="0" cellspacing="0" class="data">';
        $str .= '<tr class="sort">';
        $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="companyId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Company.companyId').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'companyId' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="companyName";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Company.companyName').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'companyName' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="address";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Company.address').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'address' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="phone";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Company.phone').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'phone' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="createDate";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Company.createDate').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'createDate' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="createUser";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Company.createUser').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'createUser' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="updateDate";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Company.updateDate').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'updateDate' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="updateUser";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Company.updateUser').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'updateUser' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="fax";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Company.fax').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'fax' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="representName";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Company.representName').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'representName' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="representPhone";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Company.representPhone').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'representPhone' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="representFax";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Company.representFax').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'representFax' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="description";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Company.description').'</a>';
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
            $str .= '<td>'.$data['companyId'].'</td>';
            $str .= '<td>'.$data['companyName'].'</td>';
            $str .= '<td>'.$data['address'].'</td>';
            $str .= '<td>'.$data['phone'].'</td>';
            $str .= '<td>'.$data['createDate'].'</td>';
            $str .= '<td>'.$data['createUser'].'</td>';
            $str .= '<td>'.$data['updateDate'].'</td>';
            $str .= '<td>'.$data['updateUser'].'</td>';
            $str .= '<td>'.$data['fax'].'</td>';
            $str .= '<td>'.$data['representName'].'</td>';
            $str .= '<td>'.$data['representPhone'].'</td>';
            $str .= '<td>'.$data['representFax'].'</td>';
            $str .= '<td>'.$data['description'].'</td>';
            //$str .= '<td>'.($contract->contractDate != null ? date("d/m/Y H:i:s", strtotime($contract->contractDate)) : '') .'</td>';
            $str .= '</tr>';
            $i++;
        }
        $str .= '</table>';
        
        return $str;
    }
	
    function _sort() {
	    $order_by = 'companyId';
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
		$DataList = $this->CompanyModel->findPaging($criteria);
		$countSearch = $this->CompanyModel->count($criteria);
		
        $searchResult = '';
        if (count($DataList) == 0) {
            $searchResult = "Không tìm thấy dữ liệu";
        } else {
            $searchResult = $this->_buildTable($DataList, $criteria['pageNumber'], $criteria);
            
            $config['base_url'] = base_url().'index.php?c=companycontroller&action=next';
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
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('companyId'), $this->input->post('txtCompanyId'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('companyName'), $this->input->post('txtCompanyName'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('address'), $this->input->post('txtAddress'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('phone'), $this->input->post('txtPhone'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('createDate'), $this->input->post('txtCreateDate'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('createUser'), $this->input->post('txtCreateUser'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('updateDate'), $this->input->post('txtUpdateDate'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('updateUser'), $this->input->post('txtUpdateUser'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('fax'), $this->input->post('txtFax'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('representName'), $this->input->post('txtRepresentName'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('representPhone'), $this->input->post('txtRepresentPhone'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('representFax'), $this->input->post('txtRepresentFax'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('description'), $this->input->post('txtDescription'));
		ObjectCriteria::addOrder($criteria, ColumnHelper::mapContractColumn('companyId'), FALSE);
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