<?php

class ReplacePartModel extends Model {

    function insert($ReplacePart) {
		$sql = 'INSERT INTO replace_part(';
        $sql .= '    REPLACE_PART_ID, ';
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
        $paramArr[] = $ReplacePart->replacePartId;
        $paramArr[] = $ReplacePart->partNo;
        $paramArr[] = $ReplacePart->description;
        $paramArr[] = $ReplacePart->quantity;
        $paramArr[] = $ReplacePart->priceUsd;
        $paramArr[] = $ReplacePart->priceVnd;
        $paramArr[] = $ReplacePart->createDate;
        $paramArr[] = $ReplacePart->createUser;
        $paramArr[] = $ReplacePart->updateDate;
        $paramArr[] = $ReplacePart->updateUser;
		if ($ReplacePart->request != null) {
        	$paramArr[] = $ReplacePart->request->requestId;
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
        $paramArr[] = $ReplacePart->partNo;
        $paramArr[] = $ReplacePart->description;
        $paramArr[] = $ReplacePart->quantity;
        $paramArr[] = $ReplacePart->priceUsd;
        $paramArr[] = $ReplacePart->priceVnd;
        $paramArr[] = $ReplacePart->createDate;
        $paramArr[] = $ReplacePart->createUser;
        $paramArr[] = $ReplacePart->updateDate;
        $paramArr[] = $ReplacePart->updateUser;
		if ($ReplacePart->request != null) {
        	$paramArr[] = $ReplacePart->request->requestId;
        } else {
        	$paramArr[] = '';
        }
        $paramArr[] = $ReplacePart->replacePartId;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    replace_part.REPLACE_PART_ID ';
        $sql .= '    ,replace_part.PART_NO ';
        $sql .= '    ,replace_part.DESCRIPTION ';
        $sql .= '    ,replace_part.QUANTITY ';
        $sql .= '    ,replace_part.PRICE_USD ';
        $sql .= '    ,replace_part.PRICE_VND ';
        $sql .= '    ,replace_part.CREATE_DATE ';
        $sql .= '    ,replace_part.CREATE_USER ';
        $sql .= '    ,replace_part.UPDATE_DATE ';
        $sql .= '    ,replace_part.UPDATE_USER ';
        $sql .= '    ,request.REQUEST_ID ';
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
        $sql .= ' FROM replace_part';
		$sql .= '    LEFT OUTER JOIN request ON ';
        $sql .= '        request.REQUEST_ID ';
		$sql .= ' WHERE ';
        $sql .= '    replace_part.REPLACE_PART_ID = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->row();
            $result = new ReplacePart();
        	$result->replacePartId = $row['replace_part.REPLACE_PART_ID'];
            $result->partNo = $row['replace_part.PART_NO'];
            $result->description = $row['replace_part.DESCRIPTION'];
            $result->quantity = $row['replace_part.QUANTITY'];
            $result->priceUsd = $row['replace_part.PRICE_USD'];
            $result->priceVnd = $row['replace_part.PRICE_VND'];
            $result->createDate = $row['replace_part.CREATE_DATE'];
            $result->createUser = $row['replace_part.CREATE_USER'];
            $result->updateDate = $row['replace_part.UPDATE_DATE'];
            $result->updateUser = $row['replace_part.UPDATE_USER'];
             $result->request = new Request();
        	$result->request->requestId = $row['request.REQUEST_ID'];
			$result->request->machineId = $row['request.MACHINE_ID'];
			$result->request->followUpRequestId = $row['request.FOLLOW_UP_REQUEST_ID'];
			$result->request->customerCallDate = $row['request.CUSTOMER_CALL_DATE'];
			$result->request->reportDate = $row['request.REPORT_DATE'];
			$result->request->finishDate = $row['request.FINISH_DATE'];
			$result->request->serviceType = $row['request.SERVICE_TYPE'];
			$result->request->problemReport = $row['request.PROBLEM_REPORT'];
			$result->request->symptom = $row['request.SYMPTOM'];
			$result->request->cause = $row['request.CAUSE'];
			$result->request->action = $row['request.ACTION'];
			$result->request->customerOpinion = $row['request.CUSTOMER_OPINION'];
			$result->request->createDate = $row['request.CREATE_DATE'];
			$result->request->createUser = $row['request.CREATE_USER'];
			$result->request->updateDate = $row['request.UPDATE_DATE'];
			$result->request->updateUser = $row['request.UPDATE_USER'];
			$result->request->requestCost = $row['request.REQUEST_COST'];
			$result->request->tempCustomerName = $row['request.TEMP_CUSTOMER_NAME'];
			$result->request->tempCompanyName = $row['request.TEMP_COMPANY_NAME'];
			$result->request->tempAddress = $row['request.TEMP_ADDRESS'];
			$result->request->tempPhone = $row['request.TEMP_PHONE'];
			$result->request->tempFax = $row['request.TEMP_FAX'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    replace_part.REPLACE_PART_ID ';
        $sql .= '    ,replace_part.PART_NO ';
        $sql .= '    ,replace_part.DESCRIPTION ';
        $sql .= '    ,replace_part.QUANTITY ';
        $sql .= '    ,replace_part.PRICE_USD ';
        $sql .= '    ,replace_part.PRICE_VND ';
        $sql .= '    ,replace_part.CREATE_DATE ';
        $sql .= '    ,replace_part.CREATE_USER ';
        $sql .= '    ,replace_part.UPDATE_DATE ';
        $sql .= '    ,replace_part.UPDATE_USER ';
        $sql .= '    ,request.REQUEST_ID ';
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
        $sql .= ' FROM replace_part';
		$sql .= '    LEFT OUTER JOIN request ON ';
        $sql .= '        request.REQUEST_ID ';
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
                $result = new ReplacePart();
        	    $result->replacePartId = $row['replace_part.REPLACE_PART_ID'];
                $result->partNo = $row['replace_part.PART_NO'];
                $result->description = $row['replace_part.DESCRIPTION'];
                $result->quantity = $row['replace_part.QUANTITY'];
                $result->priceUsd = $row['replace_part.PRICE_USD'];
                $result->priceVnd = $row['replace_part.PRICE_VND'];
                $result->createDate = $row['replace_part.CREATE_DATE'];
                $result->createUser = $row['replace_part.CREATE_USER'];
                $result->updateDate = $row['replace_part.UPDATE_DATE'];
                $result->updateUser = $row['replace_part.UPDATE_USER'];
                 $result->request = new Request();
        	    $result->request->requestId = $row['request.REQUEST_ID'];
			    $result->request->machineId = $row['request.MACHINE_ID'];
			    $result->request->followUpRequestId = $row['request.FOLLOW_UP_REQUEST_ID'];
			    $result->request->customerCallDate = $row['request.CUSTOMER_CALL_DATE'];
			    $result->request->reportDate = $row['request.REPORT_DATE'];
			    $result->request->finishDate = $row['request.FINISH_DATE'];
			    $result->request->serviceType = $row['request.SERVICE_TYPE'];
			    $result->request->problemReport = $row['request.PROBLEM_REPORT'];
			    $result->request->symptom = $row['request.SYMPTOM'];
			    $result->request->cause = $row['request.CAUSE'];
			    $result->request->action = $row['request.ACTION'];
			    $result->request->customerOpinion = $row['request.CUSTOMER_OPINION'];
			    $result->request->createDate = $row['request.CREATE_DATE'];
			    $result->request->createUser = $row['request.CREATE_USER'];
			    $result->request->updateDate = $row['request.UPDATE_DATE'];
			    $result->request->updateUser = $row['request.UPDATE_USER'];
			    $result->request->requestCost = $row['request.REQUEST_COST'];
			    $result->request->tempCustomerName = $row['request.TEMP_CUSTOMER_NAME'];
			    $result->request->tempCompanyName = $row['request.TEMP_COMPANY_NAME'];
			    $result->request->tempAddress = $row['request.TEMP_ADDRESS'];
			    $result->request->tempPhone = $row['request.TEMP_PHONE'];
			    $result->request->tempFax = $row['request.TEMP_FAX'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*)';
        $sql .= ' FROM replace_part ';
		$sql .= '    LEFT OUTER JOIN request ON ';
        $sql .= '        request.REQUEST_ID ';
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
        $sql .= '    replace_part.REPLACE_PART_ID ';
        $sql .= '    ,replace_part.PART_NO ';
        $sql .= '    ,replace_part.DESCRIPTION ';
        $sql .= '    ,replace_part.QUANTITY ';
        $sql .= '    ,replace_part.PRICE_USD ';
        $sql .= '    ,replace_part.PRICE_VND ';
        $sql .= '    ,replace_part.CREATE_DATE ';
        $sql .= '    ,replace_part.CREATE_USER ';
        $sql .= '    ,replace_part.UPDATE_DATE ';
        $sql .= '    ,replace_part.UPDATE_USER ';
        $sql .= '    ,request.REQUEST_ID ';
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
        $sql .= ' FROM replace_part';
		$sql .= '    LEFT OUTER JOIN request ON ';
        $sql .= '        request.REQUEST_ID ';
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
                $result = new ReplacePart();
        	    $result->replacePartId = $row['replace_part.REPLACE_PART_ID'];
                $result->partNo = $row['replace_part.PART_NO'];
                $result->description = $row['replace_part.DESCRIPTION'];
                $result->quantity = $row['replace_part.QUANTITY'];
                $result->priceUsd = $row['replace_part.PRICE_USD'];
                $result->priceVnd = $row['replace_part.PRICE_VND'];
                $result->createDate = $row['replace_part.CREATE_DATE'];
                $result->createUser = $row['replace_part.CREATE_USER'];
                $result->updateDate = $row['replace_part.UPDATE_DATE'];
                $result->updateUser = $row['replace_part.UPDATE_USER'];
                 $result->request = new Request();
        	    $result->request->requestId = $row['request.REQUEST_ID'];
			    $result->request->machineId = $row['request.MACHINE_ID'];
			    $result->request->followUpRequestId = $row['request.FOLLOW_UP_REQUEST_ID'];
			    $result->request->customerCallDate = $row['request.CUSTOMER_CALL_DATE'];
			    $result->request->reportDate = $row['request.REPORT_DATE'];
			    $result->request->finishDate = $row['request.FINISH_DATE'];
			    $result->request->serviceType = $row['request.SERVICE_TYPE'];
			    $result->request->problemReport = $row['request.PROBLEM_REPORT'];
			    $result->request->symptom = $row['request.SYMPTOM'];
			    $result->request->cause = $row['request.CAUSE'];
			    $result->request->action = $row['request.ACTION'];
			    $result->request->customerOpinion = $row['request.CUSTOMER_OPINION'];
			    $result->request->createDate = $row['request.CREATE_DATE'];
			    $result->request->createUser = $row['request.CREATE_USER'];
			    $result->request->updateDate = $row['request.UPDATE_DATE'];
			    $result->request->updateUser = $row['request.UPDATE_USER'];
			    $result->request->requestCost = $row['request.REQUEST_COST'];
			    $result->request->tempCustomerName = $row['request.TEMP_CUSTOMER_NAME'];
			    $result->request->tempCompanyName = $row['request.TEMP_COMPANY_NAME'];
			    $result->request->tempAddress = $row['request.TEMP_ADDRESS'];
			    $result->request->tempPhone = $row['request.TEMP_PHONE'];
			    $result->request->tempFax = $row['request.TEMP_FAX'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>