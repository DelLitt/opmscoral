<?php

class RequestActionTypeMasterModel extends Model {

    function insert($RequestActionTypeMaster) {
		$sql = 'INSERT INTO request_action_type_master(';
        
        $sql .= '    REQUEST_ACTION_TYPE_NAME ';
        $sql .= ') VALUES (';
		$sql .= '   ?,  ?)';
		
        $paramArr = array();
        
        $paramArr[] = isset($RequestActionTypeMaster['requestActionTypeName']) ? $RequestActionTypeMaster['requestActionTypeName'] : null;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
    function update($RequestActionTypeMaster) {
		$sql = 'UPDATE request_action_type_master SET ';
        $sql .= '    REQUEST_ACTION_TYPE_NAME = ? ';
		$sql .= ' WHERE ';
        $sql .= '    REQUEST_ACTION_TYPE_ID = ? ' ;
		
        $paramArr = array();
        $paramArr[] = isset($RequestActionTypeMaster['requestActionTypeName']) ? $RequestActionTypeMaster['requestActionTypeName'] : null;
        $paramArr[] = isset($RequestActionTypeMaster['requestActionTypeId']) ? $RequestActionTypeMaster['requestActionTypeId'] : null;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    request_action_type_master.REQUEST_ACTION_TYPE_ID as request_action_type_master_REQUEST_ACTION_TYPE_ID';
        $sql .= '    ,request_action_type_master.REQUEST_ACTION_TYPE_NAME as request_action_type_master_REQUEST_ACTION_TYPE_NAME';
        $sql .= ' FROM request_action_type_master';
		$sql .= ' WHERE ';
        $sql .= '    request_action_type_master.REQUEST_ACTION_TYPE_ID = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->result_array();
            $result = array();
        	$result['requestActionTypeId'] = $row[0]['request_action_type_master_REQUEST_ACTION_TYPE_ID'];
            $result['requestActionTypeName'] = $row[0]['request_action_type_master_REQUEST_ACTION_TYPE_NAME'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    request_action_type_master_REQUEST_ACTION_TYPE_ID as request_action_type_master.REQUEST_ACTION_TYPE_ID ';
        $sql .= '    ,request_action_type_master.REQUEST_ACTION_TYPE_NAME as request_action_type_master_REQUEST_ACTION_TYPE_NAME ';
        $sql .= ' FROM request_action_type_master';
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
        	    $result['requestActionTypeId'] = $row['request_action_type_master_REQUEST_ACTION_TYPE_ID'];
                $result['requestActionTypeName'] = $row['request_action_type_master_REQUEST_ACTION_TYPE_NAME'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*) as COUNT_VALUE ';
        $sql .= ' FROM request_action_type_master ';
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
        $sql .= '    request_action_type_master.REQUEST_ACTION_TYPE_ID as request_action_type_master_REQUEST_ACTION_TYPE_ID ';
        $sql .= '    ,request_action_type_master.REQUEST_ACTION_TYPE_NAME as request_action_type_master_REQUEST_ACTION_TYPE_NAME ';
        $sql .= ' FROM request_action_type_master';
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
        	    $result['requestActionTypeId'] = $row['request_action_type_master_REQUEST_ACTION_TYPE_ID'];
                $result['requestActionTypeName'] = $row['request_action_type_master_REQUEST_ACTION_TYPE_NAME'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>