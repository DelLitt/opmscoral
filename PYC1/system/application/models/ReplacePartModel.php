<?php

class ReplacePartModel extends Model {

    function insert($ReplacePart) {
		$sql = 'INSERT INTO replace_part(';
        
        $sql .= '    PART_NO, ';
        $sql .= '    DESCRIPTION, ';
        $sql .= '    QUANTITY, ';
        $sql .= '    PRICE_USD, ';
        $sql .= '    PRICE_VND, ';
        $sql .= '    CREATE_DATE, ';
        $sql .= '    CREATE_USER, ';
        $sql .= '    UPDATE_DATE, ';
        $sql .= '    UPDATE_USER ';
        $sql .= '    REQUEST_ID) VALUES (';
		$sql .= '   ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?,  ?)';
		
        $paramArr = array();
        
        $paramArr[] = isset($ReplacePart['partNo']) ? $ReplacePart['partNo'] : null;
        $paramArr[] = isset($ReplacePart['description']) ? $ReplacePart['description'] : null;
        $paramArr[] = isset($ReplacePart['quantity']) ? $ReplacePart['quantity'] : null;
        $paramArr[] = isset($ReplacePart['priceUsd']) ? $ReplacePart['priceUsd'] : null;
        $paramArr[] = isset($ReplacePart['priceVnd']) ? $ReplacePart['priceVnd'] : null;
        $paramArr[] = isset($ReplacePart['createDate']) ? $ReplacePart['createDate'] : null;
        $paramArr[] = isset($ReplacePart['createUser']) ? $ReplacePart['createUser'] : null;
        $paramArr[] = isset($ReplacePart['updateDate']) ? $ReplacePart['updateDate'] : null;
        $paramArr[] = isset($ReplacePart['updateUser']) ? $ReplacePart['updateUser'] : null;
		if ($ReplacePart->request != null) {
        	$paramArr[] = isset($ReplacePart['request.requestId']) ? $ReplacePart['request.requestId'] : null;
        } else {
        	$paramArr[] = '';
        }
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
    function update($ReplacePart) {
		$sql = 'UPDATE replace_part SET ';
        $sql .= '    PART_NO = ? ';
        $sql .= '    ,DESCRIPTION = ? ';
        $sql .= '    ,QUANTITY = ? ';
        $sql .= '    ,PRICE_USD = ? ';
        $sql .= '    ,PRICE_VND = ? ';
        $sql .= '    ,CREATE_DATE = ? ';
        $sql .= '    ,CREATE_USER = ? ';
        $sql .= '    ,UPDATE_DATE = ? ';
        $sql .= '    ,UPDATE_USER = ? ';
        $sql .= '    ,REQUEST_ID = ? ';
		$sql .= ' WHERE ';
        $sql .= '    REPLACE_PART_ID = ? ' ;
		
        $paramArr = array();
        $paramArr[] = isset($ReplacePart['partNo']) ? $ReplacePart['partNo'] : null;
        $paramArr[] = isset($ReplacePart['description']) ? $ReplacePart['description'] : null;
        $paramArr[] = isset($ReplacePart['quantity']) ? $ReplacePart['quantity'] : null;
        $paramArr[] = isset($ReplacePart['priceUsd']) ? $ReplacePart['priceUsd'] : null;
        $paramArr[] = isset($ReplacePart['priceVnd']) ? $ReplacePart['priceVnd'] : null;
        $paramArr[] = isset($ReplacePart['createDate']) ? $ReplacePart['createDate'] : null;
        $paramArr[] = isset($ReplacePart['createUser']) ? $ReplacePart['createUser'] : null;
        $paramArr[] = isset($ReplacePart['updateDate']) ? $ReplacePart['updateDate'] : null;
        $paramArr[] = isset($ReplacePart['updateUser']) ? $ReplacePart['updateUser'] : null;
       	$paramArr[] = isset($ReplacePart['request.requestId']) ? $ReplacePart['request.requestId'] : null;
        $paramArr[] = isset($ReplacePart['replacePartId']) ? $ReplacePart['replacePartId'] : null;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    replace_part.REPLACE_PART_ID as replace_part_REPLACE_PART_ID';
        $sql .= '    ,replace_part.PART_NO as replace_part_PART_NO';
        $sql .= '    ,replace_part.DESCRIPTION as replace_part_DESCRIPTION';
        $sql .= '    ,replace_part.QUANTITY as replace_part_QUANTITY';
        $sql .= '    ,replace_part.PRICE_USD as replace_part_PRICE_USD';
        $sql .= '    ,replace_part.PRICE_VND as replace_part_PRICE_VND';
        $sql .= '    ,replace_part.CREATE_DATE as replace_part_CREATE_DATE';
        $sql .= '    ,replace_part.CREATE_USER as replace_part_CREATE_USER';
        $sql .= '    ,replace_part.UPDATE_DATE as replace_part_UPDATE_DATE';
        $sql .= '    ,replace_part.UPDATE_USER as replace_part_UPDATE_USER';
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
        $sql .= ' FROM replace_part';
		$sql .= '    LEFT OUTER JOIN request ON ';
        $sql .= '        request.REQUEST_ID ';
		$sql .= ' WHERE ';
        $sql .= '    replace_part.REPLACE_PART_ID = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->result_array();
            $result = array();
        	$result['replacePartId'] = $row[0]['replace_part_REPLACE_PART_ID'];
            $result['partNo'] = $row[0]['replace_part_PART_NO'];
            $result['description'] = $row[0]['replace_part_DESCRIPTION'];
            $result['quantity'] = $row[0]['replace_part_QUANTITY'];
            $result['priceUsd'] = $row[0]['replace_part_PRICE_USD'];
            $result['priceVnd'] = $row[0]['replace_part_PRICE_VND'];
            $result['createDate'] = $row[0]['replace_part_CREATE_DATE'];
            $result['createUser'] = $row[0]['replace_part_CREATE_USER'];
            $result['updateDate'] = $row[0]['replace_part_UPDATE_DATE'];
            $result['updateUser'] = $row[0]['replace_part_UPDATE_USER'];
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
        $sql .= '    replace_part_REPLACE_PART_ID as replace_part.REPLACE_PART_ID ';
        $sql .= '    ,replace_part.PART_NO as replace_part_PART_NO ';
        $sql .= '    ,replace_part.DESCRIPTION as replace_part_DESCRIPTION ';
        $sql .= '    ,replace_part.QUANTITY as replace_part_QUANTITY ';
        $sql .= '    ,replace_part.PRICE_USD as replace_part_PRICE_USD ';
        $sql .= '    ,replace_part.PRICE_VND as replace_part_PRICE_VND ';
        $sql .= '    ,replace_part.CREATE_DATE as replace_part_CREATE_DATE ';
        $sql .= '    ,replace_part.CREATE_USER as replace_part_CREATE_USER ';
        $sql .= '    ,replace_part.UPDATE_DATE as replace_part_UPDATE_DATE ';
        $sql .= '    ,replace_part.UPDATE_USER as replace_part_UPDATE_USER ';
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
        $sql .= ' FROM replace_part';
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
        	    $result['replacePartId'] = $row['replace_part_REPLACE_PART_ID'];
                $result['partNo'] = $row['replace_part_PART_NO'];
                $result['description'] = $row['replace_part_DESCRIPTION'];
                $result['quantity'] = $row['replace_part_QUANTITY'];
                $result['priceUsd'] = $row['replace_part_PRICE_USD'];
                $result['priceVnd'] = $row['replace_part_PRICE_VND'];
                $result['createDate'] = $row['replace_part_CREATE_DATE'];
                $result['createUser'] = $row['replace_part_CREATE_USER'];
                $result['updateDate'] = $row['replace_part_UPDATE_DATE'];
                $result['updateUser'] = $row['replace_part_UPDATE_USER'];
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
        $sql .= ' FROM replace_part ';
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
        $sql .= '    replace_part.REPLACE_PART_ID as replace_part_REPLACE_PART_ID ';
        $sql .= '    ,replace_part.PART_NO as replace_part_PART_NO ';
        $sql .= '    ,replace_part.DESCRIPTION as replace_part_DESCRIPTION ';
        $sql .= '    ,replace_part.QUANTITY as replace_part_QUANTITY ';
        $sql .= '    ,replace_part.PRICE_USD as replace_part_PRICE_USD ';
        $sql .= '    ,replace_part.PRICE_VND as replace_part_PRICE_VND ';
        $sql .= '    ,replace_part.CREATE_DATE as replace_part_CREATE_DATE ';
        $sql .= '    ,replace_part.CREATE_USER as replace_part_CREATE_USER ';
        $sql .= '    ,replace_part.UPDATE_DATE as replace_part_UPDATE_DATE ';
        $sql .= '    ,replace_part.UPDATE_USER as replace_part_UPDATE_USER ';
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
        $sql .= ' FROM replace_part';
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
        	    $result['replacePartId'] = $row['replace_part_REPLACE_PART_ID'];
                $result['partNo'] = $row['replace_part_PART_NO'];
                $result['description'] = $row['replace_part_DESCRIPTION'];
                $result['quantity'] = $row['replace_part_QUANTITY'];
                $result['priceUsd'] = $row['replace_part_PRICE_USD'];
                $result['priceVnd'] = $row['replace_part_PRICE_VND'];
                $result['createDate'] = $row['replace_part_CREATE_DATE'];
                $result['createUser'] = $row['replace_part_CREATE_USER'];
                $result['updateDate'] = $row['replace_part_UPDATE_DATE'];
                $result['updateUser'] = $row['replace_part_UPDATE_USER'];
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