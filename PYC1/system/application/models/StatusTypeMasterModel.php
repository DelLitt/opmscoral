<?php

class StatusTypeMasterModel extends Model {

    function insert($StatusTypeMaster) {
		$sql = 'INSERT INTO status_type_master(';
        
        $sql .= '    STATUS_NAME ';
        $sql .= ') VALUES (';
		$sql .= '   ?,  ?)';
		
        $paramArr = array();
        
        $paramArr[] = isset($StatusTypeMaster['statusName']) ? $StatusTypeMaster['statusName'] : null;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
    function update($StatusTypeMaster) {
		$sql = 'UPDATE status_type_master SET ';
        $sql .= '    STATUS_NAME = ? ';
		$sql .= ' WHERE ';
        $sql .= '    STATUS_TYPE = ? ' ;
		
        $paramArr = array();
        $paramArr[] = isset($StatusTypeMaster['statusName']) ? $StatusTypeMaster['statusName'] : null;
        $paramArr[] = isset($StatusTypeMaster['statusType']) ? $StatusTypeMaster['statusType'] : null;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    status_type_master.STATUS_TYPE as status_type_master_STATUS_TYPE';
        $sql .= '    ,status_type_master.STATUS_NAME as status_type_master_STATUS_NAME';
        $sql .= ' FROM status_type_master';
		$sql .= ' WHERE ';
        $sql .= '    status_type_master.STATUS_TYPE = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->result_array();
            $result = array();
        	$result['statusType'] = $row[0]['status_type_master_STATUS_TYPE'];
            $result['statusName'] = $row[0]['status_type_master_STATUS_NAME'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    status_type_master_STATUS_TYPE as status_type_master.STATUS_TYPE ';
        $sql .= '    ,status_type_master.STATUS_NAME as status_type_master_STATUS_NAME ';
        $sql .= ' FROM status_type_master';
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
        	    $result['statusType'] = $row['status_type_master_STATUS_TYPE'];
                $result['statusName'] = $row['status_type_master_STATUS_NAME'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*) as COUNT_VALUE ';
        $sql .= ' FROM status_type_master ';
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
        $sql .= '    status_type_master.STATUS_TYPE as status_type_master_STATUS_TYPE ';
        $sql .= '    ,status_type_master.STATUS_NAME as status_type_master_STATUS_NAME ';
        $sql .= ' FROM status_type_master';
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
        	    $result['statusType'] = $row['status_type_master_STATUS_TYPE'];
                $result['statusName'] = $row['status_type_master_STATUS_NAME'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>