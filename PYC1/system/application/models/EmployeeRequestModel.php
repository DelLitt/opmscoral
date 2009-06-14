<?php

class EmployeeRequestModel extends Model {

    function insert($EmployeeRequest) {
		$sql = 'INSERT INTO employee_request(';
        
        
        
        $sql .= ') VALUES (';
		$sql .= '   ?,  ?,  ?)';
		
        $paramArr = array();
        
        
        
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
    function update($EmployeeRequest) {
		$sql = 'UPDATE employee_request SET ';
		$sql .= ' WHERE ';
        $sql .= '    REQUEST_ID = ? ' ;
        $sql .= '    EMPLOYEE_ID = ? ' ;
        $sql .= '    REQUEST_ACTION_TYPE_ID = ? AND' ;
		
        $paramArr = array();
        $paramArr[] = isset($EmployeeRequest['requestId']) ? $EmployeeRequest['requestId'] : null;
        $paramArr[] = isset($EmployeeRequest['employeeId']) ? $EmployeeRequest['employeeId'] : null;
        $paramArr[] = isset($EmployeeRequest['requestActionTypeId']) ? $EmployeeRequest['requestActionTypeId'] : null;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    employee_request.REQUEST_ID as employee_request_REQUEST_ID';
        $sql .= '    employee_request.EMPLOYEE_ID as employee_request_EMPLOYEE_ID';
        $sql .= '    employee_request.REQUEST_ACTION_TYPE_ID as employee_request_REQUEST_ACTION_TYPE_ID';
        $sql .= ' FROM employee_request ';
		$sql .= ' WHERE ';
        $sql .= '    employee_request.REQUEST_ID = ? ';
        $sql .= '    employee_request.EMPLOYEE_ID = ? ';
        $sql .= '    employee_request.REQUEST_ACTION_TYPE_ID = ? ';
		$query = $this->db->query($sql, $id);
        if ($query->num_rows() > 0)
        {
            $row = $query->result_array();
            $result = array();
        	$result['requestId'] = $row[0]['employee_request_REQUEST_ID'];
        	$result['employeeId'] = $row[0]['employee_request_EMPLOYEE_ID'];
        	$result['requestActionTypeId'] = $row[0]['employee_request_REQUEST_ACTION_TYPE_ID'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    employee_request_REQUEST_ID as employee_request.REQUEST_ID ';
        $sql .= '    employee_request_EMPLOYEE_ID as employee_request.EMPLOYEE_ID ';
        $sql .= '    employee_request_REQUEST_ACTION_TYPE_ID as employee_request.REQUEST_ACTION_TYPE_ID ';
        $sql .= ' FROM employee_request ';
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
        	    $result['requestId'] = $row['employee_request_REQUEST_ID'];
        	    $result['employeeId'] = $row['employee_request_EMPLOYEE_ID'];
        	    $result['requestActionTypeId'] = $row['employee_request_REQUEST_ACTION_TYPE_ID'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*) as COUNT_VALUE ';
        $sql .= ' FROM employee_request ';
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
        $sql .= '    employee_request.REQUEST_ID as employee_request_REQUEST_ID ';
        $sql .= '    employee_request.EMPLOYEE_ID as employee_request_EMPLOYEE_ID ';
        $sql .= '    employee_request.REQUEST_ACTION_TYPE_ID as employee_request_REQUEST_ACTION_TYPE_ID ';
        $sql .= ' FROM employee_request ';
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
        	    $result['requestId'] = $row['employee_request_REQUEST_ID'];
        	    $result['employeeId'] = $row['employee_request_EMPLOYEE_ID'];
        	    $result['requestActionTypeId'] = $row['employee_request_REQUEST_ACTION_TYPE_ID'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>