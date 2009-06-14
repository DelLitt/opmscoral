<?php

class ContractTypeMasterModel extends Model {

    function insert($ContractTypeMaster) {
		$sql = 'INSERT INTO contract_type_master(';
        
        $sql .= '    CONTRACT_TYPE_NAME ';
        $sql .= ') VALUES (';
		$sql .= '   ?,  ?)';
		
        $paramArr = array();
        
        $paramArr[] = isset($ContractTypeMaster['contractTypeName']) ? $ContractTypeMaster['contractTypeName'] : null;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
    function update($ContractTypeMaster) {
		$sql = 'UPDATE contract_type_master SET ';
        $sql .= '    CONTRACT_TYPE_NAME = ? ';
		$sql .= ' WHERE ';
        $sql .= '    CONTRACT_TYPE_ID = ? ' ;
		
        $paramArr = array();
        $paramArr[] = isset($ContractTypeMaster['contractTypeName']) ? $ContractTypeMaster['contractTypeName'] : null;
        $paramArr[] = isset($ContractTypeMaster['contractTypeId']) ? $ContractTypeMaster['contractTypeId'] : null;
    
        $this->db->query($sql, $paramArr);
		$this->db->affected_rows(); 
	}
	
	function findById($id) {
		$sql = 'SELECT ';
        $sql .= '    contract_type_master.CONTRACT_TYPE_ID as contract_type_master_CONTRACT_TYPE_ID';
        $sql .= '    ,contract_type_master.CONTRACT_TYPE_NAME as contract_type_master_CONTRACT_TYPE_NAME';
        $sql .= ' FROM contract_type_master';
		$sql .= ' WHERE ';
        $sql .= '    contract_type_master.CONTRACT_TYPE_ID = ?';
		$query = $this->db->query($sql, array($id));
        if ($query->num_rows() > 0)
        {
            $row = $query->result_array();
            $result = array();
        	$result['contractTypeId'] = $row[0]['contract_type_master_CONTRACT_TYPE_ID'];
            $result['contractTypeName'] = $row[0]['contract_type_master_CONTRACT_TYPE_NAME'];
            return $result;
        } else {
            return null;
        }
	}
	
	function findAll($criteria) {
		$sql = 'SELECT ';
        $sql .= '    contract_type_master_CONTRACT_TYPE_ID as contract_type_master.CONTRACT_TYPE_ID ';
        $sql .= '    ,contract_type_master.CONTRACT_TYPE_NAME as contract_type_master_CONTRACT_TYPE_NAME ';
        $sql .= ' FROM contract_type_master';
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
        	    $result['contractTypeId'] = $row['contract_type_master_CONTRACT_TYPE_ID'];
                $result['contractTypeName'] = $row['contract_type_master_CONTRACT_TYPE_NAME'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
	
	function count($criteria) {
		$sql = 'SELECT COUNT(*) as COUNT_VALUE ';
        $sql .= ' FROM contract_type_master ';
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
        $sql .= '    contract_type_master.CONTRACT_TYPE_ID as contract_type_master_CONTRACT_TYPE_ID ';
        $sql .= '    ,contract_type_master.CONTRACT_TYPE_NAME as contract_type_master_CONTRACT_TYPE_NAME ';
        $sql .= ' FROM contract_type_master';
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
        	    $result['contractTypeId'] = $row['contract_type_master_CONTRACT_TYPE_ID'];
                $result['contractTypeName'] = $row['contract_type_master_CONTRACT_TYPE_NAME'];
                $resultList[] = $result;
			}
            return $resultList;
        } else {
            return array();
        }
	}
}

?>