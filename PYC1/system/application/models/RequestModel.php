<?php

class RequestModel extends Model {

    function insert($Request) {
		$sql = 'INSERT INTO request(';
        $sql .= '    REQUEST_ID, ';
        $sql .= '    MACHINE_ID, ';
        $sql .= '    FOLLOW_UP_REQUEST_ID, ';
        $sql .= '    CUSTOMER_CALL_DATE, ';
        $sql .= '    REPORT_DATE, ';
        $sql .= '    FINISH_DATE, ';
        $sql .= '    SERVICE_TYPE, ';
        $sql .= '    PROBLEM_REPORT, ';
        $sql .= '    SYMPTOM, ';
        $sql .= '    CAUSE, ';
        $sql .= '    ACTION, ';
        $sql .= '    CUSTOMER_OPINION, ';
        $sql .= '    CREATE_DATE, ';
        $sql .= '    CREATE_USER, ';
        $sql .= '    UPDATE_DATE, ';
        $sql .= '    UPDATE_USER, ';
        $sql .= '    REQUEST_COST, ';
        $sql .= '    TEMP_CUSTOMER_NAME, ';
        $sql .= '    TEMP_COMPANY_NAME, ';
        $sql .= '    TEMP_ADDRESS, ';
        $sql .= '    TEMP_PHONE, ';
        $sql .= '    TEMP_FAX ';
        $sql .= '    CONTRACT_ID, ';
        $sql .= '    CUSTOMER_ID, ';
        $sql .= '    COMPANY_ID, ';
        $sql .= ') VALUES (';
		$sql .= '   ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?)';
		
        $paramArr = array();
        $paramArr[] = $Request->requestId;
        $paramArr[] = $Request->machineId;
        $paramArr[] = $Request->followUpRequestId;
        $paramArr[] = $Request->customerCallDate;
        $paramArr[] = $Request->reportDate;
        $paramArr[] = $Request->finishDate;
        $paramArr[] = $Request->serviceType;
        $paramArr[] = $Request->problemReport;
        $paramArr[] = $Request->symptom;
        $paramArr[] = $Request->cause;
        $paramArr[] = $Request->action;
        $paramArr[] = $Request->customerOpinion;
        $paramArr[] = $Request->createDate;
        $paramArr[] = $Request->createUser;
        $paramArr[] = $Request->updateDate;
        $paramArr[] = $Request->updateUser;
        $paramArr[] = $Request->requestCost;
        $paramArr[] = $Request->tempCustomerName;
        $paramArr[] = $Request->tempCompanyName;
        $paramArr[] = $Request->tempAddress;
        $paramArr[] = $Request->tempPhone;
        $paramArr[] = $Request->tempFax;
		if ($Request->contract != null) {
        	$paramArr[] = $Request->contract->contractId;
        } else {
        	$paramArr[] = '';
        }
		if ($Request->customer != null) {
        	$paramArr[] = $Request->customer->customerId;
        } else {
        	$paramArr[] = '';
        }
		if ($Request->company != null) {
        	$paramArr[] = $Request->company->companyId;
        } else {
        	$paramArr[] = '';
        }
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
    function update($Request) {
		$sql = 'UPDATE request SET ';
        $sql .= '    MACHINE_ID = ? ';
        $sql .= '    ,FOLLOW_UP_REQUEST_ID = ? ';
        $sql .= '    ,CUSTOMER_CALL_DATE = ? ';
        $sql .= '    ,REPORT_DATE = ? ';
        $sql .= '    ,FINISH_DATE = ? ';
        $sql .= '    ,SERVICE_TYPE = ? ';
        $sql .= '    ,PROBLEM_REPORT = ? ';
        $sql .= '    ,SYMPTOM = ? ';
        $sql .= '    ,CAUSE = ? ';
        $sql .= '    ,ACTION = ? ';
        $sql .= '    ,CUSTOMER_OPINION = ? ';
        $sql .= '    ,CREATE_DATE = ? ';
        $sql .= '    ,CREATE_USER = ? ';
        $sql .= '    ,UPDATE_DATE = ? ';
        $sql .= '    ,UPDATE_USER = ? ';
        $sql .= '    ,REQUEST_COST = ? ';
        $sql .= '    ,TEMP_CUSTOMER_NAME = ? ';
        $sql .= '    ,TEMP_COMPANY_NAME = ? ';
        $sql .= '    ,TEMP_ADDRESS = ? ';
        $sql .= '    ,TEMP_PHONE = ? ';
        $sql .= '    ,TEMP_FAX = ? ';
        $sql .= '    ,CONTRACT_ID = ? ';
        $sql .= '    ,CUSTOMER_ID = ? ';
        $sql .= '    ,COMPANY_ID = ? ';
		$sql .= ' WHERE ';
        $sql .= '    REQUEST_ID = ? ' ;
		
        $paramArr = array();
        $paramArr[] = $Request->machineId;
        $paramArr[] = $Request->followUpRequestId;
        $paramArr[] = $Request->customerCallDate;
        $paramArr[] = $Request->reportDate;
        $paramArr[] = $Request->finishDate;
        $paramArr[] = $Request->serviceType;
        $paramArr[] = $Request->problemReport;
        $paramArr[] = $Request->symptom;
        $paramArr[] = $Request->cause;
        $paramArr[] = $Request->action;
        $paramArr[] = $Request->customerOpinion;
        $paramArr[] = $Request->createDate;
        $paramArr[] = $Request->createUser;
        $paramArr[] = $Request->updateDate;
        $paramArr[] = $Request->updateUser;
        $paramArr[] = $Request->requestCost;
        $paramArr[] = $Request->tempCustomerName;
        $paramArr[] = $Request->tempCompanyName;
        $paramArr[] = $Request->tempAddress;
        $paramArr[] = $Request->tempPhone;
        $paramArr[] = $Request->tempFax;
		if ($Request->contract != null) {
        	$paramArr[] = $Request->contract->contractId;
        } else {
        	$paramArr[] = '';
        }
		if ($Request->customer != null) {
        	$paramArr[] = $Request->customer->customerId;
        } else {
        	$paramArr[] = '';
        }
		if ($Request->company != null) {
        	$paramArr[] = $Request->company->companyId;
        } else {
        	$paramArr[] = '';
        }
        $paramArr[] = $Request->requestId;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    request.REQUEST_ID ';
        $sql .= '    ,request.MACHINE_ID ';
        $sql .= '    ,request.FOLLOW_UP_REQUEST_ID ';
        $sql .= '    ,request.CUSTOMER_CALL_DATE ';
        $sql .= '    ,request.REPORT_DATE ';
        $sql .= '    ,request.FINISH_DATE ';
        $sql .= '    ,request.SERVICE_TYPE ';
        $sql .= '    ,request.PROBLEM_REPORT ';
        $sql .= '    ,request.SYMPTOM ';
        $sql .= '    ,request.CAUSE ';
        $sql .= '    ,request.ACTION ';
        $sql .= '    ,request.CUSTOMER_OPINION ';
        $sql .= '    ,request.CREATE_DATE ';
        $sql .= '    ,request.CREATE_USER ';
        $sql .= '    ,request.UPDATE_DATE ';
        $sql .= '    ,request.UPDATE_USER ';
        $sql .= '    ,request.REQUEST_COST ';
        $sql .= '    ,request.TEMP_CUSTOMER_NAME ';
        $sql .= '    ,request.TEMP_COMPANY_NAME ';
        $sql .= '    ,request.TEMP_ADDRESS ';
        $sql .= '    ,request.TEMP_PHONE ';
        $sql .= '    ,request.TEMP_FAX ';
        $sql .= '    ,contract.CONTRACT_ID ';
        $sql .= '    ,contract.CONTRACT_NUMBER ';
        $sql .= '    ,contract.CUSTOMER_ID ';
        $sql .= '    ,contract.COMPANY_ID ';
        $sql .= '    ,contract.CONTRACT_DATE ';
        $sql .= '    ,contract.CREATE_DATE ';
        $sql .= '    ,contract.CREATE_USER ';
        $sql .= '    ,contract.UPDATE_DATE ';
        $sql .= '    ,contract.UPDATE_USER ';
        $sql .= '    ,customer.CUSTOMER_ID ';
        $sql .= '    ,customer.CUSTOMER_NAME ';
        $sql .= '    ,customer.ADDRESS ';
        $sql .= '    ,customer.COMPANY_ID ';
        $sql .= '    ,customer.PHONE ';
        $sql .= '    ,customer.FAX ';
        $sql .= '    ,customer.CREATE_DATE ';
        $sql .= '    ,customer.CREATE_USER ';
        $sql .= '    ,customer.UPDATE_DATE ';
        $sql .= '    ,customer.UPDATE_USER ';
        $sql .= '    ,company.COMPANY_ID ';
        $sql .= '    ,company.COMPANY_NAME ';
        $sql .= '    ,company.ADDRESS ';
        $sql .= '    ,company.PHONE ';
        $sql .= '    ,company.CREATE_DATE ';
        $sql .= '    ,company.CREATE_USER ';
        $sql .= '    ,company.UPDATE_DATE ';
        $sql .= '    ,company.UPDATE_USER ';
        $sql .= '    ,company.FAX ';
        $sql .= '    ,company.REPRESENT_NAME ';
        $sql .= '    ,company.REPRESENT_PHONE ';
        $sql .= '    ,company.REPRESENT_FAX ';
        $sql .= ' FROM request';
		$sql .= '    LEFT OUTER JOIN contract ON ';
        $sql .= '        contract.CONTRACT_ID ';
		$sql .= '    LEFT OUTER JOIN customer ON ';
        $sql .= '        customer.CUSTOMER_ID ';
		$sql .= '    LEFT OUTER JOIN company ON ';
        $sql .= '        company.COMPANY_ID ';
		$sql .= ' WHERE ';
        $sql .= '    request.REQUEST_ID = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->row();
            $result = new Request();
        	$result->requestId = $row['request.REQUEST_ID'];
            $result->machineId = $row['request.MACHINE_ID'];
            $result->followUpRequestId = $row['request.FOLLOW_UP_REQUEST_ID'];
            $result->customerCallDate = $row['request.CUSTOMER_CALL_DATE'];
            $result->reportDate = $row['request.REPORT_DATE'];
            $result->finishDate = $row['request.FINISH_DATE'];
            $result->serviceType = $row['request.SERVICE_TYPE'];
            $result->problemReport = $row['request.PROBLEM_REPORT'];
            $result->symptom = $row['request.SYMPTOM'];
            $result->cause = $row['request.CAUSE'];
            $result->action = $row['request.ACTION'];
            $result->customerOpinion = $row['request.CUSTOMER_OPINION'];
            $result->createDate = $row['request.CREATE_DATE'];
            $result->createUser = $row['request.CREATE_USER'];
            $result->updateDate = $row['request.UPDATE_DATE'];
            $result->updateUser = $row['request.UPDATE_USER'];
            $result->requestCost = $row['request.REQUEST_COST'];
            $result->tempCustomerName = $row['request.TEMP_CUSTOMER_NAME'];
            $result->tempCompanyName = $row['request.TEMP_COMPANY_NAME'];
            $result->tempAddress = $row['request.TEMP_ADDRESS'];
            $result->tempPhone = $row['request.TEMP_PHONE'];
            $result->tempFax = $row['request.TEMP_FAX'];
             $result->contract = new Contract();
        	$result->contract->contractId = $row['contract.CONTRACT_ID'];
			$result->contract->contractNumber = $row['contract.CONTRACT_NUMBER'];
			$result->contract->customerId = $row['contract.CUSTOMER_ID'];
			$result->contract->companyId = $row['contract.COMPANY_ID'];
			$result->contract->contractDate = $row['contract.CONTRACT_DATE'];
			$result->contract->createDate = $row['contract.CREATE_DATE'];
			$result->contract->createUser = $row['contract.CREATE_USER'];
			$result->contract->updateDate = $row['contract.UPDATE_DATE'];
			$result->contract->updateUser = $row['contract.UPDATE_USER'];
             $result->customer = new Customer();
        	$result->customer->customerId = $row['customer.CUSTOMER_ID'];
			$result->customer->customerName = $row['customer.CUSTOMER_NAME'];
			$result->customer->address = $row['customer.ADDRESS'];
			$result->customer->companyId = $row['customer.COMPANY_ID'];
			$result->customer->phone = $row['customer.PHONE'];
			$result->customer->fax = $row['customer.FAX'];
			$result->customer->createDate = $row['customer.CREATE_DATE'];
			$result->customer->createUser = $row['customer.CREATE_USER'];
			$result->customer->updateDate = $row['customer.UPDATE_DATE'];
			$result->customer->updateUser = $row['customer.UPDATE_USER'];
             $result->company = new Company();
        	$result->company->companyId = $row['company.COMPANY_ID'];
			$result->company->companyName = $row['company.COMPANY_NAME'];
			$result->company->address = $row['company.ADDRESS'];
			$result->company->phone = $row['company.PHONE'];
			$result->company->createDate = $row['company.CREATE_DATE'];
			$result->company->createUser = $row['company.CREATE_USER'];
			$result->company->updateDate = $row['company.UPDATE_DATE'];
			$result->company->updateUser = $row['company.UPDATE_USER'];
			$result->company->fax = $row['company.FAX'];
			$result->company->representName = $row['company.REPRESENT_NAME'];
			$result->company->representPhone = $row['company.REPRESENT_PHONE'];
			$result->company->representFax = $row['company.REPRESENT_FAX'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    request.REQUEST_ID ';
        $sql .= '    ,request.MACHINE_ID ';
        $sql .= '    ,request.FOLLOW_UP_REQUEST_ID ';
        $sql .= '    ,request.CUSTOMER_CALL_DATE ';
        $sql .= '    ,request.REPORT_DATE ';
        $sql .= '    ,request.FINISH_DATE ';
        $sql .= '    ,request.SERVICE_TYPE ';
        $sql .= '    ,request.PROBLEM_REPORT ';
        $sql .= '    ,request.SYMPTOM ';
        $sql .= '    ,request.CAUSE ';
        $sql .= '    ,request.ACTION ';
        $sql .= '    ,request.CUSTOMER_OPINION ';
        $sql .= '    ,request.CREATE_DATE ';
        $sql .= '    ,request.CREATE_USER ';
        $sql .= '    ,request.UPDATE_DATE ';
        $sql .= '    ,request.UPDATE_USER ';
        $sql .= '    ,request.REQUEST_COST ';
        $sql .= '    ,request.TEMP_CUSTOMER_NAME ';
        $sql .= '    ,request.TEMP_COMPANY_NAME ';
        $sql .= '    ,request.TEMP_ADDRESS ';
        $sql .= '    ,request.TEMP_PHONE ';
        $sql .= '    ,request.TEMP_FAX ';
        $sql .= '    ,contract.CONTRACT_ID ';
        $sql .= '    ,contract.CONTRACT_NUMBER ';
        $sql .= '    ,contract.CUSTOMER_ID ';
        $sql .= '    ,contract.COMPANY_ID ';
        $sql .= '    ,contract.CONTRACT_DATE ';
        $sql .= '    ,contract.CREATE_DATE ';
        $sql .= '    ,contract.CREATE_USER ';
        $sql .= '    ,contract.UPDATE_DATE ';
        $sql .= '    ,contract.UPDATE_USER ';
        $sql .= '    ,customer.CUSTOMER_ID ';
        $sql .= '    ,customer.CUSTOMER_NAME ';
        $sql .= '    ,customer.ADDRESS ';
        $sql .= '    ,customer.COMPANY_ID ';
        $sql .= '    ,customer.PHONE ';
        $sql .= '    ,customer.FAX ';
        $sql .= '    ,customer.CREATE_DATE ';
        $sql .= '    ,customer.CREATE_USER ';
        $sql .= '    ,customer.UPDATE_DATE ';
        $sql .= '    ,customer.UPDATE_USER ';
        $sql .= '    ,company.COMPANY_ID ';
        $sql .= '    ,company.COMPANY_NAME ';
        $sql .= '    ,company.ADDRESS ';
        $sql .= '    ,company.PHONE ';
        $sql .= '    ,company.CREATE_DATE ';
        $sql .= '    ,company.CREATE_USER ';
        $sql .= '    ,company.UPDATE_DATE ';
        $sql .= '    ,company.UPDATE_USER ';
        $sql .= '    ,company.FAX ';
        $sql .= '    ,company.REPRESENT_NAME ';
        $sql .= '    ,company.REPRESENT_PHONE ';
        $sql .= '    ,company.REPRESENT_FAX ';
        $sql .= ' FROM request';
		$sql .= '    LEFT OUTER JOIN contract ON ';
        $sql .= '        contract.CONTRACT_ID ';
		$sql .= '    LEFT OUTER JOIN customer ON ';
        $sql .= '        customer.CUSTOMER_ID ';
		$sql .= '    LEFT OUTER JOIN company ON ';
        $sql .= '        company.COMPANY_ID ';
		$paramArr = array();
	    if ($criteria != null) {
	    	if (count($criteria->where) > 0) {
	    		$countCriteria = count($criteria->where);
				$sql .= ' WHERE ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria->where as $key => $value) {
		            if ($index != $countCriteria - 1) {
		            	$concator = ' AND ';
		            } else {
		            	$concator = ' ';
		            }
		            $index++;
		            
		            $sql .= $key . ' ' . $criteria->operator[$key] . ' ' . $value . $concator;
		            if ($value != null) {
						$paramArr[] = $value;
		            }
		        }
		    }
	    	if (count($criteria->order) > 0) {
				$countCriteria = count($criteria->order);
				$sql .= ' ORDER BY ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria->order as $key => $value) {
		            if ($index != $countCriteria - 1) {
		            	$concator = ' , ';
		            } else {
		            	$concator = ' ';
		            }
		            $index++;
		            
		            $sql .= $key . ' ' . $value . ' '.$concator;
		        }
		    }
	    }
    
    	$query = $this->db->query($sql, $paramArr);

        if ($query->num_rows() > 0)
        {
        	$resultList = array();
        	foreach ($query->result() as $row) {
                $result = new Request();
        	    $result->requestId = $row['request.REQUEST_ID'];
                $result->machineId = $row['request.MACHINE_ID'];
                $result->followUpRequestId = $row['request.FOLLOW_UP_REQUEST_ID'];
                $result->customerCallDate = $row['request.CUSTOMER_CALL_DATE'];
                $result->reportDate = $row['request.REPORT_DATE'];
                $result->finishDate = $row['request.FINISH_DATE'];
                $result->serviceType = $row['request.SERVICE_TYPE'];
                $result->problemReport = $row['request.PROBLEM_REPORT'];
                $result->symptom = $row['request.SYMPTOM'];
                $result->cause = $row['request.CAUSE'];
                $result->action = $row['request.ACTION'];
                $result->customerOpinion = $row['request.CUSTOMER_OPINION'];
                $result->createDate = $row['request.CREATE_DATE'];
                $result->createUser = $row['request.CREATE_USER'];
                $result->updateDate = $row['request.UPDATE_DATE'];
                $result->updateUser = $row['request.UPDATE_USER'];
                $result->requestCost = $row['request.REQUEST_COST'];
                $result->tempCustomerName = $row['request.TEMP_CUSTOMER_NAME'];
                $result->tempCompanyName = $row['request.TEMP_COMPANY_NAME'];
                $result->tempAddress = $row['request.TEMP_ADDRESS'];
                $result->tempPhone = $row['request.TEMP_PHONE'];
                $result->tempFax = $row['request.TEMP_FAX'];
                 $result->contract = new Contract();
        	    $result->contract->contractId = $row['contract.CONTRACT_ID'];
			    $result->contract->contractNumber = $row['contract.CONTRACT_NUMBER'];
			    $result->contract->customerId = $row['contract.CUSTOMER_ID'];
			    $result->contract->companyId = $row['contract.COMPANY_ID'];
			    $result->contract->contractDate = $row['contract.CONTRACT_DATE'];
			    $result->contract->createDate = $row['contract.CREATE_DATE'];
			    $result->contract->createUser = $row['contract.CREATE_USER'];
			    $result->contract->updateDate = $row['contract.UPDATE_DATE'];
			    $result->contract->updateUser = $row['contract.UPDATE_USER'];
                 $result->customer = new Customer();
        	    $result->customer->customerId = $row['customer.CUSTOMER_ID'];
			    $result->customer->customerName = $row['customer.CUSTOMER_NAME'];
			    $result->customer->address = $row['customer.ADDRESS'];
			    $result->customer->companyId = $row['customer.COMPANY_ID'];
			    $result->customer->phone = $row['customer.PHONE'];
			    $result->customer->fax = $row['customer.FAX'];
			    $result->customer->createDate = $row['customer.CREATE_DATE'];
			    $result->customer->createUser = $row['customer.CREATE_USER'];
			    $result->customer->updateDate = $row['customer.UPDATE_DATE'];
			    $result->customer->updateUser = $row['customer.UPDATE_USER'];
                 $result->company = new Company();
        	    $result->company->companyId = $row['company.COMPANY_ID'];
			    $result->company->companyName = $row['company.COMPANY_NAME'];
			    $result->company->address = $row['company.ADDRESS'];
			    $result->company->phone = $row['company.PHONE'];
			    $result->company->createDate = $row['company.CREATE_DATE'];
			    $result->company->createUser = $row['company.CREATE_USER'];
			    $result->company->updateDate = $row['company.UPDATE_DATE'];
			    $result->company->updateUser = $row['company.UPDATE_USER'];
			    $result->company->fax = $row['company.FAX'];
			    $result->company->representName = $row['company.REPRESENT_NAME'];
			    $result->company->representPhone = $row['company.REPRESENT_PHONE'];
			    $result->company->representFax = $row['company.REPRESENT_FAX'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*)';
        $sql .= ' FROM request ';
		$sql .= '    LEFT OUTER JOIN contract ON ';
        $sql .= '        contract.CONTRACT_ID ';
		$sql .= '    LEFT OUTER JOIN customer ON ';
        $sql .= '        customer.CUSTOMER_ID ';
		$sql .= '    LEFT OUTER JOIN company ON ';
        $sql .= '        company.COMPANY_ID ';
		$paramArr = array();
	    if ($criteria != null) {
	    	if (count($criteria->where) > 0) {
	    		$countCriteria = count($criteria->where);
				$sql .= ' WHERE ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria->where as $key => $value) {
		            if ($index != $countCriteria - 1) {
		            	$concator = ' AND ';
		            } else {
		            	$concator = ' ';
		            }
		            $index++;
		            
		            $sql .= $key . ' ' . $criteria->operator[$key] . ' ' . $value . $concator;
		            if ($value != null) {
						$paramArr[] = $value;
		            }
		        }
		    }
	    }
    
    	$query = $this->db->query($sql, $paramArr);
        $row = $query->row();
		return $row->COUNTER;	
	}
	
	function findPaging($criteria, $pageNumber, $recordPerPage) {
		$sql = 'SELECT ';
        $sql .= '    request.REQUEST_ID ';
        $sql .= '    ,request.MACHINE_ID ';
        $sql .= '    ,request.FOLLOW_UP_REQUEST_ID ';
        $sql .= '    ,request.CUSTOMER_CALL_DATE ';
        $sql .= '    ,request.REPORT_DATE ';
        $sql .= '    ,request.FINISH_DATE ';
        $sql .= '    ,request.SERVICE_TYPE ';
        $sql .= '    ,request.PROBLEM_REPORT ';
        $sql .= '    ,request.SYMPTOM ';
        $sql .= '    ,request.CAUSE ';
        $sql .= '    ,request.ACTION ';
        $sql .= '    ,request.CUSTOMER_OPINION ';
        $sql .= '    ,request.CREATE_DATE ';
        $sql .= '    ,request.CREATE_USER ';
        $sql .= '    ,request.UPDATE_DATE ';
        $sql .= '    ,request.UPDATE_USER ';
        $sql .= '    ,request.REQUEST_COST ';
        $sql .= '    ,request.TEMP_CUSTOMER_NAME ';
        $sql .= '    ,request.TEMP_COMPANY_NAME ';
        $sql .= '    ,request.TEMP_ADDRESS ';
        $sql .= '    ,request.TEMP_PHONE ';
        $sql .= '    ,request.TEMP_FAX ';
        $sql .= '    ,contract.CONTRACT_ID ';
        $sql .= '    ,contract.CONTRACT_NUMBER ';
        $sql .= '    ,contract.CUSTOMER_ID ';
        $sql .= '    ,contract.COMPANY_ID ';
        $sql .= '    ,contract.CONTRACT_DATE ';
        $sql .= '    ,contract.CREATE_DATE ';
        $sql .= '    ,contract.CREATE_USER ';
        $sql .= '    ,contract.UPDATE_DATE ';
        $sql .= '    ,contract.UPDATE_USER ';
        $sql .= '    ,customer.CUSTOMER_ID ';
        $sql .= '    ,customer.CUSTOMER_NAME ';
        $sql .= '    ,customer.ADDRESS ';
        $sql .= '    ,customer.COMPANY_ID ';
        $sql .= '    ,customer.PHONE ';
        $sql .= '    ,customer.FAX ';
        $sql .= '    ,customer.CREATE_DATE ';
        $sql .= '    ,customer.CREATE_USER ';
        $sql .= '    ,customer.UPDATE_DATE ';
        $sql .= '    ,customer.UPDATE_USER ';
        $sql .= '    ,company.COMPANY_ID ';
        $sql .= '    ,company.COMPANY_NAME ';
        $sql .= '    ,company.ADDRESS ';
        $sql .= '    ,company.PHONE ';
        $sql .= '    ,company.CREATE_DATE ';
        $sql .= '    ,company.CREATE_USER ';
        $sql .= '    ,company.UPDATE_DATE ';
        $sql .= '    ,company.UPDATE_USER ';
        $sql .= '    ,company.FAX ';
        $sql .= '    ,company.REPRESENT_NAME ';
        $sql .= '    ,company.REPRESENT_PHONE ';
        $sql .= '    ,company.REPRESENT_FAX ';
        $sql .= ' FROM request';
		$sql .= '    LEFT OUTER JOIN contract ON ';
        $sql .= '        contract.CONTRACT_ID ';
		$sql .= '    LEFT OUTER JOIN customer ON ';
        $sql .= '        customer.CUSTOMER_ID ';
		$sql .= '    LEFT OUTER JOIN company ON ';
        $sql .= '        company.COMPANY_ID ';
		$paramArr = array();
	    if ($criteria != null) {
	    	if (count($criteria->where) > 0) {
	    		$countCriteria = count($criteria->where);
				$sql .= ' WHERE ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria->where as $key => $value) {
		            if ($index != $countCriteria - 1) {
		            	$concator = ' AND ';
		            } else {
		            	$concator = ' ';
		            }
		            $index++;
		            
		            $sql .= $key . ' ' . $criteria->operator[$key] . ' ' . $value . $concator;
		            if ($value != null) {
						$paramArr[] = $value;
		            }
		        }
		    }
	    	if (count($criteria->order) > 0) {
				$countCriteria = count($criteria->order);
				$sql .= ' ORDER BY ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria->order as $key => $value) {
		            if ($index != $countCriteria - 1) {
		            	$concator = ' , ';
		            } else {
		            	$concator = ' ';
		            }
		            $index++;
		            
		            $sql .= $key . ' ' . $value . ' '.$concator;
		        }
		    }
	    }

