<?php
require "./system/application/helpers/ObjectCriteria.php";
require "./system/application/helpers/ColumnHelper.php";

class MachineController extends Controller {

	function index() {
	    $this->load->model('MachineModel');
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
        //$this->form_validation->set_rules('txtDescription', 'Description', 'required');    
        //$this->form_validation->set_rules('cbbMACHINE_TYPE', 'MACHINE_TYPE', 'required');
		if ($this->form_validation->run() == FALSE)
		{
			$this->load->view('myform');
		}
		else
		{
                $Machine = array();
                if ($this->input->post('txtMachineId') != FALSE) {
                    $Machine['machineId'] = $this->input->post('txtMachineId');
                }
                if ($this->input->post('txtMachineName') != FALSE) {
                    $Machine['machineName'] = $this->input->post('txtMachineName');
                }
                if ($this->input->post('txtSerialNumber') != FALSE) {
                    $Machine['serialNumber'] = $this->input->post('txtSerialNumber');
                }
                if ($this->input->post('txtModel') != FALSE) {
                    $Machine['model'] = $this->input->post('txtModel');
                }
                if ($this->input->post('txtCounterNo') != FALSE) {
                    $Machine['counterNo'] = $this->input->post('txtCounterNo');
                }
                if ($this->input->post('txtColor') != FALSE) {
                    $Machine['color'] = $this->input->post('txtColor');
                }
                if ($this->input->post('txtFaxTx') != FALSE) {
                    $Machine['faxTx'] = $this->input->post('txtFaxTx');
                }
                if ($this->input->post('txtReceiveRx') != FALSE) {
                    $Machine['receiveRx'] = $this->input->post('txtReceiveRx');
                }
                if ($this->input->post('txtPreportMaster') != FALSE) {
                    $Machine['preportMaster'] = $this->input->post('txtPreportMaster');
                }
                if ($this->input->post('txtCopy') != FALSE) {
                    $Machine['copy'] = $this->input->post('txtCopy');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Machine['createDate'] = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Machine['createUser'] = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Machine['updateDate'] = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Machine['updateUser'] = $this->input->post('txtUpdateUser');
                }
                if ($this->input->post('txtDescription') != FALSE) {
                    $Machine['description'] = $this->input->post('txtDescription');
                }
                if ($this->input->post('cbbMACHINE_TYPE') != FALSE) {
                    $Machine['machineTypeMaster.typeId'] = $this->input->post('cbbMACHINE_TYPE');
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
        //$this->form_validation->set_rules('txtDescription', 'Description', 'required');    
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
                    $Machine['machineId'] = $this->input->post('txtMachineId');
                }
                if ($this->input->post('txtMachineName') != FALSE) {
                    $Machine['machineName'] = $this->input->post('txtMachineName');
                }
                if ($this->input->post('txtSerialNumber') != FALSE) {
                    $Machine['serialNumber'] = $this->input->post('txtSerialNumber');
                }
                if ($this->input->post('txtModel') != FALSE) {
                    $Machine['model'] = $this->input->post('txtModel');
                }
                if ($this->input->post('txtCounterNo') != FALSE) {
                    $Machine['counterNo'] = $this->input->post('txtCounterNo');
                }
                if ($this->input->post('txtColor') != FALSE) {
                    $Machine['color'] = $this->input->post('txtColor');
                }
                if ($this->input->post('txtFaxTx') != FALSE) {
                    $Machine['faxTx'] = $this->input->post('txtFaxTx');
                }
                if ($this->input->post('txtReceiveRx') != FALSE) {
                    $Machine['receiveRx'] = $this->input->post('txtReceiveRx');
                }
                if ($this->input->post('txtPreportMaster') != FALSE) {
                    $Machine['preportMaster'] = $this->input->post('txtPreportMaster');
                }
                if ($this->input->post('txtCopy') != FALSE) {
                    $Machine['copy'] = $this->input->post('txtCopy');
                }
                if ($this->input->post('txtCreateDate') != FALSE) {
                    $Machine['createDate'] = $this->input->post('txtCreateDate');
                }
                if ($this->input->post('txtCreateUser') != FALSE) {
                    $Machine['createUser'] = $this->input->post('txtCreateUser');
                }
                if ($this->input->post('txtUpdateDate') != FALSE) {
                    $Machine['updateDate'] = $this->input->post('txtUpdateDate');
                }
                if ($this->input->post('txtUpdateUser') != FALSE) {
                    $Machine['updateUser'] = $this->input->post('txtUpdateUser');
                }
                if ($this->input->post('txtDescription') != FALSE) {
                    $Machine['description'] = $this->input->post('txtDescription');
                }
                if ($this->input->post('cbbMACHINE_TYPE') != FALSE) {
                    $Machine['machineTypeMaster.typeId'] = $this->input->post('cbbMACHINE_TYPE');
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
	
    function _buildTable($InList, $pageNum, $criteria) {
        $str = '<table border="0" cellpadding="0" cellspacing="0" class="data">';
        $str .= '<tr class="sort">';
        $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="machineId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Machine.machineId').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'machineId' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="machineName";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Machine.machineName').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'machineName' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="serialNumber";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Machine.serialNumber').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'serialNumber' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="model";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Machine.model').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'model' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="counterNo";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Machine.counterNo').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'counterNo' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="color";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Machine.color').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'color' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="faxTx";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Machine.faxTx').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'faxTx' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="receiveRx";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Machine.receiveRx').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'receiveRx' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="preportMaster";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Machine.preportMaster').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'preportMaster' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="copy";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Machine.copy').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'copy' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="createDate";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Machine.createDate').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'createDate' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="createUser";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Machine.createUser').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'createUser' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="updateDate";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Machine.updateDate').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'updateDate' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="updateUser";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Machine.updateUser').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'updateUser' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="description";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('Machine.description').'</a>';
        if ($criteria != null && count($criteria) > 0 && 'description' == $criteria['orderField']) {
        	if ($criteria['orderDirection'] == TRUE) {
			 	$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_down.png"/>';       		
        	} else {
        		$str .= '&nbsp;&nbsp;<img src="'.base_url().'/images/arrow_up.png"/>';
        	}
        }
		$str .= '</th>';
	    $str .= '<th> <a class="header_style" href=\'javascript:document.getElementById("action").value ="sort";document.getElementById("hidOrderBy").value ="machineTypeMaster.typeId";document.getElementById("hidPageNum").value ="'.$pageNum.'";document.forms["mainform"].submit();\'>'.$this->lang->line('MachineTypeMaster.typeId').'</a>';				
        if ($criteria != null && count($criteria) > 0 && 'typeId' == $criteria['orderField']) {
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
            $str .= '<td>'.$data['machineId'].'</td>';
            $str .= '<td>'.$data['machineName'].'</td>';
            $str .= '<td>'.$data['serialNumber'].'</td>';
            $str .= '<td>'.$data['model'].'</td>';
            $str .= '<td>'.$data['counterNo'].'</td>';
            $str .= '<td>'.$data['color'].'</td>';
            $str .= '<td>'.$data['faxTx'].'</td>';
            $str .= '<td>'.$data['receiveRx'].'</td>';
            $str .= '<td>'.$data['preportMaster'].'</td>';
            $str .= '<td>'.$data['copy'].'</td>';
            $str .= '<td>'.$data['createDate'].'</td>';
            $str .= '<td>'.$data['createUser'].'</td>';
            $str .= '<td>'.$data['updateDate'].'</td>';
            $str .= '<td>'.$data['updateUser'].'</td>';
            $str .= '<td>'.$data['description'].'</td>';
            $str .= '<td>'.$data['machineTypeMaster.typeId'].'</td>';				
            //$str .= '<td>'.($contract->contractDate != null ? date("d/m/Y H:i:s", strtotime($contract->contractDate)) : '') .'</td>';
            $str .= '</tr>';
            $i++;
        }
        $str .= '</table>';
        
        return $str;
    }
	
    function _sort() {
	    $order_by = 'machineId';
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
		$DataList = $this->MachineModel->findPaging($criteria);
		$countSearch = $this->MachineModel->count($criteria);
		
        $searchResult = '';
        if (count($DataList) == 0) {
            $searchResult = "Không tìm thấy dữ liệu";
        } else {
            $searchResult = $this->_buildTable($DataList, $criteria['pageNumber'], $criteria);
            
            $config['base_url'] = base_url().'index.php?c=machinecontroller&action=next';
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
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('machineId'), $this->input->post('txtMachineId'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('machineName'), $this->input->post('txtMachineName'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('serialNumber'), $this->input->post('txtSerialNumber'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('model'), $this->input->post('txtModel'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('counterNo'), $this->input->post('txtCounterNo'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('color'), $this->input->post('txtColor'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('faxTx'), $this->input->post('txtFaxTx'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('receiveRx'), $this->input->post('txtReceiveRx'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('preportMaster'), $this->input->post('txtPreportMaster'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('copy'), $this->input->post('txtCopy'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('createDate'), $this->input->post('txtCreateDate'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('createUser'), $this->input->post('txtCreateUser'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('updateDate'), $this->input->post('txtUpdateDate'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('updateUser'), $this->input->post('txtUpdateUser'));
		ObjectCriteria::addEqCriteria($criteria, ColumnHelper::mapContractColumn('description'), $this->input->post('txtDescription'));
		ObjectCriteria::addOrder($criteria, ColumnHelper::mapContractColumn('machineId'), FALSE);
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