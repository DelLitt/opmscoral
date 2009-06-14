<?php
require "./system/application/helpers/ObjectCriteria.php";
require "./system/application/helpers/ColumnHelper.php";

class ReplacePartController extends Controller {

	function index() {
	    $this->load->model('ReplacePartModel');
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
                $ReplacePart = array();
                if ($this->input->post('txtReplacePartId') != FALSE) {
                    $ReplacePart['replacePartId'] = $this->input->post('txtReplacePartId');
                }
                if ($this->input->post('txtPartNo') != FALSE) {
                    $ReplacePart['partNo'] = $this->input->post('txtPartNo');
                }
                if ($this->input->post('txtDescription') != FALSE) {
                    $ReplacePart['description'] = $this->input->post('txtDescription');
                }
                if ($this->input->post('txtQuantity') != FALSE) {
                    $ReplacePart['quantity'] = $this->input->post('txtQuantity');
                }
                if ($this->input->post('txtPriceUsd') != FALSE) {
                    $ReplacePart['priceUsd'] = $this->input->post('txtPriceUsd');
                }
                if ($this->input->post('txtPriceVnd') != FALSE) {
                    $ReplacePart['priceVnd'] = $this->input->post('txtPriceVnd');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $ReplacePart['createDate'] = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $ReplacePart['createUser'] = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $ReplacePart['updateDate'] = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $ReplacePart['updateUser'] = $this->input->post('txtUpdateUser');
                }
                if ($this->input->post('cbbREQUEST_ID') != FALSE) {
                    $ReplacePart['request.requestId'] = $this->input->post('cbbREQUEST_ID');
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
                    $ReplacePart['replacePartId'] = $this->input->post('txtReplacePartId');
                }
                if ($this->input->post('txtPartNo') != FALSE) {
                    $ReplacePart['partNo'] = $this->input->post('txtPartNo');
                }
                if ($this->input->post('txtDescription') != FALSE) {
                    $ReplacePart['description'] = $this->input->post('txtDescription');
                }
                if ($this->input->post('txtQuantity') != FALSE) {
                    $ReplacePart['quantity'] = $this->input->post('txtQuantity');
                }
                if ($this->input->post('txtPriceUsd') != FALSE) {
                    $ReplacePart['priceUsd'] = $this->input->post('txtPriceUsd');
                }
                if ($this->input->post('txtPriceVnd') != FALSE) {
                    $ReplacePart['priceVnd'] = $this->input->post('txtPriceVnd');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $ReplacePart['createDate'] = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $ReplacePart['createUser'] = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $ReplacePart['updateDate'] = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $ReplacePart['updateUser'] = $this->input->post('txtUpdateUser');
                }
                if ($this->input->post('cbbREQUEST_ID') != FALSE) {
                    $ReplacePart['request.requestId'] = $this->input->post('cbbREQUEST_ID');
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
	
    function _buildTable($InList, $pageNum, $criteria) {
        $str = '<table border="0" cellpadding="0" cellspacing="0" class="data">';
        $str .= '<tr class="sort">';
        $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="replacePartId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('ReplacePart.replacePartId').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'replacePartId' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="partNo";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('ReplacePart.partNo').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'partNo' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="description";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('ReplacePart.description').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'description' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="quantity";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('ReplacePart.quantity').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'quantity' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="priceUsd";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('ReplacePart.priceUsd').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'priceUsd' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="priceVnd";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('ReplacePart.priceVnd').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'priceVnd' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="createDate";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('ReplacePart.createDate').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'createDate' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="createUser";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('ReplacePart.createUser').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'createUser' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="updateDate";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('ReplacePart.updateDate').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'updateDate' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="updateUser";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('ReplacePart.updateUser').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'updateUser' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="request.requestId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Request.requestId').'</a>';				
        if ($criteria != null && count($criteria) > 0 && 'requestId' == $criteria['orderField']) {
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
            $str .= '<td>'.$data['replacePartId'].'</td>';
            $str .= '<td>'.$data['partNo'].'</td>';
            $str .= '<td>'.$data['description'].'</td>';
            $str .= '<td>'.$data['quantity'].'</td>';
            $str .= '<td>'.$data['priceUsd'].'</td>';
            $str .= '<td>'.$data['priceVnd'].'</td>';
            $str .= '<td>'.$data['createDate'].'</td>';
            $str .= '<td>'.$data['createUser'].'</td>';
            $str .= '<td>'.$data['updateDate'].'</td>';
            $str .= '<td>'.$data['updateUser'].'</td>';
            $str .= '<td>'.$data['request.requestId'].'</td>';				
            //$str .= '<td>'.($contract->contractDate != null ? date("d/m/Y H:i:s", strtotime($contract->contractDate)) : '') .'</td>';
            $str .= '</tr>';
            $i++;
        }
        $str .= '</table>';
        
        return $str;
    }
	
    function _sort() {
	    $order_by = 'replacePartId';
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
		$DataList = $this->ReplacePartModel->findPaging($criteria);
		$countSearch = $this->ReplacePartModel->count($criteria);
		
        $searchResult = '';
        if (count($DataList) == 0) {
            $searchResult = "Không tìm thấy dữ liệu";
        } else {
            $searchResult = $this->_buildTable($DataList, $criteria['pageNumber'], $criteria);
            
            $config['base_url'] = base_url().'index.php?c=replacepartcontroller&action=next';
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
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('replacePartId'), $this->input->post('txtReplacePartId'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('partNo'), $this->input->post('txtPartNo'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('description'), $this->input->post('txtDescription'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('quantity'), $this->input->post('txtQuantity'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('priceUsd'), $this->input->post('txtPriceUsd'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('priceVnd'), $this->input->post('txtPriceVnd'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('createDate'), $this->input->post('txtCreateDate'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('createUser'), $this->input->post('txtCreateUser'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('updateDate'), $this->input->post('txtUpdateDate'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('updateUser'), $this->input->post('txtUpdateUser'));
		ObjectCriteria::addOrder($criteria, ColumnHelper::mapContractColumn('replacePartId'), FALSE);
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