		$sql .= ' LIMIT ' . ($pageNumber * $recordPerPage) . ' ' . $recordPerPage;

    	$query = $this->db->query($sql, $paramArr);

        if ($query->num_rows() > 0)
        {
        	$resultList = array();
        	foreach ($query->result() as $row) {
                $result = new Request();
        	    $result->requestId = $row['request.REQUEST_ID'];
                $result->machineId = $row['request.MACHINE_ID'];
                $result->followUpRequestId = $row['request.FOLLOW_UP_REQUEST_ID'];
                $result->customerCallDate = $row['request.CUSTOMER_CALL_DATE'];
                $result->reportDate = $row['request.REPORT_DATE'];
                $result->finishDate = $row['request.FINISH_DATE'];
                $result->serviceType = $row['request.SERVICE_TYPE'];
                $result->problemReport = $row['request.PROBLEM_REPORT'];
                $result->symptom = $row['request.SYMPTOM'];
                $result->cause = $row['request.CAUSE'];
                $result->action = $row['request.ACTION'];
                $result->customerOpinion = $row['request.CUSTOMER_OPINION'];
                $result->createDate = $row['request.CREATE_DATE'];
                $result->createUser = $row['request.CREATE_USER'];
                $result->updateDate = $row['request.UPDATE_DATE'];
                $result->updateUser = $row['request.UPDATE_USER'];
                $result->requestCost = $row['request.REQUEST_COST'];
                $result->tempCustomerName = $row['request.TEMP_CUSTOMER_NAME'];
                $result->tempCompanyName = $row['request.TEMP_COMPANY_NAME'];
                $result->tempAddress = $row['request.TEMP_ADDRESS'];
                $result->tempPhone = $row['request.TEMP_PHONE'];
                $result->tempFax = $row['request.TEMP_FAX'];
                 $result->contract = new Contract();
        	    $result->contract->contractId = $row['contract.CONTRACT_ID'];
			    $result->contract->contractNumber = $row['contract.CONTRACT_NUMBER'];
			    $result->contract->customerId = $row['contract.CUSTOMER_ID'];
			    $result->contract->companyId = $row['contract.COMPANY_ID'];
			    $result->contract->contractDate = $row['contract.CONTRACT_DATE'];
			    $result->contract->createDate = $row['contract.CREATE_DATE'];
			    $result->contract->createUser = $row['contract.CREATE_USER'];
			    $result->contract->updateDate = $row['contract.UPDATE_DATE'];
			    $result->contract->updateUser = $row['contract.UPDATE_USER'];
                 $result->customer = new Customer();
        	    $result->customer->customerId = $row['customer.CUSTOMER_ID'];
			    $result->customer->customerName = $row['customer.CUSTOMER_NAME'];
			    $result->customer->address = $row['customer.ADDRESS'];
			    $result->customer->companyId = $row['customer.COMPANY_ID'];
			    $result->customer->phone = $row['customer.PHONE'];
			    $result->customer->fax = $row['customer.FAX'];
			    $result->customer->createDate = $row['customer.CREATE_DATE'];
			    $result->customer->createUser = $row['customer.CREATE_USER'];
			    $result->customer->updateDate = $row['customer.UPDATE_DATE'];
			    $result->customer->updateUser = $row['customer.UPDATE_USER'];
                 $result->company = new Company();
        	    $result->company->companyId = $row['company.COMPANY_ID'];
			    $result->company->companyName = $row['company.COMPANY_NAME'];
			    $result->company->address = $row['company.ADDRESS'];
			    $result->company->phone = $row['company.PHONE'];
			    $result->company->createDate = $row['company.CREATE_DATE'];
			    $result->company->createUser = $row['company.CREATE_USER'];
			    $result->company->updateDate = $row['company.UPDATE_DATE'];
			    $result->company->updateUser = $row['company.UPDATE_USER'];
			    $result->company->fax = $row['company.FAX'];
			    $result->company->representName = $row['company.REPRESENT_NAME'];
			    $result->company->representPhone = $row['company.REPRESENT_PHONE'];
			    $result->company->representFax = $row['company.REPRESENT_FAX'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>