<?php

class RequestStatusModel extends Model {

    function insert($RequestStatus) {
		$sql = 'INSERT INTO request_status(';
        
        $sql .= '    CREATE_DATE, ';
        $sql .= '    CREATE_USER, ';
        $sql .= '    UPDATE_DATE, ';
        $sql .= '    UPDATE_USER, ';
        $sql .= '    DESCRIPTION ';
        $sql .= '    STATUS_TYPE, ';
        $sql .= '    REQUEST_ID) VALUES (';
		$sql .= '   ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?)';
		
        $paramArr = array();
        
        $paramArr[] = isset($RequestStatus['createDate']) ? $RequestStatus['createDate'] : null;
        $paramArr[] = isset($RequestStatus['createUser']) ? $RequestStatus['createUser'] : null;
        $paramArr[] = isset($RequestStatus['updateDate']) ? $RequestStatus['updateDate'] : null;
        $paramArr[] = isset($RequestStatus['updateUser']) ? $RequestStatus['updateUser'] : null;
        $paramArr[] = isset($RequestStatus['description']) ? $RequestStatus['description'] : null;
		if ($RequestStatus->statusTypeMaster != null) {
        	$paramArr[] = isset($RequestStatus['statusTypeMaster.statusType']) ? $RequestStatus['statusTypeMaster.statusType'] : null;
        } else {
        	$paramArr[] = '';
        }
		if ($RequestStatus->request != null) {
        	$paramArr[] = isset($RequestStatus['request.requestId']) ? $RequestStatus['request.requestId'] : null;
        } else {
        	$paramArr[] = '';
        }
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
    function update($RequestStatus) {
		$sql = 'UPDATE request_status SET ';
        $sql .= '    CREATE_DATE = ? ';
        $sql .= '    ,CREATE_USER = ? ';
        $sql .= '    ,UPDATE_DATE = ? ';
        $sql .= '    ,UPDATE_USER = ? ';
        $sql .= '    ,DESCRIPTION = ? ';
        $sql .= '    ,STATUS_TYPE = ? ';
        $sql .= '    ,REQUEST_ID = ? ';
		$sql .= ' WHERE ';
        $sql .= '    REQUEST_STATUS_ID = ? ' ;
		
        $paramArr = array();
        $paramArr[] = isset($RequestStatus['createDate']) ? $RequestStatus['createDate'] : null;
        $paramArr[] = isset($RequestStatus['createUser']) ? $RequestStatus['createUser'] : null;
        $paramArr[] = isset($RequestStatus['updateDate']) ? $RequestStatus['updateDate'] : null;
        $paramArr[] = isset($RequestStatus['updateUser']) ? $RequestStatus['updateUser'] : null;
        $paramArr[] = isset($RequestStatus['description']) ? $RequestStatus['description'] : null;
       	$paramArr[] = isset($RequestStatus['statusTypeMaster.statusType']) ? $RequestStatus['statusTypeMaster.statusType'] : null;
       	$paramArr[] = isset($RequestStatus['request.requestId']) ? $RequestStatus['request.requestId'] : null;
        $paramArr[] = isset($RequestStatus['requestStatusId']) ? $RequestStatus['requestStatusId'] : null;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    request_status.REQUEST_STATUS_ID as request_status_REQUEST_STATUS_ID';
        $sql .= '    ,request_status.CREATE_DATE as request_status_CREATE_DATE';
        $sql .= '    ,request_status.CREATE_USER as request_status_CREATE_USER';
        $sql .= '    ,request_status.UPDATE_DATE as request_status_UPDATE_DATE';
        $sql .= '    ,request_status.UPDATE_USER as request_status_UPDATE_USER';
        $sql .= '    ,request_status.DESCRIPTION as request_status_DESCRIPTION';
        $sql .= '    ,status_type_master.STATUS_TYPE as status_type_master_STATUS_TYPE';
        $sql .= '    ,status_type_master.STATUS_NAME as status_type_master_STATUS_NAME';
        $sql .= '    ,request.REQUEST_ID as request_REQUEST_ID';
        $sql .= '    ,request.FOLLOW_UP_REQUEST_ID as request_FOLLOW_UP_REQUEST_ID';
        $sql .= '    ,request.CUSTOMER_CALL_DATE as request_CUSTOMER_CALL_DATE';
        $sql .= '    ,request.REPORT_DATE as request_REPORT_DATE';
        $sql .= '    ,request.FINISH_DATE as request_FINISH_DATE';
        $sql .= '    ,request.SERVICE_TYPE as request_SERVICE_TYPE';
        $sql .= '    ,request.PROBLEM_REPORT as request_PROBLEM_REPORT';
        $sql .= '    ,request.SYMPTOM as request_SYMPTOM';
        $sql .= '    ,request.CAUSE as request_CAUSE';
        $sql .= '    ,request.ACTION as request_ACTION';
        $sql .= '    ,request.CUSTOMER_OPINION as request_CUSTOMER_OPINION';
        $sql .= '    ,request.CREATE_DATE as request_CREATE_DATE';
        $sql .= '    ,request.CREATE_USER as request_CREATE_USER';
        $sql .= '    ,request.UPDATE_DATE as request_UPDATE_DATE';
        $sql .= '    ,request.UPDATE_USER as request_UPDATE_USER';
        $sql .= '    ,request.REQUEST_COST as request_REQUEST_COST';
        $sql .= '    ,request.TEMP_CUSTOMER_NAME as request_TEMP_CUSTOMER_NAME';
        $sql .= '    ,request.TEMP_COMPANY_NAME as request_TEMP_COMPANY_NAME';
        $sql .= '    ,request.TEMP_ADDRESS as request_TEMP_ADDRESS';
        $sql .= '    ,request.TEMP_PHONE as request_TEMP_PHONE';
        $sql .= '    ,request.TEMP_FAX as request_TEMP_FAX';
        $sql .= ' FROM request_status';
		$sql .= '    LEFT OUTER JOIN status_type_master ON ';
        $sql .= '        status_type_master.STATUS_TYPE ';
		$sql .= '    LEFT OUTER JOIN request ON ';
        $sql .= '        request.REQUEST_ID ';
		$sql .= ' WHERE ';
        $sql .= '    request_status.REQUEST_STATUS_ID = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->result_array();
            $result = array();
        	$result['requestStatusId'] = $row[0]['request_status_REQUEST_STATUS_ID'];
            $result['createDate'] = $row[0]['request_status_CREATE_DATE'];
            $result['createUser'] = $row[0]['request_status_CREATE_USER'];
            $result['updateDate'] = $row[0]['request_status_UPDATE_DATE'];
            $result['updateUser'] = $row[0]['request_status_UPDATE_USER'];
            $result['description'] = $row[0]['request_status_DESCRIPTION'];
        	$result['statusTypeMaster.statusType'] = $row[0]['status_type_master_STATUS_TYPE'];
			$result['statusTypeMaster.statusName'] = $row[0]['status_type_master_STATUS_NAME'];
        	$result['request.requestId'] = $row[0]['request_REQUEST_ID'];
			$result['request.followUpRequestId'] = $row[0]['request_FOLLOW_UP_REQUEST_ID'];
			$result['request.customerCallDate'] = $row[0]['request_CUSTOMER_CALL_DATE'];
			$result['request.reportDate'] = $row[0]['request_REPORT_DATE'];
			$result['request.finishDate'] = $row[0]['request_FINISH_DATE'];
			$result['request.serviceType'] = $row[0]['request_SERVICE_TYPE'];
			$result['request.problemReport'] = $row[0]['request_PROBLEM_REPORT'];
			$result['request.symptom'] = $row[0]['request_SYMPTOM'];
			$result['request.cause'] = $row[0]['request_CAUSE'];
			$result['request.action'] = $row[0]['request_ACTION'];
			$result['request.customerOpinion'] = $row[0]['request_CUSTOMER_OPINION'];
			$result['request.createDate'] = $row[0]['request_CREATE_DATE'];
			$result['request.createUser'] = $row[0]['request_CREATE_USER'];
			$result['request.updateDate'] = $row[0]['request_UPDATE_DATE'];
			$result['request.updateUser'] = $row[0]['request_UPDATE_USER'];
			$result['request.requestCost'] = $row[0]['request_REQUEST_COST'];
			$result['request.tempCustomerName'] = $row[0]['request_TEMP_CUSTOMER_NAME'];
			$result['request.tempCompanyName'] = $row[0]['request_TEMP_COMPANY_NAME'];
			$result['request.tempAddress'] = $row[0]['request_TEMP_ADDRESS'];
			$result['request.tempPhone'] = $row[0]['request_TEMP_PHONE'];
			$result['request.tempFax'] = $row[0]['request_TEMP_FAX'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    request_status_REQUEST_STATUS_ID as request_status.REQUEST_STATUS_ID ';
        $sql .= '    ,request_status.CREATE_DATE as request_status_CREATE_DATE ';
        $sql .= '    ,request_status.CREATE_USER as request_status_CREATE_USER ';
        $sql .= '    ,request_status.UPDATE_DATE as request_status_UPDATE_DATE ';
        $sql .= '    ,request_status.UPDATE_USER as request_status_UPDATE_USER ';
        $sql .= '    ,request_status.DESCRIPTION as request_status_DESCRIPTION ';
        $sql .= '    ,status_type_master.STATUS_TYPE as status_type_master_STATUS_TYPE ';
        $sql .= '    ,status_type_master.STATUS_NAME as status_type_master_STATUS_NAME ';
        $sql .= '    ,request.REQUEST_ID as request_REQUEST_ID ';
        $sql .= '    ,request.FOLLOW_UP_REQUEST_ID as request_FOLLOW_UP_REQUEST_ID ';
        $sql .= '    ,request.CUSTOMER_CALL_DATE as request_CUSTOMER_CALL_DATE ';
        $sql .= '    ,request.REPORT_DATE as request_REPORT_DATE ';
        $sql .= '    ,request.FINISH_DATE as request_FINISH_DATE ';
        $sql .= '    ,request.SERVICE_TYPE as request_SERVICE_TYPE ';
        $sql .= '    ,request.PROBLEM_REPORT as request_PROBLEM_REPORT ';
        $sql .= '    ,request.SYMPTOM as request_SYMPTOM ';
        $sql .= '    ,request.CAUSE as request_CAUSE ';
        $sql .= '    ,request.ACTION as request_ACTION ';
        $sql .= '    ,request.CUSTOMER_OPINION as request_CUSTOMER_OPINION ';
        $sql .= '    ,request.CREATE_DATE as request_CREATE_DATE ';
        $sql .= '    ,request.CREATE_USER as request_CREATE_USER ';
        $sql .= '    ,request.UPDATE_DATE as request_UPDATE_DATE ';
        $sql .= '    ,request.UPDATE_USER as request_UPDATE_USER ';
        $sql .= '    ,request.REQUEST_COST as request_REQUEST_COST ';
        $sql .= '    ,request.TEMP_CUSTOMER_NAME as request_TEMP_CUSTOMER_NAME ';
        $sql .= '    ,request.TEMP_COMPANY_NAME as request_TEMP_COMPANY_NAME ';
        $sql .= '    ,request.TEMP_ADDRESS as request_TEMP_ADDRESS ';
        $sql .= '    ,request.TEMP_PHONE as request_TEMP_PHONE ';
        $sql .= '    ,request.TEMP_FAX as request_TEMP_FAX ';
        $sql .= ' FROM request_status';
		$sql .= '    LEFT OUTER JOIN status_type_master ON ';
        $sql .= '        status_type_master.STATUS_TYPE ';
		$sql .= '    LEFT OUTER JOIN request ON ';
        $sql .= '        request.REQUEST_ID ';
		$paramArr = array();
	    if ($criteria != null && count($criteria) > 0) {
	    	if (count($criteria['where']) > 0) {
	    		$countCriteria = count($criteria['where']);
				$sql .= ' WHERE ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria['where'] as $key => $value) {
		            if ($index != $countCriteria - 1) {
		            	$concator = ' AND ';
		            } else {
		            	$concator = ' ';
		            }
		            $index++;
		            
		            $sql .= $key . ' ' . $criteria['operator'][$key] . ' ' . $value . $concator;
		            if ($value != null) {
						$paramArr[] = $value;
		            }
		        }
		    }
	    	if (count($criteria['order']) > 0) {
				$countCriteria = count($criteria['order']);
				$sql .= ' ORDER BY ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria['order'] as $key => $value) {
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
        	foreach ($query->result_array() as $row) {
                $result = array();
        	    $result['requestStatusId'] = $row['request_status_REQUEST_STATUS_ID'];
                $result['createDate'] = $row['request_status_CREATE_DATE'];
                $result['createUser'] = $row['request_status_CREATE_USER'];
                $result['updateDate'] = $row['request_status_UPDATE_DATE'];
                $result['updateUser'] = $row['request_status_UPDATE_USER'];
                $result['description'] = $row['request_status_DESCRIPTION'];
        	    $result['statusTypeMaster.statusType'] = $row['status_type_master_STATUS_TYPE'];
			    $result['statusTypeMaster.statusName'] = $row['status_type_master_STATUS_NAME'];
        	    $result['request.requestId'] = $row['request_REQUEST_ID'];
			    $result['request.followUpRequestId'] = $row['request_FOLLOW_UP_REQUEST_ID'];
			    $result['request.customerCallDate'] = $row['request_CUSTOMER_CALL_DATE'];
			    $result['request.reportDate'] = $row['request_REPORT_DATE'];
			    $result['request.finishDate'] = $row['request_FINISH_DATE'];
			    $result['request.serviceType'] = $row['request_SERVICE_TYPE'];
			    $result['request.problemReport'] = $row['request_PROBLEM_REPORT'];
			    $result['request.symptom'] = $row['request_SYMPTOM'];
			    $result['request.cause'] = $row['request_CAUSE'];
			    $result['request.action'] = $row['request_ACTION'];
			    $result['request.customerOpinion'] = $row['request_CUSTOMER_OPINION'];
			    $result['request.createDate'] = $row['request_CREATE_DATE'];
			    $result['request.createUser'] = $row['request_CREATE_USER'];
			    $result['request.updateDate'] = $row['request_UPDATE_DATE'];
			    $result['request.updateUser'] = $row['request_UPDATE_USER'];
			    $result['request.requestCost'] = $row['request_REQUEST_COST'];
			    $result['request.tempCustomerName'] = $row['request_TEMP_CUSTOMER_NAME'];
			    $result['request.tempCompanyName'] = $row['request_TEMP_COMPANY_NAME'];
			    $result['request.tempAddress'] = $row['request_TEMP_ADDRESS'];
			    $result['request.tempPhone'] = $row['request_TEMP_PHONE'];
			    $result['request.tempFax'] = $row['request_TEMP_FAX'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*) as COUNT_VALUE ';
        $sql .= ' FROM request_status ';
		$sql .= '    LEFT OUTER JOIN status_type_master ON ';
        $sql .= '        status_type_master.STATUS_TYPE ';
		$sql .= '    LEFT OUTER JOIN request ON ';
        $sql .= '        request.REQUEST_ID ';
		$paramArr = array();
	    if ($criteria != null && count($criteria) > 0) {
	    	if (count($criteria['where']) > 0) {
	    		$countCriteria = count($criteria['where']);
				$sql .= ' WHERE ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria['where'] as $key => $value) {
		            if ($index != $countCriteria - 1) {
		            	$concator = ' AND ';
		            } else {
		            	$concator = ' ';
		            }
		            $index++;
		            
		            $sql .= $key . ' ' . $criteria['operator'][$key] . ' ' . $value . $concator;
		            if ($value != null) {
						$paramArr[] = $value;
		            }
		        }
		    }
	    }
    
    	$query = $this->db->query($sql, $paramArr);
        $row = $query->result_array();
		return $row[0]['COUNT_VALUE'];	
	}
	
	function findPaging($criteria) {
		$sql = 'SELECT ';
        $sql .= '    request_status.REQUEST_STATUS_ID as request_status_REQUEST_STATUS_ID ';
        $sql .= '    ,request_status.CREATE_DATE as request_status_CREATE_DATE ';
        $sql .= '    ,request_status.CREATE_USER as request_status_CREATE_USER ';
        $sql .= '    ,request_status.UPDATE_DATE as request_status_UPDATE_DATE ';
        $sql .= '    ,request_status.UPDATE_USER as request_status_UPDATE_USER ';
        $sql .= '    ,request_status.DESCRIPTION as request_status_DESCRIPTION ';
        $sql .= '    ,status_type_master.STATUS_TYPE as status_type_master_STATUS_TYPE ';
        $sql .= '    ,status_type_master.STATUS_NAME as status_type_master_STATUS_NAME ';
        $sql .= '    ,request.REQUEST_ID as request_REQUEST_ID ';
        $sql .= '    ,request.FOLLOW_UP_REQUEST_ID as request_FOLLOW_UP_REQUEST_ID ';
        $sql .= '    ,request.CUSTOMER_CALL_DATE as request_CUSTOMER_CALL_DATE ';
        $sql .= '    ,request.REPORT_DATE as request_REPORT_DATE ';
        $sql .= '    ,request.FINISH_DATE as request_FINISH_DATE ';
        $sql .= '    ,request.SERVICE_TYPE as request_SERVICE_TYPE ';
        $sql .= '    ,request.PROBLEM_REPORT as request_PROBLEM_REPORT ';
        $sql .= '    ,request.SYMPTOM as request_SYMPTOM ';
        $sql .= '    ,request.CAUSE as request_CAUSE ';
        $sql .= '    ,request.ACTION as request_ACTION ';
        $sql .= '    ,request.CUSTOMER_OPINION as request_CUSTOMER_OPINION ';
        $sql .= '    ,request.CREATE_DATE as request_CREATE_DATE ';
        $sql .= '    ,request.CREATE_USER as request_CREATE_USER ';
        $sql .= '    ,request.UPDATE_DATE as request_UPDATE_DATE ';
        $sql .= '    ,request.UPDATE_USER as request_UPDATE_USER ';
        $sql .= '    ,request.REQUEST_COST as request_REQUEST_COST ';
        $sql .= '    ,request.TEMP_CUSTOMER_NAME as request_TEMP_CUSTOMER_NAME ';
        $sql .= '    ,request.TEMP_COMPANY_NAME as request_TEMP_COMPANY_NAME ';
        $sql .= '    ,request.TEMP_ADDRESS as request_TEMP_ADDRESS ';
        $sql .= '    ,request.TEMP_PHONE as request_TEMP_PHONE ';
        $sql .= '    ,request.TEMP_FAX as request_TEMP_FAX ';
        $sql .= ' FROM request_status';
		$sql .= '    LEFT OUTER JOIN status_type_master ON ';
        $sql .= '        status_type_master.STATUS_TYPE ';
		$sql .= '    LEFT OUTER JOIN request ON ';
        $sql .= '        request.REQUEST_ID ';
		$paramArr = array();
	    if ($criteria != null && count($criteria) > 0) {
	    	if (count($criteria['where']) > 0) {
	    		$countCriteria = count($criteria['where']);
				$sql .= ' WHERE ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria['where'] as $key => $value) {
		            if ($index != $countCriteria - 1) {
		            	$concator = ' AND ';
		            } else {
		            	$concator = ' ';
		            }
		            $index++;
		            
		            $sql .= $key . ' ' . $criteria['operator'][$key] . ' ' . $value . $concator;
		            if ($value != null) {
						$paramArr[] = $value;
		            }
		        }
		    }
	    	if (count($criteria['order']) > 0) {
				$countCriteria = count($criteria['order']);
				$sql .= ' ORDER BY ';
				$concator = '';
				
				$index = 0;
		        foreach ($criteria['order'] as $key => $value) {
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

		$sql .= ' LIMIT ' . ($criteria['pageNumber']) . ', ' . ($criteria['recordPerPage']);

    	$query = $this->db->query($sql, $paramArr);

        if ($query->num_rows() > 0)
        {
        	$resultList = array();
        	foreach ($query->result_array() as $row) {
                $result = array();
        	    $result['requestStatusId'] = $row['request_status_REQUEST_STATUS_ID'];
                $result['createDate'] = $row['request_status_CREATE_DATE'];
                $result['createUser'] = $row['request_status_CREATE_USER'];
                $result['updateDate'] = $row['request_status_UPDATE_DATE'];
                $result['updateUser'] = $row['request_status_UPDATE_USER'];
                $result['description'] = $row['request_status_DESCRIPTION'];
        	    $result['statusTypeMaster.statusType'] = $row['status_type_master_STATUS_TYPE'];
			    $result['statusTypeMaster.statusName'] = $row['status_type_master_STATUS_NAME'];
        	    $result['request.requestId'] = $row['request_REQUEST_ID'];
			    $result['request.followUpRequestId'] = $row['request_FOLLOW_UP_REQUEST_ID'];
			    $result['request.customerCallDate'] = $row['request_CUSTOMER_CALL_DATE'];
			    $result['request.reportDate'] = $row['request_REPORT_DATE'];
			    $result['request.finishDate'] = $row['request_FINISH_DATE'];
			    $result['request.serviceType'] = $row['request_SERVICE_TYPE'];
			    $result['request.problemReport'] = $row['request_PROBLEM_REPORT'];
			    $result['request.symptom'] = $row['request_SYMPTOM'];
			    $result['request.cause'] = $row['request_CAUSE'];
			    $result['request.action'] = $row['request_ACTION'];
			    $result['request.customerOpinion'] = $row['request_CUSTOMER_OPINION'];
			    $result['request.createDate'] = $row['request_CREATE_DATE'];
			    $result['request.createUser'] = $row['request_CREATE_USER'];
			    $result['request.updateDate'] = $row['request_UPDATE_DATE'];
			    $result['request.updateUser'] = $row['request_UPDATE_USER'];
			    $result['request.requestCost'] = $row['request_REQUEST_COST'];
			    $result['request.tempCustomerName'] = $row['request_TEMP_CUSTOMER_NAME'];
			    $result['request.tempCompanyName'] = $row['request_TEMP_COMPANY_NAME'];
			    $result['request.tempAddress'] = $row['request_TEMP_ADDRESS'];
			    $result['request.tempPhone'] = $row['request_TEMP_PHONE'];
			    $result['request.tempFax'] = $row['request_TEMP_FAX'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>