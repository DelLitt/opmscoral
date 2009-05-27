<?php

class RequestActionTypeMasterModel extends Model {

    function insert($RequestActionTypeMaster) {
		$sql = 'INSERT INTO request_action_type_master(';
        $sql .= '    REQUEST_ACTION_TYPE_ID, ';
        $sql .= '    REQUEST_ACTION_TYPE_NAME ';
        $sql .= ') VALUES (';
		$sql .= '   ?,  ?)';
		
        $paramArr = array();
        $paramArr[] = $RequestActionTypeMaster->requestActionTypeId;
        $paramArr[] = $RequestActionTypeMaster->requestActionTypeName;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
    function update($RequestActionTypeMaster) {
		$sql = 'UPDATE request_action_type_master SET ';
        $sql .= '    REQUEST_ACTION_TYPE_NAME = ? ';
		$sql .= ' WHERE ';
        $sql .= '    REQUEST_ACTION_TYPE_ID = ? ' ;
		
        $paramArr = array();
        $paramArr[] = $RequestActionTypeMaster->requestActionTypeName;
        $paramArr[] = $RequestActionTypeMaster->requestActionTypeId;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    request_action_type_master.REQUEST_ACTION_TYPE_ID ';
        $sql .= '    ,request_action_type_master.REQUEST_ACTION_TYPE_NAME ';
        $sql .= ' FROM request_action_type_master';
		$sql .= ' WHERE ';
        $sql .= '    request_action_type_master.REQUEST_ACTION_TYPE_ID = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->row();
            $result = new RequestActionTypeMaster();
        	$result->requestActionTypeId = $row['request_action_type_master.REQUEST_ACTION_TYPE_ID'];
            $result->requestActionTypeName = $row['request_action_type_master.REQUEST_ACTION_TYPE_NAME'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    request_action_type_master.REQUEST_ACTION_TYPE_ID ';
        $sql .= '    ,request_action_type_master.REQUEST_ACTION_TYPE_NAME ';
        $sql .= ' FROM request_action_type_master';
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
                $result = new RequestActionTypeMaster();
        	    $result->requestActionTypeId = $row['request_action_type_master.REQUEST_ACTION_TYPE_ID'];
                $result->requestActionTypeName = $row['request_action_type_master.REQUEST_ACTION_TYPE_NAME'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*)';
        $sql .= ' FROM request_action_type_master ';
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
        $sql .= '    request_action_type_master.REQUEST_ACTION_TYPE_ID ';
        $sql .= '    ,request_action_type_master.REQUEST_ACTION_TYPE_NAME ';
        $sql .= ' FROM request_action_type_master';
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
                $result = new RequestActionTypeMaster();
        	    $result->requestActionTypeId = $row['request_action_type_master.REQUEST_ACTION_TYPE_ID'];
                $result->requestActionTypeName = $row['request_action_type_master.REQUEST_ACTION_TYPE_NAME'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>